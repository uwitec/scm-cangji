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
    public partial class ButtonEx : UserControl
    {
        public bool isIn;
        public String buttonName="";
        public enum STYLE { ARROW, BUTTON, RADIOBUTTON, OFFICE2007BLUE }

        STYLE butStyle;

        DrawLayer drawLayer;
        DrawLayer.ARROW arrowflage;

        Rectangle butRect;
        Color backColor;
        SolidBrush backColorBrush;
        SolidBrush fontBrush;

        Pen arrowPen;
        Rectangle arrowRect;
        Font m_Font = new Font("宋体", 10, FontStyle.Bold);// | FontStyle.Italic

        //按钮背景
        private const int BMPBACKHEIGHT = 26;
        private int bmpOffsetY = 0;
        Bitmap bmpBack = null;
        bool isFocus;

        StringFormat alignFormat;

        Panel parentPanel = null;

        public ButtonEx()
        {
            InitializeVariable();

            InitializeComponent();
        }

        public ButtonEx(Panel param)
        {
            parentPanel = param;

            InitializeVariable();

            InitializeComponent();
        }

        private void InitializeVariable()
        {
            isIn = false;
            isFocus = false;
            buttonName = "";
            butStyle = STYLE.BUTTON;

            drawLayer = new DrawLayer();

            bmpBack = global::SCM_CangJi.Properties.Resources.OFFICE2007BLUEBUTTON;

            arrowflage = DrawLayer.ARROW.LEFT;

            alignFormat = new StringFormat();
            alignFormat.LineAlignment = StringAlignment.Center;
            alignFormat.Alignment = StringAlignment.Center;

            fontBrush = new SolidBrush(Color.FromArgb(105, 187, 255));//Color.FromArgb(2, 150, 211)

            arrowPen = new Pen(Color.FromArgb(105, 187, 255), 2);

            backColor = Color.FromArgb(227, 239, 255);
            backColorBrush = new SolidBrush(backColor);

            butRect = new Rectangle(0, 0, 0, 0);
            arrowRect = new Rectangle(-1, -2, 5, 5);
        }
        private void OnLoad(object sender, EventArgs e)
        {
        }

        public void CreateWindow(string name, int x, int y, int w, int h, STYLE style)
        {
            butStyle = style;
            buttonName = name;
            
            this.Left = x;
            this.Top = y;
            this.Width = w;
            this.Height = h;

            butRect.X = x;
            butRect.Y = 1;
            butRect.Width = w;
            butRect.Height = h;
        }

        //用来创建按钮,自动获取宽度
        public void CreateWindow(string name, int x, int y, int h, STYLE style)
        {
            butStyle = style;
            
            buttonName = name;
            
            this.Left = x;
            this.Top = y;

            //箭头按钮的宽和高相同
            if (butStyle == STYLE.ARROW)
            {
                this.Width = h;
            }
            else
            {
                this.Width = drawLayer.GetStringPixelWidth(this, name, m_Font) + 10;
            }

            this.Height = h;

            butRect.X = x;
            butRect.Y = 1;
            butRect.Width = this.Width;
            butRect.Height = this.Height;
        }

        public void CreateWindow(string name, int x, int y, int w, int h, STYLE style, int arrowflages)
        {
            butStyle = style;
            buttonName = name;
            
            this.Left = x;
            this.Top = y;
            
            butRect.X = x;
            butRect.Y = 1;
            
            switch (style)
            {
                case STYLE.ARROW:
                    if (arrowflages == 1)
                    {
                        arrowflage = DrawLayer.ARROW.LEFT;
                    }
                    else
                    {
                        arrowflage = DrawLayer.ARROW.RIGHT;
                    }

                    arrowRect.Width = w;
                    arrowRect.Height = h;
                    
                    this.Width = w * 4;
                    this.Height = h * 4;
        
                    butRect.Width = w * 4;
                    butRect.Height = h * 4;
                    break;

                case STYLE.BUTTON:
                    this.Width = w;
                    this.Height = h;

                    butRect.Width = w;
                    butRect.Height = h;
                    break;
            }
        }

        public void SetWindowPos(int x, int y)
        {
            this.Left = x;
            this.Top = y;
            this.Visible = true;
        }

        public Rectangle GetClientRect()
        {
            return butRect;
        }

        private void OnMouseHover(object sender, EventArgs e)
        {
            isIn = true;

            if (butStyle == STYLE.OFFICE2007BLUE)
            {
                
                if (isFocus == false)
                {
                    bmpOffsetY = BMPBACKHEIGHT;
                }
                else
                {
                    bmpOffsetY = (BMPBACKHEIGHT * 5) - BMPBACKHEIGHT;
                }
            }
            Invalidate();
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            isIn = false;

            if (butStyle == STYLE.OFFICE2007BLUE)
            {
                if (isFocus == false)
                {
                    bmpOffsetY = 0;
                }
                else
                {
                    bmpOffsetY = (BMPBACKHEIGHT * 4) - BMPBACKHEIGHT;
                }
            }
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            //开启双缓冲
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            Graphics dc = e.Graphics;

            switch (butStyle)
            {
                case STYLE.ARROW:
                    DrawArrow(dc);                    
                    break;

                case STYLE.BUTTON:
                    DrawButton(dc);                    
                    break;

                case STYLE.OFFICE2007BLUE:
                    DrawOffice2007Blue(dc);
                    break;

                case STYLE.RADIOBUTTON:
                    DrawRadioButton(dc);
                    break;
            }
        }

        private void DrawArrow(Graphics dc)
        {
            if (isIn == true)
            {
                drawLayer.DrawRounded(dc, Color.FromArgb(222, 222, 222), Color.FromArgb(255, 245, 204),
                    0, 0, butRect.Width, butRect.Height, Color.FromArgb(255, 255, 255), Color.FromArgb(255, 219, 117));
            }

            drawLayer.DrawArrow(dc, arrowRect, arrowPen, arrowflage);
        }

        private void DrawButton(Graphics dc)
        {
            if (isIn == true)
            {
                drawLayer.DrawRounded(dc, Color.FromArgb(222, 222, 222), Color.FromArgb(255, 245, 204),
                    0, 0, butRect.Width, butRect.Height, Color.FromArgb(255, 255, 255), Color.FromArgb(255, 219, 117));
            }

            dc.DrawString(buttonName, m_Font, fontBrush,
                new Rectangle(0, 0, butRect.Width, butRect.Bottom + 3), alignFormat);
        }

        private void DrawOffice2007Blue(Graphics dc)
        {
            Rectangle rect;
            fontBrush.Dispose();
            fontBrush = new SolidBrush(Color.FromArgb(0, 0, 0));

            rect = new Rectangle(1, 1, butRect.Width, butRect.Bottom);

            dc.DrawImage(bmpBack, rect, 0, bmpOffsetY, 1, BMPBACKHEIGHT, System.Drawing.GraphicsUnit.Pixel);
            dc.DrawString(buttonName, m_Font, fontBrush, rect, alignFormat);
            Pen p = new Pen(Color.FromArgb(101, 147, 201));
            dc.DrawLine(p, rect.Width - 1, rect.Top, rect.Width - 1, rect.Bottom);
        }

        private void DrawRadioButton(Graphics dc)
        {
            Pen p = new Pen(Color.FromArgb(33, 85, 132),2);
            
            dc.DrawEllipse(p,1, 5, 10, 10);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (butStyle == STYLE.BUTTON)
                {
                    
                }
                if (butStyle == STYLE.ARROW)
                {
                    if (parentPanel != null)
                    {
                        parentPanel.Visible = false;
                    }
                }

                if (butStyle == STYLE.OFFICE2007BLUE)
                {
                    if (isFocus == true)
                    {
                        bmpOffsetY = (BMPBACKHEIGHT * 3) - BMPBACKHEIGHT;
                        Invalidate();
                    }
                }
            }
        }
                
        private void OnLeave(object sender, EventArgs e)
        {
            if (butStyle == STYLE.OFFICE2007BLUE)
            {
                if (isFocus == true)
                {
                    isFocus = false;
                    bmpOffsetY = 0;
                    Invalidate();
                }
            }            
        }

        private void OnEnter(object sender, EventArgs e)
        {
            if (butStyle == STYLE.OFFICE2007BLUE)
            {
                bmpOffsetY = (BMPBACKHEIGHT * 3) - BMPBACKHEIGHT;
                
                isFocus = true;
            }
            Invalidate();
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (butStyle == STYLE.OFFICE2007BLUE)
                {
                    bmpOffsetY = (BMPBACKHEIGHT * 5) - BMPBACKHEIGHT;
                }
                Invalidate();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
