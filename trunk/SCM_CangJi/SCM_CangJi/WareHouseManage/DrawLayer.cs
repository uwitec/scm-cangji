using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace SCM_CangJi.WareHouseManage
{
    class DrawLayer
    {
        #region 常量
        public enum ARROW { LEFT, RIGHT }
        private const int ARROWWH = 5;
        private const int ADDYOFFSET = 14;
        #endregion

        public DrawLayer()
        {           
        }

        #region 画渐变圆角矩形
        public void DrawRounded(Graphics pDC, int x, int y, int iwidth, int iheight, Color colorStrat, Color colorEnd)
        {
            Pen pen;
            
            Brush brush = new LinearGradientBrush(new Rectangle(x, y, iwidth, iheight),
                        colorStrat, colorEnd, LinearGradientMode.Vertical);
            pDC.FillRectangle(brush, x+2, y+2, iwidth-4, iheight-3);

            DrawRounded(pDC, x, y, iwidth, iheight);

            return;


            //tab
            //LEFT-LINE
            
            pDC.DrawLine(pen, x, y, x, y + iheight);
            
            //pDC.DrawLine(pen, x + 1, y, x + 1, y + 1);
            //pDC.DrawLine(pen, x + 1, y + iheight - 1, x + 1, y + iheight);
            
            //TOP-LINE
            pDC.DrawLine(pen, x + 1, y - 1, x + iwidth, y - 1);

            //RIGHT-LINE
            pDC.DrawLine(pen, x + iwidth, y, x + iwidth, y + iheight);
            //pDC.DrawLine(pen, x + iwidth - 1, y, x + iwidth - 1, y + 1);
            //pDC.DrawLine(pen, x + iwidth - 1, y + iheight - 1, x + iwidth - 1, y + iheight);

            //BOTTOM-LINE
            pDC.DrawLine(pen, x + 1, y + iheight, x + iwidth, y + iheight);

            brush.Dispose();
        }
        
        public void DrawRounded(Graphics pDC, int x, int y, int iwidth, int iheight)
        {

            DrawRounded(pDC, Color.FromArgb(105, 187, 255), Color.FromArgb(251, 253, 253), x, y, iwidth, iheight);
            /*
            Pen pen;

            //pen = new Pen(Color.FromArgb(244, 243, 234));
            //pen = new Pen(Color.FromArgb(213, 221, 230));
            //Pen pen1 = new Pen(Color.FromArgb(251, 253, 253));

            pen = new Pen(Color.FromArgb(105, 187, 255));
            Pen pen1 = new Pen(Color.FromArgb(251, 253, 253));

            //left
            pDC.DrawLine(pen, x, y + 2, x, y + iheight - 2);
            pDC.DrawLine(pen1, x + 1, y + 2, x + 1, y + iheight - 2);

            //top
            pDC.DrawLine(pen, x + 2, y, (x + iwidth) - 2, y);
            pDC.DrawLine(pen1, x + 2, y + 1, (x + iwidth) - 2, y + 1);

            //right
            pDC.DrawLine(pen, x + iwidth, y + 2, x + iwidth, y + iheight - 2);
            pDC.DrawLine(pen1, x + iwidth - 1, y + 2, x + iwidth - 1, y + iheight - 2);

            //bottom
            pDC.DrawLine(pen, x + 2, y + iheight, (x + iwidth) - 2, y + iheight);
            pDC.DrawLine(pen1, x + 2, y + iheight - 1, (x + iwidth) - 2, y + iheight - 1);

            //设置圆角
            pDC.DrawLine(pen, x + 1, y, x + 1, y + 1);//上左竖
            pDC.DrawLine(pen, x, y + 1, x + 1, y + 1);//上左横

            pDC.DrawLine(pen, x + iwidth - 1, y, x + iwidth - 1, y + 1);//上右竖
            pDC.DrawLine(pen, x + iwidth - 1, y + 1, x + iwidth, y + 1);//上右横

            pDC.DrawLine(pen, x + 1, y + iheight - 1, x + 1, y + iheight);//下左竖
            pDC.DrawLine(pen, x, y + iheight - 1, x + 1, y + iheight - 1);//下左横

            pDC.DrawLine(pen, x + iwidth - 1, y + iheight - 1, x + iwidth - 1, y + iheight);//下右竖
            pDC.DrawLine(pen, x + iwidth - 1, y + iheight - 1, x + iwidth, y + iheight - 1);//下右横
             * */
        }

        public void DrawRounded(Graphics pDC, Color color1, Color color2, int x, int y, int iwidth, int iheight, Color colorStrat, Color colorEnd)
        {
            Brush brush = new LinearGradientBrush(new Rectangle(x, y, iwidth, iheight),
                        colorStrat, colorEnd, LinearGradientMode.Vertical);
            pDC.FillRectangle(brush, x + 2, y + 2, iwidth - 4, iheight - 3);

            DrawRounded(pDC, color1, color2, x, y, iwidth, iheight);

            brush.Dispose();
        }

        public void DrawRounded(Graphics pDC, Color color1, Color color2, int x, int y, int iwidth, int iheight)
        {
            Pen frame1 = new Pen(color1);
            Pen frame2 = new Pen(color2);

            //left
            pDC.DrawLine(frame1, x, y + 2, x, y + iheight - 3);
            pDC.DrawLine(frame2, x + 1, y + 2, x + 1, y + iheight - 3);

            //top
            pDC.DrawLine(frame1, x + 2, y, (x + iwidth) - 3, y);
            pDC.DrawLine(frame2, x + 2, y + 1, (x + iwidth) - 3, y + 1);
            
            //right
            pDC.DrawLine(frame1, x + iwidth-1, y + 2, x + iwidth-1, y + iheight - 3);
            pDC.DrawLine(frame2, x + iwidth - 2, y + 2, x + iwidth - 2, y + iheight - 3);
            
            //bottom
            pDC.DrawLine(frame1, x + 2, y + iheight-1, (x + iwidth) - 3, y + iheight-1);
            pDC.DrawLine(frame2, x + 2, y + iheight - 2, (x + iwidth) - 3, y + iheight - 2);
            
            //设置圆角
            pDC.DrawLine(frame1, x + 1, y, x + 1, y + 1);//上左竖
            pDC.DrawLine(frame1, x, y + 1, x + 1, y + 1);//上左横
            
            pDC.DrawLine(frame1, x + iwidth - 2, y, x + iwidth - 2, y + 1);//上右竖
            pDC.DrawLine(frame1, x + iwidth - 2, y + 1, x + iwidth - 1, y + 1);//上右横
            
            pDC.DrawLine(frame1, x + 1, y + iheight - 2, x + 1, y + iheight-1);//下左竖
            pDC.DrawLine(frame1, x, y + iheight - 2, x + 1, y + iheight - 2);//下左横
            
            pDC.DrawLine(frame1, x + iwidth - 2, y + iheight - 2, x + iwidth - 2, y + iheight-1);//下右竖
            pDC.DrawLine(frame1, x + iwidth - 2, y + iheight - 2, x + iwidth - 1, y + iheight - 2);//下右横
        }
        #endregion

        #region 画添加箭头
        public void DrawArrow(Graphics pDC, Rectangle rect, Pen pen, ARROW flags)
        {
            //箭头向左边
            if (flags == ARROW.LEFT)
            {
                //1-上
                int a = rect.Top + (rect.Height * 2 + 1);
                int y = rect.Top + rect.Height + 1;
                pDC.DrawLine(pen, rect.Left + rect.Width, rect.Top + (rect.Height * 2 + 1),
                    rect.Left + (rect.Width * 2), rect.Top + rect.Height + 1);
                //1-下
                pDC.DrawLine(pen, rect.Left + rect.Width, rect.Top + (rect.Height * 2 + 1),
                     rect.Left + (rect.Width * 2), rect.Top + (rect.Height * 3) + 1);

                //2-上
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2 + 1), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + rect.Width + (rect.Width * 2 + 1), rect.Top + rect.Height + 1);

                //2-下
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2 + 1), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + rect.Width + (rect.Width * 2 + 1), rect.Top + (rect.Height * 3) + 1);
            }

            //箭头向右边
            if (flags == ARROW.RIGHT)
            {
                //1-上
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2), rect.Top + (rect.Height * 2 + 1),
                    rect.Left + rect.Width, rect.Top + rect.Height + 1);

                //1-下
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + rect.Width, rect.Top + (rect.Height * 3) + 1);

                //2-上
                pDC.DrawLine(pen, rect.Left + rect.Width + (rect.Width * 2 + 1), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + (rect.Width * 2 + 1), rect.Top + rect.Height + 1);

                //2-下
                pDC.DrawLine(pen, rect.Left + rect.Width + (rect.Width * 2 + 1), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + (rect.Width * 2 + 1), rect.Top + (rect.Height * 3) + 1);
            }

        }
        #endregion

        #region 获取字符串像素宽度
        public int GetStringPixelWidth(Control wnd, string str, Font font)
        {
            SizeF siFont = GetStringPixelSize(wnd, str, font);
            return (int)siFont.Width;
        }

        public SizeF GetStringPixelSize(Control wnd, string str, Font font)
        {
            Graphics g = wnd.CreateGraphics();
            SizeF siFont = g.MeasureString(str, font);
            g.Dispose();
            return siFont;
        }
        #endregion

        #region 获取字符串可以显示的长度
        public int GetStringShowLength(Control wnd, string str, Font font, int showwidth)
        {
            int fontWidth = GetStringPixelWidth(wnd, str, font);
            int showlen = GetStringShowLength(str, fontWidth, showwidth);

            return showlen;
        }

        public int GetStringShowLength(string str, int pixelwidth, int showwidth)
        {
            int len = System.Text.Encoding.Default.GetByteCount(str);
            int showlen = showwidth / (pixelwidth / len) - 10;

            return showlen;
        }
        #endregion

        #region 格式化字符串长度超出部分显示省略号(...)
        public String StringFormat(String str, int n)
        {
            String temp = String.Empty;
            int len = System.Text.Encoding.Default.GetByteCount(str);
            if (len <= n)//长度比需要的长度小返回原字符串
            {
                return str;
            }
            else
            {
                int l = 0;
                char[] bty = str.ToCharArray();
                for (int i = 0; i < bty.Length && l < n; i++)
                {
                    if ((int)bty[i] >= 0x4e00 && (int)bty[i] <= 0x9fa5)//是否汉字
                    {
                        temp += bty[i];
                        l += 2;
                    }
                    else
                    {
                        temp += bty[i];
                        l++;
                    }
                }
                return (temp + "...");
            }
        }
        #endregion
    }
}
