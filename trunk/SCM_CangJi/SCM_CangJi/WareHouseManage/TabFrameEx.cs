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
using DevExpress.XtraEditors;

namespace SCM_CangJi.WareHouseManage
{
    public class TabFrameEx : Panel
    {
        TextBox box;
        int ooo = 1;
        bool isAdd = false;
        #region 变量
        int tabXOffset;
        DrawLayer drawLayer;

        int m_tabWidth = 0;

        public Rectangle tabItemRect;
        private Rectangle m_rectFrame;
        
        private const int XFRAMEOFF = 90;

        int tabFrameWidth = 874;
        int tabFrameLeft = 250;
        int tabFrameTop = 53;
        int tabFrameHeight = 20;

        int iPagBarCol = 1;	//要显示的Tab数量,根据每个Tab项的宽自动调整
        int ipagBarIndex = 1;

        int m_iClickPos;    //选中的Tab
        Color starColor = Color.FromArgb(251, 252, 253);
        Color DefaultTabOutRGB = Color.FromArgb(235, 229, 214);	//默认选中颜色
        Color DefaultTabInRGB = Color.FromArgb(105, 187, 255);	//默认选中颜色

        Pen p = new Pen(Color.FromArgb(172, 168, 153), 2);
        Pen pSeclectPen = new Pen(Color.FromArgb(255, 200, 60), 2);
        Pen pClickPen;

        Bitmap bitmap;

        //TAB选项卡结构
        private struct TABINFO
        {
            public String strName;
            public String strID;
            public Rectangle rect;
            public int Width;
            public Color bkClr;
            public Region tabRgn;
            public IntPtr pParent;
            public uint uIcon;
            public uint nFlags;	//有焦点状态
            public uint nClick;	//选中状态
            public uint show;
            public bool IsDisplay;
        }
        TABINFO m_TabInfo;
        List<TABINFO> m_arTabInfo;

        Font m_Font = new Font("宋体", 10, FontStyle.Bold);// | FontStyle.Italic
        #endregion

        #region Win32
        private const int ALTERNATE = 1;

        [StructLayout(LayoutKind.Sequential)]

        #region POINT
        public struct POINT
        {
            public int x;
            public int y;
        }
        #endregion

        #region API
        [DllImport("gdi32.dll")]
        private static extern IntPtr CreatePolygonRgn(ref POINT lpPoint, int nCount, int nPolyFillMode);
        #endregion

        #endregion

        public TabFrameEx()
        {
            InitializeVariable();
            InitializeComponent();
        }

        private void InitializeVariable()
        {
            tabXOffset = 0;

            tabItemRect = new Rectangle();
            drawLayer = new DrawLayer();
        }

        public void SetTabXOffset(int xoffset)
        {
            tabXOffset = xoffset;
        }
        
        public TabFrameEx(TextBox textBox1)
        {
            box = textBox1;
            InitializeComponent();
        }

        public Rectangle GetClientRect()
        {
            return new Rectangle(m_rectFrame.Left + 8, m_rectFrame.Top + 5,
                m_rectFrame.Width - 16 , (m_rectFrame.Height - 13));
        }
        public void SetWindowsPos(int x, int y, int w, int h)
        {
            //tab项的矩形
            tabItemRect.X = x + tabXOffset + 100;
            tabItemRect.Y = y;// y + 1;
            tabItemRect.Width = w - (100 + 50 + tabXOffset);
            tabItemRect.Height = 20;

            //框架的矩形
            m_rectFrame.X = x + 5;
            m_rectFrame.Width = w - 15 - x;
        }

        private void InitializeComponent()
        {
            m_TabInfo = new TABINFO();
            m_arTabInfo = new List<TABINFO>();
            m_iClickPos = -1;
            m_rectFrame = new Rectangle();

            this.Name = "StorageAreFrame";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
        }

        public Rectangle GetFrameRect() { return m_rectFrame; }

        public void DrawTab(Graphics pDC)
        {
            DrawTabItem(pDC);
        }

        private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //开启双缓冲
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            /*
            String str = tabFrameWidth.ToString();
           
            Graphics g = e.Graphics;

            SolidBrush solidbrush = new SolidBrush(Color.DarkGreen);

            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            // Create rectangle.
            Rectangle rect = new Rectangle(tabItemRect.X, 1, tabItemRect.Width, 5);


           
            g.FillRectangle(blueBrush, rect);
            */

            //DrawTabItem(e.Graphics);

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //MoveTabItem(1, m_iClickPos);
                //AddTabItem("货架-" + ooo.ToString() + ":aaaa", "asa", 1, DefaultTabOutRGB);
                //MoveTabItem(1, m_iClickPos);
                /*
                TABINFO a;
                bool b = false;
                for (int y = 0; y < m_arTabInfo.Count(); y++)
                {
                    if (m_arTabInfo[y].show == 2)
                    {
                        a = m_arTabInfo[y];
                        a.IsDisplay = false;
                        a.show = 1;
                        m_arTabInfo[y] = a;

                        b = true;
                    }

                }
                */
                /*
                //对齐LEFT
                if (b)
                {
                    for (int y = 0; y < m_arTabInfo.Count(); y++)
                    {
                        if (m_arTabInfo[y].IsDisplay == true)
                        {
                            a = m_arTabInfo[y];
                            a.IsDisplay = true;
                            a.rect.X = tabItemRect.Left;
                            a.rect.Width += m_arTabInfo[y + 1].rect.Left - a.rect.Right;
                            m_arTabInfo[y] = a;
                            return;

                        }

                    }
                }
                 * */

                ooo += 1;

                Invalidate();
            }

