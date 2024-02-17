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
                    return "BarcodePOSLocalDB"; // SQLite bağlantı dizesi
                case TypeDatabase.SQLServer:
                    return "BarcodePOSSQLServer"; // SQL Server bağlantı dizesi
                                                     // Diğer veritabanı türleri için gerekli bağlantı dizelerini ekleyebilirsiniz
                default:
                    throw new NotSupportedException("Database type not supported.");
            }
        }
    }
}
