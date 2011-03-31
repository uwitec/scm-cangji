using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.Lib;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace SCM_CangJi.InputOrderManage
{
    public partial class AssignedAreaList :FormBase
    {
        #region ISingleton<AssignedAreaList> Members
        private static AssignedAreaList _instance = null;
        public static AssignedAreaList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new AssignedAreaList();
                }
                return _instance;
            }
        }


        #endregion
        public AssignedAreaList()
        {
            InitializeComponent();
            this.ProgressStart();
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            InitGrid();
            base.DoWork(sender, e);
        }
        private void InitGrid()
        {
            gridControlInputOrders.DataSource = InputOrderService.Instance.GetInputOrdersFull(Lib.InputStatus.待分配库位);
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            int RowHandle = gridViewInputOrders.GetFocusedDataSourceRowIndex();
            if (RowHandle >= 0)
            {
                int orderId = (int)gridViewInputOrders.GetRowCellValue(RowHandle, "ID");
                AssignStorageArea assignStorage = new AssignStorageArea(orderId);
                DialogResult reslut = assignStorage.ShowDialog();
                if (reslut == System.Windows.Forms.DialogResult.OK)
                {
                    InitGrid();
                }
                else if (reslut == System.Windows.Forms.DialogResult.Retry)
                {
                    BLL.Services.InputOrderService.Instance.UpdateStatus(orderId, InputStatus.待入库);
                    InitGrid();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void gridControlInputOrders_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewInputOrders.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int orderId = (int)gridViewInputOrders.GetRowCellValue(hi.RowHandle, "ID");
                int companyId = (int)gridViewInputOrders.GetRowCellValue(hi.RowHandle, "CompanyId");
                //ViewPreInputDetails viewform = new ViewPreInputDetails(orderId, companyId);
                //if (viewform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{

                //}
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int RowHandle = gridViewInputOrders.GetFocusedDataSourceRowIndex();
            if (RowHandle >= 0)
            {
                int orderId = (int)gridViewInputOrders.GetRowCellValue(RowHandle, "ID");
                object inputNumber = gridViewInputOrders.GetRowCellValue(RowHandle, "InputOrderNumber");
                if (ShowQuestion(string.Format("确实要打回入库单：{0},进行修改吗？", inputNumber)) == System.Windows.Forms.DialogResult.OK)
                {
                    BLL.Services.InputOrderService.Instance.UpdateStatus(orderId, InputStatus.待入库);
                    InitGrid();
                }
            }
        }
    }
}