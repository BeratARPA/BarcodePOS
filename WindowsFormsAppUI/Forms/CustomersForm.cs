using Database.Data;
using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CustomersForm : Form
    {
        private readonly GenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>();
        private List<Customer> _customers = new List<Customer>();

        public CustomersForm()
        {
            InitializeComponent();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            _customers = _genericRepositoryCustomer.GetAllAsNoTracking();

            GetCustomers();
            paginationUserControl1.TotalRecords = _customers.Count;

            Fill();
        }

        public void AddCustomerDataGridView(List<Customer> customers)
        {
            dataGridViewCustomers.Rows.Clear();

            customers = customers.Skip(paginationUserControl1.PageSize * (paginationUserControl1.CurrentPage - 1)).Take(paginationUserControl1.PageSize).ToList();
            foreach (var customer in customers)
            {
                dataGridViewCustomers.Rows.Add(customer.CustomerId, customer.Name, customer.PhoneNumber, customer.Address, customer.Note);
            }
        }

        public List<Customer> GetCustomers()
        {
            _customers = _genericRepositoryCustomer.GetAllAsNoTracking();

            if (string.IsNullOrEmpty(textBoxSearchCustomer.Text))
                return _customers;

            _customers = _customers.Where(x => x.Name.ToLower().Contains(textBoxSearchCustomer.Text.ToLower()) || x.PhoneNumber.Contains(textBoxSearchCustomer.Text) || x.Address.ToLower().Contains(textBoxSearchCustomer.Text.ToLower())).ToList();
            return _customers;
        }

        public void Fill()
        {
            paginationUserControl1.TotalRecords = _customers.Count;
            paginationUserControl1.Update();
            AddCustomerDataGridView(_customers);
        }

        private void paginationUserControl1_GoFirst(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_GoLast(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_GoNext(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_GoPrevious(object sender, EventArgs e)
        {
            Fill();
        }

        private void paginationUserControl1_PageSizeChanged(object sender, EventArgs e)
        {
            Fill();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            GetCustomers();
            Fill();
        }
    }
}
