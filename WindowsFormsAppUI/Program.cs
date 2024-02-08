using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsAppUI.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI
{
    internal static class Program
    {
        /// <summary>
        /// Main thread exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            CrashHandlerForm crashHandlerForm = new CrashHandlerForm(e.Exception);
            crashHandlerForm.ShowDialog();
        }

        /// <summary>
        /// Application domain exception handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">event</param>
        public static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            CrashHandlerForm crashHandlerForm = new CrashHandlerForm((Exception)e.ExceptionObject);
            crashHandlerForm.ShowDialog();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (null == System.Windows.Application.Current)
            {
                new System.Windows.Application();
            }

            // Unhandled exceptions for our Application Domain
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);

            // Unhandled exceptions for the executing UI thread
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

            // Whatever else your application does on startup

            FolderLocations.CreateFolders();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShellForm());
        }
    }
}
