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
using System.Data.Linq;
using System.Linq;
namespace SCM_CangJi.InputOrderManage
{
    public partial class AssignStorageArea : FormBase
    {
        private int _orderId;
        private InputOrder _inputOrder;
        private DataTable dt;
        public IEnumerable<InputOrderDetail> _assignedInputDetails;
        public AssignStorageArea(int orderId)
            : base()
        {
            _orderId = orderId;
            InitializeComponent();
            this.ProgressStart();
        }
        private void InitDll()
        {
            gcProducts.DataSource = ProductService.Instance.GetProducts(_inputOrder.CompanyId);
            CommonService.BindDDLStorageArea(gcStorageArea);
        }
        
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            _inputOrder = InputOrderService.Instance.GetInputOrder(_orderId);
            _assignedInputDetails = _inputOrder.InputOrderDetails.ToList();
            InitDll();
          
            base.DoWork(sender, e);
        }

        protected override void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dt = InputOrderService.Instance.GetInputOrderDetailsDataTable(_orderId);
            gridControlInputOrerDetails.DataSource = dt;
            base._bw_RunWorkerCompleted(sender, e);
        }
      
        private void btnCompleteAssign_Click(object sender, EventArgs e)
        {
           InputOrderService.Instance.CompleteAssignStorageArea(_orderId, _assignedInputDetails);
           PrintCurrentProductOrder printForm = new PrintCurrentProductOrder(_orderId, false);
           printForm.Show();
        }
       
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //PickProductsOrder p = new PickProductsOrder(_orderId, false);
            //p.Show();
        }

        private void gridViewInputOrderDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = e.Row as DataRow;
        }

        private void gridViewInputOrderDetails_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "StorageAreaId")
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

        private void gridViewInputOrderDetails_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            lock (this)
            {
                DataRow row = (e.Row as DataRowView).Row;
                Updated = false;
                var detail = this._assignedInputDetails.SingleOrDefault(o => o.ID.Equals(row["ID"]));
                if (detail == null)
                {
                    DeliveryOrderDetail newDetail = new DeliveryOrderDetail();
                }
                else
                {
                    SetValue(row, ref detail);
                }
            }
        }

        private void SetValue(DataRow row, ref InputOrderDetail detail)
        {
            detail.StorageAreaId = int.Parse(row["StorageAreaId"].ToString());
        }

    }
}