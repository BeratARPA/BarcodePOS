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
        private ClientConsoleForm _clientConsoleForm;

        public async Task Connect(string serverName = "localhost", int port = 8080)
        {
            try
            {
                if (Properties.Settings.Default.ClientConsole)
                {
                    _clientConsoleForm = new ClientConsoleForm();
                    _clientConsoleForm.Show();
                }

                _clientWebSocket = new ClientWebSocket();

                if (_clientWebSocket.State == WebSocketState.Open || _clientWebSocket.State == WebSocketState.Connecting)
                {
                    AddLog("Zaten bir bağlantı var.");
                    return;
                }

                _clientWebSocket.Options.SetRequestHeader("Terminal-Name", GlobalVariables.TerminalName);

                await _clientWebSocket.ConnectAsync(new Uri(string.Format("ws://{0}:{1}/", serverName, port)), CancellationToken.None);
                AddLog("Sunucuya bağlandı.");

                await Task.Run(ReceiveMessages);
            }
            catch (Exception ex)
            {
                AddLog("Bağlantı hatası: " + ex.Message);
            }
        }

        public async Task Send(string message)
        {
            if (_clientWebSocket.State == WebSocketState.Open)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
            }
        }

        private async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            while (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                var serverMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);

                #region Events
                if (serverMessage == ClientCommandsEnum.REFRESH.ToString())
                {
                    TablesForm tablesForm = (TablesForm)GetForm.Get("TablesForm");
                    if (tablesForm != null)
                    {
                        tablesForm.Invoke((MethodInvoker)delegate
                        {
                            tablesForm.CreateSections();
                            tablesForm.CreateTables(1);
                        });
                    }

                    TicketsForm ticketsForm = (TicketsForm)GetForm.Get("TicketsForm");
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
            }
            catch (Exception ex)
            {
                AddLog("Bağlantı kapatma hatası: " + ex.Message);
            }
            finally
            {
                _clientWebSocket = null;
            }
        }

        public void AddLog(string log)
        {
            if (_clientConsoleForm.listBoxLogs.InvokeRequired)
            {
                _clientConsoleForm.listBoxLogs.Invoke(new Action<string>(AddLog), log);
            }
            else
            {
                _clientConsoleForm.listBoxLogs.Items.Add(log);
            }
        }
    }
}
