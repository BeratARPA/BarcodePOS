using Database.Data;
using Database.Models;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsFormsAppUI.Helpers;

namespace WindowsFormsAppUI.Forms
{
    public partial class CrashHandlerForm : Form
    {
        [DllImport("kernel32.dll")] internal static extern uint GetTickCount();

        /**** CHANGE THESE ****/
        private readonly string ErrorDirectory = string.Format(@"{0}\Errors", Environment.CurrentDirectory);

        private readonly string strErrorLog = "";

        private readonly IGenericRepository<CompanyInformation> _genericRepositoryCompanyInformation = new GenericRepository<CompanyInformation>();

        public CrashHandlerForm(Exception e)
        {
            InitializeComponent();

            #region Information
            // Set application product name
            this.labelInfo.Text = string.Format(GlobalVariables.CultureHelper.GetText("AnExceptionOccurredInComponent"), Application.ProductName);

            UpdateUILanguage();

            // Set icons to error
            this.Icon = SystemIcons.Error;
            this.pictureBoxErr.Image = SystemIcons.Error.ToBitmap();

            string strBuildTime = new DateTime(2000, 1, 1).AddDays(Assembly.GetExecutingAssembly().GetName().Version.Build).ToShortDateString();

            // Gets program uptime
            TimeSpan timeSpanProcTime = Process.GetCurrentProcess().TotalProcessorTime;

            // Used to get disk space
            DriveInfo driveInfo = new DriveInfo(Directory.GetDirectoryRoot(Application.ExecutablePath));

            this.listView1.Items.Add(new ListViewItem(new string[] { "Current Date/Time", DateTime.Now.ToString() }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Exec. Date/Time", Process.GetCurrentProcess().StartTime.ToString() }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Build Date", strBuildTime }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "OS", Environment.OSVersion.VersionString }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Language", Application.CurrentInputLanguage.LayoutName }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "System Uptime", string.Format("{0} Days {1} Hours {2} Mins {3} Secs", Math.Round((decimal)GetTickCount() / 86400000), Math.Round((decimal)GetTickCount() / 3600000 % 24), Math.Round((decimal)GetTickCount() / 120000 % 60), Math.Round((decimal)GetTickCount() / 1000 % 60)) }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Program Uptime", string.Format("{0} hours {1} mins {2} secs", timeSpanProcTime.TotalHours.ToString("0"), timeSpanProcTime.TotalMinutes.ToString("0"), timeSpanProcTime.TotalSeconds.ToString("0")) }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "PID", Process.GetCurrentProcess().Id.ToString() }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Thread Count", Process.GetCurrentProcess().Threads.Count.ToString() }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Thread Id", System.Threading.Thread.CurrentThread.ManagedThreadId.ToString() }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Executable", Application.ExecutablePath }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Process Name", Process.GetCurrentProcess().ProcessName }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "Version", Application.ProductVersion }));
            this.listView1.Items.Add(new ListViewItem(new string[] { "CLR Version", Environment.Version.ToString() }));

            Exception ex = e;
            for (int i = 0; ex != null; ex = ex.InnerException, i++)
            {
                this.listView2.Items.Add(new ListViewItem(new string[] { "Type #" + i.ToString(), ex.GetType().ToString() }));
                if (!string.IsNullOrEmpty(ex.Message))
                    this.listView2.Items.Add(new ListViewItem(new string[] { "Message #" + i.ToString(), ex.Message }));
                if (!string.IsNullOrEmpty(ex.Source))
                    this.listView2.Items.Add(new ListViewItem(new string[] { "Source #" + i.ToString(), ex.Source }));
                if (!string.IsNullOrEmpty(ex.HelpLink))
                    this.listView2.Items.Add(new ListViewItem(new string[] { "Help Link #" + i.ToString(), ex.HelpLink }));
                if (ex.TargetSite != null)
                    this.listView2.Items.Add(new ListViewItem(new string[] { "Target Site #" + i.ToString(), ex.TargetSite.ToString() }));
                if (ex.Data != null)
                {
                    foreach (DictionaryEntry de in ex.Data)
                    {
                        this.listView2.Items.Add(new ListViewItem(new string[] { "Dictionary Entry #" + i.ToString(), string.Format("Key: {0} Value: {1}", de.Key, de.Value) }));
                    }
                }
            }

            this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            this.textBoxStackTrace.Text = e.StackTrace;

            this.strErrorLog = string.Format("{0}\\{1:yyyy}_{1:MM}_{1:dd}_{1:HH}{1:mm}{1:ss}.txt", ErrorDirectory, DateTime.Now);
            #endregion

        }

        public void UpdateUILanguage()
        {
            tabPage1.Text = GlobalVariables.CultureHelper.GetText("General");
            tabPage2.Text = GlobalVariables.CultureHelper.GetText("Error");
            tabPage3.Text = GlobalVariables.CultureHelper.GetText("StackTrace");
            listView1.Columns[0].Text = GlobalVariables.CultureHelper.GetText("Definition");
            listView1.Columns[1].Text = GlobalVariables.CultureHelper.GetText("Value");
            listView2.Columns[0].Text = GlobalVariables.CultureHelper.GetText("Definition");
            listView2.Columns[1].Text = GlobalVariables.CultureHelper.GetText("Value");
            checkBoxRestart.Text = GlobalVariables.CultureHelper.GetText("Restart");
            buttonSend.Text = GlobalVariables.CultureHelper.GetText("SubmitErrorReport");
            buttonDontSend.Text = GlobalVariables.CultureHelper.GetText("DontSend");
        }

        #region Send
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (CreateErrorLog())
            {
                bool bReportSent = SendBugReport();

                if (!bReportSent)
                {
                    MessageBox.Show(this, GlobalVariables.CultureHelper.GetText("ErrorReportCouldNotBeSent!"), GlobalVariables.CultureHelper.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(this, GlobalVariables.CultureHelper.GetText("ErrorReportSent"), GlobalVariables.CultureHelper.GetText("Information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, GlobalVariables.CultureHelper.GetText("ErrorReportCouldNotBeSent!"), GlobalVariables.CultureHelper.GetText("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Close();
        }
        #endregion

        #region SendBugReport
        /// <summary>
        /// Uses PHP to upload bug report and email it
        /// </summary>
        /// <returns>True if it was sent</returns>
        private bool SendBugReport()
        {
            var companyInformation = _genericRepositoryCompanyInformation.GetById(1);

            string fileFormName = "Hata Raporu" + " - " + companyInformation.Name;

            // Build up the post message header

            StringBuilder sb = new StringBuilder();
            sb.Append("--");
            sb.Append(DateTime.Now.ToString());
            sb.Append("--");
            sb.Append("\n");
            sb.Append("Name: ");
            sb.Append(companyInformation.Name);
            sb.Append("\n");
            sb.Append("Address: ");
            sb.Append(companyInformation.Address);
            sb.Append("\n");
            sb.Append("Phone: ");
            sb.Append(companyInformation.Phone);
            sb.Append("\n");
            sb.Append("E-Mail: ");
            sb.Append(companyInformation.EMail);
            sb.Append("\n");
            sb.Append("Software: " + Assembly.GetExecutingAssembly().GetName().Name);

            string postHeader = sb.ToString();

            try
            {
                using (MailMessage emailMessage = new MailMessage())
                {
                    emailMessage.From = new MailAddress("beratarpa@hotmail.com", "BarcodePOS");
                    emailMessage.To.Add(new MailAddress("beratarpa@hotmail.com", "Innovative Software Company"));
                    emailMessage.Subject = fileFormName;
                    emailMessage.Body = postHeader;
                    emailMessage.Attachments.Add(new Attachment(strErrorLog));

                    using (SmtpClient MailClient = new SmtpClient("smtp.office365.com", 587))
                    {
                        MailClient.EnableSsl = true;
                        MailClient.UseDefaultCredentials = true;
                        MailClient.Credentials = new NetworkCredential("beratarpa@hotmail.com", "...");
                        MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        MailClient.Send(emailMessage);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region CreateErrorLog
        /// <summary>
        /// Creates error log file
        /// </summary>
        /// <returns>True on success</returns>
        private bool CreateErrorLog()
        {
            int i;
            StreamWriter streamErrorLog = null;

            // Create directory if it doesnt exist
            if (!Directory.Exists(ErrorDirectory))
                Directory.CreateDirectory(ErrorDirectory);

            try
            {
                streamErrorLog = File.CreateText(strErrorLog);

                for (i = 0; i < this.listView1.Items.Count; i++)
                {
                    string strDesc = this.listView1.Items[i].SubItems[0].Text;
                    string strValue = this.listView1.Items[i].SubItems[1].Text;

                    streamErrorLog.WriteLine(string.Format("{0}: {1}", strDesc, strValue));
                }

                streamErrorLog.WriteLine();

                for (i = 0; i < this.listView2.Items.Count; i++)
                {
                    string strDesc = this.listView2.Items[i].SubItems[0].Text;
                    string strValue = this.listView2.Items[i].SubItems[1].Text;

                    streamErrorLog.WriteLine(string.Format("{0}: {1}", strDesc, strValue));
                }

                streamErrorLog.WriteLine("Stack Trace:");
                streamErrorLog.WriteLine(this.textBoxStackTrace.Text);

                streamErrorLog.Close();

            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region FormClosed
        private void CrashHandlerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.checkBoxRestart.Checked)
            {
                Application.Restart();
                Process.GetCurrentProcess().Kill();
            }
        }
        #endregion

        #region DontSend
        private void buttonDontSend_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
