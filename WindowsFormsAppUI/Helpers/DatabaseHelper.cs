using Database.Enums;
using Database.Helpers;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Helpers
{
    public class DatabaseHelper
    {
        public static void Backup()
        {
            try
            {
                FolderLocations.CreateFolders();

                string dbname = GlobalVariables.SQLContext.Database.Connection.Database;
                string dbBackUpPath = Path.Combine(FolderLocations.databaseBackupsFolderPath, dbname + ".bak");
                string dbZipPath = "";

                if (GetDatabaseTypeSetting.Get() == 0)
                {
                    dbZipPath = Path.Combine(FolderLocations.databaseBackupsFolderPath, dbname + "_LocalDB_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
                }
                else
                {
                    dbZipPath = Path.Combine(FolderLocations.databaseBackupsFolderPath, dbname + "_SQLServer_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip");
                }

                string sqlCommand = @"BACKUP DATABASE [" + dbname + "] TO DISK = '" + dbBackUpPath + "'";
                GlobalVariables.SQLContext.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCommand);

                using (ZipArchive archive = ZipFile.Open(dbZipPath, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(dbBackUpPath, dbname + ".bak");
                    File.Delete(dbBackUpPath);
                }

                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("TheBackupHasBeenCreatedSuccessfully."), GlobalVariables.CultureHelper.GetText("Information"), Forms.MessageButton.OK, Forms.MessageIcon.Information);
            }
            catch (Exception ex)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(ex.ToString(), GlobalVariables.CultureHelper.GetText("Error"), Forms.MessageButton.OK, Forms.MessageIcon.Error);
            }
        }

        public class DatabaseInformation
        {
            public string DatabaseAddress { get; set; }
            public string DatabaseName { get; set; }
            public string RestoreUrl { get; set; }
            public string CurrentDirectory { get; set; }
        }

        public static void Restore(string databaseName, string restoreUrl)
        {
            try
            {
                FolderLocations.CreateFolders();

                string path = Path.Combine(FolderLocations.barcodePOSFolderPath, "DatabaseInformation.json");

                DatabaseInformation databaseInformation = new DatabaseInformation();

                databaseInformation.DatabaseAddress = ConfigurationManager.ConnectionStrings[DatabaseType.GetConnectionString((TypeDatabase)GetDatabaseTypeSetting.Get())].ConnectionString;
                databaseInformation.DatabaseName = databaseName;
                databaseInformation.RestoreUrl = restoreUrl;
                databaseInformation.CurrentDirectory = Application.StartupPath;

                string result = JsonHelper.Serialize(databaseInformation);

                if (File.Exists(path))
                {
                    File.Delete(path);
                    using (var streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine(result.ToString());
                        streamWriter.Close();
                    }
                }
                else if (!File.Exists(path))
                {
                    using (var streamWriter = new StreamWriter(path, true))
                    {
                        streamWriter.WriteLine(result.ToString());
                        streamWriter.Close();
                    }
                }

                Process.Start(Application.StartupPath + "\\Database Restore.exe");
                Application.Exit();
            }
            catch (Exception ex)
            {
                GlobalVariables.MessageBoxForm.ShowMessage(ex.ToString(), GlobalVariables.CultureHelper.GetText("Error"), Forms.MessageButton.OK, Forms.MessageIcon.Error);
            }
        }
    }
}
