using Database.Data;
using Database.Models;

namespace WindowsFormsAppUI.Helpers
{
    public class CustomerHelper
    {
        private static readonly IGenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(GlobalVariables.SQLContext);

        public static string GetName(int customerId)
        {
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);

            return customer.Name != "" ? customer.Name : customer.PhoneNumber;
        }

        public static string GetNameAndBalance(int customerId)
        {
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);

            return customer.Name != "" ? customer.Name + $" ({customer.Balance})" : customer.PhoneNumber + $" ({customer.Balance})";
        }

        public static string GetAddress(int customerId)
        {
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);

            return customer.Address != "" ? customer.Address : "";
        }

        public static string GetNameAndPhoneNumber(int customerId)
        {
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);

            return customer.Name + " - " + customer.PhoneNumber;
        }

        public static void UpdateBalance(int customerId, double value, bool mode)
        {
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);
            if (customer.IsAccount)
            {
                double balance = 0;

                if (mode)
                    balance = customer.Balance + value;
                else
                    balance = customer.Balance - value;

                _genericRepositoryCustomer.UpdateColumn(customer, x => x.Balance, balance);
            }
        }
    }
}
