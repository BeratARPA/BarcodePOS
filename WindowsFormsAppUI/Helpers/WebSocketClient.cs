using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppUI.Enums;
using WindowsFormsAppUI.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class WebSocketClient
    {
        private ClientWebSocket _clientWebSocket;

        public async Task Connect(string serverName = "192.168.1.243", int port = 8080)
        {
            try
            {
                _clientWebSocket = new ClientWebSocket();

                if (_clientWebSocket.State == WebSocketState.Open || _clientWebSocket.State == WebSocketState.Connecting)
                {
                    AddLog("Zaten bir bağlantı var.");
                    return;
                }

                await _clientWebSocket.ConnectAsync(new Uri(string.Format("ws://{0}:{1}/", serverName, port)), CancellationToken.None);
                AddLog("Sunucuya bağlandı: " + _clientWebSocket.GetHashCode());

                await Task.Run(ReceiveMessages);
            }
            catch (Exception ex)
            {
                AddLog("Bağlantı hatası: " + ex.Message);
            }
        }

        public async Task Send(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
        }

        private async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            while (_clientWebSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var serverMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);

                #region Events
                TablesForm tablesForm = null;
                TicketsForm ticketsForm = null;

                if (serverMessage == ClientCommandsEnum.REFRESH.ToString())
                {

                    tablesForm = (TablesForm)GetForm.Get("TablesForm");
                    if (tablesForm != null)
                    {
                        tablesForm.Invoke((MethodInvoker)delegate
                        {
                            tablesForm.CreateSections();
                            tablesForm.CreateTables(1);
                        });
                    }

                    ticketsForm = (TicketsForm)GetForm.Get("TicketsForm");
                    if (ticketsForm != null)
                    {
                        ticketsForm.Invoke((MethodInvoker)delegate
                        {
                            ticketsForm.RemoveColumn();
                            ticketsForm.AddTicketsDataGridView(ticketsForm.comboBoxFilter.SelectedIndex);
                        });
                    }
                }
                else
                {
                    AddLog(serverMessage);
                }
                #endregion

                buffer = new byte[1024];
            }
        }

        public async Task Disconnect()
        {
            try
            {
                if (_clientWebSocket.State != WebSocketState.Open)
                {
                    AddLog("Zaten bir bağlantı yok.");
                    return;
                }

                AddLog("Bağlantı kesildi.");

                await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "İstemci tarafından kapatıldı.", CancellationToken.None);
                _clientWebSocket = null;
            }
            catch (Exception ex)
            {
                AddLog("Bağlantı kapatma hatası: " + ex.Message);
            }
        }

        public void AddLog(string log)
        {
            Console.WriteLine(log);
        }
    }
}