            if (e.Button == MouseButtons.Left)
            {
                TABINFO update;
                for (int i = 0; i < m_arTabInfo.Count(); i++)
                {
                    if (m_arTabInfo[i].IsDisplay == false)
                        continue;

                    if (m_arTabInfo[i].tabRgn.IsVisible(e.X, e.Y))
                    {
                        //box.Text = m_arTabInfo[m_iClickPos].rect.Left.ToString();
                        update = m_arTabInfo[i];
                        update.nClick = 1;
                        update.nFlags = 1;
                        m_arTabInfo[i] = update;

                        if (m_iClickPos > -1 && m_iClickPos != i)
                        {
                            update = m_arTabInfo[m_iClickPos];
                            update.nClick = 0;
                            update.nFlags = 0;
                            m_arTabInfo[m_iClickPos] = update;
                        }

                        m_iClickPos = i;

                        if (m_arTabInfo[m_iClickPos].rect.Left == tabItemRect.Left)
                        {
                            isAdd = false;
                            MoveTabItem(2, m_iClickPos);
                            Invalidate();
                        }

                        if (m_arTabInfo[m_iClickPos].rect.Right >= tabItemRect.Right)
                        {
                            //XtraMessageBox.Show("向下翻页");
                            isAdd = false;
                            MoveTabItem(3, m_iClickPos);
                            Invalidate();
                        }


                        //UpdatePagCount(m_iClickPos);
                        //GetPagBarIndex(m_iClickPos + 1);
                        //AutoMovePage(m_iClickPos + 1);
                        return;

                    }
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < m_arTabInfo.Count(); i++)
            {
                if (m_arTabInfo[i].IsDisplay == false)
                    continue;

                if (m_arTabInfo[i].tabRgn.IsVisible(e.X, e.Y))
                {
                    TABINFO update;
                    update = m_arTabInfo[i];
                    update.nFlags = 1;
                    m_arTabInfo[i] = update;

                    this.Invalidate();
                    return;
                }
            }
        }

        #region 添加Tab选项
        public void AddTabItem(String szName, String szID)
        {
            AddTabItem(szName, szID, 1, DefaultTabOutRGB);
        }

        public void AddTabItem(String szName, String szID, uint nIcon, Color cbk)
        {
            int iTabCout = m_arTabInfo.Count();
            
            int iFontWidth = drawLayer.GetStringPixelWidth(this, szName, m_Font);

            POINT[] pointRgn = new POINT[7];

            m_TabInfo.nClick = 1;
            m_TabInfo.strName = szName;
            m_TabInfo.strID = szID;
            m_TabInfo.nFlags = 0;
            m_TabInfo.uIcon = nIcon;
            m_TabInfo.bkClr = cbk;
            m_TabInfo.tabRgn = new Region();
            m_TabInfo.rect = new Rectangle();
            m_TabInfo.IsDisplay = true;

            m_TabInfo.rect.Y = tabItemRect.Top;
            m_TabInfo.rect.Height = tabItemRect.Height;

            //字体的宽度是否超出TAB的宽度，是就用TAB宽度的一半给iFontWidth作为值
            if (iFontWidth >= tabItemRect.Width / 2)
            {
                if((tabItemRect.Right / 2) - tabItemRect.Left>0)
                {
                    iFontWidth = (tabItemRect.Right / 2) - tabItemRect.Left;
                }
            }

            m_TabInfo.Width = iFontWidth + 25;

            if (iTabCout > 0)
            {
                m_TabInfo.rect.X = m_arTabInfo[iTabCout - 1].rect.Right;
                m_TabInfo.rect.Width = m_TabInfo.Width;
                m_tabWidth = m_tabWidth + m_TabInfo.rect.Width;

                /*
                pointRgn[0].x   = m_TabInfo.rect.left + 3;
                pointRgn[0].y   = m_TabInfo.rect.bottom - 6;
                pointRgn[1].x   = m_TabInfo.rect.left + 12;
                pointRgn[1].y   = m_TabInfo.rect.top + 5;

                pointRgn[6].x   = m_TabInfo.rect.left + 3;
                pointRgn[6].y   = m_TabInfo.rect.bottom;
                 * */
            }
            else
            {
                m_iClickPos = 0;
                m_TabInfo.rect.X = tabItemRect.Left;//14
                m_TabInfo.rect.Width = m_TabInfo.Width;
                m_tabWidth = tabItemRect.Left + m_TabInfo.rect.Width;

                /*
                pointRgn[0].x   = m_TabInfo.rect.left - 3;
                pointRgn[0].y   = m_TabInfo.rect.bottom;
                pointRgn[1].x   = m_TabInfo.rect.left + 12;
                pointRgn[1].y   = m_TabInfo.rect.top + 5;
		
                pointRgn[6].x   = m_TabInfo.rect.left - 3;
                pointRgn[6].y   = m_TabInfo.rect.bottom;
                 * */
            }

            if (m_tabWidth >= tabItemRect.Right)
            {
            }

            pointRgn[0].x = m_TabInfo.rect.Left - 3;
            pointRgn[0].y = m_TabInfo.rect.Bottom;
            pointRgn[1].x = m_TabInfo.rect.Left + 12;
            pointRgn[1].y = m_TabInfo.rect.Top + 5;

            pointRgn[6].x = m_TabInfo.rect.Left - 3;
            pointRgn[6].y = m_TabInfo.rect.Bottom;

            pointRgn[2].x = m_TabInfo.rect.Left + 16;
            pointRgn[2].y = m_TabInfo.rect.Top + 2;
            pointRgn[3].x = m_TabInfo.rect.Right + 1;
            pointRgn[3].y = m_TabInfo.rect.Top + 2;
            pointRgn[4].x = m_TabInfo.rect.Right + 4;
            pointRgn[4].y = m_TabInfo.rect.Top + 5;
            pointRgn[5].x = m_TabInfo.rect.Right + 4;
            pointRgn[5].y = m_TabInfo.rect.Bottom;

            IntPtr tabRgn = CreatePolygonRgn(ref pointRgn[0], 7, ALTERNATE);
            m_TabInfo.tabRgn = Region.FromHrgn(tabRgn);

            m_arTabInfo.Add(m_TabInfo);
            SetClickTabPos(iTabCout);

        }
        #endregion

        //货取能显示的Tab数量
        public int GetShowTabCount()
        {
            int count = 0;
            for (int i = 0; i < m_arTabInfo.Count(); i++)
            {
                if (m_arTabInfo[i].IsDisplay == true)
                {
                    count = count + 1;
                }
            }

            return count;
        }

        //货取能Tab数量
        public int GetTabItemCount()
        {
            return m_arTabInfo.Count();
        }

        public void ClearTabItem()
        {
            m_arTabInfo.Clear();
        }

