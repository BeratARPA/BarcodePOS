using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.UserControls
{
    public partial class PaginationUserControl : UserControl
    {
        public event EventHandler GoFirst;
        public event EventHandler GoPrevious;
        public event EventHandler GoNext;
        public event EventHandler GoLast;
        public event EventHandler PageSizeChanged;

        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public PaginationUserControl()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            comboBoxPageSize.Text = "10";
            PageSize = 10;
            CurrentPage = 1;
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            int totalPages = (int)Math.Ceiling((double)TotalRecords / PageSize);
            labelStatus.Text = $"{CurrentPage} / {totalPages}";
            labelTotalRecords.Text = TotalRecords.ToString();
        }

        private void buttonGoFirst_Click(object sender, EventArgs e)
        {
            CurrentPage = 1;
            UpdateStatus();
            GoFirst?.Invoke(this, EventArgs.Empty);
        }

        private void buttonGoPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage = Math.Max(1, CurrentPage - 1);
            UpdateStatus();
            GoPrevious?.Invoke(this, EventArgs.Empty);
        }

        private void buttonGoNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)TotalRecords / PageSize);
            CurrentPage = Math.Min(totalPages, CurrentPage + 1);
            UpdateStatus();
            GoNext?.Invoke(this, EventArgs.Empty);
        }

        private void buttonGoLast_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)TotalRecords / PageSize);
            CurrentPage = totalPages;
            UpdateStatus();
            GoLast?.Invoke(this, EventArgs.Empty);
        }

        private void comboBoxPageSize_SelectedValueChanged(object sender, EventArgs e)
        {
            PageSize = int.Parse(comboBoxPageSize.SelectedItem.ToString());
            UpdateStatus();
            PageSizeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
