using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppUI.Helpers
{
    public class FolderLocations
    {
        public static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string baskentToptanFolderPath = Path.Combine(documentsPath, "Başkent Toptan");
        public static string fastPOSFolderPath = Path.Combine(baskentToptanFolderPath, "FastPOS");
        public static string databaseBackupsFolderPath = Path.Combine(fastPOSFolderPath, "Database Backups");

        public static void CreateFolders()
        {
            if (!Directory.Exists(baskentToptanFolderPath))
            {
                Directory.CreateDirectory(baskentToptanFolderPath);
                GrantAccess(baskentToptanFolderPath);
            }

            if (!Directory.Exists(fastPOSFolderPath))
            {
                Directory.CreateDirectory(fastPOSFolderPath);
                GrantAccess(fastPOSFolderPath);
            }

            if (!Directory.Exists(databaseBackupsFolderPath))
            {
                Directory.CreateDirectory(databaseBackupsFolderPath);
                GrantAccess(databaseBackupsFolderPath);
            }
        }

        public static void GrantAccess(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            directoryInfo.SetAccessControl(directorySecurity);

        }
    }
}
