using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsAppUI.Forms
{
    partial class POSForm
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
            this.tableLayoutPanelCategories = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDynamicCategories = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonProductsWitoutBarcode = new System.Windows.Forms.Button();
            this.buttonProductsWithBarcode = new System.Windows.Forms.Button();
            this.buttonQuickMenu = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTicketDelete = new System.Windows.Forms.Button();
            this.buttonDiscount = new System.Windows.Forms.Button();
            this.buttonTickets = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonOpenTheDrawer = new System.Windows.Forms.Button();
            this.buttonChangeTable = new System.Windows.Forms.Button();
            this.flowLayoutPanelOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.labelTable = new System.Windows.Forms.Label();
            this.tableLayoutPanelProducts = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonMultiplePayment = new System.Windows.Forms.Button();
            this.tableLayoutPanelPaymentTypes = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonNewTicket = new System.Windows.Forms.Button();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labelDiscountPercent = new System.Windows.Forms.Label();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTicketTotal = new System.Windows.Forms.Label();
            this.numeratorUserControl = new WindowsFormsAppUI.UserControls.NumeratorUserControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelCategories.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanelMiddle.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 480F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelCategories, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelMiddle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 923);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelCategories
            // 
            this.tableLayoutPanelCategories.ColumnCount = 1;
            this.tableLayoutPanelCategories.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCategories.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanelCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCategories.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelCategories.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelCategories.Name = "tableLayoutPanelCategories";
            this.tableLayoutPanelCategories.RowCount = 1;
            this.tableLayoutPanelCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCategories.Size = new System.Drawing.Size(142, 923);
            this.tableLayoutPanelCategories.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanelDynamicCategories, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(142, 923);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // tableLayoutPanelDynamicCategories
            // 
            this.tableLayoutPanelDynamicCategories.AutoScroll = true;
            this.tableLayoutPanelDynamicCategories.ColumnCount = 1;
            this.tableLayoutPanelDynamicCategories.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDynamicCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDynamicCategories.Location = new System.Drawing.Point(0, 461);
            this.tableLayoutPanelDynamicCategories.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDynamicCategories.Name = "tableLayoutPanelDynamicCategories";
            this.tableLayoutPanelDynamicCategories.RowCount = 1;
            this.tableLayoutPanelDynamicCategories.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDynamicCategories.Size = new System.Drawing.Size(142, 462);
            this.tableLayoutPanelDynamicCategories.TabIndex = 3;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.buttonProductsWitoutBarcode, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.buttonProductsWithBarcode, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.buttonQuickMenu, 0, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(142, 461);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // buttonProductsWitoutBarcode
            // 
            this.buttonProductsWitoutBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonProductsWitoutBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonProductsWitoutBarcode.FlatAppearance.BorderSize = 0;
            this.buttonProductsWitoutBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonProductsWitoutBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonProductsWitoutBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductsWitoutBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonProductsWitoutBarcode.ForeColor = System.Drawing.Color.White;
            this.buttonProductsWitoutBarcode.Location = new System.Drawing.Point(6, 6);
            this.buttonProductsWitoutBarcode.Margin = new System.Windows.Forms.Padding(6);
            this.buttonProductsWitoutBarcode.Name = "buttonProductsWitoutBarcode";
            this.buttonProductsWitoutBarcode.Size = new System.Drawing.Size(130, 141);
            this.buttonProductsWitoutBarcode.TabIndex = 9;
            this.buttonProductsWitoutBarcode.Text = "Barkodsuz Ürünler";
            this.buttonProductsWitoutBarcode.UseVisualStyleBackColor = false;
            this.buttonProductsWitoutBarcode.Click += new System.EventHandler(this.buttonProductsWitoutBarcode_Click);
            // 
            // buttonProductsWithBarcode
            // 
            this.buttonProductsWithBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonProductsWithBarcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonProductsWithBarcode.FlatAppearance.BorderSize = 0;
            this.buttonProductsWithBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonProductsWithBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonProductsWithBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProductsWithBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonProductsWithBarcode.ForeColor = System.Drawing.Color.White;
            this.buttonProductsWithBarcode.Location = new System.Drawing.Point(6, 159);
            this.buttonProductsWithBarcode.Margin = new System.Windows.Forms.Padding(6);
            this.buttonProductsWithBarcode.Name = "buttonProductsWithBarcode";
            this.buttonProductsWithBarcode.Size = new System.Drawing.Size(130, 141);
            this.buttonProductsWithBarcode.TabIndex = 9;
            this.buttonProductsWithBarcode.Text = "Barkodlu Ürünler";
            this.buttonProductsWithBarcode.UseVisualStyleBackColor = false;
            this.buttonProductsWithBarcode.Click += new System.EventHandler(this.buttonProductsWithBarcode_Click);
            // 
            // buttonQuickMenu
            // 
            this.buttonQuickMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonQuickMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonQuickMenu.FlatAppearance.BorderSize = 0;
            this.buttonQuickMenu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonQuickMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonQuickMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuickMenu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonQuickMenu.ForeColor = System.Drawing.Color.White;
            this.buttonQuickMenu.Location = new System.Drawing.Point(6, 312);
            this.buttonQuickMenu.Margin = new System.Windows.Forms.Padding(6);
            this.buttonQuickMenu.Name = "buttonQuickMenu";
            this.buttonQuickMenu.Size = new System.Drawing.Size(130, 143);
            this.buttonQuickMenu.TabIndex = 9;
            this.buttonQuickMenu.Text = "Hızlı Menü";
            this.buttonQuickMenu.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanelOrders, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numeratorUserControl, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(720, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 385F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(480, 923);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.buttonTicketDelete, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.buttonDiscount, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.buttonTickets, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonPrint, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.buttonOpenTheDrawer, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.buttonChangeTable, 1, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 692);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(480, 231);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // buttonTicketDelete
            // 
            this.buttonTicketDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonTicketDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTicketDelete.FlatAppearance.BorderSize = 0;
            this.buttonTicketDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonTicketDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonTicketDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTicketDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonTicketDelete.ForeColor = System.Drawing.Color.White;
            this.buttonTicketDelete.Location = new System.Drawing.Point(246, 83);
            this.buttonTicketDelete.Margin = new System.Windows.Forms.Padding(6);
            this.buttonTicketDelete.Name = "buttonTicketDelete";
            this.buttonTicketDelete.Size = new System.Drawing.Size(228, 65);
            this.buttonTicketDelete.TabIndex = 11;
            this.buttonTicketDelete.Text = "Fiş İptal";
            this.buttonTicketDelete.UseVisualStyleBackColor = false;
            this.buttonTicketDelete.Click += new System.EventHandler(this.buttonTicketDelete_Click);
            // 
            // buttonDiscount
            // 
            this.buttonDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDiscount.FlatAppearance.BorderSize = 0;
            this.buttonDiscount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonDiscount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiscount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonDiscount.ForeColor = System.Drawing.Color.White;
            this.buttonDiscount.Location = new System.Drawing.Point(6, 83);
            this.buttonDiscount.Margin = new System.Windows.Forms.Padding(6);
            this.buttonDiscount.Name = "buttonDiscount";
            this.buttonDiscount.Size = new System.Drawing.Size(228, 65);
            this.buttonDiscount.TabIndex = 10;
            this.buttonDiscount.Text = "% İskonto";
            this.buttonDiscount.UseVisualStyleBackColor = false;
            this.buttonDiscount.Click += new System.EventHandler(this.buttonDiscount_Click);
            // 
            // buttonTickets
            // 
            this.buttonTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTickets.FlatAppearance.BorderSize = 0;
            this.buttonTickets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonTickets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonTickets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTickets.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonTickets.ForeColor = System.Drawing.Color.White;
            this.buttonTickets.Location = new System.Drawing.Point(6, 6);
            this.buttonTickets.Margin = new System.Windows.Forms.Padding(6);
            this.buttonTickets.Name = "buttonTickets";
            this.buttonTickets.Size = new System.Drawing.Size(228, 65);
            this.buttonTickets.TabIndex = 9;
            this.buttonTickets.Text = "Fişler";
            this.buttonTickets.UseVisualStyleBackColor = false;
            this.buttonTickets.Click += new System.EventHandler(this.buttonTickets_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonPrint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonPrint.ForeColor = System.Drawing.Color.White;
            this.buttonPrint.Location = new System.Drawing.Point(246, 6);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(6);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(228, 65);
            this.buttonPrint.TabIndex = 9;
            this.buttonPrint.Text = "Yazdır";
            this.buttonPrint.UseVisualStyleBackColor = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonOpenTheDrawer
            // 
            this.buttonOpenTheDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonOpenTheDrawer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenTheDrawer.FlatAppearance.BorderSize = 0;
            this.buttonOpenTheDrawer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonOpenTheDrawer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonOpenTheDrawer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpenTheDrawer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonOpenTheDrawer.ForeColor = System.Drawing.Color.White;
            this.buttonOpenTheDrawer.Location = new System.Drawing.Point(6, 160);
            this.buttonOpenTheDrawer.Margin = new System.Windows.Forms.Padding(6);
            this.buttonOpenTheDrawer.Name = "buttonOpenTheDrawer";
            this.buttonOpenTheDrawer.Size = new System.Drawing.Size(228, 65);
            this.buttonOpenTheDrawer.TabIndex = 9;
            this.buttonOpenTheDrawer.Text = "Çekmeceyi Aç";
            this.buttonOpenTheDrawer.UseVisualStyleBackColor = false;
            // 
            // buttonChangeTable
            // 
            this.buttonChangeTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonChangeTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChangeTable.FlatAppearance.BorderSize = 0;
            this.buttonChangeTable.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonChangeTable.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonChangeTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeTable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonChangeTable.ForeColor = System.Drawing.Color.White;
            this.buttonChangeTable.Location = new System.Drawing.Point(246, 160);
            this.buttonChangeTable.Margin = new System.Windows.Forms.Padding(6);
            this.buttonChangeTable.Name = "buttonChangeTable";
            this.buttonChangeTable.Size = new System.Drawing.Size(228, 65);
            this.buttonChangeTable.TabIndex = 9;
            this.buttonChangeTable.Text = "Masa Değiştir";
            this.buttonChangeTable.UseVisualStyleBackColor = false;
            this.buttonChangeTable.Click += new System.EventHandler(this.buttonChangeTable_Click);
            // 
            // flowLayoutPanelOrders
            // 
            this.flowLayoutPanelOrders.AutoScroll = true;
            this.flowLayoutPanelOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelOrders.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelOrders.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            this.flowLayoutPanelOrders.Size = new System.Drawing.Size(480, 307);
            this.flowLayoutPanelOrders.TabIndex = 0;
            // 
            // tableLayoutPanelMiddle
            // 
            this.tableLayoutPanelMiddle.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelMiddle.ColumnCount = 1;
            this.tableLayoutPanelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMiddle.Controls.Add(this.tableLayoutPanelProducts, 0, 1);
            this.tableLayoutPanelMiddle.Controls.Add(this.labelTable, 0, 0);
            this.tableLayoutPanelMiddle.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanelMiddle.Controls.Add(this.tableLayoutPanelLabels, 0, 2);
            this.tableLayoutPanelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMiddle.Location = new System.Drawing.Point(142, 0);
            this.tableLayoutPanelMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMiddle.Name = "tableLayoutPanelMiddle";
            this.tableLayoutPanelMiddle.RowCount = 4;
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 154F));
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMiddle.Size = new System.Drawing.Size(578, 923);
            this.tableLayoutPanelMiddle.TabIndex = 3;
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTable.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelTable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelTable.Location = new System.Drawing.Point(1, 1);
            this.labelTable.Margin = new System.Windows.Forms.Padding(0);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(576, 50);
            this.labelTable.TabIndex = 0;
            this.labelTable.Text = "Masa: ";
            this.labelTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelProducts
            // 
            this.tableLayoutPanelProducts.AutoScroll = true;
            this.tableLayoutPanelProducts.ColumnCount = 1;
            this.tableLayoutPanelProducts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelProducts.Location = new System.Drawing.Point(1, 52);
            this.tableLayoutPanelProducts.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelProducts.Name = "tableLayoutPanelProducts";
            this.tableLayoutPanelProducts.RowCount = 1;
            this.tableLayoutPanelProducts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProducts.Size = new System.Drawing.Size(576, 560);
            this.tableLayoutPanelProducts.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.buttonMultiplePayment, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanelPaymentTypes, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClose, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonNewTicket, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 768);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(576, 154);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // buttonMultiplePayment
            // 
            this.buttonMultiplePayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonMultiplePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplePayment.FlatAppearance.BorderSize = 0;
            this.buttonMultiplePayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonMultiplePayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonMultiplePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMultiplePayment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonMultiplePayment.ForeColor = System.Drawing.Color.White;
            this.buttonMultiplePayment.Location = new System.Drawing.Point(236, 6);
            this.buttonMultiplePayment.Margin = new System.Windows.Forms.Padding(6);
            this.buttonMultiplePayment.Name = "buttonMultiplePayment";
            this.buttonMultiplePayment.Size = new System.Drawing.Size(103, 142);
            this.buttonMultiplePayment.TabIndex = 9;
            this.buttonMultiplePayment.Text = "Çoklu Ödeme";
            this.buttonMultiplePayment.UseVisualStyleBackColor = false;
            this.buttonMultiplePayment.Click += new System.EventHandler(this.buttonPayment_Click);
            // 
            // tableLayoutPanelPaymentTypes
            // 
            this.tableLayoutPanelPaymentTypes.AutoScroll = true;
            this.tableLayoutPanelPaymentTypes.ColumnCount = 1;
            this.tableLayoutPanelPaymentTypes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPaymentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPaymentTypes.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelPaymentTypes.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPaymentTypes.Name = "tableLayoutPanelPaymentTypes";
            this.tableLayoutPanelPaymentTypes.RowCount = 1;
            this.tableLayoutPanelPaymentTypes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPaymentTypes.Size = new System.Drawing.Size(230, 154);
            this.tableLayoutPanelPaymentTypes.TabIndex = 2;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            this.buttonClose.Location = new System.Drawing.Point(466, 6);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 142);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Kapat";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonNewTicket
            // 
            this.buttonNewTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(156)))), ((int)(((byte)(161)))));
            this.buttonNewTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNewTicket.FlatAppearance.BorderSize = 0;
            this.buttonNewTicket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonNewTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(202)))), ((int)(((byte)(10)))));
            this.buttonNewTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNewTicket.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.buttonNewTicket.ForeColor = System.Drawing.Color.White;
            this.buttonNewTicket.Location = new System.Drawing.Point(351, 6);
            this.buttonNewTicket.Margin = new System.Windows.Forms.Padding(6);
            this.buttonNewTicket.Name = "buttonNewTicket";
            this.buttonNewTicket.Size = new System.Drawing.Size(103, 142);
            this.buttonNewTicket.TabIndex = 9;
            this.buttonNewTicket.Text = "Yeni Fiş";
            this.buttonNewTicket.UseVisualStyleBackColor = false;
            this.buttonNewTicket.Click += new System.EventHandler(this.buttonNewTicket_Click);
            // 
            // tableLayoutPanelLabels
            // 
            this.tableLayoutPanelLabels.ColumnCount = 2;
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLabels.Controls.Add(this.labelDiscountPercent, 0, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.labelDiscount, 1, 1);
            this.tableLayoutPanelLabels.Controls.Add(this.labelBalance, 1, 2);
            this.tableLayoutPanelLabels.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanelLabels.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanelLabels.Controls.Add(this.labelTicketTotal, 1, 0);
            this.tableLayoutPanelLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(1, 613);
            this.tableLayoutPanelLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 3;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(576, 154);
            this.tableLayoutPanelLabels.TabIndex = 3;
            // 
            // labelDiscountPercent
            // 
            this.labelDiscountPercent.AutoSize = true;
            this.labelDiscountPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDiscountPercent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDiscountPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelDiscountPercent.Location = new System.Drawing.Point(15, 51);
            this.labelDiscountPercent.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.labelDiscountPercent.Name = "labelDiscountPercent";
            this.labelDiscountPercent.Size = new System.Drawing.Size(273, 51);
            this.labelDiscountPercent.TabIndex = 0;
            this.labelDiscountPercent.Text = "İskonto 0,00%";
            this.labelDiscountPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDiscount
            // 
            this.labelDiscount.AutoSize = true;
            this.labelDiscount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDiscount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelDiscount.Location = new System.Drawing.Point(288, 51);
            this.labelDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(288, 51);
            this.labelDiscount.TabIndex = 0;
            this.labelDiscount.Text = "(0,00)";
            this.labelDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBalance.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelBalance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelBalance.Location = new System.Drawing.Point(288, 102);
            this.labelBalance.Margin = new System.Windows.Forms.Padding(0);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(288, 52);
            this.labelBalance.TabIndex = 0;
            this.labelBalance.Text = "0,00";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bakiye:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 51);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fiş Toplamı:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTicketTotal
            // 
            this.labelTicketTotal.AutoSize = true;
            this.labelTicketTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTicketTotal.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelTicketTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelTicketTotal.Location = new System.Drawing.Point(288, 0);
            this.labelTicketTotal.Margin = new System.Windows.Forms.Padding(0);
            this.labelTicketTotal.Name = "labelTicketTotal";
            this.labelTicketTotal.Size = new System.Drawing.Size(288, 51);
            this.labelTicketTotal.TabIndex = 0;
            this.labelTicketTotal.Text = "0,00";
            this.labelTicketTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numeratorUserControl
            // 
            this.numeratorUserControl.BackColor = System.Drawing.Color.Transparent;
            this.numeratorUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numeratorUserControl.Location = new System.Drawing.Point(0, 307);
            this.numeratorUserControl.Margin = new System.Windows.Forms.Padding(0);
            this.numeratorUserControl.Name = "numeratorUserControl";
            this.numeratorUserControl.NumeratorDisplay = "";
            this.numeratorUserControl.Size = new System.Drawing.Size(480, 385);
            this.numeratorUserControl.TabIndex = 2;
            this.numeratorUserControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumeratorTextBoxPin_KeyPress);
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 923);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "POSForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.POSForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelCategories.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanelMiddle.ResumeLayout(false);
            this.tableLayoutPanelMiddle.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanelOrders;
        private TableLayoutPanel tableLayoutPanel2;
        private Button buttonMultiplePayment;
        private TableLayoutPanel tableLayoutPanelProducts;
        private TableLayoutPanel tableLayoutPanelCategories;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonClose;
        private UserControls.NumeratorUserControl numeratorUserControl;
        private TableLayoutPanel tableLayoutPanelMiddle;
        private TableLayoutPanel tableLayoutPanelLabels;
        private Label label1;
        private Label labelBalance;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private Button buttonProductsWitoutBarcode;
        private Button buttonProductsWithBarcode;
        private Button buttonTickets;
        private Button buttonDiscount;
        private TableLayoutPanel tableLayoutPanel4;
        private Button buttonTicketDelete;
        private Button buttonPrint;
        private Button buttonQuickMenu;
        private TableLayoutPanel tableLayoutPanelPaymentTypes;
        private Button buttonOpenTheDrawer;
        private TableLayoutPanel tableLayoutPanelDynamicCategories;
        private Button buttonNewTicket;
        private Label labelDiscountPercent;
        private Label labelDiscount;
        private Label label4;
        private Label labelTicketTotal;
        private Label labelTable;
        private Button buttonChangeTable;
    }
}