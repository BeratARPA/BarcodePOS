using Database.Data;
using Database.Models;
using System.Linq;

namespace WindowsFormsAppUI.Helpers
{
    public class TicketNumberHelper
    {
        private static readonly IGenericRepository<Ticket> _genericRepositoryTicket = new GenericRepository<Ticket>(GlobalVariables.SQLContext);

        public static int GetNumber()
        {
            var _tickets = _genericRepositoryTicket.GetAll();
            int lastTicketNumber = 0;

            try
            {
                lastTicketNumber = _tickets.Max(x => int.Parse(x.TicketNumber));
            }
            catch
            {
                lastTicketNumber = 0;
            }

            return lastTicketNumber + 1;
        }
    }
}
