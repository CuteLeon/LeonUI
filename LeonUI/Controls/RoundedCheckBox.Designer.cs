namespace LeonUI.Controls
{
    partial class RoundedCheckBox
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
            this.SuspendLayout();
            // 
            // RoundedCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::LeonUI.UnityResource.CheckBox_Off_0;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(204, 64);
            this.MinimumSize = new System.Drawing.Size(50, 15);
            this.Name = "RoundedCheckBox";
            this.Size = new System.Drawing.Size(102, 32);
            this.Load += new System.EventHandler(this.RoundedCheckBox_Load);
            this.Click += new System.EventHandler(this.RoundedCheckBox_Click);
            this.MouseEnter += new System.EventHandler(this.RoundedCheckBox_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.RoundedCheckBox_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
