using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class VirtualKeyboardHelper
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SHOW_NORMAL = 1;

        public static void Run()
        {
            try
            {
                bool forState = false;
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (process.ProcessName.Equals("Touch Screen Keyboard"))
                    {
                        forState = true;
                        IntPtr s = process.MainWindowHandle;
                        ShowWindow(s, SHOW_NORMAL);
                        break;
                    }
                }

                if (!forState)
                {
                    ProcessStartInfo proc = new ProcessStartInfo(Application.StartupPath + "\\Touch Screen Keyboard.exe");
                    proc.UseShellExecute = true;
                    Process.Start(proc);
                }
            }
            catch
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("KeyboardNotFound!"), GlobalVariables.CultureHelper.GetText("Warning"),Forms.MessageButton.OK,Forms.MessageIcon.Warning);
            }
        }
    }
}
