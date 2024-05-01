using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DatabaseBackupRestore.Helpers
{
    public class DatabaseInformation
    {
        public DatabaseInformation()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string posFolderPath = Path.Combine(documentsPath, "POS");
            string barcodePOSFolderPath = Path.Combine(posFolderPath, "BarcodePOS");
            string databaseBackupsFolderPath = Path.Combine(barcodePOSFolderPath, "Database Backups");
            string path = Path.Combine(barcodePOSFolderPath, "DatabaseInformation.json");

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    JObject json = JObject.Parse(streamReader.ReadToEnd());

                    DatabaseAddress = json["DatabaseAddress"].ToString();
                    DatabaseName = json["DatabaseName"].ToString();
                    RestoreUrl = json["RestoreUrl"].ToString();
                    CurrentDirectory = json["CurrentDirectory"].ToString();
                }
            }
        }

        public string DatabaseAddress { get; set; }
        public string DatabaseName { get; set; }
        public string RestoreUrl { get; set; }
        public string CurrentDirectory { get; set; }
    }
}
