namespace LeonUI.Controls
{
    partial class SmipleTextBox
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
            this.InnerTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // InnerTextBox
            // 
            this.InnerTextBox.BackColor = System.Drawing.Color.White;
            this.InnerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InnerTextBox.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.InnerTextBox.ForeColor = System.Drawing.Color.Tomato;
            this.InnerTextBox.Location = new System.Drawing.Point(16, 7);
            this.InnerTextBox.Name = "InnerTextBox";
            this.InnerTextBox.Size = new System.Drawing.Size(70, 20);
            this.InnerTextBox.TabIndex = 0;
            this.InnerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SmipleTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::LeonUI.UnityResource.TextBoxBGI;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.InnerTextBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SmipleTextBox";
            this.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.Size = new System.Drawing.Size(102, 32);
            this.Resize += new System.EventHandler(this.SmipleTextBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox InnerTextBox;
    }
}
