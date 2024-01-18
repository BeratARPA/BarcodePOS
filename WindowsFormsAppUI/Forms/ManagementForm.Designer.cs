namespace WindowsFormsAppUI.Forms
{
    partial class ManagementForm
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
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElementUsers = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.panelMain = new System.Windows.Forms.Panel();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement5 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // accordionControl1
            // 
            this.accordionControl1.AllowDrop = true;
            this.accordionControl1.AllowElementDragging = true;
            this.accordionControl1.AllowHtmlText = false;
            this.accordionControl1.AllowItemSelection = true;
            this.accordionControl1.AnimationType = DevExpress.XtraBars.Navigation.AnimationType.Simple;
            this.accordionControl1.Appearance.AccordionControl.ForeColor = System.Drawing.Color.White;
            this.accordionControl1.Appearance.AccordionControl.Options.UseForeColor = true;
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.accordionControlElement4,
            this.accordionControlElement5});
            this.accordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            this.accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            this.accordionControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            this.accordionControl1.Size = new System.Drawing.Size(282, 923);
            this.accordionControl1.TabIndex = 4;
            // 
            // accordionControlElementUsers
            // 
            this.accordionControlElementUsers.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementUsers.Appearance.Default.Options.UseFont = true;
            this.accordionControlElementUsers.Appearance.Default.Options.UseTextOptions = true;
            this.accordionControlElementUsers.Appearance.Default.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementUsers.Appearance.Disabled.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementUsers.Appearance.Disabled.Options.UseFont = true;
            this.accordionControlElementUsers.Appearance.Disabled.Options.UseTextOptions = true;
            this.accordionControlElementUsers.Appearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementUsers.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementUsers.Appearance.Hovered.Options.UseFont = true;
            this.accordionControlElementUsers.Appearance.Hovered.Options.UseTextOptions = true;
            this.accordionControlElementUsers.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementUsers.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementUsers.Appearance.Normal.Options.UseFont = true;
            this.accordionControlElementUsers.Appearance.Normal.Options.UseTextOptions = true;
            this.accordionControlElementUsers.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementUsers.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementUsers.Appearance.Pressed.Options.UseFont = true;
            this.accordionControlElementUsers.Appearance.Pressed.Options.UseTextOptions = true;
            this.accordionControlElementUsers.Appearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementUsers.Expanded = true;
            this.accordionControlElementUsers.Height = 50;
            this.accordionControlElementUsers.Name = "accordionControlElementUsers";
            this.accordionControlElementUsers.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementUsers.Text = "Kullanıcılar";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(282, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(918, 923);
            this.panelMain.TabIndex = 5;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElementUsers});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Text = "Element1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Text = "Element2";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Text = "Element3";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Text = "Element4";
            // 
            // accordionControlElement5
            // 
            this.accordionControlElement5.Name = "accordionControlElement5";
            this.accordionControlElement5.Text = "Element5";
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 923);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.accordionControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementForm";
            this.Text = "BarcodePOS";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementUsers;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement5;
        private System.Windows.Forms.Panel panelMain;
    }
}