        public void MoveTabItem(int flags, int click)
        {
            if (click - 1 < 0)
                return;

            int width = m_tabWidth;//tabItemRect.Left;

            TABINFO update;
            int newx = 0;

            bool isFirst = true;
            bool isShow = false;

            #region 调整新添加Tab项的位置
            if (flags == 1)     //添加
            {
                for (int i1 = 0; i1 < m_arTabInfo.Count(); i1++)
                {
                    if (m_arTabInfo[i1].show == 2)
                    {
                        update = m_arTabInfo[i1];
                        //update.IsDisplay = false;
                        m_arTabInfo[i1] = update;
                    }
                }

                //新增加的宽度是否超出了总Tab的宽度
                width = m_arTabInfo[click].rect.Left + m_arTabInfo[click].rect.Width;
                if (width >= tabItemRect.Right)//超出总Tab的宽度就右对齐
                {
                    isAdd = true;
                    update = m_arTabInfo[click];
                    update.rect.Width = update.Width;
                    m_arTabInfo[click] = update;
                    newx = tabItemRect.Right - m_arTabInfo[click].rect.Width;
                    UpdateTabInfo(click, newx, true);

                    //向右对齐
                    for (int i = click - 1; i >= 0; i--)
                    {
                        //update = m_arTabInfo[i+1];
                        //update.rect.Width = update.Width;
                        // m_arTabInfo[i + 1] = update;

                        newx = m_arTabInfo[i + 1].rect.Left - m_arTabInfo[i].rect.Width;

                        //判断是否超出左边界
                        if (newx >= tabItemRect.Left)
                        {
                            UpdateTabInfo(i, newx, true);
                        }
                        else
                        {
                            /*
                            //左对齐
                            if (isFirst == true)
                            {
                                if (i + 2 < m_arTabInfo.Count())
                                {
                                    update = m_arTabInfo[i + 1];
                                    update.rect.X = tabItemRect.Left;
                                    update.rect.Width += (m_arTabInfo[i + 2].rect.Left - update.rect.Right);
                                    m_arTabInfo[i + 1] = update;
                                    UpdateTabInfo(i + 1, update.rect.X, true);
                                }
                                isFirst = false;
                            }
                            else
                            {
                                UpdateTabInfo(i, newx, false);
                            }
                            */
                            UpdateTabInfo(i, newx, false);
                        }
                    }

                    //补齐左边的位置
                    for (int i = 0; i < m_arTabInfo.Count(); i++)
                    {
                        if (m_arTabInfo[i].IsDisplay == true)
                        {
                            int xx = m_arTabInfo[i].rect.Left - tabItemRect.Left;
                            if (i - 1 >= 0 && i + 1 < m_arTabInfo.Count())
                            {
                                if (m_arTabInfo[i - 1].Width / 2 <= xx && m_arTabInfo[i - 1].Width < xx)//容纳下就显示前面一个
                                {
                                    update = m_arTabInfo[i - 1];
                                    update.rect.X = tabItemRect.Left;
                                    update.rect.Width += (m_arTabInfo[i].rect.Left - update.rect.Right);
                                    m_arTabInfo[i - 1] = update;

                                    UpdateTabInfo(i - 1, tabItemRect.Left, true);
                                }
                                else//容纳不下就拉伸当前项
                                {
                                    update = m_arTabInfo[i];
                                    update.rect.X = tabItemRect.Left;
                                    update.rect.Width += (m_arTabInfo[i + 1].rect.Left - update.rect.Right);
                                    m_arTabInfo[i] = update;

                                    UpdateTabInfo(i, tabItemRect.Left, true);
                                }
                            }

                            break;
                        }
                    }
                }

                //显示最小数量为2,不足的补齐2
                if (GetShowTabCount() < 2)
                {
                    //XtraMessageBox.Show("显示最小数量不足2,将用"+m_arTabInfo[m_iClickPos - 1].strName+"补足");
                    update = m_arTabInfo[m_iClickPos - 1];
                    update.rect.Width = m_arTabInfo[m_iClickPos].rect.Left - tabItemRect.Left;
                    m_arTabInfo[m_iClickPos - 1] = update;
                    UpdateTabInfo(m_iClickPos - 1, tabItemRect.Left, true);
                }

            }
            #endregion

            #region 向上调整位置
            if (flags == 2)
            {
                //隐藏后面的
                for (int i = click + 2; i < m_arTabInfo.Count(); i++)
                {
                    update = m_arTabInfo[i];
                    update.IsDisplay = false;
                    m_arTabInfo[i] = update;
                }

                //显示后面一个
                update = m_arTabInfo[click + 1];
                update.rect.Width = update.Width;
                update.rect.X = tabItemRect.Right - update.Width;
                update.show = 2;
                m_arTabInfo[click + 1] = update;
                UpdateTabInfo(click + 1, update.rect.X, true);

                //向右对齐
                for (int i = click; i >= 0; i--)
                {
                    update = m_arTabInfo[i];
                    update.rect.Width = update.Width;
                    update.show = 2;
                    m_arTabInfo[i] = update;

                    newx = m_arTabInfo[i + 1].rect.Left - m_arTabInfo[i].rect.Width;

                    //判断是否超出左边界
                    if (newx >= tabItemRect.Left)
                    {
                        UpdateTabInfo(i, newx, true);
                    }
                    else
                    {
                        UpdateTabInfo(i, newx, false);
                    }
                }

                //补齐左边的位置
                for (int i = 0; i < m_arTabInfo.Count(); i++)
                {
                    if (m_arTabInfo[i].IsDisplay == true)
                    {

                        if (i == 0)//左对齐
                        {
                            isFirst = true;
                            for (int z = 0; z < m_arTabInfo.Count(); z++)
                            {
                                if (z == 0)
                                {
                                    UpdateTabInfo(z, tabItemRect.Left, true);
                                }
                                else
                                {
                                    update = m_arTabInfo[z];
                                    update.rect.X = m_arTabInfo[z - 1].rect.Right;

                                    m_arTabInfo[z] = update;

                                    if (update.rect.Right <= tabItemRect.Right)
                                    {
                                        UpdateTabInfo(z, m_arTabInfo[z - 1].rect.Right, true);
                                    }
                                    else
                                    {
                                        if (isFirst == true)
                                        {
                                            //超出了把上一个右对齐
                                            TABINFO u;
                                            u = m_arTabInfo[z - 1];
                                            u.rect.Width += (tabItemRect.Right - u.rect.Right);
                                            m_arTabInfo[z - 1] = u;
                                            UpdateTabInfo(z - 1, u.rect.X, true);
                                            isFirst = false;
                                        }
                                        else
                                        {
                                            UpdateTabInfo(z, m_arTabInfo[z].rect.Left, false);
                                        }
                                    }
                                }
                            }
                            break;
                        }

                        int xx = m_arTabInfo[i].rect.Left - tabItemRect.Left;
                        if (i - 1 >= 0 && i + 1 < m_arTabInfo.Count())
                        {
                            if (m_arTabInfo[i - 1].Width / 2 <= xx && m_arTabInfo[i - 1].Width < xx)//容纳下就显示前面一个
                            {
                                update = m_arTabInfo[i - 1];
                                update.rect.X = tabItemRect.Left;
                                update.rect.Width += (m_arTabInfo[i].rect.Left - update.rect.Right);
                                m_arTabInfo[i - 1] = update;

                                UpdateTabInfo(i - 1, tabItemRect.Left, true);
                            }
                            else//容纳不下就拉伸当前项
                            {
                                update = m_arTabInfo[i];
                                update.rect.X = tabItemRect.Left;
                                update.rect.Width += (m_arTabInfo[i + 1].rect.Left - update.rect.Right);
                                m_arTabInfo[i] = update;

                                UpdateTabInfo(i, tabItemRect.Left, true);
                            }
                        }

                        break;
                    }
                }

                //显示最小数量为3,不足的补齐3,右对齐
                if (GetShowTabCount() < 3)
                {
                    //XtraMessageBox.Show("显示最小数量为3,不足的补齐3,右对齐");
                    //后面一个
                    update = m_arTabInfo[m_iClickPos + 1];
                    update.rect.X = tabItemRect.Right - update.Width / 2;
                    update.rect.Width = update.Width / 2;
                    m_arTabInfo[m_iClickPos + 1] = update;
                    UpdateTabInfo(m_iClickPos + 1, update.rect.Left, true);

                    //当前
                    update = m_arTabInfo[m_iClickPos];
                    update.rect.Width = update.Width;
                    update.rect.X = m_arTabInfo[m_iClickPos + 1].rect.Left - update.rect.Width;
                    m_arTabInfo[m_iClickPos] = update;
                    UpdateTabInfo(m_iClickPos, update.rect.Left, true);

                    //前面
                    update = m_arTabInfo[m_iClickPos - 1];
                    update.rect.X = tabItemRect.Left;
                    update.rect.Width += (m_arTabInfo[m_iClickPos].rect.Left - update.rect.Right);
                    m_arTabInfo[m_iClickPos - 1] = update;
                    UpdateTabInfo(m_iClickPos - 1, update.rect.Left, true);
                }




                return;
                //显示后面一个
                update = m_arTabInfo[click + 1];
                update.rect.Width = update.Width;
                update.rect.X = tabItemRect.Right - update.Width;
                update.show = 2;
                m_arTabInfo[click + 1] = update;
                UpdateTabInfo(click + 1, update.rect.X, true);

                //检查前面的Tab项
                for (int i = click; i >= 0; i--)
                {
                    //向前
                    update = m_arTabInfo[i];
                    update.rect.Width = update.Width;
                    update.rect.X = m_arTabInfo[i + 1].rect.Left - update.Width;
                    //检查左边界是否超出
                    if (update.rect.X > tabItemRect.Left)//没超出
                    {
                        m_arTabInfo[i] = update;
                        UpdateTabInfo(i, update.rect.X, true);
                    }
                    else//超出
                    {
                        UpdateTabInfo(i, update.rect.X, false);
                    }

                }

                //更新自己的位置并显示
                update = m_arTabInfo[click];
                update.rect.Width = update.Width;
                update.rect.X = m_arTabInfo[click + 1].rect.Left - update.Width;
                //检查自己的左边界是否超出
                if (update.rect.X < tabItemRect.Left)//是
                {
                    XtraMessageBox.Show("自己的边界超出了250");
                    //update.rect.Width = update.rect.Width / 2;
                    //update.rect.X = m_arTabInfo[click + 1].rect.Left - update.rect.Width;
                    //m_arTabInfo[click] = update;
                    //UpdateTabInfo(click, update.rect.X, true);
                }
                else//否
                {
                    m_arTabInfo[click] = update;
                    UpdateTabInfo(click, update.rect.X, true);


                }


                //再次检查自己的左边界是否超出了
                isFirst = true;
                if (m_arTabInfo[click].rect.Left <= tabItemRect.Left)//是
                {
                    //XtraMessageBox.Show("自己的左边界超出 " + m_arTabInfo[click].strName);
                    update = m_arTabInfo[click + 1];
                    update.rect.Width = update.Width / 2;
                    update.rect.X = tabItemRect.Right - update.rect.Width;

                    update.show = 2;
                    m_arTabInfo[click + 1] = update;
                    UpdateTabInfo(click + 1, update.rect.X, true);

                    //更新自己的位置并显示
                    update = m_arTabInfo[click];
                    update.rect.Width = update.Width;
                    update.rect.X = m_arTabInfo[click + 1].rect.Left - update.Width;

                    m_arTabInfo[click] = update;
                    UpdateTabInfo(click, update.rect.X, true);

                    //检查前面的Tab项
                    for (int i = click - 1; i >= 0; i--)
                    {
                        update = m_arTabInfo[i];
                        update.rect.Width = update.Width;
                        update.rect.X = m_arTabInfo[i + 1].rect.Left - update.Width;
                        //检查左边界是否超出
                        if (update.rect.X >= tabItemRect.Left)//没超出
                        {
                            m_arTabInfo[i] = update;
                            UpdateTabInfo(i, update.rect.X, true);
                        }
                        else//超出
                        {
                            if (isFirst == true)
                            {
                                //超出的第一个左对齐
                                TABINFO u;
                                u = m_arTabInfo[i + 1];
                                //XtraMessageBox.Show(u.strName);
                                u.rect.X = tabItemRect.Left;
                                u.rect.Width += (m_arTabInfo[i + 2].rect.Left - u.rect.Right);
                                m_arTabInfo[i + 1] = u;
                                UpdateTabInfo(i + 1, u.rect.X, true);
                                isFirst = false;
                            }
                            else
                            {
                                UpdateTabInfo(i, update.rect.X, false);
                            }
                        }
                    }
                }

                //隐藏后面的
                for (int i = click + 2; i < m_arTabInfo.Count(); i++)
                {

                    update = m_arTabInfo[i];
                    // XtraMessageBox.Show(update.strName);
                    update.IsDisplay = false;
                    m_arTabInfo[i] = update;
                }

                if (m_arTabInfo[0].IsDisplay == true)
                {
                    int left;
                    if (m_arTabInfo[0].rect.Left > tabItemRect.Left)
                    {
                        left = m_arTabInfo[0].rect.Left - tabItemRect.Left;
                        for (int i = 0; i < m_arTabInfo.Count(); i++)
                        {
                            update = m_arTabInfo[i];
                            if (i == 0)
                                update.rect.X = tabItemRect.Left;
                            else
                                update.rect.X = m_arTabInfo[i - 1].rect.Right;

                            m_arTabInfo[i] = update;
                            UpdateTabInfo(i, update.rect.X, true);

                        }
                    }
                }
                /*

                for (int i = click + 1; i >= 0; i--)
                {
                    update = m_arTabInfo[i];
                    update.rect.Width = update.Width;
                    update.show = 2;
                    if (i == click + 1)
                    {
                        update.rect.X = tabItemRect.Right - update.Width;
                        isShow = true;
                    }
                    else
                    {
                        update.rect.X = m_arTabInfo[i + 1].rect.Left - update.Width;
                        if (update.rect.X >= tabItemRect.Left)
                        {
                            isShow = true;
                        }
                        else
                        {
                            if (isFirst == true)
                            {
                                //左对齐第一个
                                update = m_arTabInfo[i + 1];
                                update.rect.X = tabItemRect.Left;
                                update.rect.Width += (m_arTabInfo[i + 2].rect.Left - update.rect.Right);
                                m_arTabInfo[i + 1] = update;
                                UpdateTabInfo(i + 1, update.rect.X, true);

                                isFirst = false;
                            }
                            isShow = false;
                        }

                    }
                    m_arTabInfo[i] = update;
                    UpdateTabInfo(i, update.rect.X, isShow);
                }

                //检查自己的左边界是否超出了
                if (m_arTabInfo[click].rect.Left <= tabItemRect.Left)
                {
                    XtraMessageBox.Show("自己的左边界超出 " + m_arTabInfo[click].strName);
                    update = m_arTabInfo[click];
                    update.rect.Width = update.Width;
                    update.rect.X = tabItemRect.Right - update.Width;
                    m_arTabInfo[click] = update;
                    UpdateTabInfo(click, update.rect.X, true);
                    return;
                }
                */

            }

            #endregion

            #region 向下调整位置
            if (flags == 3)
            {
                if (click - 1 < 0 || click + 1 >= m_arTabInfo.Count())
                    return;

                //隐藏前面的
                for (int i = click + 1; i >= 0; i--)
                {
                    update = m_arTabInfo[i];
                    update.IsDisplay = false;
                    m_arTabInfo[i] = update;
                }

                //前面一个左对齐
                update = m_arTabInfo[click - 1];
                update.rect.Width = update.Width;
                update.rect.X = tabItemRect.Left;
                update.show = 2;
                m_arTabInfo[click - 1] = update;
                UpdateTabInfo(click - 1, update.rect.X, true);

                //向左对齐所有
                for (int i = click; i < m_arTabInfo.Count(); i++)
                {
                    update = m_arTabInfo[i];
                    update.rect.Width = update.Width;
                    update.show = 2;
                    m_arTabInfo[i] = update;
                    if (m_arTabInfo[i - 1].rect.Right <= tabItemRect.Right)
                    {
                        UpdateTabInfo(i, m_arTabInfo[i - 1].rect.Right, true);
                    }
                    else
                    {
                        UpdateTabInfo(i, m_arTabInfo[i - 1].rect.Right, false);
                    }
                }
            }
            #endregion
            m_tabWidth = width;
        }

