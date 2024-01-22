using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Forms
{
    partial class ProductLabelDesignForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.textBoxBarcodeDescription = new System.Windows.Forms.TextBox();
            this.buttonCreateBarcode = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddTLSymbol = new System.Windows.Forms.Button();
            this.buttonAddLabel = new System.Windows.Forms.Button();
            this.buttonAddImage = new System.Windows.Forms.Button();
            this.buttonAddRectangle = new System.Windows.Forms.Button();
            this.buttonAddLocalProductionSymbol = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelMain, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 266F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 923);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 386F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1200, 266);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textBoxBarcode, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxBarcodeDescription, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.buttonCreateBarcode, 0, 4);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(407, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(386, 266);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Barkod";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(4, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 53);
            this.label2.TabIndex = 0;
            this.label2.Text = "Barkod Açıklama";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxBarcode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.textBoxBarcode.Location = new System.Drawing.Point(4, 58);
            this.textBoxBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(378, 34);
            this.textBoxBarcode.TabIndex = 1;
            // 
            // textBoxBarcodeDescription
            // 
            this.textBoxBarcodeDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxBarcodeDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBarcodeDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBoxBarcodeDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.textBoxBarcodeDescription.Location = new System.Drawing.Point(4, 164);
            this.textBoxBarcodeDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxBarcodeDescription.Name = "textBoxBarcodeDescription";
            this.textBoxBarcodeDescription.Size = new System.Drawing.Size(378, 34);
            this.textBoxBarcodeDescription.TabIndex = 1;
            // 
            // buttonCreateBarcode
            // 
            this.buttonCreateBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonCreateBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreateBarcode.FlatAppearance.BorderSize = 0;
            this.buttonCreateBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonCreateBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonCreateBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonCreateBarcode.ForeColor = System.Drawing.Color.White;
            this.buttonCreateBarcode.Location = new System.Drawing.Point(4, 217);
            this.buttonCreateBarcode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCreateBarcode.Name = "buttonCreateBarcode";
            this.buttonCreateBarcode.Size = new System.Drawing.Size(378, 44);
            this.buttonCreateBarcode.TabIndex = 2;
            this.buttonCreateBarcode.Text = "Barkod Oluştur";
            this.buttonCreateBarcode.UseVisualStyleBackColor = false;
            this.buttonCreateBarcode.Click += new System.EventHandler(this.buttonCreateBarcode_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 789);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1200, 134);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 8;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel5.Controls.Add(this.buttonAddTLSymbol, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonAddLabel, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonAddImage, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonAddRectangle, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonAddLocalProductionSymbol, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonPrint, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonSave, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonLoad, 7, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(60, 20);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1080, 94);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // buttonAddTLSymbol
            // 
            this.buttonAddTLSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonAddTLSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTLSymbol.FlatAppearance.BorderSize = 0;
            this.buttonAddTLSymbol.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddTLSymbol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddTLSymbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddTLSymbol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonAddTLSymbol.ForeColor = System.Drawing.Color.White;
            this.buttonAddTLSymbol.Location = new System.Drawing.Point(4, 5);
            this.buttonAddTLSymbol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddTLSymbol.Name = "buttonAddTLSymbol";
            this.buttonAddTLSymbol.Size = new System.Drawing.Size(127, 84);
            this.buttonAddTLSymbol.TabIndex = 2;
            this.buttonAddTLSymbol.Text = "TL Simgesi";
            this.buttonAddTLSymbol.UseVisualStyleBackColor = false;
            this.buttonAddTLSymbol.Click += new System.EventHandler(this.buttonAddTLSymbol_Click);
            // 
            // buttonAddLabel
            // 
            this.buttonAddLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonAddLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddLabel.FlatAppearance.BorderSize = 0;
            this.buttonAddLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonAddLabel.ForeColor = System.Drawing.Color.White;
            this.buttonAddLabel.Location = new System.Drawing.Point(139, 5);
            this.buttonAddLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddLabel.Name = "buttonAddLabel";
            this.buttonAddLabel.Size = new System.Drawing.Size(127, 84);
            this.buttonAddLabel.TabIndex = 2;
            this.buttonAddLabel.Text = "Etiket";
            this.buttonAddLabel.UseVisualStyleBackColor = false;
            this.buttonAddLabel.Click += new System.EventHandler(this.buttonAddLabel_Click);
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonAddImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddImage.FlatAppearance.BorderSize = 0;
            this.buttonAddImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddImage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonAddImage.ForeColor = System.Drawing.Color.White;
            this.buttonAddImage.Location = new System.Drawing.Point(274, 5);
            this.buttonAddImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(127, 84);
            this.buttonAddImage.TabIndex = 2;
            this.buttonAddImage.Text = "Resim";
            this.buttonAddImage.UseVisualStyleBackColor = false;
            this.buttonAddImage.Click += new System.EventHandler(this.buttonAddImage_Click);
            // 
            // buttonAddRectangle
            // 
            this.buttonAddRectangle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonAddRectangle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddRectangle.FlatAppearance.BorderSize = 0;
            this.buttonAddRectangle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddRectangle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddRectangle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonAddRectangle.ForeColor = System.Drawing.Color.White;
            this.buttonAddRectangle.Location = new System.Drawing.Point(409, 5);
            this.buttonAddRectangle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddRectangle.Name = "buttonAddRectangle";
            this.buttonAddRectangle.Size = new System.Drawing.Size(127, 84);
            this.buttonAddRectangle.TabIndex = 2;
            this.buttonAddRectangle.Text = "Dikdörtgen";
            this.buttonAddRectangle.UseVisualStyleBackColor = false;
            this.buttonAddRectangle.Click += new System.EventHandler(this.buttonAddRectangle_Click);
            // 
            // buttonAddLocalProductionSymbol
            // 
            this.buttonAddLocalProductionSymbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonAddLocalProductionSymbol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddLocalProductionSymbol.FlatAppearance.BorderSize = 0;
            this.buttonAddLocalProductionSymbol.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddLocalProductionSymbol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonAddLocalProductionSymbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddLocalProductionSymbol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonAddLocalProductionSymbol.ForeColor = System.Drawing.Color.White;
            this.buttonAddLocalProductionSymbol.Location = new System.Drawing.Point(544, 5);
            this.buttonAddLocalProductionSymbol.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAddLocalProductionSymbol.Name = "buttonAddLocalProductionSymbol";
            this.buttonAddLocalProductionSymbol.Size = new System.Drawing.Size(127, 84);
            this.buttonAddLocalProductionSymbol.TabIndex = 2;
            this.buttonAddLocalProductionSymbol.Text = "Yerli Üretim Simgesi";
            this.buttonAddLocalProductionSymbol.UseVisualStyleBackColor = false;
            this.buttonAddLocalProductionSymbol.Click += new System.EventHandler(this.buttonAddLocalProductionSymbol_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(679, 5);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(127, 84);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Yazdır";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(814, 5);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(127, 84);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Kaydet";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonLoad.ForeColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(949, 5);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(127, 84);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Yükle";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 486F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanelMain.Controls.Add(this.panelMain, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 266);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1200, 523);
            this.tableLayoutPanelMain.TabIndex = 3;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(356, 165);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(486, 192);
            this.panelMain.TabIndex = 1;
            // 
            // ProductLabelDesignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 923);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductLabelDesignForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.ProductLabelDesignForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Label label2;
        private TextBox textBoxBarcode;
        private TextBox textBoxBarcodeDescription;
        private Button buttonCreateBarcode;
        private Panel panelMain;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private Button buttonAddTLSymbol;
        private Button buttonAddLabel;
        private Button buttonAddImage;
        private Button buttonAddRectangle;
        private Button buttonAddLocalProductionSymbol;
        private Button buttonPrint;
        private Button buttonSave;
        private Button buttonLoad;
        private TableLayoutPanel tableLayoutPanelMain;
    }
}