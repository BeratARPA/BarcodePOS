using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Forms
{
    partial class PersonalizationForm
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementCategories = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementProducts = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElementPaymentTypes = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(282, 0);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(918, 923);
            this.panelMain.TabIndex = 1;
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
            this.accordionControlElementCategories,
            this.accordionControlElementProducts,
            this.accordionControlElementPaymentTypes});
            this.accordionControl1.ExpandElementMode = DevExpress.XtraBars.Navigation.ExpandElementMode.Multiple;
            this.accordionControl1.Location = new System.Drawing.Point(0, 0);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.OptionsFooter.ActiveGroupDisplayMode = DevExpress.XtraBars.Navigation.ActiveGroupDisplayMode.GroupHeaderAndContent;
            this.accordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.True;
            this.accordionControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            this.accordionControl1.Size = new System.Drawing.Size(282, 923);
            this.accordionControl1.TabIndex = 1;
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.HeaderVisible = false;
            this.accordionControlElement4.Name = "accordionControlElement4";
            // 
            // accordionControlElementCategories
            // 
            this.accordionControlElementCategories.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementCategories.Appearance.Default.Options.UseFont = true;
            this.accordionControlElementCategories.Appearance.Default.Options.UseTextOptions = true;
            this.accordionControlElementCategories.Appearance.Default.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementCategories.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementCategories.Appearance.Hovered.Options.UseFont = true;
            this.accordionControlElementCategories.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementCategories.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementCategories.Appearance.Normal.Options.UseFont = true;
            this.accordionControlElementCategories.Appearance.Normal.Options.UseTextOptions = true;
            this.accordionControlElementCategories.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementCategories.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementCategories.Appearance.Pressed.Options.UseFont = true;
            this.accordionControlElementCategories.Appearance.Pressed.Options.UseTextOptions = true;
            this.accordionControlElementCategories.Appearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementCategories.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElementCategories.Height = 50;
            this.accordionControlElementCategories.Name = "accordionControlElementCategories";
            this.accordionControlElementCategories.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementCategories.Text = "Kategoriler";
            this.accordionControlElementCategories.Click += new System.EventHandler(this.accordionControlElementCategories_Click);
            // 
            // accordionControlElementProducts
            // 
            this.accordionControlElementProducts.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementProducts.Appearance.Default.Options.UseFont = true;
            this.accordionControlElementProducts.Appearance.Default.Options.UseTextOptions = true;
            this.accordionControlElementProducts.Appearance.Default.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementProducts.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementProducts.Appearance.Hovered.Options.UseFont = true;
            this.accordionControlElementProducts.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementProducts.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementProducts.Appearance.Normal.Options.UseFont = true;
            this.accordionControlElementProducts.Appearance.Normal.Options.UseTextOptions = true;
            this.accordionControlElementProducts.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementProducts.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementProducts.Appearance.Pressed.Options.UseFont = true;
            this.accordionControlElementProducts.Appearance.Pressed.Options.UseTextOptions = true;
            this.accordionControlElementProducts.Appearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementProducts.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElementProducts.Height = 50;
            this.accordionControlElementProducts.Name = "accordionControlElementProducts";
            this.accordionControlElementProducts.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementProducts.Text = "Ürünler";
            this.accordionControlElementProducts.Click += new System.EventHandler(this.accordionControlElementProducts_Click);
            // 
            // accordionControlElementPaymentTypes
            // 
            this.accordionControlElementPaymentTypes.Appearance.Default.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementPaymentTypes.Appearance.Default.Options.UseFont = true;
            this.accordionControlElementPaymentTypes.Appearance.Default.Options.UseTextOptions = true;
            this.accordionControlElementPaymentTypes.Appearance.Default.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementPaymentTypes.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementPaymentTypes.Appearance.Hovered.Options.UseFont = true;
            this.accordionControlElementPaymentTypes.Appearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementPaymentTypes.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementPaymentTypes.Appearance.Normal.Options.UseFont = true;
            this.accordionControlElementPaymentTypes.Appearance.Normal.Options.UseTextOptions = true;
            this.accordionControlElementPaymentTypes.Appearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementPaymentTypes.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 15F);
            this.accordionControlElementPaymentTypes.Appearance.Pressed.Options.UseFont = true;
            this.accordionControlElementPaymentTypes.Appearance.Pressed.Options.UseTextOptions = true;
            this.accordionControlElementPaymentTypes.Appearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.accordionControlElementPaymentTypes.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.accordionControlElementPaymentTypes.Height = 50;
            this.accordionControlElementPaymentTypes.Name = "accordionControlElementPaymentTypes";
            this.accordionControlElementPaymentTypes.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElementPaymentTypes.Text = "Ödeme Tipleri";
            this.accordionControlElementPaymentTypes.Click += new System.EventHandler(this.accordionControlElementPaymentTypes_Click);
            // 
            // PersonalizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 923);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.accordionControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PersonalizationForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelMain;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementCategories;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementProducts;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElementPaymentTypes;
    }
}