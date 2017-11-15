using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Threading;
using System.Runtime.InteropServices;

namespace LeonUI.Controls
{
    public partial class ComboBox : UserControl
    {

        public int SelectedIndex
        {
            get => ItemsListBox.SelectedIndex;
            set => ItemsListBox.SelectedIndex=value;
        }

        public event EventHandler DropDown;

        public event EventHandler SelectedIndexChanged
        {
            add {ItemsListBox.SelectedIndexChanged += value;}
            remove { ItemsListBox.SelectedIndexChanged -= value; }
        }

        /// <summary>
        /// 下拉项目列表
        /// </summary>
        private ListBox ItemsListBox = null;

        /// <summary>
        /// 下拉项目浮动容器
        /// </summary>
        private ToolStripDropDown toolStripDropDown = null;

        /// <summary>
        /// 下拉项目容器
        /// </summary>
        private ToolStripControlHost toolStripControlHost = null;

        [Browsable(true)]
        // System.Windows.Forms.ListBox
        /// <summary>Gets the items of the <see cref="T:System.Windows.Forms.ListBox" />.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.ListBox.ObjectCollection" /> representing the items in the <see cref="T:System.Windows.Forms.ListBox" />.</returns>
        // Token: 0x1700096F RID: 2415
        // (get) Token: 0x06002751 RID: 10065 RVA: 0x000BA7A0 File Offset: 0x000B89A0
        [Category("CatData"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(true), Description("ListBoxItemsDescr"), Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), MergableProperty(false)]

        public ListBox.ObjectCollection Items
        {
            get => (ItemsListBox?.Items)??null;
            set
            {
                Text = "";
                ItemsListBox.Items.Clear();
                foreach (string s in value)
                    ItemsListBox.Items.Add(s);
            }
        }

