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
using SCM_CangJi.Lib;

namespace SCM_CangJi.WareHouseManage
{
    public class StorageDataView
    {
        #region 变量
        public enum ARROW {LEFT, RIGHT}
        private const int ARROWWH = 5;
        private const int ADDYOFFSET = 14;

        

        WPXX m_Wpxx;
        List<WPXX> m_arWpxx;

        CWXX cw;
        List<CWXX> arcw;

        CCXX cc;
        List<CCXX> arcc;

        List<RowInfo> arAddRect;
        
        bool up;
        bool m_IsAddRect;

        int m_iMaxPs;
        int m_iMaxCs;
        String m_strCWID;
        String m_strCWName;

        String m_strPName;

        Pen LinePenH, LinePenV, ArrowPen;
        Font m_Font = new Font("宋体", 10, FontStyle.Bold);// | FontStyle.Italic
        SolidBrush fontBrush;
        StringFormat alignFormat;
        
        Brush TitleBrush;
        Color startColor;
        Color endColor;

        #endregion

        public StorageDataView()
        {
            alignFormat = new StringFormat();
            alignFormat.LineAlignment = StringAlignment.Center; 

            fontBrush = new SolidBrush(Color.Black);
            
            ArrowPen = new Pen(Color.FromArgb(200, 200, 200));

            up = false;
            m_IsAddRect = false;
            m_iMaxPs = 0;
            m_iMaxCs = 0;
            m_strCWID = "1";
            m_strCWName = "";
            //GetWpData();

            LinePenH = new Pen(Color.FromArgb(165, 191, 255), 1);
            LinePenV = new Pen(Color.FromArgb(93, 140, 201), 2);

            m_Wpxx = new WPXX();
            m_arWpxx = new List<WPXX>();

            cw = new CWXX();
            arcw = new List<CWXX>();

            cc = new CCXX();
            arcc = new List<CCXX>();

            cc = new CCXX();
            arAddRect = new List<RowInfo>();

            
            cc.CWID="1";
            cc.CID=1;
            cc.PID=1;
            cc.PName="as1-1";
            cc.maxcol=3;
            cc.nFlags=0;
            arcc.Add(cc);

            cc.CWID="1";
            cc.CID=1;
            cc.PID=2;
            cc.PName="as1-2";
            cc.maxcol=3;
            cc.nFlags=0;
            arcc.Add(cc);

            cc.CWID = "1";
            cc.CID = 1;
            cc.PID = 3;
            cc.PName = "as1-3";
            cc.maxcol = 3;
            cc.nFlags = 0;
            arcc.Add(cc);
	
            cc.CWID="1";
            cc.CID=2;
            cc.PID=1;
            cc.PName="as2-1";
            cc.maxcol = 5;
            cc.nFlags=0;
            arcc.Add(cc);
            cc.CWID="1";
            cc.CID=2;
            cc.PID=2;
            cc.PName="as2-2";
            cc.maxcol=4;
            cc.nFlags=0;
            arcc.Add(cc);
            cc.CWID="1";
            cc.CID=2;
            cc.PID=3;
            cc.PName="as2-3";
            cc.maxcol = 5;
            cc.nFlags=0;
            arcc.Add(cc);
            cc.CWID="1";
            cc.CID=2;
            cc.PID=4;
            cc.PName="as2-4";
            cc.maxcol=5;
            cc.nFlags=0;
            arcc.Add(cc);

            cc.CWID = "1";
            cc.CID = 2;
            cc.PID = 5;
            cc.PName = "as2-5";
            cc.maxcol = 5;
            cc.nFlags = 0;
            arcc.Add(cc);

            cc.CWID="1";
            cc.CID=3;
            cc.PID=1;
            cc.PName="as3-1";
            cc.maxcol=5;
            cc.nFlags=0;
            arcc.Add(cc);

            cc.CWID = "1";
            cc.CID = 3;
            cc.PID = 2;
            cc.PName = "as3-2";
            cc.maxcol = 5;
            cc.nFlags = 0;
            arcc.Add(cc);

            cc.CWID = "1";
            cc.CID = 3;
            cc.PID = 3;
            cc.PName = "as3-3";
            cc.maxcol = 5;
            cc.nFlags = 0;
            arcc.Add(cc);

            cc.CWID="1";
            cc.CID=3;
            cc.PID=4;
            cc.PName="as3-4";
            cc.maxcol = 5;
            cc.nFlags=0;
            arcc.Add(cc);

            cc.CWID = "1";
            cc.CID = 3;
            cc.PID = 5;
            cc.PName = "as3-5";
            cc.maxcol = 5;
            cc.nFlags = 0;
            arcc.Add(cc);

            cc.CWID = "1";
            cc.CID = 4;
            cc.PID = 1;
            cc.PName = "as4-1";
            cc.maxcol = 1;
            cc.nFlags = 0;
            arcc.Add(cc);
        }

