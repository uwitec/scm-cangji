using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCM_CangJi.WareHouseManage
{
    public partial class NavigationButton : UserControl
    {
        private struct BUTTONINFO
        {
            public string Name;
            public Rectangle rect;
            public uint nFlags;
            public uint nClick;
        }

        BUTTONINFO buttonInfo;
        List<BUTTONINFO> listButtonInfo;
        
        int clickPos;  //选中的按纽位置
        bool isClick;  //判断是否在按纽区域点击了

        SolidBrush fontBrush;
        Font m_Font = new Font("宋体", 10, FontStyle.Bold);// | FontStyle.Italic
        StringFormat alignFormat;

        private Rectangle rectFrame;//框架矩形

        //按钮背景
        private const int BMPBACKHEIGHT = 26;
        private int bmpOffsetY = 0;
        Bitmap bmpBack = null;

        SolidBrush backFrameBrush = null;
        Pen penFrame = null;
                
        public NavigationButton()
        {
            InitializeVariable();
            InitializeComponent();
        }

        public void InitializeVariable()
        {
            clickPos = -1;
            isClick = false;
            rectFrame = new Rectangle(0, 0, 0, 0);
            
            fontBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

            alignFormat = new StringFormat();
            alignFormat.LineAlignment = StringAlignment.Center;
            alignFormat.Alignment = StringAlignment.Center;

            buttonInfo = new BUTTONINFO();
            listButtonInfo = new List<BUTTONINFO>();
            bmpBack = global::SCM_CangJi.Properties.Resources.OFFICE2007BLUEBUTTON;
        }

        public void SetBuottonName(int index, string name)
        {
            BUTTONINFO update;
            if(index<listButtonInfo.Count && index>=0)
            {
                update = listButtonInfo[index];
                update.Name = name;
                listButtonInfo[index] = update;
                Invalidate();
            }
        }

        public void AddButton(string name, uint click)
        {
            Rectangle rect = new Rectangle(0, 0, 0, 0);
            int count = listButtonInfo.Count;

            DrawLayer drawLayer=new DrawLayer();
            int width = drawLayer.GetStringPixelWidth(this, name, m_Font) + 10;

            buttonInfo.Name = name;
            buttonInfo.nFlags = 0;
            buttonInfo.nClick = click;
            
            if (count > 0)
            {
                rect.X = listButtonInfo[count - 1].rect.Right+1;
                rect.Y = 0;
                rect.Width = width;
                rect.Height = this.Height-1;
                buttonInfo.rect = rect;   
            }
            else
            {
                rect.X = 0;
                rect.Y = 0;
                rect.Width = width;
                rect.Height = this.Height-1;
                buttonInfo.rect = rect;                
            }

            listButtonInfo.Add(buttonInfo);

            if (click > 0)
            {
                isClick = true;
                clickPos = listButtonInfo.Count()-1;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics dc = e.Graphics;

            //开启双缓冲
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            
            if (listButtonInfo.Count() < 0)
            {
                return;
            }

            ShowFrame(dc);
            DrawButton(dc);
        }

        private void DrawButton(Graphics dc)
        {
            BUTTONINFO update;
            for (int i = 0; i < listButtonInfo.Count(); i++)
            {
                update = listButtonInfo[i];

                if (update.nClick == 0)	//按纽没按下
                {
                    if (update.nFlags == 0)	//无焦点状态
                    {
                        bmpOffsetY = 0;
                    }

                    if (update.nFlags == 1)//有焦点状态
                    {
                        bmpOffsetY = BMPBACKHEIGHT;
                        update.nFlags = 0;
                    }
                }

                if (update.nClick == 1) //按纽被按下
                {
                    if (update.nFlags == 0) //无焦点状态
                    {
                        bmpOffsetY = (BMPBACKHEIGHT * 4) - BMPBACKHEIGHT;
                    }

                    if (update.nFlags == 1)	//有焦点状态
                    {

                        bmpOffsetY = (BMPBACKHEIGHT * 5) - BMPBACKHEIGHT;
                        update.nFlags = 0;
                    }

                    if (update.nFlags == 2)	//被按下有焦点状态
                    {
                        bmpOffsetY = (BMPBACKHEIGHT * 3) - BMPBACKHEIGHT;
                    }
                }

                listButtonInfo[i] = update;

                Rectangle rect;
                rect = new Rectangle(listButtonInfo[i].rect.Left, listButtonInfo[i].rect.Top,
                    listButtonInfo[i].rect.Width, listButtonInfo[i].rect.Height);

                dc.DrawImage(bmpBack, rect, 0, bmpOffsetY, 1, BMPBACKHEIGHT, System.Drawing.GraphicsUnit.Pixel);
                dc.DrawString(listButtonInfo[i].Name, m_Font, fontBrush,
                    new Rectangle(rect.Left, rect.Top, rect.Width, rect.Height + 3), alignFormat);

                dc.DrawLine(penFrame, rect.Right, rect.Top, rect.Right, rect.Bottom);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //this.Left += Parent.Left;
            //this.Top += Parent.Top;
            
        }

        #region 创建框架
        public Rectangle CreateFrame(int x, int y, int width, int height, Color cback, Color cframe)
        {
            this.Left = x;
            this.Top = y;
            this.Width = width;
            this.Height = height;
            
            rectFrame.X = 0;
            rectFrame.Y = 0;
            rectFrame.Width = this.Width;
            rectFrame.Height = this.Height;

            backFrameBrush = new SolidBrush(cback);
            penFrame = new Pen(cframe, 1);
            
            return rectFrame;
        }

        public void ShowFrame(Graphics dc)
        {
            dc.FillRectangle(backFrameBrush, rectFrame.Left, rectFrame.Top, rectFrame.Width, rectFrame.Height);
            dc.DrawLine(penFrame, rectFrame.Left, rectFrame.Height - 1, rectFrame.Right, rectFrame.Height - 1);
        }
               
        #endregion

        public Rectangle GetClientRect()
        {
            return rectFrame;
        }

        public int GetclickPos()
        {
            return clickPos;
        }

        public string GetClickButtonName()
        {
            string name="";
            if (clickPos > -1 && isClick==true)
            {
                name = listButtonInfo[clickPos].Name;
            }

            return name;
        }

        public void SetWindowPos(int x, int y, int width, int height)
        {
            this.Left = x;
            this.Top = y;
            this.Width = width;
            this.Height = height;

            rectFrame.X = 0;
            rectFrame.Y = 0;
            rectFrame.Width = this.Width;
            rectFrame.Height = this.Height;

            Invalidate();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            BUTTONINFO update;
            for (int i = 0; i < listButtonInfo.Count(); i++)
            {
                if (listButtonInfo[i].rect.Contains(e.X, e.Y))
                {
                    update = listButtonInfo[i];
                    
                    if (update.nClick == 0)    //按钮没选中状态
                    {
                        update.nFlags = 1;      //有焦点
                    }

                    if (update.nClick == 1 && update.nFlags != 2)//按钮被选中有焦点状态
                    {
                        update.nFlags = 1;      //有焦点
                    }

                    listButtonInfo[i] = update;
                    Invalidate();
                    break;
                }
            }
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            BUTTONINFO update;

            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < listButtonInfo.Count(); i++)
                {
                    if (listButtonInfo[i].rect.Contains(e.X, e.Y))
                    {
                        update = listButtonInfo[i];
                        update.nClick = 1;        //按纽被点击
                        update.nFlags = 2;          //按纽被点击时的焦点
                        listButtonInfo[i] = update;

                        //恢复以前被点击的按纽状态
                        if (clickPos > -1 && clickPos != i)
                        {
                            update = listButtonInfo[clickPos];
                            update.nFlags = 0;
                            update.nClick = 0;
                            listButtonInfo[clickPos] = update;
                        }

                        clickPos = i;
                        isClick = true;
                        Invalidate();
                        break;
                    }
                    else
                    {
                        isClick = false;
                    }
                }
            }
        }

        private void OnMouseHover(object sender, EventArgs e)
        {
            
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            //离开导航栏恢复没选中状态
            if (clickPos > -1)
            {
                BUTTONINFO update;
                update = listButtonInfo[clickPos];
                update.nFlags = 0;
                listButtonInfo[clickPos] = update;
                Invalidate();
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            BUTTONINFO update;

            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < listButtonInfo.Count(); i++)
                {
                    if (listButtonInfo[i].rect.Contains(e.X, e.Y) && listButtonInfo[i].nClick == 1)
                    {
                        //恢复有焦点状态
                        clickPos = i;                        
                        update = listButtonInfo[i];
                        update.nFlags = 1;
                        listButtonInfo[i] = update;
                        Invalidate();
                    }
                }
            }
        }

        
    }
}
