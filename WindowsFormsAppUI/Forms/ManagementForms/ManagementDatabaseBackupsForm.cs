using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms.ManagementForms
{
    public partial class ManagementDatabaseBackupsForm : Form
    {
        public ManagementDatabaseBackupsForm()
        {
            InitializeComponent();
            UpdateUILanguage();
        }

        private void ManagementDatabaseBackupsForm_Load(object sender, EventArgs e)
        {
            LoadBackups();
        }

        public void UpdateUILanguage()
        {
            buttonDatabaseBackup.Text = GlobalVariables.CultureHelper.GetText("BackupDatabase");
            buttonDatabaseRestore.Text = GlobalVariables.CultureHelper.GetText("DatabaseRestore");
            buttonBackupLocation.Text = GlobalVariables.CultureHelper.GetText("ShowBackupLocation");
            dataGridViewBackups.Columns[1].HeaderText = GlobalVariables.CultureHelper.GetText("Name");
            dataGridViewBackups.Columns[2].HeaderText = GlobalVariables.CultureHelper.GetText("Date");
        }

        public void LoadBackups()
        {
            FolderLocations.CreateFolders();
            dataGridViewBackups.Rows.Clear();

            int i = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(FolderLocations.databaseBackupsFolderPath);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.zip");
            foreach (FileInfo file in fileInfos)
            {
                i++;

                int dosyaAdıLength = file.Name.Length;
                int dosyaFormatLength = file.Extension.Length;
                int finalLength = dosyaAdıLength - dosyaFormatLength;
                dataGridViewBackups.Rows.Add(i, file.Name.Substring(0, finalLength), file.CreationTime, file.FullName);
            }

            dataGridViewBackups.ClearSelection();
        }

        private void buttonDatabaseBackup_Click(object sender, EventArgs e)
        {
            DatabaseHelper.Backup();
            LoadBackups();
        }

        private void buttonDatabaseRestore_Click(object sender, EventArgs e)
        {
            if (dataGridViewBackups.SelectedRows.Count > 0)
            {
                if (GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("MakeSureAllTerminalsAreClosedBeforeRestoringTheDatabaseDoYouWantToContinue?"), GlobalVariables.CultureHelper.GetText("Information"), MessageButton.YesNo, MessageIcon.Information) == DialogResult.Yes)
                {
                    DatabaseHelper.Restore(GlobalVariables.SQLContext.Database.Connection.Database, dataGridViewBackups.CurrentRow.Cells[3].Value.ToString());
                }
            }
            else
            {
                GlobalVariables.MessageBoxForm.ShowMessage(GlobalVariables.CultureHelper.GetText("SelectTheDatabaseBackupYouWantToRestore."), GlobalVariables.CultureHelper.GetText("Warning"), MessageButton.OK, MessageIcon.Warning);
            }
        }

        private void buttonBackupLocation_Click(object sender, EventArgs e)
        {
            FolderLocations.CreateFolders();
            Process.Start(FolderLocations.databaseBackupsFolderPath);
        }
    }
}