        //更新Tab项的位置
        public void UpdateTabInfo()
        {
            bool isFirst = true;
            int tempRight = 0;
            POINT[] pointRgn = new POINT[7];
            TABINFO update;

            for (int i = 0; i < m_arTabInfo.Count(); i++)
            {
                m_arTabInfo[i].tabRgn.Dispose();

                if (m_arTabInfo[i].IsDisplay == true)
                {
                    update = m_arTabInfo[i];

                    if (isFirst == true)
                    {
                        isFirst = false;
                        update.rect.X = tabItemRect.Left;
                        tempRight = update.rect.Right;
                    }
                    else
                    {
                        update.rect.X = tempRight;
                        tempRight = update.rect.Right;
                    }

                    pointRgn[0].x = update.rect.Left - 3;
                    pointRgn[0].y = update.rect.Bottom;
                    pointRgn[1].x = update.rect.Left + 12;
                    pointRgn[1].y = update.rect.Top + 5;
                    pointRgn[6].x = update.rect.Left - 3;
                    pointRgn[6].y = update.rect.Bottom;
                    pointRgn[2].x = update.rect.Left + 16;
                    pointRgn[2].y = update.rect.Top + 2;
                    pointRgn[3].x = update.rect.Right + 1;
                    pointRgn[3].y = update.rect.Top + 2;
                    pointRgn[4].x = update.rect.Right + 4;
                    pointRgn[4].y = update.rect.Top + 5;
                    pointRgn[5].x = update.rect.Right + 4;
                    pointRgn[5].y = update.rect.Bottom;

                    IntPtr tabRgn = CreatePolygonRgn(ref pointRgn[0], 7, ALTERNATE);
                    update.tabRgn = Region.FromHrgn(tabRgn);
                    m_arTabInfo[i] = update;
                }
            }
            //m_tabWidth = m_arTabInfo[m_iClickPos].rect.Left + m_arTabInfo[m_iClickPos].rect.Width;
        }

