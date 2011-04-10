using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class PreDeliveryOrder : FormBase
    {
        private int _orderId = 0;
        private DeliveryOrder order = null;
        private int _companyId = 0;
        public int CompanyId
        {
            set
            {
                if (value > 0 && _companyId != value)
                {
                    _companyId = value;
                    InitProduct();
                }
            }
        }
        DataTable _deliveryOrderDetailsDatable = null;
        public DataTable DeliveryOrderDetailsDatatable
        {
            get
            {
                if (_deliveryOrderDetailsDatable == null)
                {
                    _deliveryOrderDetailsDatable = DeliveryOrderService.Instance.GetDeliveryOrderDetailsDataTable(_orderId);
                }
                return _deliveryOrderDetailsDatable;
            }
        }

        public PreDeliveryOrder():this(0)
        {
            this.Updated = false;
        }
        protected override string CloseingMessage()
        {
            
            return string.Format("出库单：{0}，未保存",lblDeliveryOrderNumber.Text);
            //return base.CloseingMessage();
        }
        public PreDeliveryOrder(int orderId)
            : base()
        {
            _orderId = orderId;

            InitializeComponent();
            InitData();
            btnImport.Visible = false;
            if (_orderId > 0)
            {
                ddlCompanies.Enabled = false;
                if (this.order.Status != DeliveryStatus.待出库.ToString())
                {
                    btnAddDetail.Visible = false;
                    btnImport.Visible = false;
                    btnPreCompletedAndAssign.Visible = false;
                    btnSaveAll.Visible = false;
                    btn.Visible = false;
                    btnSaveAndClose.Visible = false;
                    this.gridViewDeliveryOrderDetails.OptionsBehavior.Editable = false;
                    this.gridControlDeliveryOrerDetails.DoubleClick -= gridControlDeliveryOrerDetails_DoubleClick;
                    this.gridViewDeliveryOrderDetails.ShowGridMenu -= gridViewDeliveryOrderDetails_ShowGridMenu;
                }
            }

            ProgressStart();
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            base.DoWork(sender, e);
        }
        private void InitData()
        {
            CommonService.BindDDLCompany(ddlCompanies);
            if (_orderId > 0)
            {
                order = DeliveryOrderService.Instance.GetDeliveryOrder(_orderId);
                txtInvoice.EditValue = order.Invoice;
                txtReachedDate.EditValue = order.ReachedDate;
                lblPreDeliveryDate.Text = order.PreDeliveryDate.ToShortDateString();
                lblDeliveryOrderNumber.Text = order.DeliveryOrderNumber;
                ddlCompanies.EditValue = order.CompanyId;
                InitOrderDetails();
                InitAssingedDetails();
            }
            else
            {
                //SHP-20100305001
                tabAssigned.PageVisible = false;
                order = new DeliveryOrder();
                lblDeliveryOrderNumber.Text = CommonService.Instance.GetOrderNumber(OrderType.DeliveryOrder);
                lblPreDeliveryDate.Text = DateTime.Now.ToShortDateString();
                //txtReachedDate.EditValue = DateTime.Now.Date;
                InitOrderDetails();
            }
        }

      

        #region Delivery Base
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                if (dxValidationProvider1.Validate())
                {
                    SetOrderValue();
                    SetOrderDetailsValue();
                    if (this.order.Id > 0)
                    {

                        DeliveryOrderService.Instance.Update(this.order);
                        //InitOrderDetails();
                    }
                    else
                    {
                        DeliveryOrderService.Instance.Create(this.order);
                        this._orderId = this.order.Id;
                        
                    }
                    Updated = true;
                    Reset();
                    DeliveryOrderList.Instance.InitGrid();
                }
            }
           
        }
        private void Reset()
        {
            this.order = DeliveryOrderService.Instance.GetDeliveryOrder(order.Id);
            this._deliveryOrderDetailsDatable = DeliveryOrderService.Instance.GetDeliveryOrderDetailsDataTable(order.Id);
            InitData();
        }
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            btnSaveAll_Click(sender, e);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            if (this.MdiParent != null && dxValidationProvider1.Validate())
            {
                this.Close();
            }
        }


        //private void btnSaveBase_Click(object sender, EventArgs e)
        //{
        //    if (dxValidationProvider1.Validate())
        //    {
        //        UpdateOrder();
        //        DeliveryOrderList.Instance.InitGrid();
        //    }
        //}
        //private void UpdateOrder()
        //{
        //    if (_orderId > 0)
        //    {
        //        SetOrderValue();
        //        DeliveryOrderService.Instance.Update(this.order);
        //    }
        //    else
        //    {
        //        this.order = new DeliveryOrder();
        //        SetOrderValue();
        //        this.order.Status = DeliveryStatus.待出库.ToString();
        //        DeliveryOrderService.Instance.Create(this.order);
        //        _orderId = this.order.Id;
        //    }
        //}
        private void SetOrderValue()
        {
            this.order.CompanyId = int.Parse(ddlCompanies.EditValue.ToString());
            this.order.DeliveryAddressId = int.Parse(ddlDeliveryAddress.EditValue.TrytoString());
            this.order.Status = SCM_CangJi.Lib.DeliveryStatus.待出库.ToString();
            this.order.DeliveryOrderNumber = lblDeliveryOrderNumber.Text;
            this.order.Invoice = txtInvoice.EditValue.TrytoString();
            this.order.PreDeliveryDate = DateTime.Parse(lblPreDeliveryDate.Text);
            this.order.ReachedDate = DateTime.Parse(txtReachedDate.EditValue.TrytoString());
        }

        private void ddlCompanies_Properties_EditValueChanged(object sender, EventArgs e)
        {
            CompanyId=int.Parse(ddlCompanies.EditValue.ToString());
            CommonService.BindDDLDeliveryAddress(ddlDeliveryAddress, _companyId);
            if (_orderId > 0)
            {
                ddlDeliveryAddress.EditValue = order.DeliveryAddressId;
            }
        } 
        #endregion

        #region Delivery Detail

        private void InitProduct()
        {
            gcProducts.DataSource = ProductService.Instance.GetProducts(_companyId);
        }

        private void InitOrderDetails()
        {
            gridControlDeliveryOrerDetails.DataSource = this.DeliveryOrderDetailsDatatable;
        }
        private void InitAssingedDetails()
        {
            gridControlAsssigned.DataSource = DeliveryOrderService.Instance.GetAssignedDeliveryOrderDetails(order.Id);
        }
        private void SetOrderDetailsValue()
        {
            this.order.DeliveryOrderDetails.Clear();
            foreach (DataRow item in DeliveryOrderDetailsDatatable.Rows)
            {
                DeliveryOrderDetail detail = new DeliveryOrderDetail();
                SetValue(item,ref detail);

                this.order.DeliveryOrderDetails.Add(detail);
            }
        }
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                EditDeliveryDetail editform = new EditDeliveryDetail(_orderId, _companyId);
                editform.OnDeliveryDetailSaveing += new Func<DeliveryOrderDetail,DeliveryOrder>(editform_OnDeliveryDetailAdd);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitOrderDetails();
                }
            }

        }

        DeliveryOrder editform_OnDeliveryDetailAdd(DeliveryOrderDetail obj)
        {
            //UpdateOrder();
            if (obj.Id > 0)
            {
            }
            else
            {
                gridViewDeliveryOrderDetails.AddNewRow();
                DataRow row = gridViewDeliveryOrderDetails.GetFocusedDataRow();
                SetRowValue(row, obj);
                gridViewDeliveryOrderDetails.UpdateCurrentRow();
            }
            return this.order;
        }

       
       
        private void gridControlDeliveryOrerDetails_DoubleClick(object sender, EventArgs e)
        {
            //GridHitInfo hi = gridViewDeliveryOrderDetails.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            //if (hi.RowHandle >= 0)
            //{
            //    int orderDetailId = (int)gridViewDeliveryOrderDetails.GetRowCellValue(hi.RowHandle, "Id");
            //    EditDeliveryDetail editform = new EditDeliveryDetail(_orderId, _companyId, orderDetailId);
            //    if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        InitOrderDetails();
            //    }
            //}

        }
        int orderdetailrowhandle = -1;
        private void gridViewDeliveryOrderDetails_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                orderdetailrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemCreate = new DXMenuItem("增加", new EventHandler(btnAddDetail_Click));
                e.Menu.Items.Add(menuItemCreate);


                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                {
                    if (XtraMessageBox.Show("确实要删除吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        int orderdetailId = (int)gridViewDeliveryOrderDetails.GetRowCellValue(orderdetailrowhandle, "Id");
                        string message = "";
                        if (DeliveryOrderService.Instance.DeleteDetail(orderdetailId, out message))
                        {
                            gridViewDeliveryOrderDetails.DeleteSelectedRows();
                            this._deliveryOrderDetailsDatable = DeliveryOrderService.Instance.GetDeliveryOrderDetailsDataTable(order.Id);
                            this.order = DeliveryOrderService.Instance.GetDeliveryOrder(order.Id);
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
                    _deliveryOrderDetailsDatable = null;
                    InitOrderDetails();
                });
                e.Menu.Items.Add(menuItemrefrash);

                orderdetailrowhandle = e.HitInfo.RowHandle;
            }
        }
      

        private void gridViewDeliveryOrderDetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gridViewDeliveryOrderDetails.GetDataRow(e.RowHandle);
            row["DeliveryOrderId"] = this.order.Id;
            row["ProductStorageId"] = 0;
            row["AssignCount"] = 0;
        }

        private void gridViewDeliveryOrderDetails_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            lock (this)
            {
                Updated = false;
                DataRow row = (e.Row as DataRowView).Row;
                var detail = this.order.DeliveryOrderDetails.SingleOrDefault(o => o.Id.Equals(row["Id"]));
                if (detail == null)
                {
                    DeliveryOrderDetail newDetail = new DeliveryOrderDetail();
                    SetValue(row, ref newDetail);
                    this.order.DeliveryOrderDetails.Add(newDetail);
                }
                else
                {
                    SetValue(row, ref detail);
                }
            }
           
        }
        private void SetValue(DataRow row, ref DeliveryOrderDetail detail)
        {
            detail.DeliveryCount = int.Parse(row["DeliveryCount"].ToString());
            if (detail.DeliveryOrderId == 0)
            {
                detail.DeliveryOrderId = int.Parse(row["DeliveryOrderId"].ToString());
            }
            detail.Id = int.Parse(row["Id"].ToString());
            detail.InputInvoice = row["InputInvoice"].ToString();
            detail.LotsNumber = row["LotsNumber"].ToString();
            if (row["ProductDate"] != null && !string.IsNullOrEmpty(row["ProductDate"].ToString()))
                detail.ProductDate = DateTime.Parse(row["ProductDate"].ToString());
            detail.ProductId = int.Parse(row["ProductId"].ToString());
            detail.ProductStorageId = 0; 
        }
        private void SetRowValue(DataRow row, DeliveryOrderDetail detail)
        {
            row["DeliveryCount"] = detail.DeliveryCount;
            row["InputInvoice"] = detail.InputInvoice;
            row["LotsNumber"] = detail.LotsNumber;
            row["ProductId"] = detail.ProductId;
            row["Id"] = detail.Id;
            if (detail.ProductDate != null)
                row["ProductDate"] = detail.ProductDate;
        }

        #region Import
        private void btnImport_Click(object sender, EventArgs e)
        {
            //if (dxValidationProvider1.Validate())
            //{
            //    ImportDetails importForm = new ImportDetails(_companyId);
            //    importForm.OnImported += new Action<IEnumerable<DeliveryOrderDetail>>(importForm_OnImported);
            //    if (importForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {

            //    }
            //}
        }

        void importForm_OnImported(IEnumerable<DeliveryOrderDetail> deteail)
        {

        }
        #endregion

        private void btnPreCompleted_Click(object sender, EventArgs e)
        {
            if (!this.Updated)
            {
                ShowWarning("还未保存！请先保存后在完成预出库！");
                return;
            }
            if (_deliveryOrderDetailsDatable == null || _deliveryOrderDetailsDatable.Rows.Count == 0)
            {
                ShowWarning("请至少输入一个出库明细！");
                return;
            }
            if (ShowQuestion("您确实要开始分配库存吗？") == System.Windows.Forms.DialogResult.OK)
            {
                AutoAssignStorage assignStorage = new AutoAssignStorage(this.order.Id);
                if (assignStorage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.order.Status = DeliveryStatus.待分配库存.ToString();
                    DeliveryOrderService.Instance.Update(order);
                    InitData();
                }
            }
        }

        #endregion

        private void btn_Click(object sender, EventArgs e)
        {
            if (!this.Updated)
            {
                ShowWarning("还未保存！请先保存后在完成预出库！");
                return;
            }
            if (_deliveryOrderDetailsDatable == null || _deliveryOrderDetailsDatable.Rows.Count == 0)
            {
                ShowWarning("请至少输入一个出库明细！");
            }
            else
            {
                this.order.Status = DeliveryStatus.待分配库存.ToString();
                DeliveryOrderService.Instance.Update(order);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                ShowMessage("预出库完成！");
                this.Close();
            }
        }
      
    }
}