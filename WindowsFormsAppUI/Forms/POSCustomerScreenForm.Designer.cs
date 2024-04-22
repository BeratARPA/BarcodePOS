namespace WindowsFormsAppUI.Forms
{
    partial class POSCustomerScreenForm
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLabels = new System.Windows.Forms.TableLayoutPanel();
            this.labelDiscountPercent = new System.Windows.Forms.Label();
            this.labelDiscount = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTicketTotal = new System.Windows.Forms.Label();
            this.flowLayoutPanelOrders = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.tableLayoutPanelMiddle.SuspendLayout();
            this.tableLayoutPanelLabels.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(380, 600);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // tableLayoutPanelMiddle
            // 
            this.tableLayoutPanelMiddle.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanelMiddle.ColumnCount = 1;
            this.tableLayoutPanelMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMiddle.Controls.Add(this.tableLayoutPanelLabels, 0, 1);
            this.tableLayoutPanelMiddle.Controls.Add(this.flowLayoutPanelOrders, 0, 0);
            this.tableLayoutPanelMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMiddle.Location = new System.Drawing.Point(380, 0);
            this.tableLayoutPanelMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMiddle.Name = "tableLayoutPanelMiddle";
            this.tableLayoutPanelMiddle.RowCount = 2;
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanelMiddle.Size = new System.Drawing.Size(420, 600);
            this.tableLayoutPanelMiddle.TabIndex = 2;
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
            this.tableLayoutPanelLabels.Location = new System.Drawing.Point(1, 514);
            this.tableLayoutPanelLabels.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelLabels.Name = "tableLayoutPanelLabels";
            this.tableLayoutPanelLabels.RowCount = 3;
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelLabels.Size = new System.Drawing.Size(418, 85);
            this.tableLayoutPanelLabels.TabIndex = 4;
            // 
            // labelDiscountPercent
            // 
            this.labelDiscountPercent.AutoSize = true;
            this.labelDiscountPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDiscountPercent.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelDiscountPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelDiscountPercent.Location = new System.Drawing.Point(10, 28);
            this.labelDiscountPercent.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelDiscountPercent.Name = "labelDiscountPercent";
            this.labelDiscountPercent.Size = new System.Drawing.Size(199, 28);
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
            this.labelDiscount.Location = new System.Drawing.Point(209, 28);
            this.labelDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.labelDiscount.Name = "labelDiscount";
            this.labelDiscount.Size = new System.Drawing.Size(209, 28);
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
            this.labelBalance.Location = new System.Drawing.Point(209, 56);
            this.labelBalance.Margin = new System.Windows.Forms.Padding(0);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(209, 29);
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
            this.label1.Location = new System.Drawing.Point(0, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bakiye";
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
            this.label4.Size = new System.Drawing.Size(209, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fiş Toplamı";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTicketTotal
            // 
            this.labelTicketTotal.AutoSize = true;
            this.labelTicketTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTicketTotal.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.labelTicketTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.labelTicketTotal.Location = new System.Drawing.Point(209, 0);
            this.labelTicketTotal.Margin = new System.Windows.Forms.Padding(0);
            this.labelTicketTotal.Name = "labelTicketTotal";
            this.labelTicketTotal.Size = new System.Drawing.Size(209, 28);
            this.labelTicketTotal.TabIndex = 0;
            this.labelTicketTotal.Text = "0,00";
            this.labelTicketTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // flowLayoutPanelOrders
            // 
            this.flowLayoutPanelOrders.AutoScroll = true;
            this.flowLayoutPanelOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelOrders.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanelOrders.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelOrders.Name = "flowLayoutPanelOrders";
            this.flowLayoutPanelOrders.Size = new System.Drawing.Size(418, 512);
            this.flowLayoutPanelOrders.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 420F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelMiddle, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 600);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // POSCustomerScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "POSCustomerScreenForm";
            this.ShowInTaskbar = false;
            this.Text = "BarcodePOS";
            this.Load += new System.EventHandler(this.POSCustomerScreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.tableLayoutPanelMiddle.ResumeLayout(false);
            this.tableLayoutPanelLabels.ResumeLayout(false);
            this.tableLayoutPanelLabels.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOrders;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMiddle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLabels;
        private System.Windows.Forms.Label labelDiscountPercent;
        private System.Windows.Forms.Label labelDiscount;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTicketTotal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}