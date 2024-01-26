using System;
using System.Windows;
using System.Windows.Threading;

namespace WindowsFormsAppUI.Helpers
{
    public class AsyncPrintTask
    {
        public static void Exec(bool highPriority, Action action)
        {
            if (highPriority)
            {
                InternalExec(action);
            }
            else
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
                   new Action(() => InternalExec(action)));
            }
        }

        private static void InternalExec(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(e.Message, GlobalVariables.CultureHelper.GetText("Error"), Forms.MessageButton.OK, Forms.MessageIcon.Error);
            }
        }
    }
}
