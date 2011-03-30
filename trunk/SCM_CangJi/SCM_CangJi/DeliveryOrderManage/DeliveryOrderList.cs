using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class DeliveryOrderList :FormBase
    {
        #region ISingleton<DeliveryOrderList> Members
        private static DeliveryOrderList _instance = null;
        public static DeliveryOrderList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new DeliveryOrderList();
                }
                return _instance;
            }
        }


        #endregion

        public DeliveryOrderList()
        {
            InitializeComponent();
            ProgressStart();
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            InitGrid();
            base.DoWork(sender, e);
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

        public void InitGrid()
        {
            gridControlDeliveryOrders.DataSource = DeliveryOrderService.Instance.GetDeliveryOrders(Lib.DeliveryStatus.待出库);
        }

        private void gridControlDeliveryOrders_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewDeliveryOrders.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int orderId = (int)gridViewDeliveryOrders.GetRowCellValue(hi.RowHandle, "Id");
                PreDeliveryOrder editform = new PreDeliveryOrder(orderId);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitGrid();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PreDeliveryOrder preForm = new PreDeliveryOrder();
            preForm.MdiParent = this.MdiParent;
            preForm.Show();
        }
        int orderrowhandle = -1;
        private void gridViewDeliveryOrders_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                orderrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemCreate = new DXMenuItem("新建", new EventHandler(btnCreate_Click));
                e.Menu.Items.Add(menuItemCreate);


                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                {
                    if (XtraMessageBox.Show("该动作将会删除相关明细列表，确实要删除吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        int orderId = (int)gridViewDeliveryOrders.GetRowCellValue(orderrowhandle, "Id");
                        string message = "";
                        if (DeliveryOrderService.Instance.Delete(orderId, out message))
                        {
                            gridViewDeliveryOrders.DeleteSelectedRows();
                        }
                        else
                        {
                            ShowMessage(message);
                        }
                    }
                });
                e.Menu.Items.Add(menuItemDelete);
                DXMenuItem menuItemrefrash = new DXMenuItem("刷新", (s, en) =>
                {
                    InitGrid();
                });
                e.Menu.Items.Add(menuItemrefrash);

                orderrowhandle = e.HitInfo.RowHandle;
            }
        }

    }
}