        //更新Tab项的位置
        public void UpdateTabInfo(int click, int x, bool show)
        {
            TABINFO update;
            update = m_arTabInfo[click];
            update.IsDisplay = show;
            update.rect.X = x;
            if (x < 0)
            {
                m_arTabInfo[click] = update;
                return;
            }
            m_arTabInfo[click].tabRgn.Dispose();

            POINT[] pointRgn = new POINT[7];
            pointRgn[0].x = update.rect.Left - 3;
            pointRgn[0].y = update.rect.Bottom;
            pointRgn[1].x = update.rect.Left + 12;
            pointRgn[1].y = update.rect.Top + 5;
            pointRgn[6].x = update.rect.Left - 3;
            pointRgn[6].y = update.rect.Bottom;
            pointRgn[2].x = update.rect.Left + 16;
            pointRgn[2].y = update.rect.Top + 2;
            pointRgn[3].x = update.rect.Right + 1;
            pointRgn[3].y = update.rect.Top + 2;
            pointRgn[4].x = update.rect.Right + 4;
            pointRgn[4].y = update.rect.Top + 5;
            pointRgn[5].x = update.rect.Right + 4;
            pointRgn[5].y = update.rect.Bottom;

            IntPtr tabRgn = CreatePolygonRgn(ref pointRgn[0], 7, ALTERNATE);
            update.tabRgn = Region.FromHrgn(tabRgn);

            m_arTabInfo[click] = update;
        }

