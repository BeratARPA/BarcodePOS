using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace WindowsFormsAppUI.Helpers
{
    public class FolderLocations
    {
        public static string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string posFolderPath = Path.Combine(documentsPath, "POS");
        public static string barcodePOSFolderPath = Path.Combine(posFolderPath, "BarcodePOS");
        public static string databaseBackupsFolderPath = Path.Combine(barcodePOSFolderPath, "Database Backups");

        public static void CreateFolders()
        {
            if (!Directory.Exists(posFolderPath))
            {
                Directory.CreateDirectory(posFolderPath);
                GrantAccess(posFolderPath);
            }

            if (!Directory.Exists(barcodePOSFolderPath))
            {
                Directory.CreateDirectory(barcodePOSFolderPath);
                GrantAccess(barcodePOSFolderPath);
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
