using Database.Data;
using Database.Models;

namespace WindowsFormsAppUI.Helpers
{
    public class TableName
    {
        private static readonly IGenericRepository<Table> _genericRepositoryTable = new GenericRepository<Table>();

        public static string GetName(int tableId)
        {
            var table = _genericRepositoryTable.Get(x => x.TableId == tableId);

            return table.Title != "" ? table.Title : table.Name;
        }
    }
}
