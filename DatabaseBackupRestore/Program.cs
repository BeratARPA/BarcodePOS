using DatabaseBackupRestore.Helpers;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace DatabaseBackupRestore
{
    internal class Program
    {
        static DatabaseInformation databaseInformation = new DatabaseInformation();
        static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string posFolderPath = Path.Combine(documentsPath, "POS");
        static string barcodePOSFolderPath = Path.Combine(posFolderPath, "BarcodePOS");
        static string databaseBackupsFolderPath = Path.Combine(barcodePOSFolderPath, "Database Backups");

        #region ExtractToDirectoryBarcodePOSUpdaterZip
        public static void UnZip()
        {
            if (File.Exists(databaseBackupsFolderPath + "\\BarcodePOS.bak"))
            {
                File.Delete(databaseBackupsFolderPath + "\\BarcodePOS.bak");
            }

            ZipFile zipFile = null;

            try
            {
                FileStream fileStream = File.OpenRead(databaseInformation.RestoreUrl);
                zipFile = new ZipFile(fileStream);

                foreach (ZipEntry zipEntry in zipFile)
                {
                    if (!zipEntry.IsFile) continue;

                    var entryFileName = zipEntry.Name;
                    var buffer = new byte[4096];
                    var zipStream = zipFile.GetInputStream(zipEntry);

                    var fullZipToPath = Path.Combine(databaseBackupsFolderPath, entryFileName);
                    var directoryName = Path.GetDirectoryName(fullZipToPath);

                    if (directoryName != null && directoryName.Length <= 0) continue;
                    if (directoryName != null) Directory.CreateDirectory(directoryName);

                    using (var streamWriter = File.Create(fullZipToPath))
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veritabanı çıkartılırken, beklenmedik bir hata oluştu!\n\n\n\n" + ex.ToString());
                Console.ReadLine();
                throw;
            }
            finally
            {
                if (zipFile != null)
                {
                    zipFile.IsStreamOwner = true;
                    zipFile.Close();
                }
            }
        }
        #endregion       

        static void Main(string[] args)
        {
            try
            {
                UnZip();
                Console.WriteLine("Veritabanı yedeğine geri dönülüyor...");
                Thread.Sleep(10000);
                Console.WriteLine("Veritabanı adresi alınıyor...");
                string databaseAddress = databaseInformation.DatabaseAddress;
                Console.WriteLine("Veritabanı adresi alındı.");

                Console.WriteLine("Veritabanı adı alınıyor...");
                string databaseName = databaseInformation.DatabaseName;
                Console.WriteLine("Veritabanı adı alındı.");

                Console.WriteLine("Veritabanı yedek yolu alınıyor...");
                string restoreUrl = databaseInformation.RestoreUrl;
                Console.WriteLine("Veritabanı yedek yolu alındı.");

                Console.WriteLine("Program dosya yolu alınıyor...");
                string currentDirectory = databaseInformation.CurrentDirectory;
                Console.WriteLine("Program dosya yolu alındı.");

                using (SqlConnection connection = new SqlConnection(databaseAddress))
                {
                    connection.Open();
                    Console.WriteLine("Bağlantı açıldı.");

                    SqlCommand command = new SqlCommand("USE Master; If Exists(Select * From sys.databases where name='" + databaseName + "') Drop Database[" + databaseName + "]; RESTORE DATABASE[" + databaseName + "] FROM DISK=N'" + databaseBackupsFolderPath + "\\BarcodePOS.bak'", connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Güncel veritabanı silinip, veritabanı yedeği yüklendi.");

                    connection.Close();
                    Console.WriteLine("Veritabanı yedek yüklemesi başarılı.");
                }

                Console.WriteLine("BarcodePOS.exe başlatılıyor...");
                Process.Start(currentDirectory + "\\BarcodePOS.exe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Veritabanı yedeğine geri dönülürken, beklenmedik bir hata oluştu!\n\n\n\n" + ex.ToString());
                Console.ReadLine();
            }
        }
    }
}
