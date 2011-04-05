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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using SCM_CangJi.BLL;
using SCM_CangJi.Lib;

namespace SCM_CangJi.WareHouseManage
{
    public class TabStorageManage : TabFrameEx
    {
        #region 变量
        private const int WIDTHOFFSET = 220;

        int showCount;//显示数
        int showStartPos;//开始显示的位置
        int clickPos;//被选中的

        //货架
        TabStorageRack tabStorageRack;
        StorageRackManage storageRackManage;

        Rectangle rectStorage;

        ButtonEx buttonNext = null;
        ButtonEx buttonLast = null;
        //边框
        Color colorFrame1;
        Color colorFrame2;
        Color colorBack;
        Brush brushFrame1;
        Brush brushFrame2;
        Pen penFrame1;
        Pen penFrame2;


        SolidBrush LineBrush1;
        Pen linePen1;
        SolidBrush LineBrush2;
        Pen linePen2;

        Font m_Font = new Font("宋体", 10, FontStyle.Bold);// | FontStyle.Italic
        SolidBrush brushFont;

        StringFormat alignFormat;


        STORAGEINFO storageInfo;
        List<STORAGEINFO> listStorageInfo;

        #endregion

        public TabStorageManage()
        {
            InitializeVariable();
            InitializeComponent();
        }

        private void InitializeVariable()
        {
            showCount = 0;
            showStartPos = 0;
            clickPos = -1;

            storageInfo = new STORAGEINFO();
            listStorageInfo = new List<STORAGEINFO>();

            LineBrush1 = new SolidBrush(Color.FromArgb(246, 250, 254));
            linePen1 = new Pen(LineBrush1, 1);

            LineBrush2 = new SolidBrush(Color.FromArgb(181, 211, 229));
            linePen2 = new Pen(LineBrush2, 1);

            colorFrame1 = Color.FromArgb(213, 221, 230);
            colorFrame2 = Color.FromArgb(251, 253, 253);
            colorBack = Color.FromArgb(227, 239, 255);

            penFrame1 = new Pen(colorFrame1);
            penFrame2 = new Pen(colorFrame2);

            brushFont = new SolidBrush(Color.FromArgb(167, 188, 206));

            alignFormat = new StringFormat();
        }

        private void InitializeComponent()
        {
            buttonLast = new ButtonEx();
            buttonLast.CreateWindow("", 0, 0, 6, 6, ButtonEx.STYLE.ARROW, 1);
            buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            this.Controls.Add(buttonLast);
            buttonLast.Visible = false;

            buttonNext = new ButtonEx();
            buttonNext.CreateWindow("", 0, 0, 6, 6, ButtonEx.STYLE.ARROW, 2);
            buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.Controls.Add(buttonNext);
            buttonNext.Visible = false;

            tabStorageRack = new TabStorageRack(this);
            tabStorageRack.Visible = false;

            storageRackManage = new StorageRackManage(this);
            storageRackManage.Visible = false;

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            
            this.ResumeLayout(false);
        }

        public void SetLastButtonVisible()
        {
            showStartPos -= 1 ;
            clickPos = -1;//不点任何一个

            if (showStartPos <= 0)
            {
                buttonLast.Visible = false;
                buttonNext.Visible = false;

                showStartPos = 0;
            }
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            STORAGEINFO update;

            for (int i = showStartPos; i < listStorageInfo.Count(); i++)
            {
                update = listStorageInfo[i];
                update.isShow = false;
                //update.nFlags = 0;
                listStorageInfo[i] = update;
            }
            
            showStartPos -= showCount;
                        
            if (showStartPos <= 0)
            {
                buttonLast.Visible = false;
                showStartPos = 0;
            }
                        
            Invalidate();
        }

