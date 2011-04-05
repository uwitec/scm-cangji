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
    public class TabStorageRack : TabFrameEx
    {
        #region 变量
        StorageDataView m_pKuFangAddView;
        TabStorageManage storageManage;

        ButtonEx buttArrow = null;

        String m_strCKID;	//仓库号
        Rectangle [] m_rc;
	    bool jd;
        bool add;

        Point MousePoint = new Point();

        #endregion

        public TabStorageRack()
        {
            storageManage = null;

            InitializeVariable();
            InitializeComponent();
        }

        public TabStorageRack(TabStorageManage storage)
        {   
            storageManage = storage;

            InitializeVariable();
            InitializeComponent();
        }

        private void InitializeVariable()
        {
            m_rc = new Rectangle[2];
        }

        public void SetCWInfo(String szID, String szName, int row, int col)
        {
        }

	    public void SetCKID(String id)
        {
            m_strCKID = id;
        }

	    public String GetCKID()
        {
            return m_strCKID;
        }

        public void DeleteCWInfo()
        {

        }

        public void DrawFillet(Graphics pDC, int x, int y, int iwidth, int iheight)
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TabStorageArea
            // 
            m_pKuFangAddView = new StorageDataView();

            buttArrow = new ButtonEx(); 
            this.Controls.Add(buttArrow);
            buttArrow.Click += new System.EventHandler(this.buttArrow_Click);
            buttArrow.CreateWindow("ARROW", 30, 8, 20, 20, ButtonEx.STYLE.ARROW);

            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);
        }

        private void buttArrow_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            if (storageManage != null)
            {
                storageManage.Visible = true;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            int iCheck;

            MousePoint.X = e.X;
            MousePoint.Y = e.Y;

            iCheck = m_pKuFangAddView.GetActivitRow(MousePoint);
            if (iCheck > -1)
            {
                m_pKuFangAddView.SetActivitRow(iCheck - 1);
                Invalidate();
            }

            iCheck = m_pKuFangAddView.CheckPaiPos(MousePoint);
            if (iCheck > -1)
            {
                m_pKuFangAddView.SetPaiFocus(iCheck);
                Invalidate();
            }

            Invalidate();
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {  
                int iCheck;

                MousePoint.X = e.X;
                MousePoint.Y = e.Y;

                iCheck = m_pKuFangAddView.GetActivitRow(MousePoint);
                if (iCheck > -1)
                {
                    m_pKuFangAddView.SetActivitRow(iCheck - 1);
                    //int paicount = m_pKuFangAddView.GetWPCount();
                    //m_RKDialog->SetCangWeiView(this, row, paicount);
                    //m_RKDialog->DoModal();
                }

            }
        }
        private void OnResize(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                SetTabXOffset(100);
                SetWindowsPos(this.Left, Parent.Top + 10, this.Width, this.Height);
                Invalidate();
            }
        }

        private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            DrawTab(e.Graphics);
            
            Rectangle rcClient = GetFrameRect();
            
            if (rcClient.Left>0)
                m_pKuFangAddView.OnDraw(e.Graphics, rcClient);
            
        }
    }
}
