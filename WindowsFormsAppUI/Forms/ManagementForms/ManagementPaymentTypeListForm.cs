using Database.Data;
using Database.Models;
using System;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementPaymentTypeListForm : Form
    {
        private readonly IGenericRepository<PaymentType> _genericRepositoryPaymentType = new GenericRepository<PaymentType>(GlobalVariables.SQLContext);

        public ManagementPaymentTypeListForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        public void UpdateUILanguage()
        {
            label1.Text = GlobalVariables.CultureHelper.GetText("Name");
            buttonSave.Text = GlobalVariables.CultureHelper.GetText("Save");
            buttonDelete.Text = GlobalVariables.CultureHelper.GetText("Delete");
            dataGridViewPaymentTypes.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("Name");
        }

        private void ManagementPaymentTypeListForm_Load(object sender, EventArgs e)
        {
            LoadPaymentTypesDataGridView();
        }

        private void LoadPaymentTypesDataGridView()
        {
            dataGridViewPaymentTypes.Rows.Clear();

            var paymentTypes = _genericRepositoryPaymentType.GetAll();
            foreach (var paymentType in paymentTypes)
            {
                dataGridViewPaymentTypes.Rows.Add(paymentType.PaymentTypeId, paymentType.Name);
            }

            dataGridViewPaymentTypes.ClearSelection();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                return;
            }

            //Update
            if (dataGridViewPaymentTypes.SelectedRows.Count > 0)
            {
                int paymentTypesId = Convert.ToInt32(dataGridViewPaymentTypes.CurrentRow.Cells[0].Value);

                var currentPaymentType = _genericRepositoryPaymentType.GetById(paymentTypesId);

                currentPaymentType.Name = textBoxName.Text;

                _genericRepositoryPaymentType.Update(currentPaymentType);

                Clear();
                LoadPaymentTypesDataGridView();
                return;
            }

            var paymentTypeExist = _genericRepositoryPaymentType.GetAsNoTracking(x => x.Name == textBoxName.Text);
            if (paymentTypeExist != null)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("RegistrationWithASimilarNameIsNotPossible!"), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
                return;
            }

            //Save            
            PaymentType paymentType = new PaymentType
            {
                Name = textBoxName.Text,
                BackColor = "52,58,64",
                ForeColor = "224,224,224"
            };

            _genericRepositoryPaymentType.Add(paymentType);

            Clear();
            LoadPaymentTypesDataGridView();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPaymentTypes.SelectedRows.Count < 0)
            {
                return;
            }

            if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("AreYouSureTheEntityWillBeDeleted?"), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) == DialogResult.No)
            {
                return;
            }

            int paymentTypeId = Convert.ToInt32(dataGridViewPaymentTypes.CurrentRow.Cells[0].Value);
            var currentPaymentType = _genericRepositoryPaymentType.GetById(paymentTypeId);
            _genericRepositoryPaymentType.Delete(currentPaymentType);

            LoadPaymentTypesDataGridView();
        }

        private void Clear()
        {
            textBoxName.Clear();
        }

        private void dataGridViewPaymentTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.Text = dataGridViewPaymentTypes.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
