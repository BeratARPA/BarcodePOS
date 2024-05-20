namespace WindowsFormsAppUI.Helpers
{
    public class ResizeLayout
    {
        public static void CloseHeader()
        {
            GlobalVariables.ShellForm.tableLayoutPanelHeader.Visible = false;
        }

        public static void CloseFooter()
        {
            GlobalVariables.ShellForm.tableLayoutPanelFooter.Visible = false;
        }

        public static void OpenHeader()
        {
            GlobalVariables.ShellForm.tableLayoutPanelHeader.Visible = true;
        }

        public static void OpenFooter()
        {
            GlobalVariables.ShellForm.tableLayoutPanelFooter.Visible = true;          
        }
    }
}
