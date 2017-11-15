namespace LeonUI.Controls
{
    partial class RoundedComboBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            toolStripDropDown?.Dispose();
            toolStripControlHost?.Dispose();
            ItemsListBox?.Dispose();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.InnerLabel = new System.Windows.Forms.Label();
            this.InnerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InnerLabel
            // 
            this.InnerLabel.AutoEllipsis = true;
            this.InnerLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InnerLabel.ForeColor = System.Drawing.Color.Tomato;
            this.InnerLabel.Location = new System.Drawing.Point(3, 3);
            this.InnerLabel.Margin = new System.Windows.Forms.Padding(0);
            this.InnerLabel.Name = "InnerLabel";
            this.InnerLabel.Size = new System.Drawing.Size(38, 18);
            this.InnerLabel.TabIndex = 0;
            this.InnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InnerLabel.Visible = false;
            // 
            // InnerTextBox
            // 
            this.InnerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InnerTextBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InnerTextBox.ForeColor = System.Drawing.Color.Tomato;
            this.InnerTextBox.Location = new System.Drawing.Point(24, 3);
            this.InnerTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.InnerTextBox.Name = "InnerTextBox";
            this.InnerTextBox.Size = new System.Drawing.Size(53, 19);
            this.InnerTextBox.TabIndex = 1;
            // 
            // ComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::LeonUI.UnityResource.ComboBoxBGI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.InnerTextBox);
            this.Controls.Add(this.InnerLabel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(45, 32);
            this.Name = "ComboBox";
            this.Size = new System.Drawing.Size(102, 32);
            this.Click += new System.EventHandler(this.ComboBox_Click);
            this.Resize += new System.EventHandler(this.ComboBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label InnerLabel;
        public System.Windows.Forms.TextBox InnerTextBox;
    }
}
