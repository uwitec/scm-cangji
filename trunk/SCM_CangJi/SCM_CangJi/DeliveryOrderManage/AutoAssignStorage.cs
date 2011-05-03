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
using SCM_CangJi.Reports;
using SCM_CangJi.BLL;
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
            dt = DeliveryOrderService.Instance.GetDeliveryOrderAssignedDetailsDataTable(_orderId);
            dt.Columns.Add("StorageArea");
            foreach (var item in _assignedDeliveryDetails)
            {
                DataRow row = dt.NewRow();
                SetRowValue(ref row, item);
                dt.Rows.Add(row);
            }
            this.Updated = false;
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
            row["StorageArea"] = ProductStorageService.Instance.GetArea(assignedDetail.StorageAreaId);
            row["IsSucess"] = assignedDetail.IsSucess;
           // row["CurrentProductNumber"] = assignedDetail.ProductStorage.CurrentProductNumber;
            SetProductRow(row, assignedDetail.ProductId);
        }
        private void SetProductRow(DataRow row, int ProductId)
        {
            Product product = ProductService.Instance.GetProduct(ProductId);
            row["ProductNumber1"] = product.ProductNumber1;
            row["ProductChName"] = product.ProductChName;
            row["ProductEngName"] = product.ProductEngName;
            row["ProductNumber2"] = product.ProductNumber2;
            row["Spec"] = product.Spec;
            row["Brand"] = product.Brand;
        }
        private void btnCompleteAssign_Click(object sender, EventArgs e)
        {
            BLL.Services.DeliveryOrderService.Instance.CreateAssignedDetails(_orderId,_assignedDeliveryDetails);
            _deliveryOrder=DeliveryOrderService.Instance.GetDeliveryOrder(_orderId);
            this.Updated = true;
            ShowMessage("分配库存完成");
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
            DeliveryOrderService.Instance.SendBackLostStep(this._deliveryOrder.Id, this._deliveryOrder.Status);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnPrintPickOrder_Click(object sender, EventArgs e)
        {
            if (!this.Updated)
            {
                ShowWarning("还未确认分配！请完成分配后再打印");
                return;
            }
            PickProductsReport report = new PickProductsReport();
            DataSet ds = new DataSet();
            DataTable dt = DeliveryOrderService.Instance.GetDeliveryOrderAssignedDetailsDataTable(_orderId);
            dt.Columns.Add("Area");
            foreach (DataRow row in dt.Rows)
            {
                row["Area"] = ProductStorageService.Instance.GetArea(int.Parse(row["StorageAreaId"].TrytoString()));
            }
            DataTable dt2 = DeliveryOrderService.Instance.GetDeliveryOrderDataTable(_orderId);
            ds.Tables.Add(dt2);
            ds.Tables.Add(dt);
            report.DataSource = ds;
            report.ShowPreviewDialog();
            //PickProductsOrder p = new PickProductsOrder(_orderId, false);
            //p.Show();
        }

    }
}