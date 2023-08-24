using Database.Enums;
using System;

namespace Database.Helpers
{  
    public class DatabaseType
    {
        public static string GetConnectionString(TypeDatabase typeDatabase)
        {
            switch (typeDatabase)
            {
                case TypeDatabase.LocalDB:
                    return "FastPOSLocalDB"; // SQLite bağlantı dizesi
                case TypeDatabase.SQLServer:
                    return "FastPOSSQLServer"; // SQL Server bağlantı dizesi
                                                     // Diğer veritabanı türleri için gerekli bağlantı dizelerini ekleyebilirsiniz
                default:
                    throw new NotSupportedException("Database type not supported.");
            }
        }
    }
}
