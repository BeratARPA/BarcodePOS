using Database.Data;
using Database.Models;

namespace WindowsFormsAppUI.Helpers
{
    public class CustomerName
    {
        private static readonly IGenericRepository<Customer> _genericRepositoryCustomer = new GenericRepository<Customer>(GlobalVariables.SQLContext);

        public static string GetName(int customerId)
        {
            var customer = _genericRepositoryCustomer.Get(x => x.CustomerId == customerId);

            return customer.Name != "" ? customer.Name : customer.PhoneNumber;
        }
    }
}
