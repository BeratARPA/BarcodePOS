using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class Program
    {
        private static HttpListener _listener;
        private static CancellationTokenSource _cancellationTokenSource;
        private static readonly Dictionary<WebSocket, string> _connectedSockets = new Dictionary<WebSocket, string>();
        private static readonly List<string> _messageHistory = new List<string>();

        static void Main(string[] args)
        {
            Start(GetIPv4Address.Get(), 5000);
            Console.ReadLine();
        }

        public static async Task Start(string serverName, int port)
        {
            try
            {
                _listener = new HttpListener();
                _cancellationTokenSource = new CancellationTokenSource();

                if (_listener.IsListening)
                {
                    AddLog("Sunucu zaten başlatıldı.");
                    return;
                }

                _listener.Prefixes.Add(string.Format("http://{0}:{1}/", serverName, port));
                _listener.Start();
                AddLog("Sunucu başlatıldı. İstemci bağlantılarını bekliyor...");

                while (!_cancellationTokenSource.Token.IsCancellationRequested)
                {
                    HttpListenerContext context = await _listener.GetContextAsync();

                    if (context.Request.IsWebSocketRequest)
                    {
                        ProcessWebSocketRequest(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                AddLog("Sunucu başlatma hatası: " + ex.Message);
            }
        }

        private static async void ProcessWebSocketRequest(HttpListenerContext context)
        {
            WebSocketContext webSocketContext = null;

            try
            {
                webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
                WebSocket clientSocket = webSocketContext.WebSocket;

                string clientTerminalName = context.Request.Headers["Terminal-Name"];
                _connectedSockets.Add(clientSocket, clientTerminalName);

                foreach (string message in _messageHistory)
                {
                    if (clientSocket.State == WebSocketState.Open)
                    {
                        byte[] historyBuffer = Encoding.UTF8.GetBytes(message);
                        await clientSocket.SendAsync(new ArraySegment<byte>(historyBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }

                AddLog($"Yeni istemci bağlandı: {clientTerminalName} ({clientSocket.GetHashCode()})");

                await HandleClient(clientSocket);
            }
            catch (Exception ex)
            {
                if (webSocketContext?.WebSocket?.State == WebSocketState.Aborted)
                {
                    AddLog("WebSocket aborted: " + ex.Message);
                }
                else
                {
                    AddLog("WebSocket hatası: " + ex.Message);
                }

                context.Response.StatusCode = 500;
                context.Response.Close();
            }
            finally
            {
                if (webSocketContext != null && webSocketContext.WebSocket != null)
                {
                    if (_connectedSockets.ContainsKey(webSocketContext.WebSocket))
                    {
                        _connectedSockets.Remove(webSocketContext.WebSocket);
                    }

                    if (webSocketContext.WebSocket.State == WebSocketState.Open ||
                        webSocketContext.WebSocket.State == WebSocketState.CloseReceived ||
                        webSocketContext.WebSocket.State == WebSocketState.CloseSent)
                    {
                        await webSocketContext.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Sunucu tarafından kapatıldı.", CancellationToken.None);
                    }

                    webSocketContext.WebSocket.Dispose();
                }
            }
        }

        private static async Task HandleClient(WebSocket clientWebSocket)
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (clientWebSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = null;
                    using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30))) // 30 saniye timeout
                    {
                        try
                        {
                            result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            // Timeout sonrası tekrar dene
                            continue;
                        }
                    }

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        if (clientWebSocket.State == WebSocketState.Open)
                        {
                            await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closed connection", CancellationToken.None);
                        }

                        _connectedSockets.Remove(clientWebSocket);
                        AddLog($"({GetTerminalName(clientWebSocket)}) İstemci bağlantısı kapandı.");
                        break;
                    }

                    string clientMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    string clientName = GetTerminalName(clientWebSocket);
                    string message = $"{clientName}^{clientMessage}";

                    AddLog(message);
                    _messageHistory.Add(message);

                    foreach (var socket in _connectedSockets)
                    {
                        if (!socket.Key.Equals(clientWebSocket) && socket.Key.State == WebSocketState.Open)
                        {
                            byte[] responseBuffer = Encoding.UTF8.GetBytes(message);
                            await socket.Key.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }

                    Array.Clear(buffer, 0, buffer.Length); // Buffer'ı temizle
                }
            }
            catch (WebSocketException ex)
            {
                if (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                {
                    AddLog($"({GetTerminalName(clientWebSocket)}) İstemci bağlantısı beklenmedik şekilde kapandı.");
                }
                else
                {
                    AddLog($"({GetTerminalName(clientWebSocket)}) İstemci bağlantı hatası: " + ex.Message);
                }
            }
            finally
            {
                if (_connectedSockets.ContainsKey(clientWebSocket))
                {
                    _connectedSockets.Remove(clientWebSocket);
                }

                if (clientWebSocket.State == WebSocketState.Open ||
                    clientWebSocket.State == WebSocketState.CloseReceived ||
                    clientWebSocket.State == WebSocketState.CloseSent)
                {
                    await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Sunucu tarafından kapatıldı.", CancellationToken.None);
                }

                clientWebSocket.Dispose();
            }
        }


        private static string GetTerminalName(WebSocket webSocket)
        {
            foreach (var socket in _connectedSockets)
            {
                if (socket.Key == webSocket)
                {
                    return socket.Value;
                }
            }

            return webSocket.GetHashCode().ToString();
        }
      
        public static void Stop()
        {
            try
            {
                if (!_listener.IsListening)
                {
                    AddLog("Sunucu zaten durduruldu.");
                    return;
                }

                _cancellationTokenSource.Cancel();
                _listener.Stop();
                _listener.Close();

                AddLog("Sunucu durduruldu.");

                _listener = null;
            }
            catch (Exception ex)
            {
                AddLog("Sunucu durdurma hatası: " + ex.Message);
            }
        }

        public static void AddLog(string log)
        {
            Console.WriteLine(log);
        }
    }
}
