namespace WindowsFormsAppUI.Forms
{
    partial class OpenWindowsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenWindowsForm));
            this.listBoxWindows = new System.Windows.Forms.ListBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // listBoxWindows
            // 
            this.listBoxWindows.BackColor = System.Drawing.Color.White;
            this.listBoxWindows.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxWindows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxWindows.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxWindows.FormattingEnabled = true;
            this.listBoxWindows.HorizontalScrollbar = true;
            this.listBoxWindows.ItemHeight = 17;
            this.listBoxWindows.Location = new System.Drawing.Point(0, 0);
            this.listBoxWindows.Name = "listBoxWindows";
            this.listBoxWindows.Size = new System.Drawing.Size(384, 261);
            this.listBoxWindows.TabIndex = 8;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // OpenWindowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.listBoxWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OpenWindowsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Windows";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox listBoxWindows;
        private System.Windows.Forms.Timer timer;
    }
}