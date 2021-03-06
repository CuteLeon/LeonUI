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
            this.CancelButton = new LeonUI.Controls.RoundedButton();
            this.OKButton = new LeonUI.Controls.RoundedButton();
            this.TopPanel = new LeonUI.Panels.Panel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CloseButton = new LeonUI.TitleButtons.CloseButton();
            this.MiddlePanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MiddlePanel
            // 
            this.MiddlePanel.BackColor = System.Drawing.Color.White;
            this.MiddlePanel.Controls.Add(this.MessageLabel);
            this.MiddlePanel.Controls.Add(this.IconLabel);
            this.MiddlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MiddlePanel.Location = new System.Drawing.Point(1, 31);
            this.MiddlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.MiddlePanel.Name = "MiddlePanel";
            this.MiddlePanel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MiddlePanel.Size = new System.Drawing.Size(360, 100);
            this.MiddlePanel.TabIndex = 2;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoEllipsis = true;
            this.MessageLabel.BackColor = System.Drawing.Color.Transparent;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MessageLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.MessageLabel.Location = new System.Drawing.Point(72, 5);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(282, 90);
            this.MessageLabel.TabIndex = 1;
            this.MessageLabel.Text = "LeonMessageBox";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IconLabel
            // 
            this.IconLabel.BackColor = System.Drawing.Color.Transparent;
            this.IconLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconLabel.Image = global::LeonUI.UnityResource.Info;
            this.IconLabel.Location = new System.Drawing.Point(6, 5);
            this.IconLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IconLabel.Name = "IconLabel";
            this.IconLabel.Size = new System.Drawing.Size(66, 90);
            this.IconLabel.TabIndex = 0;
            this.IconLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.BottomPanel.Controls.Add(this.CancelButton);
            this.BottomPanel.Controls.Add(this.OKButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(1, 131);
            this.BottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(360, 40);
            this.BottomPanel.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.AutoEllipsis = true;
            this.CancelButton.BackColor = System.Drawing.Color.Transparent;
            this.CancelButton.CenterRectangle = new System.Drawing.Rectangle(17, 16, 70, 2);
            this.CancelButton.DownBitmap = ((System.Drawing.Bitmap)(resources.GetObject("CancelButton.DownBitmap")));
            this.CancelButton.EnterBitmap = ((System.Drawing.Bitmap)(resources.GetObject("CancelButton.EnterBitmap")));
            this.CancelButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CancelButton.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.Location = new System.Drawing.Point(125, 4);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.NormalBitmap = ((System.Drawing.Bitmap)(resources.GetObject("CancelButton.NormalBitmap")));
            this.CancelButton.Size = new System.Drawing.Size(97, 32);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "取消";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CancelButton.Visible = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.AutoEllipsis = true;
            this.OKButton.BackColor = System.Drawing.Color.Transparent;
            this.OKButton.CenterRectangle = new System.Drawing.Rectangle(17, 16, 70, 2);
            this.OKButton.DownBitmap = ((System.Drawing.Bitmap)(resources.GetObject("OKButton.DownBitmap")));
            this.OKButton.EnterBitmap = ((System.Drawing.Bitmap)(resources.GetObject("OKButton.EnterBitmap")));
            this.OKButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OKButton.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(125, 4);
            this.OKButton.Name = "OKButton";
            this.OKButton.NormalBitmap = ((System.Drawing.Bitmap)(resources.GetObject("OKButton.NormalBitmap")));
            this.OKButton.Size = new System.Drawing.Size(97, 32);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "确定";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.TopPanel.Controls.Add(this.TitleLabel);
            this.TopPanel.Controls.Add(this.CloseButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(1, 1);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(360, 30);
            this.TopPanel.TabIndex = 0;
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
            this.TitleLabel.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TitleLabel.Size = new System.Drawing.Size(332, 30);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "LeonMessageBox";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseButton.BackgroundImage")));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.Location = new System.Drawing.Point(332, 0);
            this.CloseButton.MinimumSize = new System.Drawing.Size(19, 15);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(28, 30);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // LeonMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(362, 172);
            this.Controls.Add(this.MiddlePanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "LeonMessageBox";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LeonMessageBox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LeonMessageBox_FormClosing);
            this.Load += new System.EventHandler(this.LeonMessageBox_Load);
            this.Shown += new System.EventHandler(this.LeonMessageBox_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LeonMessageBox_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LeonMessageBox_KeyPress);
            this.MiddlePanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panels.Panel TopPanel;
        private Panels.Panel BottomPanel;
        private Panels.Panel MiddlePanel;
        private System.Windows.Forms.Label IconLabel;
        private System.Windows.Forms.Label MessageLabel;
        private Controls.RoundedButton OKButton;
        private new Controls.RoundedButton CancelButton;
        private TitleButtons.CloseButton CloseButton;
        private System.Windows.Forms.Label TitleLabel;
    }
}