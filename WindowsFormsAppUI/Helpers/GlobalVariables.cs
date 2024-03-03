using Database.Data;
using WindowsFormsAppUI.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class GlobalVariables
    {
        public static ShellForm ShellForm { get; set; }
        public static MessageBoxForm MessageBoxForm = new MessageBoxForm();
        public static string TerminalName = MachineName.Get();
        public static CultureHelper CultureHelper = new CultureHelper();
        public static SQLContext SQLContext = new SQLContext();
        public static WebSocketClient webSocketClient = new WebSocketClient();
    }
}
