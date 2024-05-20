namespace WindowsFormsAppUI
{
    partial class ShellForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.labelIcon = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.tableLayoutPanelFooter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelUserFullname = new System.Windows.Forms.Label();
            this.buttonMainMenu = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonKeyboard = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.tableLayoutPanelFooter.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelFooter, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.panelMain, 0, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.tableLayoutPanelHeader.ColumnCount = 2;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Controls.Add(this.labelIcon, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.labelTime, 1, 0);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(784, 50);
            this.tableLayoutPanelHeader.TabIndex = 0;
            // 
            // labelIcon
            // 
            this.labelIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelIcon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelIcon.ForeColor = System.Drawing.Color.White;
            this.labelIcon.Location = new System.Drawing.Point(3, 0);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(194, 50);
            this.labelIcon.TabIndex = 0;
            this.labelIcon.Text = "BarcodePOS";
            this.labelIcon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelIcon.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.labelTime.Location = new System.Drawing.Point(203, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(578, 50);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "TIME";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanelFooter
            // 
            this.tableLayoutPanelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.tableLayoutPanelFooter.ColumnCount = 2;
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanelFooter.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelFooter.Location = new System.Drawing.Point(0, 511);
            this.tableLayoutPanelFooter.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelFooter.Name = "tableLayoutPanelFooter";
            this.tableLayoutPanelFooter.RowCount = 1;
            this.tableLayoutPanelFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelFooter.Size = new System.Drawing.Size(784, 50);
            this.tableLayoutPanelFooter.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.Controls.Add(this.labelUserFullname, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonMainMenu, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(392, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(392, 50);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // labelUserFullname
            // 
            this.labelUserFullname.AutoSize = true;
            this.labelUserFullname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUserFullname.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelUserFullname.ForeColor = System.Drawing.Color.White;
            this.labelUserFullname.Location = new System.Drawing.Point(3, 0);
            this.labelUserFullname.Name = "labelUserFullname";
            this.labelUserFullname.Size = new System.Drawing.Size(236, 50);
            this.labelUserFullname.TabIndex = 1;
            this.labelUserFullname.Text = "UserFullname";
            this.labelUserFullname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonMainMenu
            // 
            this.buttonMainMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonMainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMainMenu.Enabled = false;
            this.buttonMainMenu.FlatAppearance.BorderSize = 0;
            this.buttonMainMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.buttonMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.buttonMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonMainMenu.ForeColor = System.Drawing.Color.White;
            this.buttonMainMenu.Location = new System.Drawing.Point(252, 10);
            this.buttonMainMenu.Margin = new System.Windows.Forms.Padding(10);
            this.buttonMainMenu.Name = "buttonMainMenu";
            this.buttonMainMenu.Size = new System.Drawing.Size(130, 30);
            this.buttonMainMenu.TabIndex = 0;
            this.buttonMainMenu.Text = "Ana Menü";
            this.buttonMainMenu.UseVisualStyleBackColor = false;
            this.buttonMainMenu.Visible = false;
            this.buttonMainMenu.Click += new System.EventHandler(this.buttonMainMenu_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.buttonKeyboard, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(392, 50);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // buttonKeyboard
            // 
            this.buttonKeyboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonKeyboard.FlatAppearance.BorderSize = 0;
            this.buttonKeyboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.buttonKeyboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.buttonKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonKeyboard.ForeColor = System.Drawing.Color.White;
            this.buttonKeyboard.Location = new System.Drawing.Point(10, 10);
            this.buttonKeyboard.Margin = new System.Windows.Forms.Padding(10);
            this.buttonKeyboard.Name = "buttonKeyboard";
            this.buttonKeyboard.Size = new System.Drawing.Size(130, 30);
            this.buttonKeyboard.TabIndex = 0;
            this.buttonKeyboard.Text = "Klavye";
            this.buttonKeyboard.UseVisualStyleBackColor = false;
            this.buttonKeyboard.Click += new System.EventHandler(this.buttonKeyboard_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 50);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(784, 461);
            this.panelMain.TabIndex = 2;
            // 
            // ShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(798, 594);
            this.Name = "ShellForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BarcodePOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShellForm_FormClosing);
            this.Load += new System.EventHandler(this.ShellForm_Load);
            this.Resize += new System.EventHandler(this.ShellForm_Resize);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.tableLayoutPanelFooter.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        public System.Windows.Forms.Button buttonMainMenu;
        public System.Windows.Forms.Label labelUserFullname;
        public System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.Button buttonKeyboard;
        public System.Windows.Forms.Label labelIcon;
        public System.Windows.Forms.Label labelTime;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanelFooter;
    }
}