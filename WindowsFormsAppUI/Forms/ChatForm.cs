using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;
using WindowsFormsAppUI.UserControls;

namespace WindowsFormsAppUI.Forms
{
    public partial class ChatForm : Form
    {
        private ClientWebSocket _clientWebSocket;

        public ChatForm()
        {
            InitializeComponent();
        }

        private async void ChatForm_Load(object sender, EventArgs e)
        {
            await Connect();
        }

        public async Task Connect()
        {
            try
            {
                _clientWebSocket = new ClientWebSocket();

                if (_clientWebSocket.State == WebSocketState.Open || _clientWebSocket.State == WebSocketState.Connecting)
                {
                    AddMessage("Zaten bir bağlantı var.");
                    return;
                }

                _clientWebSocket.Options.SetRequestHeader("Terminal-Name", LoggedInUser.CurrentUser.Fullname);

                await _clientWebSocket.ConnectAsync(new Uri("ws://localhost:8080/"), CancellationToken.None);
                AddMessage("Sunucuya bağlandı.");

                await Task.Run(ReceiveMessages);
            }
            catch (Exception ex)
            {
                AddMessage("Bağlantı hatası: " + ex.Message);
            }
        }

        private async Task ReceiveMessages()
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (_clientWebSocket != null && _clientWebSocket.State == WebSocketState.Open)
                {
                    WebSocketReceiveResult result = null;
                    using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30))) // 30 saniye timeout
                    {
                        try
                        {
                            result = await _clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);
                        }
                        catch (OperationCanceledException)
                        {
                            // Timeout sonrası tekrar dene
                            continue;
                        }
                    }

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        if (_clientWebSocket.State == WebSocketState.Open)
                        {
                            await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Server closed connection", CancellationToken.None);
                        }

                        AddMessage("Bağlantı kapandı.");
                        break;
                    }

                    string serverMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    string[] usernameAndMessage = serverMessage.Split('^');

                    AddMessage(usernameAndMessage[1], usernameAndMessage[0]);

                    Array.Clear(buffer, 0, buffer.Length); // Buffer'ı temizle
                }
            }
            catch (Exception ex)
            {
                AddMessage("Alma hatası: " + ex.Message);
            }
        }

        public async Task Send(string message)
        {
            try
            {
                if (_clientWebSocket.State == WebSocketState.Open)
                {
                    AddMessage(message, LoggedInUser.CurrentUser.Fullname, true);
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    await _clientWebSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, endOfMessage: true, CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                AddMessage("Gönderme hatası: " + ex.Message);
            }
        }

        public void AddMessage(string message, string username = "Server", bool isSender = false)
        {
            try
            {
                MessageUserControl messageUserControl = new MessageUserControl(flowLayoutPanelMessages)
                {
                    UserName = username,
                    Message = message,
                    IsSender = isSender
                };

                if (textBoxMessage.InvokeRequired)
                {
                    flowLayoutPanelMessages.Invoke(new Action(() => AddMessage(message, username, isSender)));
                }
                else
                {
                    flowLayoutPanelMessages.Controls.Add(messageUserControl);
                }
            }
            catch (Exception ex)
            {
                MessageUserControl messageUserControl = new MessageUserControl(flowLayoutPanelMessages)
                {
                    UserName = username,
                    Message = "Ekleme hatası: " + ex.Message,
                    IsSender = false
                };

                if (textBoxMessage.InvokeRequired)
                {
                    flowLayoutPanelMessages.Invoke(new Action(() => AddMessage("Ekleme hatası: " + ex.Message, username, false)));
                }
                else
                {
                    flowLayoutPanelMessages.Controls.Add(messageUserControl);
                }
            }
        }

        private async void buttonSendMessage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMessage.Text))
                return;

            await Send(textBoxMessage.Text);

            textBoxMessage.Clear();
        }
    }
}
