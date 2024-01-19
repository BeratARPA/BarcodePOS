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
            this.SuspendLayout();
            // 
            // tileControlSections
            // 
            this.tileControlSections.AllowItemHover = true;
            this.tileControlSections.Dock = System.Windows.Forms.DockStyle.Top;
            this.tileControlSections.Groups.Add(this.tileGroupSections);
            this.tileControlSections.IndentBetweenItems = 5;
            this.tileControlSections.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.Fade;
            this.tileControlSections.LayoutMode = DevExpress.XtraEditors.TileControlLayoutMode.Adaptive;
            this.tileControlSections.Location = new System.Drawing.Point(0, 0);
            this.tileControlSections.MaxId = 11;
            this.tileControlSections.Name = "tileControlSections";
            this.tileControlSections.RowCount = 3;
            this.tileControlSections.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;
            this.tileControlSections.Size = new System.Drawing.Size(1031, 112);
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
            this.tileControlTables.Location = new System.Drawing.Point(0, 112);
            this.tileControlTables.MaxId = 21;
            this.tileControlTables.Name = "tileControlTables";
            this.tileControlTables.RowCount = 3;
            this.tileControlTables.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;
            this.tileControlTables.Size = new System.Drawing.Size(1031, 638);
            this.tileControlTables.TabIndex = 3;
            this.tileControlTables.Text = "tileControl1";
            // 
            // tileGroupTables
            // 
            this.tileGroupTables.Name = "tileGroupTables";
            // 
            // TablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 750);
            this.Controls.Add(this.tileControlTables);
            this.Controls.Add(this.tileControlSections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TablesForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.TablesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControlSections;
        private DevExpress.XtraEditors.TileGroup tileGroupSections;
        private DevExpress.XtraEditors.TileControl tileControlTables;
        private DevExpress.XtraEditors.TileGroup tileGroupTables;
    }
}