        ComboBoxStyle dropDownStyle = ComboBoxStyle.DropDown;
        /// <summary>
        /// 设置 MyComBox 显示效果类型
        /// </summary>
        public ComboBoxStyle DropDownStyle {
            get => dropDownStyle;
            set
            {
                dropDownStyle = value;
                this.BackgroundImage = null;
                BGImage = CreateBGImage();
                this.BackgroundImage = BGImage;

                switch (value)
                {
                    case ComboBoxStyle.DropDown:
                        {
                            InnerLabel.Hide();
                            InnerTextBox.Left = 16;
                            InnerTextBox.Width = this.Width - 16 - 26;
                            InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2 + 1;
                            InnerTextBox.Show();
                            break;
                        }
                    case ComboBoxStyle.DropDownList:
                        {
                            InnerLabel.Left = 16;
                            InnerLabel.Width = this.Width - 16 - 26;
                            InnerLabel.Top = (this.Height - InnerLabel.Height) / 2 + 1;
                            InnerLabel.Show();
                            InnerTextBox.Hide();
                            break;
                        }
                    case ComboBoxStyle.Simple:
                        {
                            InnerLabel.Hide();
                            InnerTextBox.Left = 16;
                            InnerTextBox.Width = this.Width - 16 - 17;
                            InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2 + 1;
                            InnerTextBox.Show();
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// MyComBox 背景图资源
        /// </summary>
        static Bitmap StaticBGImage = UnityResource.MyComBox;

        /// <summary>
        /// 左边切图
        /// </summary>
        static Bitmap LeftBitmap = StaticBGImage.Clone(new Rectangle(0, 0, 16, 32), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        /// <summary>
        /// 右边切图
        /// </summary>
        static Bitmap RightBitmap = RotateFlipBitmap(LeftBitmap);
        
        /// <summary>
        /// 按钮图像
        /// </summary>
        static Bitmap ButtonBitmap = StaticBGImage.Clone(new Rectangle(77, 0, 25, 32), System.Drawing.Imaging.PixelFormat.Format32bppArgb);

        /// <summary>
        /// 中间切图
        /// </summary>
        static Bitmap MidBitmap = StaticBGImage.Clone(new Rectangle(16, 0, 61, 32), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        /// <summary>
        /// 背景图像
        /// </summary>
        private Bitmap BGImage = null;

        //用于把属性显示在属性面板中，并在代码生成器中储存属性的值
        [Browsable(true)]
        [Description("ComBox 控件样式"), Category("自定义属性卡"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get => InnerLabel.Text;
            set
            {
                InnerTextBox.Text = value;
                InnerLabel.Text = value;
            }
        }

        public ComboBox()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.OnResize(null);
            CreateDropDownHost();

            this.MinimumSize = new Size(0,32);
            this.MaximumSize = MinimumSize;

            InnerLabel.Click += new EventHandler(MyComBox_Click);
        }

        static Bitmap RotateFlipBitmap(Bitmap iniBitmap)
        {
            Bitmap RotatedBitmap = iniBitmap.Clone() as Bitmap;
            RotatedBitmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            return RotatedBitmap;
        }

        private Bitmap CreateBGImage()
        {
            if (this.Width == 0 || this.Height == 0) return null;

            Bitmap bgimage = new Bitmap(this.Size.Width, 32);
            try
            {
                using (Graphics graphics = Graphics.FromImage(bgimage))
                {
                    graphics.DrawImage(LeftBitmap, 0, 0, 16, 32);

                    if (dropDownStyle == ComboBoxStyle.Simple)
                    {
                        using (TextureBrush MidImageBrush = new TextureBrush(MidBitmap) { WrapMode = System.Drawing.Drawing2D.WrapMode.Tile })
                            graphics.FillRectangle(MidImageBrush, new Rectangle(16, 0, this.Width - 32, 32));
                        graphics.DrawImage(RightBitmap, this.Width - 16, 0, 16, 32);
                    }
                    else
                    {
                        using (TextureBrush MidImageBrush = new TextureBrush(MidBitmap) { WrapMode = System.Drawing.Drawing2D.WrapMode.Tile })
                            graphics.FillRectangle(MidImageBrush, new Rectangle(16, 0, this.Width - 41, 32));
                        graphics.DrawImage(ButtonBitmap, this.Width - 25, 0, 25, 32);
                    }
                }
            }
            catch { }
            return bgimage;
        }

        private void MyComBox_Resize(object sender, EventArgs e)
        {
            this.BackgroundImage = null;
            BGImage = CreateBGImage();
            this.BackgroundImage = BGImage;

            if (dropDownStyle == ComboBoxStyle.DropDownList)
            {
                InnerLabel.Left = 16;
                InnerLabel.Width = this.Width - 16 - 26;
                InnerLabel.Top = (this.Height - InnerLabel.Height) / 2;
            }
            else
            {
                InnerTextBox.Left = 16;
                InnerTextBox.Width = this.Width - 16 - (dropDownStyle== ComboBoxStyle.DropDown?26:17);
                InnerTextBox.Top = (this.Height - InnerTextBox.Height) / 2;
            }
        }

        private void CreateDropDownHost()
        {
            toolStripDropDown = new ToolStripDropDown()
            {
                AutoClose = true,
                DropShadowEnabled = true,
                Opacity = 0.9,
                AllowTransparency = true,
                Padding = new Padding(1,0,1,0),
                ShowItemToolTips=false
            };

            ItemsListBox = new ListBox()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = InnerLabel.Font,
                ForeColor = InnerLabel.ForeColor,
                IntegralHeight = false,
            };

            ItemsListBox.SelectedIndexChanged += new EventHandler((s,e)=> 
            {
                this.Text = ItemsListBox.SelectedItem.ToString();
                toolStripDropDown.Hide();
            });

            toolStripControlHost = new ToolStripControlHost(ItemsListBox);
            toolStripDropDown.Items.Add(toolStripControlHost);
        }

        public void DropDownList()
        {
            DropDown?.Invoke(this, new EventArgs());

            ItemsListBox.MinimumSize = new Size(this.Width,0);
            ItemsListBox.MaximumSize = new Size(0, 300);

            Point locationOnClient = LocationOnClient(this);
            Point locationOnScreen= new Point(PointToScreen(locationOnClient).X, PointToScreen(locationOnClient).Y);
            locationOnScreen.Offset(-locationOnClient.X,-locationOnClient.Y);
            locationOnScreen.Offset(0, this.Height);

            toolStripDropDown.Show(locationOnScreen);
        }

        private Point LocationOnClient(Control c)
        {
            Point retval = new Point(0, 0);
            for (; c.Parent != null; c = c.Parent)
            { retval.Offset(c.Location); }
            return retval;
        }

        private void MyComBox_Click(object sender, EventArgs e)
        {
            if(dropDownStyle!= ComboBoxStyle.Simple)
                DropDownList();
        }

    }

}
