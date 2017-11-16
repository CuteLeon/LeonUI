namespace LeonUI.Forms
{
    partial class NoBorderSizableForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoBorderSizableForm));
            this.TitlePanel = new LeonUI.Panels.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.IconLabel = new System.Windows.Forms.Label();
            this.MinButton = new LeonUI.TitleButtons.MinButton();
            this.RestoreButton = new LeonUI.TitleButtons.RestoreButton();
            this.MaxButton = new LeonUI.TitleButtons.MaxButton();
            this.CloseButton = new LeonUI.TitleButtons.CloseButton();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.Transparent;
            this.TitlePanel.Controls.Add(this.TitleLabel);
            this.TitlePanel.Controls.Add(this.IconLabel);
            this.TitlePanel.Controls.Add(this.MinButton);
            this.TitlePanel.Controls.Add(this.RestoreButton);
            this.TitlePanel.Controls.Add(this.MaxButton);
            this.TitlePanel.Controls.Add(this.CloseButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(5, 5);
            this.TitlePanel.MaximumSize = new System.Drawing.Size(0, 24);
            this.TitlePanel.MinimumSize = new System.Drawing.Size(0, 24);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(274, 24);
            this.TitlePanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.Location = new System.Drawing.Point(24, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.TitleLabel.Size = new System.Drawing.Size(130, 24);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "NoBorderSizableForm";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconLabel
            // 
            this.IconLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IconLabel.Location = new System.Drawing.Point(0, 0);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(24, 24);
            this.IconLabel.TabIndex = 4;
            // 
            // MinButton
            // 
            this.MinButton.BackColor = System.Drawing.Color.Transparent;
            this.MinButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MinButton.BackgroundImage")));
            this.MinButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MinButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinButton.Location = new System.Drawing.Point(154, 0);
            this.MinButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(30, 24);
            this.MinButton.TabIndex = 3;
            // 
            // RestoreButton
            // 
            this.RestoreButton.BackColor = System.Drawing.Color.Transparent;
            this.RestoreButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RestoreButton.BackgroundImage")));
            this.RestoreButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RestoreButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RestoreButton.Location = new System.Drawing.Point(184, 0);
            this.RestoreButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(30, 24);
            this.RestoreButton.TabIndex = 2;
            this.RestoreButton.Visible = false;
            // 
            // MaxButton
            // 
            this.MaxButton.BackColor = System.Drawing.Color.Transparent;
            this.MaxButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MaxButton.BackgroundImage")));
            this.MaxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MaxButton.Location = new System.Drawing.Point(214, 0);
            this.MaxButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.MaxButton.Name = "MaxButton";
            this.MaxButton.Size = new System.Drawing.Size(30, 24);
            this.MaxButton.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(244, 0);
            this.CloseButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 24);
            this.CloseButton.TabIndex = 0;
            // 
            // NoBorderSizableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TitlePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NoBorderSizableForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "NoBorderSizableForm";
            this.Load += new System.EventHandler(this.NoBorderSizableForm_Load);
            this.Resize += new System.EventHandler(this.NoBorderSizableForm_Resize);
            this.TitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.Panel TitlePanel;
        private TitleButtons.CloseButton CloseButton;
        private TitleButtons.MaxButton MaxButton;
        private TitleButtons.RestoreButton RestoreButton;
        private TitleButtons.MinButton MinButton;
        private System.Windows.Forms.Label IconLabel;
        private System.Windows.Forms.Label TitleLabel;
    }
}