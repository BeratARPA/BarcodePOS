using System;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Forms
{
    public partial class OpenWindowsForm : Form
    {
        public OpenWindowsForm()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            listBoxWindows.Items.Clear();
            FormCollection formCollection = Application.OpenForms;
            foreach (Form form in formCollection)
            {
                listBoxWindows.Items.Add(form.Name);
            }
        }
    }
}
