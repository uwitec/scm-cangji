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
using SCM_CangJi.Lib;

namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class AssigningProducts: FormBase
    {
        #region ISingleton<AssigningProducts> Members
        private static AssigningProducts _instance = null;
        public static AssigningProducts Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new AssigningProducts();
                }
                return _instance;
            }
        }


        #endregion
        public AssigningProducts()
        {
            InitializeComponent();
            InitGrid();
        }

        private void InitGrid()
        {
            gridControlDeliveryOrders.DataSource = DeliveryOrderService.Instance.GetDeliveryOrders(Lib.DeliveryStatus.待分配库存);
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int RowHandle= gridViewDeliveryOrders.GetFocusedDataSourceRowIndex();
            if (RowHandle >= 0)
            {
                int orderId = (int)gridViewDeliveryOrders.GetRowCellValue(RowHandle, "Id");
                AutoAssignStorage assignStorage = new AutoAssignStorage(orderId);
                DialogResult reslut=assignStorage.ShowDialog();
                if (reslut == System.Windows.Forms.DialogResult.OK)
                {
                    InitGrid();
                }
                else if (reslut == System.Windows.Forms.DialogResult.Retry)
                {
                    BLL.Services.DeliveryOrderService.Instance.UpdateStatus(orderId, DeliveryStatus.待出库);
                    InitGrid();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void gridControlDeliveryOrders_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewDeliveryOrders.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int orderId = (int)gridViewDeliveryOrders.GetRowCellValue(hi.RowHandle, "Id");
                int companyId = (int)gridViewDeliveryOrders.GetRowCellValue(hi.RowHandle, "CompanyId");
                ViewPreDeliveryDetails viewform = new ViewPreDeliveryDetails(orderId,companyId);
                if (viewform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int RowHandle = gridViewDeliveryOrders.GetFocusedDataSourceRowIndex();
            if (RowHandle >= 0)
            {
                int orderId = (int)gridViewDeliveryOrders.GetRowCellValue(RowHandle, "Id");
                object deliveryNumber = gridViewDeliveryOrders.GetRowCellValue(RowHandle, "DeliveryOrderNumber");
                if (ShowQuestion(string.Format("确实要打回预出库订单：{0},进行修改预分配吗？", deliveryNumber)) == System.Windows.Forms.DialogResult.OK)
                {
                    BLL.Services.DeliveryOrderService.Instance.UpdateStatus(orderId,DeliveryStatus.待出库);
                    InitGrid();
                }
            }
        }
    }
}