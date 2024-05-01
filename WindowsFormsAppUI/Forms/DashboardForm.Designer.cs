using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Forms
{
    partial class DashboardForm
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
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            this.tileControl = new DevExpress.XtraEditors.TileControl();
            this.tileGroupMain = new DevExpress.XtraEditors.TileGroup();
            this.tileItemCreateProductLabel = new DevExpress.XtraEditors.TileItem();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.simpleButtonEditMode = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSmall = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonMedium = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonWide = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonLarge = new DevExpress.XtraEditors.SimpleButton();
            this.tileItemReports = new DevExpress.XtraEditors.TileItem();
            this.tileItemPOS = new DevExpress.XtraEditors.TileItem();
            this.tileItemStocks = new DevExpress.XtraEditors.TileItem();
            this.tileItemTables = new DevExpress.XtraEditors.TileItem();
            this.tileItemTickets = new DevExpress.XtraEditors.TileItem();
            this.tileItemCustomers = new DevExpress.XtraEditors.TileItem();
            this.tileItemTechnicalSupport = new DevExpress.XtraEditors.TileItem();
            this.tileItemPersonalization = new DevExpress.XtraEditors.TileItem();
            this.tileItemLogout = new DevExpress.XtraEditors.TileItem();
            this.tileItemManagement = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // tileControl
            // 
            this.tileControl.AllowDrag = false;
            this.tileControl.AllowItemHover = true;
            this.tileControl.BackColor = System.Drawing.Color.White;
            this.tileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl.Groups.Add(this.tileGroupMain);
            this.tileControl.Groups.Add(this.tileGroup2);
            this.tileControl.IndentBetweenItems = 5;
            this.tileControl.ItemContentAnimation = DevExpress.XtraEditors.TileItemContentAnimationType.RandomSegmentedFade;
            this.tileControl.Location = new System.Drawing.Point(0, 0);
            this.tileControl.MaxId = 15;
            this.tileControl.Name = "tileControl";
            this.tileControl.RowCount = 3;
            this.tileControl.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.TouchScrollBar;
            this.tileControl.Size = new System.Drawing.Size(800, 600);
            this.tileControl.TabIndex = 1;
            this.tileControl.Text = "tileControl1";
            // 
            // tileGroupMain
            // 
            this.tileGroupMain.Items.Add(this.tileItemReports);
            this.tileGroupMain.Items.Add(this.tileItemPOS);
            this.tileGroupMain.Items.Add(this.tileItemStocks);
            this.tileGroupMain.Items.Add(this.tileItemCreateProductLabel);
            this.tileGroupMain.Items.Add(this.tileItemTables);
            this.tileGroupMain.Items.Add(this.tileItemTickets);
            this.tileGroupMain.Items.Add(this.tileItemCustomers);
            this.tileGroupMain.Name = "tileGroupMain";
            // 
            // tileItemCreateProductLabel
            // 
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemCreateProductLabel.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemCreateProductLabel.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemCreateProductLabel.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemCreateProductLabel.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemCreateProductLabel.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement4.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.LabelDesign;
            tileItemElement4.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement4.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement4.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement4.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement4.ImageOptions.ImageToTextIndent = 25;
            tileItemElement4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage3")));
            tileItemElement4.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement4.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement4.Text = "Etiketi Oluştur";
            this.tileItemCreateProductLabel.Elements.Add(tileItemElement4);
            this.tileItemCreateProductLabel.Id = 8;
            this.tileItemCreateProductLabel.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemCreateProductLabel.Name = "tileItemCreateProductLabel";
            this.tileItemCreateProductLabel.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemCreateProductLabel_ItemClick);
            this.tileItemCreateProductLabel.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItemTechnicalSupport);
            this.tileGroup2.Items.Add(this.tileItemPersonalization);
            this.tileGroup2.Items.Add(this.tileItemLogout);
            this.tileGroup2.Items.Add(this.tileItemManagement);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileItem1
            // 
            tileItemElement12.Text = "tileItem1";
            this.tileItem1.Elements.Add(tileItemElement12);
            this.tileItem1.Id = 9;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem1.Name = "tileItem1";
            // 
            // simpleButtonEditMode
            // 
            this.simpleButtonEditMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonEditMode.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.simpleButtonEditMode.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonEditMode.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.simpleButtonEditMode.Appearance.Options.UseBackColor = true;
            this.simpleButtonEditMode.Appearance.Options.UseBorderColor = true;
            this.simpleButtonEditMode.Appearance.Options.UseFont = true;
            this.simpleButtonEditMode.Appearance.Options.UseTextOptions = true;
            this.simpleButtonEditMode.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonEditMode.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonEditMode.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButtonEditMode.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButtonEditMode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonEditMode.ImageOptions.SvgImage")));
            this.simpleButtonEditMode.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.simpleButtonEditMode.Location = new System.Drawing.Point(12, 488);
            this.simpleButtonEditMode.Name = "simpleButtonEditMode";
            this.simpleButtonEditMode.Size = new System.Drawing.Size(100, 100);
            this.simpleButtonEditMode.TabIndex = 2;
            this.simpleButtonEditMode.Text = "Düzenleme Modu";
            this.simpleButtonEditMode.Click += new System.EventHandler(this.simpleButtonEditMode_Click);
            // 
            // simpleButtonSave
            // 
            this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.simpleButtonSave.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonSave.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.simpleButtonSave.Appearance.Options.UseBackColor = true;
            this.simpleButtonSave.Appearance.Options.UseBorderColor = true;
            this.simpleButtonSave.Appearance.Options.UseFont = true;
            this.simpleButtonSave.Appearance.Options.UseTextOptions = true;
            this.simpleButtonSave.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonSave.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonSave.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButtonSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButtonSave.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonSave.ImageOptions.SvgImage")));
            this.simpleButtonSave.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.simpleButtonSave.Location = new System.Drawing.Point(118, 488);
            this.simpleButtonSave.Name = "simpleButtonSave";
            this.simpleButtonSave.Size = new System.Drawing.Size(100, 100);
            this.simpleButtonSave.TabIndex = 2;
            this.simpleButtonSave.Text = "Kaydet";
            this.simpleButtonSave.Visible = false;
            this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
            // 
            // simpleButtonSmall
            // 
            this.simpleButtonSmall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonSmall.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.simpleButtonSmall.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonSmall.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.simpleButtonSmall.Appearance.Options.UseBackColor = true;
            this.simpleButtonSmall.Appearance.Options.UseBorderColor = true;
            this.simpleButtonSmall.Appearance.Options.UseFont = true;
            this.simpleButtonSmall.Appearance.Options.UseTextOptions = true;
            this.simpleButtonSmall.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonSmall.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonSmall.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButtonSmall.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButtonSmall.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonSmall.ImageOptions.SvgImage")));
            this.simpleButtonSmall.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.simpleButtonSmall.Location = new System.Drawing.Point(12, 382);
            this.simpleButtonSmall.Name = "simpleButtonSmall";
            this.simpleButtonSmall.Size = new System.Drawing.Size(100, 100);
            this.simpleButtonSmall.TabIndex = 2;
            this.simpleButtonSmall.Tag = "1";
            this.simpleButtonSmall.Text = "Küçük";
            this.simpleButtonSmall.Visible = false;
            this.simpleButtonSmall.Click += new System.EventHandler(this.simpleButtonLarge_Click);
            // 
            // simpleButtonMedium
            // 
            this.simpleButtonMedium.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonMedium.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.simpleButtonMedium.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonMedium.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.simpleButtonMedium.Appearance.Options.UseBackColor = true;
            this.simpleButtonMedium.Appearance.Options.UseBorderColor = true;
            this.simpleButtonMedium.Appearance.Options.UseFont = true;
            this.simpleButtonMedium.Appearance.Options.UseTextOptions = true;
            this.simpleButtonMedium.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonMedium.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonMedium.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButtonMedium.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButtonMedium.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonMedium.ImageOptions.SvgImage")));
            this.simpleButtonMedium.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.simpleButtonMedium.Location = new System.Drawing.Point(12, 276);
            this.simpleButtonMedium.Name = "simpleButtonMedium";
            this.simpleButtonMedium.Size = new System.Drawing.Size(100, 100);
            this.simpleButtonMedium.TabIndex = 2;
            this.simpleButtonMedium.Tag = "2";
            this.simpleButtonMedium.Text = "Orta";
            this.simpleButtonMedium.Visible = false;
            this.simpleButtonMedium.Click += new System.EventHandler(this.simpleButtonLarge_Click);
            // 
            // simpleButtonWide
            // 
            this.simpleButtonWide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonWide.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.simpleButtonWide.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonWide.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.simpleButtonWide.Appearance.Options.UseBackColor = true;
            this.simpleButtonWide.Appearance.Options.UseBorderColor = true;
            this.simpleButtonWide.Appearance.Options.UseFont = true;
            this.simpleButtonWide.Appearance.Options.UseTextOptions = true;
            this.simpleButtonWide.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonWide.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonWide.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButtonWide.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButtonWide.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonWide.ImageOptions.SvgImage")));
            this.simpleButtonWide.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.simpleButtonWide.Location = new System.Drawing.Point(12, 170);
            this.simpleButtonWide.Name = "simpleButtonWide";
            this.simpleButtonWide.Size = new System.Drawing.Size(100, 100);
            this.simpleButtonWide.TabIndex = 2;
            this.simpleButtonWide.Tag = "3";
            this.simpleButtonWide.Text = "Geniş";
            this.simpleButtonWide.Visible = false;
            this.simpleButtonWide.Click += new System.EventHandler(this.simpleButtonLarge_Click);
            // 
            // simpleButtonLarge
            // 
            this.simpleButtonLarge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButtonLarge.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.simpleButtonLarge.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonLarge.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.simpleButtonLarge.Appearance.Options.UseBackColor = true;
            this.simpleButtonLarge.Appearance.Options.UseBorderColor = true;
            this.simpleButtonLarge.Appearance.Options.UseFont = true;
            this.simpleButtonLarge.Appearance.Options.UseTextOptions = true;
            this.simpleButtonLarge.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.simpleButtonLarge.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.simpleButtonLarge.AppearanceHovered.Options.UseBackColor = true;
            this.simpleButtonLarge.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButtonLarge.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButtonLarge.ImageOptions.SvgImage")));
            this.simpleButtonLarge.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            this.simpleButtonLarge.Location = new System.Drawing.Point(12, 64);
            this.simpleButtonLarge.Name = "simpleButtonLarge";
            this.simpleButtonLarge.Size = new System.Drawing.Size(100, 100);
            this.simpleButtonLarge.TabIndex = 2;
            this.simpleButtonLarge.Tag = "4";
            this.simpleButtonLarge.Text = "Büyük";
            this.simpleButtonLarge.Visible = false;
            this.simpleButtonLarge.Click += new System.EventHandler(this.simpleButtonLarge_Click);
            // 
            // tileItemReports
            // 
            this.tileItemReports.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemReports.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemReports.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemReports.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemReports.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemReports.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemReports.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemReports.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemReports.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemReports.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemReports.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemReports.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemReports.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemReports.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemReports.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemReports.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemReports.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemReports.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemReports.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemReports.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement1.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Report;
            tileItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement1.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement1.ImageOptions.ImageToTextIndent = 25;
            tileItemElement1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage")));
            tileItemElement1.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement1.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement1.Text = "Raporlar";
            this.tileItemReports.Elements.Add(tileItemElement1);
            this.tileItemReports.Id = 4;
            this.tileItemReports.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemReports.Name = "tileItemReports";
            this.tileItemReports.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_ItemClick);
            this.tileItemReports.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemPOS
            // 
            this.tileItemPOS.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemPOS.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemPOS.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemPOS.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemPOS.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemPOS.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemPOS.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemPOS.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemPOS.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemPOS.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemPOS.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemPOS.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemPOS.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemPOS.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemPOS.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemPOS.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemPOS.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemPOS.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemPOS.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemPOS.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement2.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.POS;
            tileItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement2.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement2.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement2.ImageOptions.ImageToTextIndent = 25;
            tileItemElement2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage1")));
            tileItemElement2.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement2.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement2.Text = "Satış Noktası";
            this.tileItemPOS.Elements.Add(tileItemElement2);
            this.tileItemPOS.Id = 3;
            this.tileItemPOS.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemPOS.Name = "tileItemPOS";
            this.tileItemPOS.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemPOS_ItemClick);
            this.tileItemPOS.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemStocks
            // 
            this.tileItemStocks.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemStocks.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemStocks.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemStocks.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemStocks.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemStocks.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemStocks.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemStocks.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemStocks.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemStocks.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemStocks.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemStocks.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemStocks.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemStocks.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemStocks.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemStocks.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemStocks.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemStocks.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemStocks.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemStocks.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement3.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Stock;
            tileItemElement3.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement3.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement3.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement3.ImageOptions.ImageToTextIndent = 25;
            tileItemElement3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage2")));
            tileItemElement3.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement3.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement3.Text = "Stoklar";
            this.tileItemStocks.Elements.Add(tileItemElement3);
            this.tileItemStocks.Id = 6;
            this.tileItemStocks.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemStocks.Name = "tileItemStocks";
            this.tileItemStocks.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemStocks_ItemClick);
            this.tileItemStocks.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemTables
            // 
            this.tileItemTables.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemTables.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemTables.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemTables.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemTables.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemTables.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemTables.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemTables.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemTables.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemTables.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemTables.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemTables.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemTables.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemTables.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemTables.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemTables.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemTables.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemTables.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemTables.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemTables.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement5.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Table;
            tileItemElement5.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement5.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement5.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement5.ImageOptions.ImageToTextIndent = 25;
            tileItemElement5.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage4")));
            tileItemElement5.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement5.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement5.Text = "Masalar";
            this.tileItemTables.Elements.Add(tileItemElement5);
            this.tileItemTables.Id = 10;
            this.tileItemTables.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemTables.Name = "tileItemTables";
            this.tileItemTables.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemTables_ItemClick);
            this.tileItemTables.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemTickets
            // 
            this.tileItemTickets.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemTickets.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemTickets.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemTickets.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemTickets.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemTickets.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemTickets.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemTickets.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemTickets.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemTickets.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemTickets.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemTickets.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemTickets.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemTickets.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemTickets.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemTickets.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemTickets.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemTickets.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemTickets.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemTickets.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement6.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Ticket;
            tileItemElement6.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement6.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement6.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement6.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement6.ImageOptions.ImageToTextIndent = 25;
            tileItemElement6.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage5")));
            tileItemElement6.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement6.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement6.Text = "Fişler";
            this.tileItemTickets.Elements.Add(tileItemElement6);
            this.tileItemTickets.Id = 1;
            this.tileItemTickets.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemTickets.Name = "tileItemTickets";
            this.tileItemTickets.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemTickets_ItemClick);
            this.tileItemTickets.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemCustomers
            // 
            this.tileItemCustomers.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemCustomers.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemCustomers.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemCustomers.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemCustomers.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemCustomers.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemCustomers.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemCustomers.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemCustomers.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemCustomers.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemCustomers.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemCustomers.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemCustomers.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemCustomers.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemCustomers.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemCustomers.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemCustomers.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemCustomers.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemCustomers.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemCustomers.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement7.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Customer;
            tileItemElement7.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement7.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement7.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement7.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement7.ImageOptions.ImageToTextIndent = 25;
            tileItemElement7.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage6")));
            tileItemElement7.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement7.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement7.Text = "Müşteriler";
            this.tileItemCustomers.Elements.Add(tileItemElement7);
            this.tileItemCustomers.Id = 14;
            this.tileItemCustomers.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemCustomers.Name = "tileItemCustomers";
            this.tileItemCustomers.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemCustomers_ItemClick);
            this.tileItemCustomers.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemTechnicalSupport
            // 
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemTechnicalSupport.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemTechnicalSupport.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemTechnicalSupport.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemTechnicalSupport.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemTechnicalSupport.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement8.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Support;
            tileItemElement8.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement8.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement8.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement8.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement8.ImageOptions.ImageToTextIndent = 25;
            tileItemElement8.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage7")));
            tileItemElement8.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement8.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement8.Text = "Teknik Destek";
            this.tileItemTechnicalSupport.Elements.Add(tileItemElement8);
            this.tileItemTechnicalSupport.Id = 7;
            this.tileItemTechnicalSupport.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemTechnicalSupport.Name = "tileItemTechnicalSupport";
            this.tileItemTechnicalSupport.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemTechnicalSupport_ItemClick);
            this.tileItemTechnicalSupport.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemPersonalization
            // 
            this.tileItemPersonalization.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemPersonalization.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemPersonalization.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemPersonalization.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemPersonalization.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemPersonalization.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemPersonalization.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemPersonalization.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemPersonalization.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemPersonalization.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemPersonalization.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemPersonalization.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemPersonalization.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemPersonalization.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemPersonalization.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemPersonalization.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemPersonalization.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemPersonalization.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemPersonalization.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemPersonalization.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement9.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Customize;
            tileItemElement9.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement9.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement9.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement9.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement9.ImageOptions.ImageToTextIndent = 25;
            tileItemElement9.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage8")));
            tileItemElement9.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement9.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement9.Text = "Kişiselleştirme";
            this.tileItemPersonalization.Elements.Add(tileItemElement9);
            this.tileItemPersonalization.Id = 2;
            this.tileItemPersonalization.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemPersonalization.Name = "tileItemPersonalization";
            this.tileItemPersonalization.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemPersonalization_ItemClick);
            this.tileItemPersonalization.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemLogout
            // 
            this.tileItemLogout.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemLogout.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemLogout.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemLogout.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemLogout.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemLogout.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemLogout.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemLogout.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemLogout.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemLogout.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemLogout.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemLogout.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemLogout.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemLogout.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemLogout.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemLogout.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemLogout.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemLogout.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemLogout.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemLogout.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement10.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Exit;
            tileItemElement10.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement10.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement10.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement10.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement10.ImageOptions.ImageToTextIndent = 25;
            tileItemElement10.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage9")));
            tileItemElement10.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement10.Text = "Çıkış";
            this.tileItemLogout.Elements.Add(tileItemElement10);
            this.tileItemLogout.Id = 5;
            this.tileItemLogout.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemLogout.Name = "tileItemLogout";
            this.tileItemLogout.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemLogout_ItemClick);
            this.tileItemLogout.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // tileItemManagement
            // 
            this.tileItemManagement.AppearanceItem.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
            this.tileItemManagement.AppearanceItem.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.tileItemManagement.AppearanceItem.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemManagement.AppearanceItem.Hovered.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.tileItemManagement.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItemManagement.AppearanceItem.Hovered.Options.UseFont = true;
            this.tileItemManagement.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.tileItemManagement.AppearanceItem.Hovered.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemManagement.AppearanceItem.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tileItemManagement.AppearanceItem.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.tileItemManagement.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.tileItemManagement.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Black;
            this.tileItemManagement.AppearanceItem.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tileItemManagement.AppearanceItem.Normal.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.tileItemManagement.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItemManagement.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItemManagement.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItemManagement.AppearanceItem.Normal.Options.UseTextOptions = true;
            this.tileItemManagement.AppearanceItem.Normal.TextOptions.Trimming = DevExpress.Utils.Trimming.None;
            this.tileItemManagement.AppearanceItem.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            tileItemElement11.ImageOptions.Image = global::WindowsFormsAppUI.Properties.Resources.Settings;
            tileItemElement11.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement11.ImageOptions.ImageBorder = DevExpress.XtraEditors.TileItemElementImageBorderMode.None;
            tileItemElement11.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.Stretch;
            tileItemElement11.ImageOptions.ImageSize = new System.Drawing.Size(65, 65);
            tileItemElement11.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement11.ImageOptions.ImageToTextIndent = 25;
            tileItemElement11.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage10")));
            tileItemElement11.ImageOptions.SvgImageColorizationMode = DevExpress.Utils.SvgImageColorizationMode.None;
            tileItemElement11.ImageOptions.SvgImageSize = new System.Drawing.Size(64, 64);
            tileItemElement11.Text = "Yönetim";
            this.tileItemManagement.Elements.Add(tileItemElement11);
            this.tileItemManagement.Id = 0;
            this.tileItemManagement.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItemManagement.Name = "tileItemManagement";
            this.tileItemManagement.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemManagement_ItemClick);
            this.tileItemManagement.RightItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItemReports_RightItemClick);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.simpleButtonSave);
            this.Controls.Add(this.simpleButtonLarge);
            this.Controls.Add(this.simpleButtonWide);
            this.Controls.Add(this.simpleButtonMedium);
            this.Controls.Add(this.simpleButtonSmall);
            this.Controls.Add(this.simpleButtonEditMode);
            this.Controls.Add(this.tileControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TileControl tileControl;
        private DevExpress.XtraEditors.TileGroup tileGroupMain;
        private DevExpress.XtraEditors.TileItem tileItemManagement;
        private DevExpress.XtraEditors.TileItem tileItemTickets;
        private DevExpress.XtraEditors.TileItem tileItemPersonalization;
        private DevExpress.XtraEditors.TileItem tileItemPOS;
        private DevExpress.XtraEditors.TileItem tileItemReports;
        private DevExpress.XtraEditors.TileItem tileItemLogout;
        private DevExpress.XtraEditors.TileItem tileItemStocks;
        private DevExpress.XtraEditors.TileItem tileItemTechnicalSupport;
        private DevExpress.XtraEditors.TileItem tileItemCreateProductLabel;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEditMode;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSmall;
        private DevExpress.XtraEditors.SimpleButton simpleButtonMedium;
        private DevExpress.XtraEditors.SimpleButton simpleButtonWide;
        private DevExpress.XtraEditors.SimpleButton simpleButtonLarge;
        private DevExpress.XtraEditors.TileItem tileItemTables;
        private DevExpress.XtraEditors.TileItem tileItemCustomers;
    }
}