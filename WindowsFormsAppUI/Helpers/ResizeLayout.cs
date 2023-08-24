namespace WindowsFormsAppUI.Helpers
{
    public class ResizeLayout
    {
        public static void CloseHeader()
        {       
            GlobalVariables.ShellForm.tableLayoutPanelMain.RowStyles[0].Height = 0;
        }

        public static void CloseFooter()
        {       
            GlobalVariables.ShellForm.tableLayoutPanelMain.RowStyles[2].Height = 0;
        }

        public static void OpenHeader()
        {       
            GlobalVariables.ShellForm.tableLayoutPanelMain.RowStyles[0].Height = 50;
        }

        public static void OpenFooter()
        {         
            GlobalVariables.ShellForm.tableLayoutPanelMain.RowStyles[2].Height = 50;
        }
    }
}
