namespace WindowsFormsAppUI.Forms
{
    partial class CrashHandlerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxErr = new System.Windows.Forms.PictureBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonDontSend = new System.Windows.Forms.Button();
            this.checkBoxRestart = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxStackTrace = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErr)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxErr
            // 
            this.pictureBoxErr.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxErr.Name = "pictureBoxErr";
            this.pictureBoxErr.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxErr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxErr.TabIndex = 34;
            this.pictureBoxErr.TabStop = false;
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(174, 381);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(120, 30);
            this.buttonSend.TabIndex = 31;
            this.buttonSend.Text = "Hata Raporu Gönder";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // buttonDontSend
            // 
            this.buttonDontSend.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonDontSend.Location = new System.Drawing.Point(300, 381);
            this.buttonDontSend.Name = "buttonDontSend";
            this.buttonDontSend.Size = new System.Drawing.Size(100, 30);
            this.buttonDontSend.TabIndex = 33;
            this.buttonDontSend.Text = "Gönderme";
            this.buttonDontSend.UseVisualStyleBackColor = true;
            this.buttonDontSend.Click += new System.EventHandler(this.buttonDontSend_Click);
            // 
            // checkBoxRestart
            // 
            this.checkBoxRestart.AutoSize = true;
            this.checkBoxRestart.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRestart.Location = new System.Drawing.Point(12, 394);
            this.checkBoxRestart.Name = "checkBoxRestart";
            this.checkBoxRestart.Size = new System.Drawing.Size(97, 17);
            this.checkBoxRestart.TabIndex = 32;
            this.checkBoxRestart.Text = "Yeniden Başlat";
            this.checkBoxRestart.UseVisualStyleBackColor = false;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(66, 12);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(334, 48);
            this.labelInfo.TabIndex = 30;
            this.labelInfo.Text = "{0} bileşeninde bir istisna oluştu. Bize gönderebileceğiniz bir hata raporu oluşt" +
    "urduk. Bu raporu gizli ve anonim olarak ele alacağız.";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-4, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(420, 309);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(412, 283);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Genel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(406, 277);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tanım";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Değer";
            this.columnHeader3.Width = 180;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(412, 283);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hata";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(406, 277);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tanım";
            this.columnHeader2.Width = 130;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Değer";
            this.columnHeader4.Width = 241;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxStackTrace);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(412, 283);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Yığın izleme";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxStackTrace
            // 
            this.textBoxStackTrace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStackTrace.Location = new System.Drawing.Point(3, 3);
            this.textBoxStackTrace.Multiline = true;
            this.textBoxStackTrace.Name = "textBoxStackTrace";
            this.textBoxStackTrace.ReadOnly = true;
            this.textBoxStackTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStackTrace.Size = new System.Drawing.Size(406, 277);
            this.textBoxStackTrace.TabIndex = 1;
            this.textBoxStackTrace.WordWrap = false;
            // 
            // CrashHandlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 423);
            this.Controls.Add(this.pictureBoxErr);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonDontSend);
            this.Controls.Add(this.checkBoxRestart);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CrashHandlerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crash Handler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CrashHandlerForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErr)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxErr;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonDontSend;
        private System.Windows.Forms.CheckBox checkBoxRestart;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox textBoxStackTrace;
    }
}