        public void UpdatePagCount(int ClickCol)
        {
            //iPagBarCol

            int width = 0;
            int oldPagBarCol = iPagBarCol;


            if (m_arTabInfo[ClickCol].rect.Right >= tabItemRect.Width - 25)		//向下
            {
                iPagBarCol = 0;
                width = tabItemRect.Left;
                for (int i = ClickCol - 1; i < m_arTabInfo.Count(); i++)
                {
                    width = width + m_arTabInfo[i].rect.Width;
                    if (width <= tabItemRect.Right)
                    {
                        iPagBarCol = iPagBarCol + 1;
                    }

                    // return;
                }
                int y = oldPagBarCol - iPagBarCol;
                if (y > 0)
                    iPagBarCol = iPagBarCol + y;

                return;
            }

            if (m_arTabInfo[ClickCol].rect.Left <= tabItemRect.Left)		//向上
            {
                if (m_arTabInfo[ClickCol].strName == "货架11xxxxxxx")
                {
                    String sl;
                    sl = m_arTabInfo[ClickCol].strName;

                }
                iPagBarCol = 0;
                width = tabItemRect.Right;
                for (int i = ClickCol + 1; i > 0; i--)
                {
                    width = width - m_arTabInfo[i].rect.Width;
                    if (width >= tabItemRect.Left)
                    {
                        String h = m_arTabInfo[i].strName;
                        XtraMessageBox.Show("可以显示：" + m_arTabInfo[i].strName);
                        iPagBarCol = iPagBarCol + 1;
                    }
                }

                int y = oldPagBarCol - iPagBarCol;
                if (y > 0)
                    iPagBarCol = iPagBarCol + y;
                // XtraMessageBox.Show("向上" +  " 新的:" + iPagBarCol.ToString());

            }
        }

        public void SetClickTabPos(int pos)
        {
            if (m_arTabInfo.Count() > 0)
            {
                TABINFO update;

                update = m_arTabInfo[GetClickTabPos()];
                update.nClick = 0;
                m_arTabInfo[GetClickTabPos()] = update;

                update = m_arTabInfo[pos];
                update.nClick = 1;
                m_arTabInfo[pos] = update;

                m_iClickPos = pos;
            }
        }

        public int GetClickTabPos()
        {
            return m_iClickPos;
        }

        #region 绘制Tab选项
        public void DrawTabItem(Graphics pDC)
        {
            Rectangle m_rectTabAux = new Rectangle();

            if (m_arTabInfo.Count() == 0)
                return;

            for (int i = m_arTabInfo.Count() - 1; i >= 0; i--)
            {
                if (m_arTabInfo[i].IsDisplay == false)
                    continue;

                m_rectTabAux = m_arTabInfo[i].rect;

                if (m_arTabInfo[i].nClick == 1)	//选中状态
                {
                    m_iClickPos = i;
                }
                else//没选中状态
                {
                    TABINFO update;
                    update = m_arTabInfo[i];

                    if (m_arTabInfo[i].nFlags == 1)	//有焦点
                    {
                        DrawClickTabItem(pDC, pSeclectPen, m_rectTabAux.Left, m_TabInfo.rect.Top,
                            m_rectTabAux.Right, m_rectTabAux.Bottom, false, i);

                        update.nFlags = 0;
                        m_arTabInfo[i] = update;
                    }
                    else	//没焦点
                    {
                        DrawClickTabItem(pDC, p, m_rectTabAux.Left, m_TabInfo.rect.Top,
                            m_rectTabAux.Right, m_rectTabAux.Bottom, false, i);
                    }

                    //渐变色的矩形
                    Rectangle brushRect = new Rectangle(m_arTabInfo[i].rect.Left, m_arTabInfo[i].rect.Top, m_arTabInfo[i].rect.Width, 73);
                    DrawTabBackGround(pDC, brushRect, Color.FromArgb(253, 253, 252), m_arTabInfo[i].bkClr,
                            m_arTabInfo[i].tabRgn);

                    SolidBrush fontBrush = new SolidBrush(Color.FromArgb(172, 168, 153));

                    //或取字符串显示区域的可见字符数
                    String str = m_arTabInfo[i].strName;
                    int fontWidth = drawLayer.GetStringPixelWidth(this, str, m_Font);
                    int len = drawLayer.GetStringShowLength(str, fontWidth, m_arTabInfo[i].rect.Width);
                    //判断字符串的像素宽度是否大于用于显示字符串的区域,大于就截断后面的字符
                    if (fontWidth > m_arTabInfo[i].rect.Width)
                        str = drawLayer.StringFormat(str, len);

                    pDC.DrawString(str, m_Font, fontBrush,
                        m_arTabInfo[i].rect.Left + 13, m_arTabInfo[i].rect.Top + 5);

                }
            }

            if (m_arTabInfo[m_iClickPos].nClick == 1)	//选中状态
            {
                //if (m_arTabInfo[m_iClickPos].IsDisplay == false)
                //  return;

                Rectangle ClickRect = m_arTabInfo[m_iClickPos].rect;

                Color BackColor;

                if (m_arTabInfo[m_iClickPos].bkClr == DefaultTabOutRGB)
                {
                    pClickPen = new Pen(DefaultTabInRGB, 2);
                    BackColor = DefaultTabInRGB;
                }
                else
                {
                    pClickPen = new Pen(m_arTabInfo[m_iClickPos].bkClr, 2);
                    BackColor = m_arTabInfo[m_iClickPos].bkClr;
                }

                DrawClickTabItem(pDC, pClickPen, ClickRect.Left, m_TabInfo.rect.Top,
                  ClickRect.Right, ClickRect.Bottom, true, m_iClickPos);
                
                //渐变色的矩形
                Rectangle brushRect = new Rectangle(ClickRect.Left, ClickRect.Top, ClickRect.Width, 73);
                DrawTabBackGround(pDC, brushRect, starColor, BackColor,
                        m_arTabInfo[m_iClickPos].tabRgn);

                //填充Tab栏下方当中的一块区域
                Brush GradientBrush = new LinearGradientBrush(brushRect, starColor, BackColor, LinearGradientMode.Vertical);
                //Rectangle GradientRect = new Rectangle(ClickRect.Left - 4, ClickRect.Bottom -1 , ClickRect.Width + 8, 5);

                m_rectFrame.Y = ClickRect.Bottom;
                m_rectFrame.Height = (this.Height - m_rectFrame.Y - 1);

                SolidBrush h = new SolidBrush(Color.FromArgb(10, 10, 10));
                //Rectangle GradientRect1 = new Rectangle(1, 1, ClickRect.Width + 8, 5);
                bitmap = new Bitmap(brushRect.Width + 10, brushRect.Height + ClickRect.Top);
                Graphics memDC = Graphics.FromImage(bitmap);
                memDC.FillRectangle(GradientBrush, new Rectangle(1, ClickRect.Bottom - 1, brushRect.Width + 10, 5));


                DrawTabFrame(pDC, m_rectFrame, BackColor);
                pDC.DrawImage(bitmap, ClickRect.Left - 5, 0);
                //pDC.FillRectangle(GradientBrush, GradientRect);
                pClickPen.Dispose();

                SolidBrush fontBrush = new SolidBrush(BackColor);
                //或取字符串显示区域的可见字符数
                String str = m_arTabInfo[m_iClickPos].strName;
                int fontWidth = drawLayer.GetStringPixelWidth(this, str, m_Font);
                int len = drawLayer.GetStringShowLength(str, fontWidth, m_arTabInfo[m_iClickPos].Width);
                //判断字符串的像素宽度是否大于用于显示字符串的区域,大于就截断后面的字符
                if (fontWidth > m_arTabInfo[m_iClickPos].Width)
                    str = drawLayer.StringFormat(str, len);
                pDC.DrawString(str, m_Font, fontBrush,
                    ClickRect.Left + 15, ClickRect.Top + 5);

            }

        }
        #endregion

