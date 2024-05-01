namespace WindowsFormsAppUI.Forms.ManagementForms
{
    partial class ManagementDatabaseBackupsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewBackups = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDatabaseBackup = new System.Windows.Forms.Button();
            this.buttonDatabaseRestore = new System.Windows.Forms.Button();
            this.buttonBackupLocation = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBackups, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonBackupLocation, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDatabaseRestore, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDatabaseBackup, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(20, 530);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(760, 50);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridViewBackups
            // 
            this.dataGridViewBackups.AllowUserToAddRows = false;
            this.dataGridViewBackups.AllowUserToDeleteRows = false;
            this.dataGridViewBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBackups.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBackups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewBackups.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBackups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBackups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBackups.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBackups.EnableHeadersVisualStyles = false;
            this.dataGridViewBackups.Location = new System.Drawing.Point(23, 23);
            this.dataGridViewBackups.MultiSelect = false;
            this.dataGridViewBackups.Name = "dataGridViewBackups";
            this.dataGridViewBackups.ReadOnly = true;
            this.dataGridViewBackups.RowHeadersVisible = false;
            this.dataGridViewBackups.RowHeadersWidth = 62;
            this.dataGridViewBackups.RowTemplate.Height = 25;
            this.dataGridViewBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBackups.Size = new System.Drawing.Size(754, 504);
            this.dataGridViewBackups.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Ad";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tarih";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "URL";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // buttonDatabaseBackup
            // 
            this.buttonDatabaseBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonDatabaseBackup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDatabaseBackup.FlatAppearance.BorderSize = 0;
            this.buttonDatabaseBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonDatabaseBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonDatabaseBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDatabaseBackup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDatabaseBackup.ForeColor = System.Drawing.Color.White;
            this.buttonDatabaseBackup.Location = new System.Drawing.Point(4, 4);
            this.buttonDatabaseBackup.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDatabaseBackup.Name = "buttonDatabaseBackup";
            this.buttonDatabaseBackup.Size = new System.Drawing.Size(212, 42);
            this.buttonDatabaseBackup.TabIndex = 10;
            this.buttonDatabaseBackup.Text = "Veritabanı Yedekle";
            this.buttonDatabaseBackup.UseVisualStyleBackColor = false;
            this.buttonDatabaseBackup.Click += new System.EventHandler(this.buttonDatabaseBackup_Click);
            // 
            // buttonDatabaseRestore
            // 
            this.buttonDatabaseRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonDatabaseRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDatabaseRestore.FlatAppearance.BorderSize = 0;
            this.buttonDatabaseRestore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonDatabaseRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonDatabaseRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDatabaseRestore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDatabaseRestore.ForeColor = System.Drawing.Color.White;
            this.buttonDatabaseRestore.Location = new System.Drawing.Point(224, 4);
            this.buttonDatabaseRestore.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDatabaseRestore.Name = "buttonDatabaseRestore";
            this.buttonDatabaseRestore.Size = new System.Drawing.Size(212, 42);
            this.buttonDatabaseRestore.TabIndex = 11;
            this.buttonDatabaseRestore.Text = "Veritabanı Geri Yükleme";
            this.buttonDatabaseRestore.UseVisualStyleBackColor = false;
            this.buttonDatabaseRestore.Click += new System.EventHandler(this.buttonDatabaseRestore_Click);
            // 
            // buttonBackupLocation
            // 
            this.buttonBackupLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonBackupLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackupLocation.FlatAppearance.BorderSize = 0;
            this.buttonBackupLocation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonBackupLocation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonBackupLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackupLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonBackupLocation.ForeColor = System.Drawing.Color.White;
            this.buttonBackupLocation.Location = new System.Drawing.Point(444, 4);
            this.buttonBackupLocation.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBackupLocation.Name = "buttonBackupLocation";
            this.buttonBackupLocation.Size = new System.Drawing.Size(212, 42);
            this.buttonBackupLocation.TabIndex = 12;
            this.buttonBackupLocation.Text = "Yedekleme Konumunu Göster";
            this.buttonBackupLocation.UseVisualStyleBackColor = false;
            this.buttonBackupLocation.Click += new System.EventHandler(this.buttonBackupLocation_Click);
            // 
            // ManagementDatabaseBackupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementDatabaseBackupsForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.ManagementDatabaseBackupsForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBackups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridViewBackups;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button buttonBackupLocation;
        private System.Windows.Forms.Button buttonDatabaseRestore;
        private System.Windows.Forms.Button buttonDatabaseBackup;
    }
}