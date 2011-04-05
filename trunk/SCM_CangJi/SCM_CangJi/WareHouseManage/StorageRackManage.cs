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
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;

namespace SCM_CangJi.WareHouseManage
{
    public partial class StorageRackManage : TabFrameEx
    {
        private TabStorageManage storageManage;
        private string storageName; //仓库名
        private int storageID;   //仓库编号

        private NavigationRackButton buttonNav = null;
        private const int NAVIGHEIGHT = 25;

        public StorageRackManage()
        {
            storageManage = null;
            InitializeVariable();
            InitializeComponent();
        }

        public StorageRackManage(TabStorageManage storage)
        {
            storageManage = storage;

            InitializeVariable();
            InitializeComponent();
        }

        public void SetStorageInfo(string name, int id)
        {
            storageName = name;
            storageID = id;
            ShowXtraGridView(storageID);
            ShowGridView();
        }

        public string GetStorageName()
        {
            return storageName;
        }

        public int GetStorageId()
        {
            return storageID;
        }

        public void InitializeVariable()
        {
            buttonNav = new NavigationRackButton();
            this.Controls.Add(buttonNav);
            buttonNav.Click += new System.EventHandler(this.buttonNav_Click);
            buttonNav.CreateFrame(0, 0, 0, NAVIGHEIGHT, Color.FromArgb(173, 209, 255), Color.FromArgb(101, 147, 201));
            buttonNav.AddButton("增加货架", 0);
            buttonNav.AddButton("查找库位", 1);
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                SetTabXOffset(250);
                SetWindowsPos(this.Left, Parent.Top + 10, this.Width, this.Height);

                buttonNav.SetWindowPos(this.Left + 12, this.Top + 36, this.Width - (this.Left + 29), NAVIGHEIGHT);
                ShowGridView();
                Invalidate();
            }
        }

        private void OnPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics pDC = e.Graphics;
            DrawTab(pDC);
        }

        private void buttonNav_Click(object sender, EventArgs e)
        {
            string str = buttonNav.GetClickButtonName();

            switch (str)
            {
                case "增加货架":
                    EditStorageRack editStorage = new EditStorageRack(ACTION.INSERT, this);
                    editStorage.ShowDialog();
                    break;

                case "查找库位":

                    break;
            }
        }

        private void buttArrow_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            if (storageManage != null)
            {
                storageManage.Visible = true;
                storageManage.ShowXtraGridView(storageID);
            }
        }

        private void buttRackType_Click(object sender, EventArgs e)
        {
            EditRackType rackType = new EditRackType();
            rackType.ShowDialog();
        }

        private void buttRackArea_Click(object sender, EventArgs e)
        {
            EditRackArea rackArea = new EditRackArea();
            rackArea.ShowDialog();
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
                + "(select AreaType from RackArea where RackAreaID=id) as 存储区域,Remark as 备注,"
                + "(select [仓库编号] from Storages where StorageID=id) as 仓库名称"
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
                EditStorageRack editStorage = new EditStorageRack(ACTION.UPDATE, orderId, RackName, storageID);
                editStorage.ShowDialog();

                ShowXtraGridView(storageID);
            }
        }

        private void ShowGridView()
        {
            if (gridTab != null)
            {
                Rectangle rect = GetClientRect();
                gridTab.Top = buttonNav.Bottom + 1;
                gridTab.Left = buttonNav.Left;
                gridTab.Width = rect.Width;
                gridTab.Height = this.Height - (gridTab.Top+10);
            }
        }
        #endregion
    }
}