        #region 绘制Tab框架
        public void DrawTabFrame(Graphics pDC, Rectangle rect, Color cPen)
        {
            Rectangle rectClient = rect;
            Color GradientColor1 = bitmap.GetPixel(1, rectClient.Top);
            Color GradientColor2 = bitmap.GetPixel(1, rectClient.Top + 1);

            Pen p1 = new Pen(cPen, 1);
            Pen p2 = new Pen(Color.FromArgb(255, 255, 255), 1);
            Pen p3 = new Pen(GradientColor1, 2);
            Pen p4 = new Pen(GradientColor2, 1);
            Pen p5 = new Pen(cPen, 1);

            //rectClient.Y+=20;
            rectClient.X += 1;
            rectClient.Height -= 3;
            rectClient.Width -= 5;
            SolidBrush solidbrush = new SolidBrush(cPen);

            //LEFT-LINE
            pDC.DrawLine(p1, rectClient.Left, rectClient.Top, rectClient.Left, rectClient.Bottom);

            pDC.DrawLine(p2, rectClient.Left + 1, rectClient.Top + 1, rectClient.Left + 1, rectClient.Bottom);

            pDC.DrawLine(p3, rectClient.Left + 3, rectClient.Top + 1, rectClient.Left + 3, rectClient.Bottom - 1);

            pDC.DrawLine(p4, rectClient.Left + 4, rectClient.Top + 3, rectClient.Left + 4, rectClient.Bottom - 3);

            pDC.DrawLine(p5, rectClient.Left + 5, rectClient.Top, rectClient.Left + 5, rectClient.Bottom);

            //TOP-LINE
            pDC.DrawLine(p1, rectClient.Left + 1, rectClient.Top - 1, rectClient.Right + 1, rectClient.Top - 1);

            pDC.DrawLine(p2, rectClient.Left + 1, rectClient.Top, rectClient.Right + 1, rectClient.Top);

            pDC.DrawLine(p3, rectClient.Left + 2, rectClient.Top + 2, rectClient.Right, rectClient.Top + 2);

            pDC.DrawLine(p4, rectClient.Left + 4, rectClient.Top + 3, rectClient.Right - 2, rectClient.Top + 3);

            pDC.DrawLine(p5, rectClient.Left + 5, rectClient.Top + 4, rectClient.Right + 1, rectClient.Top + 4);

            //RIGHT-LINE
            pDC.DrawLine(p1, rectClient.Right + 2, rectClient.Top, rectClient.Right + 2, rectClient.Bottom);

            pDC.DrawLine(p2, rectClient.Right + 1, rectClient.Top + 1, rectClient.Right + 1, rectClient.Bottom);

            pDC.DrawLine(p3, rectClient.Right, rectClient.Top + 1, rectClient.Right, rectClient.Bottom - 1);

            pDC.DrawLine(p4, rectClient.Right - 2, rectClient.Top + 3, rectClient.Right - 2, rectClient.Bottom - 3);

            pDC.DrawLine(p5, rectClient.Right - 3, rectClient.Top + 5, rectClient.Right - 3, rectClient.Bottom - 5);

            //pDC.DrawLine(p1, rectClient.left, rectClient.bottom + 1, rectClient.right, rectClient.bottom + 1);
            //BOTTOM-LINE
            pDC.DrawLine(p1, rectClient.Left + 1, rectClient.Bottom + 1, rectClient.Right + 1, rectClient.Bottom + 1);

            pDC.DrawLine(p2, rectClient.Left + 2, rectClient.Bottom, rectClient.Right + 1, rectClient.Bottom);

            pDC.DrawLine(p3, rectClient.Left + 2, rectClient.Bottom - 1, rectClient.Right + 1, rectClient.Bottom - 1);

            pDC.DrawLine(p4, rectClient.Left + 4, rectClient.Bottom - 3, rectClient.Right - 1, rectClient.Bottom - 3);

            pDC.DrawLine(p5, rectClient.Left + 5, rectClient.Bottom - 4, rectClient.Right - 3, rectClient.Bottom - 4);
        }
        #endregion

