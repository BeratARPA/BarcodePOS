namespace WindowsFormsAppUI.Helpers
{
    public class ChatHelper
    {
        public static bool IsExpanded { get; set; }

        public static void CollapseMenu()
        {
            if (!IsExpanded)
            {
                GlobalVariables.ShellForm.tableLayoutPanel1.ColumnStyles[0].Width = 20;
                IsExpanded = true;
            }
            else
            {
                GlobalVariables.ShellForm.tableLayoutPanel1.ColumnStyles[0].Width = 0;
                IsExpanded = false;
            }
        }
    }
}
