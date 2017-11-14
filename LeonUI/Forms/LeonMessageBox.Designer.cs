﻿namespace LeonUI.Forms
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
            this.MiddlePanel = new LeonUI.Panels.Panel();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.IconLabel = new System.Windows.Forms.Label();
            this.BottomPanel = new LeonUI.Panels.Panel();
            this.TopPanel = new LeonUI.Panels.Panel();
            this.CloseButton = new LeonUI.TitleButtons.CloseButton();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.roundedButton1 = new LeonUI.Controls.RoundedButton();
            this.MiddlePanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.BackColor = System.Drawing.Color.White;
            this.MiddlePanel.Controls.Add(this.roundedButton1);
            this.MiddlePanel.Controls.Add(this.MessageLabel);
            this.MiddlePanel.Controls.Add(this.IconLabel);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePanel.Location = new System.Drawing.Point(1, 31);
            this.MiddlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Padding = new System.Windows.Forms.Padding(6);
            this.MiddlePanel.Size = new System.Drawing.Size(360, 100);
            this.MiddlePanel.TabIndex = 2;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoEllipsis = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.MessageLabel.Location = new System.Drawing.Point(66, 6);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(288, 88);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "LeonMessageBox";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MessageLabel.Visible = false;
            // 
            // IconLabel
            // 
            this.IconLabel.BackColor = System.Drawing.Color.Transparent;
            this.IconLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconLabel.Image = global::LeonUI.UnityResource.Info;
            this.IconLabel.Location = new System.Drawing.Point(6, 6);
            this.IconLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(60, 88);
            this.IconLabel.TabIndex = 0;
            this.IconLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.IconLabel.Visible = false;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(1, 131);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(360, 40);
            this.BottomPanel.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TopPanel.Controls.Add(this.CloseButton);
            this.TopPanel.Controls.Add(this.TitleLabel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(1, 1);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(360, 30);
            this.TopPanel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(330, 0);
            this.CloseButton.MinimumSize = new System.Drawing.Size(20, 20);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(30, 30);
            this.CloseButton.TabIndex = 4;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoEllipsis = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TitleLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.TitleLabel.Size = new System.Drawing.Size(360, 30);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "LeonMessageBox";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // roundedButton1
            // 
            this.roundedButton1.AutoEllipsis = true;
            this.roundedButton1.BackColor = System.Drawing.Color.Transparent;
            this.roundedButton1.CenterRectangle = new System.Drawing.Rectangle(17, 16, 70, 2);
            this.roundedButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedButton1.DownBitmap = ((System.Drawing.Bitmap)(resources.GetObject("roundedButton1.DownBitmap")));
            this.roundedButton1.EnterBitmap = ((System.Drawing.Bitmap)(resources.GetObject("roundedButton1.EnterBitmap")));
            this.roundedButton1.ForeColor = System.Drawing.Color.White;
            this.roundedButton1.Image = ((System.Drawing.Image)(resources.GetObject("roundedButton1.Image")));
            this.roundedButton1.Location = new System.Drawing.Point(66, 6);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.NormalBitmap = ((System.Drawing.Bitmap)(resources.GetObject("roundedButton1.NormalBitmap")));
            this.roundedButton1.Size = new System.Drawing.Size(288, 88);
            this.roundedButton1.TabIndex = 2;
            this.roundedButton1.Text = "roundedButton1";
            this.roundedButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeonMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(362, 172);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LeonMessageBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LeonMessageBox";
            this.Load += new System.EventHandler(this.LeonMessageBox_Load);
            this.Shown += new System.EventHandler(this.LeonMessageBox_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LeonMessageBox_Paint);
            this.MiddlePanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panels.Panel TopPanel;
        private Panels.Panel BottomPanel;
        private Panels.Panel MiddlePanel;
        private System.Windows.Forms.Label IconLabel;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.Label TitleLabel;
        private TitleButtons.CloseButton CloseButton;
        private Controls.RoundedButton roundedButton1;
    }
}