        #region 绘制被选中Tab项
        public void DrawClickTabItem(Graphics pDC, Pen pen, int x1, int y1, int x2, int y2, bool isClick, int pos)
        {
            //画前面的
            int TABXOFF;
            int TABYOFF = 1;
            if (isClick == true)
            {
                TABXOFF = 1;
                pDC.DrawLine(pen, x1 + (12 - TABXOFF), y1 + (5 - TABYOFF), x1 - (3 + TABXOFF), y2 - TABYOFF);
                pDC.DrawLine(pen, x1 + (11 - TABXOFF), y1 + (6 - TABYOFF), x1 + (16 - TABXOFF), y1 + TABYOFF);
                pDC.DrawLine(pen, x1 + (16 - TABXOFF), y1 + (TABYOFF), x2 + 2, y1 + (TABYOFF));
                pDC.DrawLine(pen, x2 + 1, y1 + (TABYOFF), x2 + 4, y1 + (5 - TABYOFF));
                pDC.DrawLine(pen, x2 + 4 + TABYOFF, y1 + 5, x2 + 4 + TABYOFF, y2);
            }
            else
            {
                TABXOFF = -1;
                pDC.DrawLine(pen, x1 + (12 - TABXOFF), y1 + (5 - TABYOFF), x1 - (3 + TABXOFF), y2 - TABYOFF);
                pDC.DrawLine(pen, x1 + (11 - TABXOFF), y1 + (6 - TABYOFF), x1 + (16 - TABXOFF), y1 + TABYOFF);
                pDC.DrawLine(pen, x1 + (16 - TABXOFF), y1 + (TABYOFF + 1), x2 + 2, y1 + (TABYOFF + 1));
                pDC.DrawLine(pen, x2 + 1, y1 + (TABYOFF + 1), x2 + 4, y1 + (5 - TABYOFF + 1));
                pDC.DrawLine(pen, x2 + 4 + TABYOFF - 1, y1 + 5, x2 + 4 + TABYOFF - 1, y2);
            }

            //画后面的
            int old;
            if (pos + 1 >= m_arTabInfo.Count())
            {
                old = pos;
            }
            else
            {
                old = pos + 1;
            }
            if (m_arTabInfo[old].nClick == 1 && pos + 1 < m_arTabInfo.Count())
            {
                //   pDC.DrawLine(pen, x2 + 4 + TABYOFF-1, y1 + 4, x2 + 4 + TABYOFF-1, y2 - 9);
            }

            /*
            if (flags == true)
                pDC.DrawLine(pen, x2 + 4 + TABYOFF, y1 + 4, x2 + 4 + TABYOFF, y2);
            else
                pDC.DrawLine(pen, x2 + 4 + TABYOFF, y1 + 4, x2 + 4 + TABYOFF, y2-10);
             * */
        }
        #endregion

        #region 绘制没选中Tab项
        public void DrawNoClickTabItem(Graphics pDC, Pen pen, int x1, int y1, int x2, int y2, int pos)
        {
            int TABXOFF = 2;
            int TABYOFF = 1;
            pDC.DrawLine(pen, x1 + (12 - TABXOFF), y1 + (5 - TABYOFF), x1 - (3 + TABXOFF), y2 - TABYOFF);
            pDC.DrawLine(pen, x1 + (11 - TABXOFF), y1 + (6 - TABYOFF), x1 + (16 - TABXOFF), y1 + TABYOFF);
            pDC.DrawLine(pen, x1 + (16 - TABXOFF), y1 + (TABYOFF), x2 + 2, y1 + (TABYOFF));
            pDC.DrawLine(pen, x2 + 1, y1 + (TABYOFF), x2 + 4, y1 + (5 - TABYOFF));
            pDC.DrawLine(pen, x2 + 4 + TABYOFF, y1 + 4, x2 + 4 + TABYOFF, y2);
            if (pos == 0)
            {
                //画第一个Tab选项
                if (m_arTabInfo[0].nClick == 0)
                {
                    pDC.DrawLine(pen, x1 + (12 - TABXOFF), y1 + (5 - TABYOFF), x1 - (3 + TABXOFF), y2 - TABYOFF);
                }
            }

            int old;
            if (pos + 1 >= m_arTabInfo.Count())
            {
                old = pos;
            }
            else
            {
                old = pos + 1;
            }
            if (m_arTabInfo[old].nClick == 1)
            {
                pDC.DrawLine(pen, x2 + 4, y1 + 5,
                    x2 + 4, y2 - 8);
            }
            else
            {
                pDC.DrawLine(pen, x2 + 4, y1 + 5,
                        x2 + 4, y2);
            }
        }
        #endregion

        #region 绘制Tab背景
        public void DrawTabBackGround(Graphics g, Rectangle rect, Color startColor, Color endColor, Region tabRgn)
        {
            Brush brush = new LinearGradientBrush(rect,
                startColor,
                endColor,
                LinearGradientMode.Vertical);

            //Bitmap bitmap = new Bitmap(rect.Width, rect.Height);
            //Graphics memDC = Graphics.FromImage(bitmap);

            //Brush GradientBrush = new LinearGradientBrush(rect, starColor, BackColor, LinearGradientMode.Vertical);
            //memDC.FillRegion(brush, tabRgn);


            //e.Graphics.FillRectangle(GradientBrush, TabRgn);

            //e.Graphics.FillRectangle(GradientBrush, new Rectangle(200,0,184,20));
            //Rectangle de = new Rectangle(0, 22, 184, 74);
            //Rectangle se = new Rectangle(0, 0, 184, 74);
            //g.DrawImage(bitmap, de, se, GraphicsUnit.Pixel);    

            //g.FillRectangle(brush, rect);
            g.FillRegion(brush, tabRgn);
        }
        #endregion

    }
}