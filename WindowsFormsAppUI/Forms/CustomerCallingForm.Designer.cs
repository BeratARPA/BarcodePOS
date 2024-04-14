namespace WindowsFormsAppUI.Forms
{
    partial class CustomerCallingForm
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.labelPhoneNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 51);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.CustomerCallingForm_Click);
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelPhoneNumber.ForeColor = System.Drawing.Color.White;
            this.labelPhoneNumber.Location = new System.Drawing.Point(9, 9);
            this.labelPhoneNumber.Margin = new System.Windows.Forms.Padding(0);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(139, 28);
            this.labelPhoneNumber.TabIndex = 1;
            this.labelPhoneNumber.Text = "PhoneNumber";
            this.labelPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPhoneNumber.Click += new System.EventHandler(this.CustomerCallingForm_Click);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelDate.Location = new System.Drawing.Point(9, 51);
            this.labelDate.Margin = new System.Windows.Forms.Padding(0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(53, 28);
            this.labelDate.TabIndex = 1;
            this.labelDate.Text = "Date";
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDate.Click += new System.EventHandler(this.CustomerCallingForm_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelDescription.Location = new System.Drawing.Point(9, 79);
            this.labelDescription.Margin = new System.Windows.Forms.Padding(0);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(282, 62);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelDescription.Click += new System.EventHandler(this.CustomerCallingForm_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(247, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(50, 35);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CustomerCallingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerCallingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Click += new System.EventHandler(this.CustomerCallingForm_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonClose;
    }
}