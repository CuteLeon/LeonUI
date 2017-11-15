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
    public partial class MyComBox : UserControl
    {

        public int SelectedIndex
        {
            get => ItemsList.SelectedIndex;
            set => ItemsList.SelectedIndex=value;
        }

        public event EventHandler DropDown;

        public event EventHandler SelectedIndexChanged
        {
            add {ItemsList.SelectedIndexChanged += value;}
            remove { ItemsList.SelectedIndexChanged -= value; }
        }

        bool CanCloseForm = false;

        /// <summary>
        /// 下拉项目列表窗体
        /// </summary>
        private ItemsForm _itemsForm = null;
        /// <summary>
        /// 下拉项目列表
        /// </summary>
        private ListBox ItemsList = null;

        [Browsable(true)]
        // System.Windows.Forms.ListBox
        /// <summary>Gets the items of the <see cref="T:System.Windows.Forms.ListBox" />.</summary>
        /// <returns>An <see cref="T:System.Windows.Forms.ListBox.ObjectCollection" /> representing the items in the <see cref="T:System.Windows.Forms.ListBox" />.</returns>
        // Token: 0x1700096F RID: 2415
        // (get) Token: 0x06002751 RID: 10065 RVA: 0x000BA7A0 File Offset: 0x000B89A0
        [Category("CatData"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Localizable(true), Description("ListBoxItemsDescr"), Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), MergableProperty(false)]

        public ListBox.ObjectCollection Items
        {
            get => (ItemsList?.Items)??null;
            set
            {
                Text = "";
                ItemsList.Items.Clear();
                foreach (string s in value)
                    ItemsList.Items.Add(s);
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

        public MyComBox()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.OnResize(null);
            CreateItemsForm();

            InnerLabel.Click += new EventHandler(MyComBox_Click);
            //InnerTextBox.GotFocus += new EventHandler(MyComBox_Click);
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

        private void CreateItemsForm()
        {
            _itemsForm = new ItemsForm()
            {
                Name = "ItemsName",
                FormBorderStyle = FormBorderStyle.None,
                Text = "",
                TopLevel = true,
                ShowIcon=false,
                ShowInTaskbar=false,
            };
            _itemsForm.Deactivate += new EventHandler((s, e) => { _itemsForm.Hide(); });
            _itemsForm.FormClosing += new FormClosingEventHandler((s,e)=> { if (!CanCloseForm) { e.Cancel = true; _itemsForm.Hide(); }});
            
            ItemsList = new ListBox()
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Font = InnerLabel.Font,
                ForeColor = InnerLabel.ForeColor,
                IntegralHeight = false,
            };
            _itemsForm.Controls.Add(ItemsList);
            ItemsList.SelectedIndexChanged += new EventHandler((s,e)=> 
            {
                this.Text = ItemsList.SelectedItem.ToString();
                _itemsForm.Hide();
            });
        }

        public void DropDownList()
        {
            DropDown?.Invoke(this, new EventArgs());

            _itemsForm.Width = this.Width;
            _itemsForm.Height = 0;
            _itemsForm.MaximumSize = new Size(this.Width,ItemsList.ItemHeight * 8);
            _itemsForm.MinimumSize = new Size(this.Width,10);

            bool DisplayAbove = false;
            int TargetHeight = Math.Min(_itemsForm.MaximumSize.Height, ItemsList.PreferredHeight);
            Point locationOnClient = LocationOnClient(this);
            Point locationOnScreen= new Point(PointToScreen(locationOnClient).X, PointToScreen(locationOnClient).Y);
            locationOnScreen.Offset(-locationOnClient.X,-locationOnClient.Y);

            _itemsForm.Show();

            if (Screen.FromPoint(locationOnScreen).Bounds.Height - locationOnScreen.Y < TargetHeight)
            {
                DisplayAbove = true;
                _itemsForm.Location = locationOnScreen;
            }
            else
            {
                locationOnScreen.Y += this.Height;
                _itemsForm.Location = locationOnScreen;
            }

            ThreadPool.QueueUserWorkItem(new WaitCallback((displayAbove) => {
                try
                {
                    if ((bool)displayAbove)
                    {
                        while (_itemsForm.Height < TargetHeight)
                        {
                            if (!_itemsForm.Visible) break;
                            _itemsForm.Top =Math.Max(0, _itemsForm.Top - 10);
                            _itemsForm.Height += 10;
                            Thread.Sleep(5);
                        }
                        _itemsForm.Top = locationOnScreen.Y - _itemsForm.Height;
                    }
                    else
                    {
                        while (_itemsForm.Height < TargetHeight)
                        {
                            if (!_itemsForm.Visible) break;
                            _itemsForm.Height += 10;
                            Thread.Sleep(5);
                        }
                    }
                }
                catch {}
            }), DisplayAbove);
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


        private class ItemsForm : Form
        {
            const int WS_EX_NOACTIVATE = 0x08000000;

            //重载Form的CreateParams属性，添加不获取焦点属性值。  
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.ExStyle |= WS_EX_NOACTIVATE;
                    cp.Parent = IntPtr.Zero;
                    return cp;
                }

            }
        }
    }

}
