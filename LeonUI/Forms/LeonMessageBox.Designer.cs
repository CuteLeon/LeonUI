namespace LeonUI.Forms
{
    partial class LeonMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeonMessageBox));
            this.CloseBitmap = new LeonUI.Controls.ImageBitmap();
            this.TopPanel = new LeonUI.Panels.Panel();
            this.BottomPanel = new LeonUI.Panels.Panel();
            this.MiddlePanel = new LeonUI.Panels.Panel();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBitmap
            // 
            this.CloseBitmap.AutoEllipsis = true;
            this.CloseBitmap.BackColor = System.Drawing.Color.Transparent;
            this.CloseBitmap.BitmapResourceName = "Close";
            this.CloseBitmap.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseBitmap.ForeColor = System.Drawing.Color.White;
            this.CloseBitmap.Image = ((System.Drawing.Image)(resources.GetObject("CloseBitmap.Image")));
            this.CloseBitmap.Location = new System.Drawing.Point(355, 0);
            this.CloseBitmap.Name = "CloseBitmap";
            this.CloseBitmap.Size = new System.Drawing.Size(30, 30);
            this.CloseBitmap.TabIndex = 2;
            this.CloseBitmap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.TopPanel.Controls.Add(this.CloseBitmap);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(385, 30);
            this.TopPanel.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 143);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(385, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePanel.Location = new System.Drawing.Point(0, 30);
            this.MiddlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Size = new System.Drawing.Size(385, 113);
            this.MiddlePanel.TabIndex = 2;
            // 
            // LeonMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(385, 193);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LeonMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LeonMessageBox";
            this.Load += new System.EventHandler(this.LeonMessageBox_Load);
            this.Shown += new System.EventHandler(this.LeonMessageBox_Shown);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ImageBitmap CloseBitmap;
        private Panels.Panel TopPanel;
        private Panels.Panel BottomPanel;
        private Panels.Panel MiddlePanel;
    }
}