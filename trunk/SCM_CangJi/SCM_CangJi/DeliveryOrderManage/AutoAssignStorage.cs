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
           // row["CurrentProductNumber"] = assignedDetail.ProductStorage.CurrentProductNumber;
        }

        private void btnCompleteAssign_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            PickProductsOrder p = new PickProductsOrder(_orderId);
            p.Show();
        }

    }
}