using Database.Models;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.UserControls
{
    public partial class CategoryUserControl : UserControl
    {
        public Category _category;
        public event EventHandler CategoryTypeClick;

        public CategoryUserControl(Category category)
        {
            InitializeComponent();

            _category = category;
        }

        private void CategoryUserControl_Load(object sender, EventArgs e)
        {
            Name = _category.Name;

            string[] backColorArgb = _category.BackColor.Split(',');
            string[] foreColorArgb = _category.ForeColor.Split(',');

            this.BackColor = Color.FromArgb(50, Convert.ToInt32(backColorArgb[0]), Convert.ToInt32(backColorArgb[1]), Convert.ToInt32(backColorArgb[2]));

            labelName.ForeColor = Color.FromArgb(Convert.ToInt32(foreColorArgb[0]), Convert.ToInt32(foreColorArgb[1]), Convert.ToInt32(foreColorArgb[2]));
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                labelName.Text = value;
            }
        }

        private void CategoryUserControl_Click(object sender, EventArgs e)
        {
            CategoryTypeClick?.Invoke(this, e);
        }

        private void CategoryUserControl_Resize(object sender, EventArgs e)
        {
            int divide = 15;

            var controls = new List<Control> { labelName };
            for (int i = 0; i < controls.Count; i++)
            {
                int controlSize = controls[i].Height + controls[i].Width;
                controls[i].Font = new Font("Microsoft Sans Serif", controlSize / divide);
            }
        }
    }
}
