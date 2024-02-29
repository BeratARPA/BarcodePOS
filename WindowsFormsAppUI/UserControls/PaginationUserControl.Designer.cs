namespace WindowsFormsAppUI.UserControls
{
    partial class PaginationUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonGoFirst = new System.Windows.Forms.Button();
            this.labelTotalRecords = new System.Windows.Forms.Label();
            this.buttonGoPrevious = new System.Windows.Forms.Button();
            this.buttonGoNext = new System.Windows.Forms.Button();
            this.buttonGoLast = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.comboBoxPageSize = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.3666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.3666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.3666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.3666F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.5336F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel1.Controls.Add(this.buttonGoFirst, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelTotalRecords, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonGoPrevious, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonGoNext, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonGoLast, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelStatus, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxPageSize, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonGoFirst
            // 
            this.buttonGoFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonGoFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoFirst.FlatAppearance.BorderSize = 0;
            this.buttonGoFirst.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoFirst.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGoFirst.ForeColor = System.Drawing.Color.White;
            this.buttonGoFirst.Location = new System.Drawing.Point(1, 23);
            this.buttonGoFirst.Margin = new System.Windows.Forms.Padding(1);
            this.buttonGoFirst.Name = "buttonGoFirst";
            this.buttonGoFirst.Size = new System.Drawing.Size(96, 36);
            this.buttonGoFirst.TabIndex = 11;
            this.buttonGoFirst.Text = "|<";
            this.buttonGoFirst.UseVisualStyleBackColor = false;
            this.buttonGoFirst.Click += new System.EventHandler(this.buttonGoFirst_Click);
            // 
            // labelTotalRecords
            // 
            this.labelTotalRecords.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTotalRecords, 2);
            this.labelTotalRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalRecords.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelTotalRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelTotalRecords.Location = new System.Drawing.Point(0, 0);
            this.labelTotalRecords.Margin = new System.Windows.Forms.Padding(0);
            this.labelTotalRecords.Name = "labelTotalRecords";
            this.labelTotalRecords.Size = new System.Drawing.Size(196, 22);
            this.labelTotalRecords.TabIndex = 1;
            this.labelTotalRecords.Text = "0";
            this.labelTotalRecords.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonGoPrevious
            // 
            this.buttonGoPrevious.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonGoPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoPrevious.FlatAppearance.BorderSize = 0;
            this.buttonGoPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoPrevious.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGoPrevious.ForeColor = System.Drawing.Color.White;
            this.buttonGoPrevious.Location = new System.Drawing.Point(99, 23);
            this.buttonGoPrevious.Margin = new System.Windows.Forms.Padding(1);
            this.buttonGoPrevious.Name = "buttonGoPrevious";
            this.buttonGoPrevious.Size = new System.Drawing.Size(96, 36);
            this.buttonGoPrevious.TabIndex = 11;
            this.buttonGoPrevious.Text = "<";
            this.buttonGoPrevious.UseVisualStyleBackColor = false;
            this.buttonGoPrevious.Click += new System.EventHandler(this.buttonGoPrevious_Click);
            // 
            // buttonGoNext
            // 
            this.buttonGoNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonGoNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoNext.FlatAppearance.BorderSize = 0;
            this.buttonGoNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGoNext.ForeColor = System.Drawing.Color.White;
            this.buttonGoNext.Location = new System.Drawing.Point(295, 23);
            this.buttonGoNext.Margin = new System.Windows.Forms.Padding(1);
            this.buttonGoNext.Name = "buttonGoNext";
            this.buttonGoNext.Size = new System.Drawing.Size(96, 36);
            this.buttonGoNext.TabIndex = 11;
            this.buttonGoNext.Text = ">";
            this.buttonGoNext.UseVisualStyleBackColor = false;
            this.buttonGoNext.Click += new System.EventHandler(this.buttonGoNext_Click);
            // 
            // buttonGoLast
            // 
            this.buttonGoLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonGoLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoLast.FlatAppearance.BorderSize = 0;
            this.buttonGoLast.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonGoLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoLast.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonGoLast.ForeColor = System.Drawing.Color.White;
            this.buttonGoLast.Location = new System.Drawing.Point(393, 23);
            this.buttonGoLast.Margin = new System.Windows.Forms.Padding(1);
            this.buttonGoLast.Name = "buttonGoLast";
            this.buttonGoLast.Size = new System.Drawing.Size(88, 36);
            this.buttonGoLast.TabIndex = 11;
            this.buttonGoLast.Text = ">|";
            this.buttonGoLast.UseVisualStyleBackColor = false;
            this.buttonGoLast.Click += new System.EventHandler(this.buttonGoLast_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelStatus.ForeColor = System.Drawing.Color.White;
            this.labelStatus.Location = new System.Drawing.Point(197, 23);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(1);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(96, 36);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "0 / 0";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxPageSize
            // 
            this.comboBoxPageSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPageSize.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxPageSize.FormattingEnabled = true;
            this.comboBoxPageSize.Items.AddRange(new object[] {
            "10",
            "30",
            "50"});
            this.comboBoxPageSize.Location = new System.Drawing.Point(485, 27);
            this.comboBoxPageSize.Name = "comboBoxPageSize";
            this.comboBoxPageSize.Size = new System.Drawing.Size(112, 25);
            this.comboBoxPageSize.TabIndex = 12;
            this.comboBoxPageSize.SelectedValueChanged += new System.EventHandler(this.comboBoxPageSize_SelectedValueChanged);
            // 
            // PaginationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PaginationUserControl";
            this.Size = new System.Drawing.Size(600, 60);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonGoFirst;
        private System.Windows.Forms.Button buttonGoPrevious;
        private System.Windows.Forms.Button buttonGoNext;
        private System.Windows.Forms.Button buttonGoLast;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ComboBox comboBoxPageSize;
        public System.Windows.Forms.Label labelTotalRecords;
    }
}
