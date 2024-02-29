using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebSocketServer
{
    public partial class ShellForm : Form
    {
        private HttpListener _listener;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly List<WebSocket> _connectedSockets = new List<WebSocket>();

        public ShellForm()
        {
            InitializeComponent();
        }

        public async Task Start(string serverName, int port)
        {
            try
            {
                _listener = new HttpListener();
                _cancellationTokenSource = new CancellationTokenSource();

                if (_listener.IsListening)
                {
                    AddLog("Sunucu zaten başlatıldı.");

                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                    return;
                }

                _listener.Prefixes.Add(string.Format("http://{0}:{1}/", serverName, port));
                _listener.Start();
                AddLog("Sunucu başlatıldı. İstemci bağlantılarını bekliyor...");

                buttonStart.Enabled = false;
                buttonStop.Enabled = true;

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

        private async void ProcessWebSocketRequest(HttpListenerContext context)
        {
            WebSocketContext webSocketContext = null;

            try
            {
                webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
                WebSocket clientSocket = webSocketContext.WebSocket;
                _connectedSockets.Add(clientSocket); // Yeni istemciyi bağlı istemciler listesine ekle
                AddLog("Yeni istemci bağlandı: " + clientSocket.GetHashCode());
                await HandleClient(clientSocket);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.Close();
                AddLog("WebSocket hatası: " + ex.Message);
            }
            finally
            {
                if (webSocketContext != null && webSocketContext.WebSocket != null)
                {
                    _connectedSockets.Remove(webSocketContext.WebSocket); // İstemci bağlantısını listeden kaldır
                    await webSocketContext.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Sunucu tarafından kapatıldı.", CancellationToken.None);
                }
            }
        }

        private async Task HandleClient(WebSocket clientWebSocket)
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (clientWebSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    string clientMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    AddLog("İstemciden gelen mesaj: " + clientMessage);

                    // Sunucudaki tüm bağlı istemcilere mesaj gönder
                    foreach (var socket in _connectedSockets)
                    {
                        if (socket != clientWebSocket && socket.State == WebSocketState.Open)
                        {
                            byte[] responseBuffer = Encoding.UTF8.GetBytes(clientMessage);
                            await socket.SendAsync(new ArraySegment<byte>(responseBuffer), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                    }

                    buffer = new byte[1024];
                }
            }
            catch (WebSocketException ex)
            {
                // Istemci tarafında bir hata oluştu, istemci bağlantısını kapat
                if (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                {
                    AddLog("İstemci bağlantısı beklenmedik şekilde kapandı.");
                }
                else
                {
                    AddLog("İstemci bağlantı hatası: " + ex.Message);
                }
            }
        }

        public void Stop()
        {
            try
            {
                if (!_listener.IsListening)
                {
                    AddLog("Sunucu zaten durduruldu.");

                    buttonStart.Enabled = true;
                    buttonStop.Enabled = false;
                    return;
                }

                _cancellationTokenSource.Cancel();
                _listener.Stop();
                _listener.Close();

                AddLog("Sunucu durduruldu.");

                _listener = null;

                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            }
            catch (Exception ex)
            {
                AddLog("Sunucu durdurma hatası: " + ex.Message);
            }
        }

        public void AddLog(string log)
        {
            if (listBoxLogs.InvokeRequired)
            {
                listBoxLogs.Invoke(new Action<string>(AddLog), log);
            }
            else
            {
                listBoxLogs.Items.Add(log);
            }
        }

        private async void buttonStart_Click(object sender, EventArgs e)
        {
            await Start(GetIPv4Address.Get(), Convert.ToInt32(textBoxPort.Text));
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }
    }
}
