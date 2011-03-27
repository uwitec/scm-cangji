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
    public partial class ConfirmDeliveryOrder :FormBase
    {
        #region ISingleton<ConfirmDeliveryOrder> Members
        private static ConfirmDeliveryOrder _instance = null;
        public static ConfirmDeliveryOrder Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ConfirmDeliveryOrder();
                }
                return _instance;
            }
        }


        #endregion

        private ConfirmDeliveryOrder()
        {
            InitializeComponent();
        }
        private void ConfirmDeliveryOrder_Load(object sender, EventArgs e)
        {
            InitGrid();
            

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            int RowHandle = gridControlDeliveryOrders.FocusedView.SourceRowHandle;
            if (RowHandle >= 0)
            {
                int orderId = (int)gridViewDeliveryOrders.GetRowCellValue(RowHandle, "Id");
                DeliveryOrderService.Instance.UpdateStatus(orderId, Lib.DeliveryStatus.已发货);
                InitGrid();
            }
        }

     
        public void InitGrid()
        {
            gridControlDeliveryOrders.DataSource = DeliveryOrderService.Instance.GetDeliveryOrdersView(Lib.DeliveryStatus.已分配库存);
            ShowMasterDetailRows();
        }

        private void ShowMasterDetailRows()
        {
            for (int i = 0; i < gridViewDeliveryOrders.RowCount; i++)
                gridViewDeliveryOrders.SetMasterRowExpanded(i, true);
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

        int orderrowhandle = -1;
        private void gridViewDeliveryOrders_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                orderrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

             
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