        public void OnDraw()
        {
            
        }

        public void OnDraw(Graphics pDC, Rectangle rect)
        {
            Rectangle rectClient = rect;

            Rectangle tt = new Rectangle(rectClient.Left + 10, rectClient.Top - 23, 5, 5);
            DrawFillet(pDC, tt.Left, tt.Top, 20, 20);

            DrawArrow(pDC, tt, new Pen(Color.FromArgb(93, 140, 201), 2), ARROW.LEFT);

            m_iMaxCs = 5;
            m_iMaxPs = 5;
            if (m_iMaxCs <= 0 && m_iMaxPs <= 0)
            {
                return;
            }

            int xStartPos = rectClient.Left + 55;
            int yStartPos = rectClient.Top + ((rectClient.Bottom - rectClient.Top) / m_iMaxCs);

            int oldYPos = rectClient.Top;
            int iX2Pos = 0;
            //防止重复增加RowInfo矩形
            if (arAddRect.Count() <= 0)
            {
                m_IsAddRect = true;
            }
            else
            {
                m_IsAddRect = false;
            }

            //画竖线分隔线（一个）
            pDC.DrawLine(LinePenV, xStartPos, rectClient.Bottom - 8, xStartPos, rectClient.Top + 6);
            for (int z = 0; z < m_iMaxCs; z++)//层
            {
                String str;
                int l = z + 1;

                xStartPos = rectClient.Left + 55;

                //画每层的横线
                pDC.DrawLine(LinePenH, rectClient.Left + 8, yStartPos, rectClient.Right-10, yStartPos);
                
                if (m_IsAddRect)
                {
                    RowInfo rowinfo = new RowInfo();
                    rowinfo.rect = new Rectangle(rectClient.Left + 8, oldYPos,
                        xStartPos - (rectClient.Left + 8), yStartPos - (oldYPos));
                    rowinfo.RowID = z + 1;
                    rowinfo.nFlags = 0;
                    arAddRect.Add(rowinfo);
                }
                
                str = l.ToString() + "层";
                alignFormat.LineAlignment = StringAlignment.Center;
                alignFormat.Alignment = StringAlignment.Near;
                pDC.DrawString(str, m_Font, fontBrush, arAddRect[z].rect, alignFormat);

                //增加层信息（防止重复增加）
                ArrowPen.Dispose();
                if (arAddRect[z].nFlags == 1)
                {
                    ArrowPen = new Pen(Color.FromArgb(93, 140, 201), 2);
                    RowInfo RowUpdate;
                    RowUpdate = arAddRect[z];
                    RowUpdate.nFlags = 0;
                    arAddRect[z] = RowUpdate;
                }
                else
                {
                    ArrowPen = new Pen(Color.FromArgb(200, 200, 200), 2);
                }

                Rectangle arrowRect = new Rectangle(arAddRect[z].rect.Right - 20, 
                    arAddRect[z].rect.Top + (arAddRect[z].rect.Height/2-10), 
                    5, 
                    5);
                DrawArrow(pDC, arrowRect, ArrowPen, ARROW.RIGHT);

                //从数据库中取出每层的最大排数
                bool IsZero = false;
                IsZero = FindCol(m_strCWID, z + 1);

                SolidBrush RectBrk = new SolidBrush(Color.FromArgb(255, 255, 255));
                SolidBrush TitleBrk = new SolidBrush(Color.FromArgb(230, 237, 247));

                if (IsZero == true)
                {
                    RectBrk.Dispose();
                    RectBrk = new SolidBrush(Color.FromArgb(255, 255, 255));
                    TitleBrk.Dispose();
                    TitleBrk = new SolidBrush(Color.FromArgb(230, 237, 247));
                    startColor = Color.FromArgb(255, 255, 255);
                    endColor = Color.FromArgb(152, 181, 226);
                }
                else
                {
                    RectBrk.Dispose();
                    RectBrk = new SolidBrush(Color.FromArgb(244, 243, 234));
                    TitleBrk.Dispose();
                    TitleBrk = new SolidBrush(Color.FromArgb(244, 243, 234));
                    startColor = Color.FromArgb(244, 243, 234);
                    endColor = Color.FromArgb(244, 243, 234);
                }

                Rectangle rectCol = new Rectangle();
                for (int i = 0; i < m_iMaxPs; i++)//排
                {
                    iX2Pos = xStartPos + ((rectClient.Right - (rectClient.Left + 55)) / m_iMaxPs);
                    
                    CCXX ccupdate;
                    String sp="";

                    //查找物品
                    int pPos = FindPName(m_strCWID, z + 1, i + 1);
                    
                    if (pPos > -1)
                    {
                        sp = "商品名称：" + arcc[pPos].sWPName + "\r\n数量：" + arcc[pPos].sl.ToString();
                    }

                    if (pPos > -1 && arcc[pPos].nFlags == 1)
                    {
                        RectBrk.Dispose();
                        RectBrk = new SolidBrush(Color.FromArgb(230, 237, 247));
                        ccupdate = arcc[pPos];
                        ccupdate.nFlags = 0;
                        arcc[pPos] = ccupdate;
                    }
                    else
                    {
                        if (IsZero == true)
                        {
                            RectBrk.Dispose();
                            RectBrk = new SolidBrush(Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            RectBrk.Dispose();
                            RectBrk = new SolidBrush(Color.FromArgb(244, 243, 234));
                        }
                    }
                    
                    //每层排开始画线的位置不同
                    if (z == 0)//第一排
                    {
                        if (m_iMaxCs > 1)//判断是否只有一层
                        {
                            if (i < m_iMaxPs - 1)//是否最后一排,最后一排不画竖线
                            {
                                pDC.DrawLine(LinePenV, iX2Pos, oldYPos + 4, iX2Pos, yStartPos);
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos + 6;
                                rectCol.Width = iX2Pos - xStartPos - 2;
                                rectCol.Height = yStartPos - oldYPos - 6;
                            }
                            else//是调整Width
                            {
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos + 6;
                                rectCol.Width = iX2Pos - xStartPos - 8;
                                rectCol.Height = yStartPos - oldYPos - 6;
                            }
                        }
                        else//是,提升底部
                        {
                            if (i < m_iMaxPs - 1)//是否最后一排,最后一排不画竖线
                            {
                                pDC.DrawLine(LinePenV, iX2Pos, oldYPos + 4, iX2Pos, yStartPos - 8);
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos + 6;
                                rectCol.Width = iX2Pos - xStartPos - 2;
                                rectCol.Height = yStartPos - oldYPos - 14;
                            }
                            else
                            {
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos + 6;
                                rectCol.Width = iX2Pos - xStartPos - 8;
                                rectCol.Height = yStartPos - oldYPos - 14;
                            }
                        }
                    }
                    else
                    {
                        if (z == m_iMaxCs - 1)//最后一排
                        {
                            if (i < m_iMaxPs - 1)//是否最后一排,最后一排不画竖线
                            {
                                pDC.DrawLine(LinePenV, iX2Pos, oldYPos - 1, iX2Pos, yStartPos - 4);
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos - 1;
                                rectCol.Width = iX2Pos - xStartPos - 2;
                                rectCol.Height = yStartPos - oldYPos - 6;
                            }
                            else//是调整Width
                            {
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos - 1;
                                rectCol.Width = iX2Pos - xStartPos - 8;
                                rectCol.Height = yStartPos - oldYPos - 6;
                            }
                        }
                        else//当中的排
                        {
                            if (i < m_iMaxPs - 1)//是否最后一排,最后一排不画竖线
                            {
                                pDC.DrawLine(LinePenV, iX2Pos, oldYPos - 1, iX2Pos, yStartPos);
                                rectCol.X = xStartPos + 1;
                                rectCol.Y = oldYPos - 1;
                                rectCol.Width = iX2Pos - xStartPos - 2;
                                rectCol.Height = yStartPos - oldYPos;
                            }
                            else//是调整Width
                            {
                                if (m_iMaxPs > 1)
                                {
                                    rectCol.X = xStartPos + 1;
                                    rectCol.Y = oldYPos - 1;
                                    rectCol.Width = iX2Pos - xStartPos - 4;
                                    rectCol.Height = yStartPos - oldYPos;
                                }
                                else
                                {
                                    rectCol.X = xStartPos + 1;
                                    rectCol.Y = oldYPos - 1;
                                    rectCol.Width = iX2Pos - xStartPos - 8;
                                    rectCol.Height = yStartPos - oldYPos;
                                }
                            }
                        }
                    }

                    if (pPos > -1)
                    {
                        ccupdate = arcc[pPos];
                        ccupdate.CCRect = rectCol;
                        arcc[pPos] = ccupdate;
                    }

                    //画排的矩形
                    pDC.FillRectangle(RectBrk, rectCol);
                    alignFormat.Alignment = StringAlignment.Near;
                    alignFormat.LineAlignment = StringAlignment.Near;
                    pDC.DrawString(sp, m_Font, fontBrush, rectCol, alignFormat);

                    //画排标题的矩形
                    TitleBrush = new LinearGradientBrush(new Rectangle(rectCol.Left, rectCol.Bottom - 26, rectCol.Width, 26),
                        endColor, startColor, LinearGradientMode.Vertical);
                    pDC.FillRectangle(TitleBrush, rectCol.Left, rectCol.Bottom - 26, rectCol.Width, 26);
                    TitleBrush.Dispose();

                    //显示排标题
                    alignFormat.LineAlignment = StringAlignment.Center;
                    alignFormat.Alignment = StringAlignment.Center;
                    pDC.DrawString(m_strPName, m_Font, fontBrush, 
                        new Rectangle(rectCol.Left, rectCol.Bottom - 26, rectCol.Width, 26), alignFormat);

                    xStartPos = xStartPos + ((rectClient.Right - (rectClient.Left + 55)) / m_iMaxPs);
                }

                oldYPos = yStartPos + 2;
                yStartPos = yStartPos + ((rectClient.Bottom - rectClient.Top) / m_iMaxCs);
            }

        }

        public bool GetWpData()
        {
            if (m_arWpxx.Count() > 0)
                m_arWpxx.Clear();

            m_Wpxx.nFlags = 0;
            m_Wpxx.nCheck = 0;
            m_Wpxx.CWID = m_strCWID;
            m_Wpxx.CWName = m_strCWName;
            m_Wpxx.iCs = 1;
            m_Wpxx.iPs = 1;
            m_Wpxx.sWPName = m_strCWName + "A-1";
            m_Wpxx.iSl = 10;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 1;
            m_Wpxx.iPs = 2;
            m_Wpxx.sWPName = "A-2";
            m_Wpxx.iSl = 10;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 1;
            m_Wpxx.iPs = 3;
            m_Wpxx.sWPName = "A-3";
            m_Wpxx.iSl = 10;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 1;
            m_Wpxx.iPs = 4;
            m_Wpxx.sWPName = "A-4";
            m_Wpxx.iSl = 10;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 1;
            m_Wpxx.iPs = 5;
            m_Wpxx.sWPName = "A-5";
            m_Wpxx.iSl = 10;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 2;
            m_Wpxx.iPs = 1;
            m_Wpxx.sWPName = "B-1";
            m_Wpxx.iSl = 1;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 2;
            m_Wpxx.iPs = 2;
            m_Wpxx.sWPName = "B-2";
            m_Wpxx.iSl = 1;
            m_arWpxx.Add(m_Wpxx);

            m_Wpxx.iCs = 3;
            m_Wpxx.iPs = 1;
            m_Wpxx.sWPName = "C-1";
            m_Wpxx.iSl = 1;
            m_arWpxx.Add(m_Wpxx);
	        return true;
        }

        #region 画渐变圆角矩形
        void DrawFillet(Graphics pDC, int x, int y, int iwidth, int iheight)
        {
	        Pen pen;

            Brush brush = new LinearGradientBrush(new Rectangle(x, y, iwidth, iheight),
                        Color.FromArgb(251, 252, 253), Color.FromArgb(152, 181, 226), LinearGradientMode.Vertical);
            pDC.FillRectangle(brush, x, y, iwidth, iheight);

            pen = new Pen(Color.FromArgb(244, 243, 234));

            //tab
            //LEFT-LINE
            pDC.DrawLine(pen, x, y, x, y + iheight);
            pDC.DrawLine(pen, x + 1, y, x + 1, y + 1);
            pDC.DrawLine(pen, x + 1, y + iheight - 1, x + 1, y + iheight);
            		
            //TOP-LINE
            pDC.DrawLine(pen, x + 1, y - 1, x + iwidth, y - 1);

            //RIGHT-LINE
            pDC.DrawLine(pen, x + iwidth, y, x + iwidth, y + iheight);
            pDC.DrawLine(pen, x + iwidth - 1, y, x + iwidth - 1, y + 1);
            pDC.DrawLine(pen, x + iwidth - 1, y + iheight - 1, x + iwidth - 1, y + iheight);

            //BOTTOM-LINE
            pDC.DrawLine(pen, x + 1, y + iheight, x + iwidth, y + iheight);

            brush.Dispose();
        }
        #endregion

        #region 画添加箭头
        public void DrawArrow(Graphics pDC, Rectangle rect, Pen pen, ARROW flags)
        {
            //箭头向左边
            if (flags == ARROW.LEFT)
            {
                //1-上
                pDC.DrawLine(pen, rect.Left + rect.Width, rect.Top + (rect.Height * 2 + 1),
                    rect.Left + (rect.Width * 2), rect.Top + rect.Height + 1);
                //1-下
                pDC.DrawLine(pen, rect.Left + rect.Width, rect.Top + (rect.Height * 2 + 1),
                     rect.Left + (rect.Width * 2), rect.Top + (rect.Height * 3)+1);

                //2-上
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2 + 1), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + rect.Width + (rect.Width * 2 + 1), rect.Top + rect.Height + 1);
                
                //2-下
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2 + 1), rect.Top + (rect.Height * 2 + 1),
                     rect.Left + rect.Width + (rect.Width * 2 + 1), rect.Top + (rect.Height * 3)+1);
            }

            //箭头向右边
            if (flags == ARROW.RIGHT)
            {
                //1-上
                pDC.DrawLine(pen, rect.Left + rect.Width, rect.Bottom - rect.Height / 2,
                    rect.Left + (rect.Width * 2), (rect.Bottom - rect.Height / 2) + rect.Height);
                //1-下
                pDC.DrawLine(pen, rect.Left + rect.Width, rect.Bottom - rect.Height / 2 + (rect.Height * 2),
                     rect.Left + (rect.Width * 2), (rect.Bottom - rect.Height / 2) + rect.Height);

                //2-上
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2 + 1), rect.Bottom - rect.Height / 2,
                    rect.Left + (rect.Width * 2 + 1) + rect.Width, (rect.Bottom - rect.Height / 2) + rect.Height);
                //2-下
                pDC.DrawLine(pen, rect.Left + (rect.Width * 2 + 1), rect.Bottom - rect.Height / 2 + (rect.Height * 2),
                     rect.Left + (rect.Width * 2 + 1) + rect.Width, (rect.Bottom - rect.Height / 2) + rect.Height);
            }
            
        }
        #endregion

        #region 获取当前活动的层
        public int GetActivitRow(Point pos)
        {
	        for(int i=0; i<arAddRect.Count(); i++)
	        {
                if (arAddRect[i].rect.Contains(pos))
		        {
			        return arAddRect[i].RowID;
		        }
	        }

	        return -1;
        }
        #endregion

        #region 设置当前活动层的焦点
        public void SetActivitRow(int atcrow)
        {
            if (atcrow < 0 || atcrow > arAddRect.Count())
                return;

            RowInfo update;
            update = arAddRect[atcrow];
            update.nFlags = 1;
            arAddRect[atcrow] = update;
        }
        #endregion

        #region 查找货物在哪个仓库、层、排
        public int FindPName(String szCWID, int iCID, int iPID)
        {
	        for(int i=0; i<arcc.Count(); i++)
	        {
		        if(arcc[i].CWID==szCWID && arcc[i].CID==iCID && arcc[i].PID==iPID)
		        {
			        m_strPName = "现品票：" + arcc[i].PName;
			        return i;
		        }
	        }
	        m_strPName = "";
	        return -1;
        }
        #endregion

        #region 查找每层的最大排数量
        bool FindCol(String szCWID, int iCID)
        {
	        for(int i=0; i<arcc.Count(); i++)
	        {
		        if(arcc[i].CWID==szCWID && arcc[i].CID==iCID)
		        {
			        m_iMaxPs	= arcc[i].maxcol;
			        return true;
		        }
	        }
	        m_iMaxPs = 1;
	
	        return false;
        }
        #endregion

        #region 设置当前活动排的焦点
        public void SetPaiFocus(int iPai)
        {
	        if(iPai<0 || iPai>arcc.Count())
		        return;
            CCXX update;
            update = arcc[iPai];
            update.nFlags = 1;
            arcc[iPai] = update;

        }
        #endregion

        #region 获取当前活动的排
        public int CheckPaiPos(Point pos)
        {
	        for(int i=0; i<arcc.Count(); i++)
	        {
                if (arcc[i].CCRect.Contains(pos) && arcc[i].CWID == m_strCWID)
		        {
			        return i;
		        }
	        }

	        return -1;
        }
        #endregion
    }
}
