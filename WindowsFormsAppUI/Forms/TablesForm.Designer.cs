namespace WindowsFormsAppUI.Forms
{
    partial class TablesForm
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
            this.tileControlSections = new DevExpress.XtraEditors.TileControl();
            this.tileGroupSections = new DevExpress.XtraEditors.TileGroup();
            this.tileControlTables = new DevExpress.XtraEditors.TileControl();
            this.tileGroupTables = new DevExpress.XtraEditors.TileGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonOpenTables = new System.Windows.Forms.Button();
            this.buttonCloseTables = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileControlSections
            // 
            this.tileControlSections.AllowItemHover = true;
            this.tileControlSections.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tileControlSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControlSections.Groups.Add(this.tileGroupSections);
            this.tileControlSections.IndentBetweenItems = 5;
            this.tileControlSections.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.Fade;
            this.tileControlSections.LayoutMode = DevExpress.XtraEditors.TileControlLayoutMode.Adaptive;
            this.tileControlSections.Location = new System.Drawing.Point(0, 0);
            this.tileControlSections.Margin = new System.Windows.Forms.Padding(0);
            this.tileControlSections.MaxId = 11;
            this.tileControlSections.Name = "tileControlSections";
            this.tileControlSections.RowCount = 3;
            this.tileControlSections.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;
            this.tileControlSections.Size = new System.Drawing.Size(1031, 85);
            this.tileControlSections.TabIndex = 2;
            this.tileControlSections.Text = "tileControl1";
            // 
            // tileGroupSections
            // 
            this.tileGroupSections.Name = "tileGroupSections";
            // 
            // tileControlTables
            // 
            this.tileControlTables.AllowItemHover = true;
            this.tileControlTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControlTables.Groups.Add(this.tileGroupTables);
            this.tileControlTables.IndentBetweenItems = 5;
            this.tileControlTables.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.Fade;
            this.tileControlTables.LayoutMode = DevExpress.XtraEditors.TileControlLayoutMode.Adaptive;
            this.tileControlTables.Location = new System.Drawing.Point(3, 88);
            this.tileControlTables.MaxId = 26;
            this.tileControlTables.Name = "tileControlTables";
            this.tileControlTables.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileControlTables.RowCount = 3;
            this.tileControlTables.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;
            this.tileControlTables.Size = new System.Drawing.Size(1025, 574);
            this.tileControlTables.TabIndex = 3;
            this.tileControlTables.Text = "tileControl1";
            // 
            // tileGroupTables
            // 
            this.tileGroupTables.Name = "tileGroupTables";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tileControlTables, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tileControlSections, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1031, 715);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonCloseTables, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonOpenTables, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 665);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1031, 50);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // buttonOpenTables
            // 
            this.buttonOpenTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonOpenTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenTables.FlatAppearance.BorderSize = 0;
            this.buttonOpenTables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonOpenTables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonOpenTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenTables.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonOpenTables.ForeColor = System.Drawing.Color.White;
            this.buttonOpenTables.Location = new System.Drawing.Point(4, 4);
            this.buttonOpenTables.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenTables.Name = "buttonOpenTables";
            this.buttonOpenTables.Size = new System.Drawing.Size(507, 42);
            this.buttonOpenTables.TabIndex = 10;
            this.buttonOpenTables.Text = "Açık Masalar";
            this.buttonOpenTables.UseVisualStyleBackColor = false;
            this.buttonOpenTables.Click += new System.EventHandler(this.buttonOpenTables_Click);
            // 
            // buttonCloseTables
            // 
            this.buttonCloseTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonCloseTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCloseTables.FlatAppearance.BorderSize = 0;
            this.buttonCloseTables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonCloseTables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonCloseTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCloseTables.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonCloseTables.ForeColor = System.Drawing.Color.White;
            this.buttonCloseTables.Location = new System.Drawing.Point(519, 4);
            this.buttonCloseTables.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCloseTables.Name = "buttonCloseTables";
            this.buttonCloseTables.Size = new System.Drawing.Size(508, 42);
            this.buttonCloseTables.TabIndex = 11;
            this.buttonCloseTables.Text = "Kapalı Masalar";
            this.buttonCloseTables.UseVisualStyleBackColor = false;
            this.buttonCloseTables.Click += new System.EventHandler(this.buttonCloseTables_Click);
            // 
            // TablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 715);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TablesForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.TablesForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControlSections;
        private DevExpress.XtraEditors.TileGroup tileGroupSections;
        private DevExpress.XtraEditors.TileControl tileControlTables;
        private DevExpress.XtraEditors.TileGroup tileGroupTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonOpenTables;
        private System.Windows.Forms.Button buttonCloseTables;
    }
}