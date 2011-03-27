using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
using System.Threading;
using SCM_CangJi.BLL.Services;
namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class AutoAssignStorage : FormBase
    {
        private int _orderId;
        private DeliveryOrder _deliveryOrder;
        private IEnumerable<AssignedDeliveryOrderDetail> _assignedDeliveryDetails;
        private DataTable dt;
        private bool isSucess = true;
        public AutoAssignStorage(int orderId)
            : base()
        {
            _orderId = orderId;
            InitializeComponent();
            this.ProgressStart();
        }
        private void InitProduct()
        {
            gcProducts.DataSource = ProductService.Instance.GetProducts(_deliveryOrder.CompanyId);
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            _deliveryOrder = DeliveryOrderService.Instance.GetDeliveryOrder(_orderId);
            AutoAssign();
            InitProduct();
            dt = DeliveryOrderService.Instance.GetAssignedDetails(_orderId);
            foreach (var item in _assignedDeliveryDetails)
            {
                DataRow row = dt.NewRow();
                SetRowValue(ref row, item);
                dt.Rows.Add(row);
            }
            base.DoWork(sender, e);
        }

        private void AutoAssign()
        {
            _assignedDeliveryDetails = ProductStorageService.Instance.AutoAssign(_orderId);
        }
        protected override void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridControlDeliveryOrerDetails.DataSource = dt;
            ValidateData();
            base._bw_RunWorkerCompleted(sender, e);
        }
        private void SetRowValue(ref DataRow row, AssignedDeliveryOrderDetail assignedDetail)
        {
            row["DeliveryCount"] = assignedDetail.DeliveryCount;
            row["AssignCount"] = assignedDetail.AssignCount;
            row["InputInvoice"] = assignedDetail.InputInvoice;
            row["LotsNumber"] = assignedDetail.LotsNumber;
            row["ProductId"] = assignedDetail.ProductId;
            row["DeliveryOrderId"] = assignedDetail.DeliveryOrderId;
            if (assignedDetail.ProductDate != null)
                row["ProductDate"] = assignedDetail.ProductDate;
            row["ProductStorageId"] = assignedDetail.ProductStorageId;
            row["CurrentProductNumber"] = assignedDetail.CurrentProductNumber;
            row["StorageArea"] = assignedDetail.StorageArea;
            row["IsSucess"] = assignedDetail.IsSucess;
           // row["CurrentProductNumber"] = assignedDetail.ProductStorage.CurrentProductNumber;
        }

        private void btnCompleteAssign_Click(object sender, EventArgs e)
        {
            BLL.Services.DeliveryOrderService.Instance.CreateAssignedDetails(_orderId,_assignedDeliveryDetails);
            PickProductsOrder p = new PickProductsOrder(_orderId, false);
            p.Show();
        }
        private void ValidateData()
        {
            foreach (var item in _assignedDeliveryDetails)
            {
                if (item.AssignCount < 0)
                {
                    isSucess = false;
                }
            }
            if (!isSucess)
            {
                ShowWarning("分配失败，可能是库存不足！请退回修改预入库单！");
                this.btnCompleteAssign.Enabled = false;

            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PickProductsOrder p = new PickProductsOrder(_orderId,false);
            p.Show();
        }

        private void gridViewDeliveryOrderDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = e.Row  as DataRow;
        }

        private void gridViewDeliveryOrderDetails_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "AssignCount")
            {
                if (((int)e.CellValue) <= 0)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Retry;
        }

    }
}