        public void SetNextButtonVisible()
        {
            if (showStartPos > showCount)
            {
                buttonNext.Visible = true;
            }
            else
            {
                buttonNext.Visible = false;
            }
            
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            STORAGEINFO update;

            showStartPos += showCount;

            if (showStartPos >= (listStorageInfo.Count) - showCount)
            {
                buttonNext.Visible = false;
                showStartPos = listStorageInfo.Count - showCount;
            }

            for (int i = showStartPos - 1; i >= 0; i--)
            {
                update = listStorageInfo[i];
                update.isShow = false;
                //update.nFlags = 0;
                listStorageInfo[i] = update;
            }

            Invalidate();
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            STORAGEINFO update;
            for (int i = 0; i < listStorageInfo.Count(); i++)
            {
                if (listStorageInfo[i].rect.Contains(e.X, e.Y) && listStorageInfo[i].isShow == true)
                {

                    update = listStorageInfo[i];
                    update.nFlags = 1;
                    listStorageInfo[i] = update;
                }
                else
                {
                    update = listStorageInfo[i];
                    update.nFlags = 0;
                    listStorageInfo[i] = update;
                }
            }
            Invalidate();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            STORAGEINFO update;

            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < listStorageInfo.Count(); i++)
                {
                    if (listStorageInfo[i].rect.Contains(e.X, e.Y) && listStorageInfo[i].isShow == true)
                    {
                        update = listStorageInfo[i];
                        update.nClick = 1;
                        update.nFlags = 1;
                        listStorageInfo[i] = update;

                        if (clickPos > -1 && clickPos != i)
                        {
                            update = listStorageInfo[clickPos];
                            update.nClick = 0;
                            update.nFlags = 0;
                            listStorageInfo[clickPos] = update;
                        }
                        
                        ShowXtraGridView(listStorageInfo[i].id);
                            
                        clickPos = i;
                        Invalidate();
                        return;
                    }
                }
            }
        }
        
        private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //开启双缓冲
            Graphics pDC = e.Graphics;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            DrawTab(pDC);
            ShowGridView();

            if (listStorageInfo.Count() < 0 && listStorageInfo == null)
            {
                return;
            }

            Rectangle rectClient = GetClientRect();
            rectStorage = new Rectangle((rectClient.Left) + 80, rectClient.Top,
                rectClient.Right - ((rectClient.Left) + 160), rectClient.Height / 2 - (rectClient.Top));



            DrawSeparatorBar(pDC, rectClient);

            //得到能显示的数量
            showCount = rectStorage.Width / WIDTHOFFSET;
            if (showCount == 0)
            {
                showCount = 1;
            }

            #region 检查数组下标是否超出边界
            if (showCount > listStorageInfo.Count())
            {
                showCount = listStorageInfo.Count();
            }

            if (showStartPos + showCount > listStorageInfo.Count())
            {
                showStartPos = listStorageInfo.Count() - showCount;
            }
            #endregion

            if (buttonNext != null)
            {
                if (showStartPos < (listStorageInfo.Count) - showCount)
                {
                    buttonNext.SetWindowPos(rectStorage.Right + 20, rectStorage.Height / 2 + 20);
                }
                else
                {
                    buttonNext.Visible = false;
                }

            }

            if (buttonLast != null)
            {
                if (showStartPos >0)
                {
                    buttonLast.SetWindowPos(rectStorage.Left - 60, rectStorage.Height / 2 + 20);
                }
            }

            //pDC.FillRectangle(LineBrush1, rectStorage);

            //Rectangle[] rect = new Rectangle[showCount];
            int width = WIDTHOFFSET * showCount;
            int xoffset = rectStorage.Right - width;
            if (showCount > 0)
            {
                xoffset = xoffset / showCount;
            }

            if (listStorageInfo.Count <= 0)
                return;

            DrawLayer draw = new DrawLayer();

            string str = "";
            STORAGEINFO update;

            for (int i = 0; i < showCount; i++)
            {
                update = listStorageInfo[showStartPos + i];

                if (i == 0)
                {
                    update.rect = new Rectangle(rectStorage.Left, rectStorage.Top + 20, WIDTHOFFSET - 20, rectStorage.Height / 2 + 40);
                }
                else
                {
                    update.rect = new Rectangle(listStorageInfo[(showStartPos + i) - 1].rect.Right + xoffset, rectStorage.Top + 20, WIDTHOFFSET - 20, rectStorage.Height / 2 + 40);
                }

                update.isShow = true;

                alignFormat.LineAlignment = StringAlignment.Near;
                alignFormat.Alignment = StringAlignment.Near;
                str = "仓库编号:\r\n    " + listStorageInfo[showStartPos + i].storageID + "\r\n";
                str += "仓库地址:\r\n    " + listStorageInfo[showStartPos + i].storageAddress + "\r\n";
                str += "备注:\r\n    " + listStorageInfo[showStartPos + i].storageRemark + "\r\n";

                if (update.nClick == 1)//画选中框
                {
                    brushFont.Dispose();
                    brushFont = new SolidBrush(Color.FromArgb(105, 187, 255));

                    draw.DrawRounded(e.Graphics, Color.FromArgb(105, 187, 255), Color.FromArgb(251, 253, 253),
                        update.rect.Left, update.rect.Top, update.rect.Width, update.rect.Bottom + 5);
                }
                else
                {
                    brushFont.Dispose();
                    brushFont = new SolidBrush(Color.FromArgb(167, 188, 206));

                    if (update.nFlags == 1)	//有焦点
                    {
                        update.nFlags = 0;
                        draw.DrawRounded(e.Graphics, Color.FromArgb(255, 200, 60), Color.FromArgb(253, 253, 251),
                        update.rect.Left, update.rect.Top, update.rect.Width, update.rect.Bottom + 5);
                    }
                }

                listStorageInfo[showStartPos + i] = update;


                //pDC.FillRectangle(LineBrush2, update.rect);

                int BRUSHFRAMEHEIGHT = 25;
                int LEFTFRAMEOFFSET = 20;
                int TOPFRAMEOFFSET = 10;
                Rectangle fontRect = new Rectangle(update.rect.Left + LEFTFRAMEOFFSET + 5, update.rect.Top + TOPFRAMEOFFSET + 5, update.rect.Width - (LEFTFRAMEOFFSET * 2 + 5), update.rect.Height - (TOPFRAMEOFFSET * 2 + 10));
                pDC.DrawString(str, m_Font, brushFont, fontRect, alignFormat);

                Rectangle rectName = new Rectangle(update.rect.Left, update.rect.Bottom, update.rect.Width, (rectStorage.Bottom - update.rect.Bottom) - 20);
                alignFormat.LineAlignment = StringAlignment.Near;
                alignFormat.Alignment = StringAlignment.Center;
                pDC.DrawString(listStorageInfo[showStartPos + i].storageName, m_Font, brushFont, rectName, alignFormat);

                #region 画边框
                //Rectangle rectFrame = new Rectangle(rect[i].Left + 20, rect[i].Top + 10, rect[i].Width - 20, rect[i].Height - 10);

                int l = update.rect.Left + LEFTFRAMEOFFSET;
                int t = update.rect.Top + TOPFRAMEOFFSET;
                int r = update.rect.Right - LEFTFRAMEOFFSET;
                int b = update.rect.Bottom - TOPFRAMEOFFSET;

                brushFrame1 = new LinearGradientBrush(new Rectangle(l, t + 2, 1, BRUSHFRAMEHEIGHT),
                    colorFrame1, colorBack, LinearGradientMode.Vertical);
                brushFrame2 = new LinearGradientBrush(new Rectangle(l + 1, t + 2, 1, BRUSHFRAMEHEIGHT),
                        colorFrame2, colorBack, LinearGradientMode.Vertical);

                //上横线
                pDC.DrawLine(penFrame1, l + 2, t, r - 2, t);
                pDC.DrawLine(penFrame2, l + 2, t + 1, r - 2, t + 1);


                //上左竖线
                pDC.FillRectangle(brushFrame1, new Rectangle(l, t, 1, BRUSHFRAMEHEIGHT));
                pDC.FillRectangle(brushFrame2, new Rectangle(l + 1, t, 1, BRUSHFRAMEHEIGHT));

                //上右竖线
                pDC.FillRectangle(brushFrame1, new Rectangle(r - 1, t, 1, BRUSHFRAMEHEIGHT));
                pDC.FillRectangle(brushFrame2, new Rectangle(r - 2, t, 1, BRUSHFRAMEHEIGHT));


                brushFrame1 = new LinearGradientBrush(new Rectangle(l, b - BRUSHFRAMEHEIGHT - 2, 1, BRUSHFRAMEHEIGHT),
                    colorBack, colorFrame1, LinearGradientMode.Vertical);
                brushFrame2 = new LinearGradientBrush(new Rectangle(l + 1, b - BRUSHFRAMEHEIGHT - 2, 1, BRUSHFRAMEHEIGHT),
                        colorBack, colorFrame2, LinearGradientMode.Vertical);
                //下横线
                pDC.DrawLine(penFrame1, l + 2, b, r - 2, b);
                pDC.DrawLine(penFrame2, l + 2, b - 1, r - 2, b - 1);

                //下左竖线
                pDC.FillRectangle(brushFrame1, new Rectangle(l, b - BRUSHFRAMEHEIGHT + 1, 1, BRUSHFRAMEHEIGHT));
                pDC.FillRectangle(brushFrame2, new Rectangle(l + 1, b - BRUSHFRAMEHEIGHT + 1, 1, BRUSHFRAMEHEIGHT));

                //下右竖线
                pDC.FillRectangle(brushFrame1, new Rectangle(r - 1, b - BRUSHFRAMEHEIGHT + 1, 1, BRUSHFRAMEHEIGHT));
                pDC.FillRectangle(brushFrame2, new Rectangle(r - 2, b - BRUSHFRAMEHEIGHT + 1, 1, BRUSHFRAMEHEIGHT));

                //设置圆角
                pDC.DrawLine(penFrame1, l + 1, t, l + 1, t + 1);//上左竖
                pDC.DrawLine(penFrame1, l, t + 1, l + 1, t + 1);//上左横

                pDC.DrawLine(penFrame1, r - 2, t, r - 2, t + 1);//上右竖
                pDC.DrawLine(penFrame1, r - 2, t + 1, r - 1, t + 1);//上右横


                pDC.DrawLine(penFrame1, l + 1, b - 1, l + 1, b);//下左竖
                pDC.DrawLine(penFrame1, l, b - 1, l + 1, b - 1);//下左横

                pDC.DrawLine(penFrame1, r - 2, b - 1, r - 2, b);//下右竖
                pDC.DrawLine(penFrame1, r - 2, b - 1, r - 1, b - 1);//下右横
                #endregion
            }
            /*
            e.Graphics.FillRectangle(LineBrush1, rectStorage);

            int widthOffset = 220;
            int count = rectStorage.Width / widthOffset;
            if (count <= 0)
            {
                count = 3;
            }
            int width = widthOffset * count;
            int xoffset = rectStorage.Right - width;
            xoffset = xoffset / count;
            

            Rectangle[] rect = new Rectangle[count];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    rect[i] = new Rectangle(rectStorage.Left, rectStorage.Top + 20, widthOffset-20, rectStorage.Height / 2 + 20);
                }
                else
                {
                    rect[i] = new Rectangle(rect[i - 1].Right + xoffset, rectStorage.Top + 20, widthOffset - 20, rectStorage.Height / 2 + 20);
                        
                }

                //e.Graphics.FillRectangle(LineBrush2, rect[i]);     
            }

            xoffset = (rectStorage.Right - rect[count-1].Right) / 2;
            for (int y = 0; y < count; y++)
            {
                Rectangle t;
                t = rect[y];
                t.X += xoffset;
                rect[y] = t;
                e.Graphics.FillRectangle(LineBrush2, rect[y]);
            }
            
            */



            Rectangle rect1 = new Rectangle(rectStorage.Left, rectStorage.Top + 20, 200, rectStorage.Height / 2 + 20);
            //e.Graphics.FillRectangle(LineBrush2, rect1);

            rect1 = new Rectangle(rectStorage.Left + 220, rectStorage.Top + 20, 200, rectStorage.Height / 2 + 20);
            //e.Graphics.FillRectangle(LineBrush2, rect1);

            rect1 = new Rectangle(rectStorage.Left + 440, rectStorage.Top + 20, 200, rectStorage.Height / 2 + 20);
            //e.Graphics.FillRectangle(LineBrush2, rect1);
        }

        #region 分隔条
        public void DrawSeparatorBar(Graphics pDC, Rectangle rect)
        {
            pDC.DrawLine(linePen1, rect.Left, rect.Height / 2 - 1, rect.Right, rect.Height / 2 - 1);
            pDC.DrawLine(linePen2, rect.Left, rect.Height / 2, rect.Right, rect.Height / 2);
        }
        #endregion

        #region 读取数据库中的信息
        public void GetStorageData()
        {
            DataBaseConnection dataBase = new DataBaseConnection();
            DataSet storageData = dataBase.Query("select * from Storages order by id");
            SetStorageInfo(storageData);
            dataBase.Close();
        }

        public void SetStorageInfo(DataSet data)
        {
            Rectangle tt = rectStorage;
            if (listStorageInfo.Count() > 0)
            {
                listStorageInfo.Clear();
            }
            int count = data.Tables[0].Rows.Count;

            for (int i = 0; i < count; i++)
            {
                if (i == clickPos)
                {
                    storageInfo.nClick = 1;
                    storageInfo.isShow = true;
                }
                else
                {
                    storageInfo.nClick = 0;
                    storageInfo.isShow = false;
                }
                storageInfo.nFlags = 0;
                storageInfo.id = int.Parse(data.Tables[0].Rows[i]["id"].ToString());
                storageInfo.storageID = data.Tables[0].Rows[i]["仓库编号"].ToString();
                storageInfo.storageName = data.Tables[0].Rows[i]["仓库名称"].ToString();
                storageInfo.storageAddress = data.Tables[0].Rows[i]["仓库地址"].ToString();
                storageInfo.storageRemark = data.Tables[0].Rows[i]["备注"].ToString();

                listStorageInfo.Add(storageInfo);
            }
        }

        public void AddStorageData(STORAGEINFO info)
        {
            storageInfo.nClick = 0;
            storageInfo.nFlags = 0;
            storageInfo.isShow = false;
            storageInfo.id = info.id;
            storageInfo.storageID = info.storageID;
            storageInfo.storageName = info.storageName;
            storageInfo.storageAddress = info.storageAddress;
            storageInfo.storageRemark = info.storageRemark;

            listStorageInfo.Add(storageInfo);
        }
        #endregion

        public STORAGEINFO GetClickStorageData()
        {
            return listStorageInfo[clickPos];
        }

        public int GetClickPosition()
        {
            return clickPos;
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        { 
            if (e.Button == MouseButtons.Left)
            {
                for (int i = 0; i < listStorageInfo.Count(); i++)
                {
                    if (listStorageInfo[i].rect.Contains(e.X, e.Y) && listStorageInfo[i].isShow == true)
                    {
                        this.Visible = false;
                        storageRackManage.Visible = true;
                        storageRackManage.Dock = DockStyle.Fill;
                        Parent.Controls.Add(storageRackManage);
                        storageRackManage.ClearTabItem();
                        storageRackManage.SetStorageInfo(listStorageInfo[i].storageName, listStorageInfo[i].id);
                        storageRackManage.AddTabItem(listStorageInfo[i].storageName, "");
                        return;


















                        DataBaseConnection Conn = new DataBaseConnection();
                        string str;
                        str = "select * from StorageRacks where StorageID="+listStorageInfo[clickPos].id.ToString();
                        int count = Conn.GetCount(str);
                        Conn.Close();
                        //count = 0;
                        if (count== 0)
                        {
                            
                            /*
                            tabStorageRack.Visible = true;
                            tabStorageRack.Dock = DockStyle.Fill;
                            Parent.Controls.Add(tabStorageRack);
                            tabStorageRack.AddTabItem("Asas", "Asas");
                             * */
                        }
                    }
                }
            }
        }

        #region DevExpress.XtraGrid

        DevExpress.XtraGrid.GridControl gridTab = null;
        DevExpress.XtraGrid.Views.Grid.GridView gridView = null;
        //DataGridView gridTab = null;
        public void ShowXtraGridView(int id)
        {
            if (gridTab == null)
            {
                //gridTab = new DataGridView();
                gridTab = new DevExpress.XtraGrid.GridControl();
                gridTab.DoubleClick += new System.EventHandler(gridDoubleClick);
                gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
                gridTab.MainView = gridView;
                gridView.OptionsBehavior.Editable = false;
                gridView.GridControl = gridTab;
                this.Controls.Add(gridTab);
            }
            DataBaseConnection dataConn = new DataBaseConnection();

            DataSet da;
            string sql = "select id as '货架自动编号', "
                + "RackName as 货架名称, (select TypeName from RackType where RackTypeID=id) as 货架类型,"
                + "(select AreaType from RackArea where RackAreaID=id) as 存储区域,Remark as 备注, "
                + "(select [仓库编号] from Storages where StorageID=id) as 仓库名称,"
                + "(select id from Storages where StorageID=id) as 仓库自动编号"
                + " from StorageRacks where StorageID=" + id.ToString();
            da = dataConn.Query(sql);

            int count = da.Tables[0].Rows.Count;
            if (count <= 0)
            {
                gridTab.DataSource = null;
                return;
            }

            gridTab.DataSource = da.Tables[0];            
        }
        private void gridDoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridView.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int orderId = (int)gridView.GetRowCellValue(hi.RowHandle, "货架自动编号");
                string RackName = (string)gridView.GetRowCellValue(hi.RowHandle, "货架名称");
                int storageId = (int)gridView.GetRowCellValue(hi.RowHandle, "仓库自动编号");
                EditStorageRack editStorage = new EditStorageRack(ACTION.UPDATE, orderId, RackName, storageId);
                editStorage.ShowDialog();

                ShowXtraGridView(listStorageInfo[clickPos].id);
            }
            
        }

        private void ShowGridView()
        {
            if (gridTab != null)
            {
                Rectangle rect = GetClientRect();
                gridTab.Top = rect.Height / 2 + 5;
                gridTab.Left = rect.Left;
                gridTab.Width = rect.Width;
                gridTab.Height = rect.Bottom - gridTab.Top;
                
            }
        }
        #endregion
    }
}
