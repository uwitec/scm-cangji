using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using SCM_CangJi.DAL;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL.Security;
using SCM_CangJi.BLL;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace SCM_CangJi.InputOrderManage
{
    public partial class PreInputOrder : FormBase
    {
        private int _orderId = 0;
        private InputOrder order = null;
        private int _companyId = 0;
        bool HasValidateDetailData = true;
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
        DataTable _inputOrderDetailsDatable = null;
        public DataTable InputOrderDetailsDatatable
        {
            get
            {
                if (_inputOrderDetailsDatable == null)
                {
                    _inputOrderDetailsDatable = InputOrderService.Instance.GetInputOrderDetailsDataTable(_orderId);
                }
                return _inputOrderDetailsDatable;
            }
        }
        
        public PreInputOrder()
            : this(0)
        {
            this.Updated = false;
        }
        protected override string CloseingMessage()
        {
            
            return string.Format("入库单：{0}，未保存",lblInputOrderNumber.Text);
            //return base.CloseingMessage();
        }
        public PreInputOrder(int orderId)
            : base()
        {
            _orderId = orderId;

            InitializeComponent();
            InitData();
            if (_orderId > 0)
            {
                ddlCompanies.Enabled = false;
                if (this.order.Status != InputStatus.待入库.ToString())
                {
                    btnAddDetail.Visible = false;
                    btnImport.Visible = false;
                    btnPreCompletedAndAssign.Visible = false;
                    btnSaveAll.Visible = false;
                    btnPreComplete.Visible = false;
                    btnSaveAndClose.Visible = false;
                    this.gridViewInputOrderDetails.OptionsBehavior.Editable = false;
                    if (this.order.Status == InputStatus.已入库.ToString() || this.order.Status == InputStatus.作废.ToString())
                    {
                    }
                    else
                    {
                        btnBack.Visible = true;
                    }
                    this.gridControlInputOrerDetails.DoubleClick -= gridControlInputOrerDetails_DoubleClick;
                    this.gridViewInputOrderDetails.ShowGridMenu -= gridViewInputOrderDetails_ShowGridMenu;
                }
            }

            ProgressStart();

        }
        private void InitData()
        {
            CommonService.BindDDLCompany(ddlCompanies);
            if (_orderId > 0)
            {
                order = InputOrderService.Instance.GetInputOrder(_orderId);
                txtInvoice.EditValue = order.Invoice;
                lblEnterUser.Text = order.EnterUser;
                lblPreInputDate.Text = order.PreInputDate.ToShortDateString();
                lblInputOrderNumber.Text = order.InputOrderNumber;
                ddlCompanies.EditValue = order.CompanyId;
                txtFromWhere.EditValue = order.FromWhere;
                InitOrderDetails();
            }
            else
            {
                //REC-20100305001
                order = new InputOrder();
                lblInputOrderNumber.Text = CommonService.Instance.GetOrderNumber(OrderType.InputOrder);
                lblPreInputDate.Text = DateTime.Now.ToShortDateString();
                lblEnterUser.Text = SecurityContext.Current.CurrentyUser.UserName;
                //txtReachedDate.EditValue = DateTime.Now.Date;
                InitOrderDetails();
            }
        }

        #region Input Base
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                if (dxValidationProvider1.Validate())
                {
                    SetOrderValue();
                    SetOrderDetailsValue();
                    if (this.order.ID > 0)
                    {

                        InputOrderService.Instance.Update(this.order);
                        //InitOrderDetails();
                    }
                    else
                    {
                        InputOrderService.Instance.Create(this.order);
                        this._orderId = this.order.ID;

                    }
                    Updated = true;
                    Reset();
                    //InputOrderList.Instance.InitGrid();
                }
            }

        }
        private void Reset()
        {
            this.order = InputOrderService.Instance.GetInputOrder(order.ID);
            this._inputOrderDetailsDatable = InputOrderService.Instance.GetInputOrderDetailsDataTable(order.ID);
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


        private void SetOrderValue()
        {
            this.order.CompanyId = int.Parse(ddlCompanies.EditValue.ToString());
            this.order.Status = SCM_CangJi.Lib.InputStatus.待入库.ToString();
            this.order.EnterUser = SecurityContext.Current.CurrentyUser.UserName;
            this.order.InputOrderNumber = lblInputOrderNumber.Text;
            this.order.Invoice = txtInvoice.EditValue.TrytoString();
            this.order.PreInputDate = DateTime.Parse(lblPreInputDate.Text);
            this.order.FromWhere = txtFromWhere.EditValue.TrytoString();
        }
        #endregion

        #region Input Detail

        private void InitProduct()
        {
            gcProducts.DataSource = ProductService.Instance.GetProducts(_companyId);
        }

        private void InitOrderDetails()
        {
            gridControlInputOrerDetails.DataSource = this.InputOrderDetailsDatatable;
        }
        private void SetOrderDetailsValue()
        {
            this.order.InputOrderDetails.Clear();
            foreach (DataRow item in InputOrderDetailsDatatable.Rows)
            {
                InputOrderDetail detail = new InputOrderDetail();
                SetValue(item, ref detail);

                this.order.InputOrderDetails.Add(detail);
            }
        }
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                EditInputDetail editform = new EditInputDetail(_orderId, _companyId);
                editform.OnInputDetailSaveing += new Func<InputOrderDetail, InputOrder>(editform_OnInputDetailUpdate);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitOrderDetails();
                }
            }

        }

        InputOrder editform_OnInputDetailUpdate(InputOrderDetail obj)
        {
            //UpdateOrder();
            if (obj.ID > 0)
            {
                DataRow row = gridViewInputOrderDetails.GetFocusedDataRow();
                SetRowValue(row, obj);
                gridViewInputOrderDetails.UpdateCurrentRow();
            }
            else
            {
                gridViewInputOrderDetails.AddNewRow();
                DataRow row = gridViewInputOrderDetails.GetFocusedDataRow();
                SetRowValue(row, obj);
                gridViewInputOrderDetails.UpdateCurrentRow();
            }
            return this.order;
        }



        private void gridControlInputOrerDetails_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewInputOrderDetails.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int orderDetailId = (int)gridViewInputOrderDetails.GetRowCellValue(hi.RowHandle, "ID");
                EditInputDetail editform = new EditInputDetail(_orderId, _companyId, orderDetailId);
                editform.OnInputDetailSaveing += new Func<InputOrderDetail, InputOrder>(editform_OnInputDetailUpdate);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitOrderDetails();
                }
            }

        }
        int orderdetailrowhandle = -1;
        private void gridViewInputOrderDetails_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
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
                        int orderdetailId = (int)gridViewInputOrderDetails.GetRowCellValue(orderdetailrowhandle, "ID");
                        string message = "";
                        if (InputOrderService.Instance.DeleteDetail(orderdetailId, out message))
                        {
                            gridViewInputOrderDetails.DeleteSelectedRows();
                            this._inputOrderDetailsDatable = InputOrderService.Instance.GetInputOrderDetailsDataTable(order.ID);
                            this.order = InputOrderService.Instance.GetInputOrder(order.ID);
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
                    _inputOrderDetailsDatable = null;
                    InitOrderDetails();
                });
                e.Menu.Items.Add(menuItemrefrash);

                orderdetailrowhandle = e.HitInfo.RowHandle;
            }
        }


        private void gridViewInputOrderDetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gridViewInputOrderDetails.GetDataRow(e.RowHandle);
            row["InputOrderId"] = this.order.ID;
        }

        private void gridViewInputOrderDetails_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            lock (this)
            {
                DataRow row = (e.Row as DataRowView).Row;
                Updated = false;
                var detail = this.order.InputOrderDetails.SingleOrDefault(o => o.ID.Equals(row["ID"]));
                if (detail == null)
                {
                    InputOrderDetail newDetail = new InputOrderDetail();
                    SetValue(row, ref newDetail);
                    this.order.InputOrderDetails.Add(newDetail);
                }
                else
                {
                    SetValue(row, ref detail);
                }
            }

        }
        private void SetValue(DataRow row, ref InputOrderDetail detail)
        {
            detail.InputCount = int.Parse(row["InputCount"].ToString());
            if (detail.InputOrderId == 0)
            {
                detail.InputOrderId = int.Parse(row["InputOrderId"].ToString());
            }
            detail.ID = int.Parse(row["ID"].ToString());
            detail.CompanyId = int.Parse(ddlCompanies.EditValue.ToString());
            detail.Remark = row["Remark"].ToString();
            detail.LotsNumber = row["LotsNumber"].ToString();
            if (row["ProductDate"] != null && !string.IsNullOrEmpty(row["ProductDate"].ToString()))
                detail.ProductDate = DateTime.Parse(row["ProductDate"].ToString());
            detail.ProductId = int.Parse(row["ProductId"].ToString());

            SetProductRow(row, detail.ProductId);
        }
        private void SetRowValue(DataRow row, InputOrderDetail detail)
        {
            SetProductRow(row, detail.ProductId);

            row["InputCount"] = detail.InputCount;
            row["ProductId"] = detail.ProductId;
            row["Remark"] = detail.Remark;
            row["LotsNumber"] = detail.LotsNumber;
            row["ProductId"] = detail.ProductId;
            row["CompanyId"] = detail.CompanyId;
            row["StorageArea"] = StorageAreaService.Instance.GetArea(detail.StorageAreaId);
            if (detail.ID == 0)
                row["ID"] = detail.ID;
            if (detail.ProductDate != null)
                row["ProductDate"] = detail.ProductDate;
        }

        private static void SetProductRow(DataRow row, int ProductId)
        {
            Product product = ProductService.Instance.GetProduct(ProductId);
            row["ProductNumber1"] = product.ProductNumber1;
            row["ProductNumber2"] = product.ProductNumber2;
            row["Spec"] = product.Spec;
        }

        #region Import
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                WareHouseManage.ImportDataBaseManage importForm = new WareHouseManage.ImportDataBaseManage();
                if (importForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitOrderDetails();
                }
            }
        }

        void importForm_OnImported(IEnumerable<InputOrderDetail> deteail)
        {

        }
        #endregion

        private void btnPreCompletedAndAssign_Click(object sender, EventArgs e)
        {
            if (!this.Updated)
            {
                ShowWarning("还未保存！请先保存后在完成预入库！");
                return;
            }
            if (_inputOrderDetailsDatable == null || _inputOrderDetailsDatable.Rows.Count == 0)
            {
                ShowWarning("请至少输入一个入库明细！");
                return;
            }
            if (ShowQuestion("您确实要开始分配库位吗？") == System.Windows.Forms.DialogResult.OK)
            {
                this.order.Status = InputStatus.待分配库位.ToString();
                InputOrderService.Instance.Update(order);
                AssignStorageArea assignStorageArea = new AssignStorageArea(this.order.ID);
                if (assignStorageArea.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.order.Status = InputStatus.已分配库位.ToString();
                    InputOrderService.Instance.Update(order);
                    InitData();
                }
            }
        }
        #endregion

        private void btnPreComplete_Click(object sender, EventArgs e)
        {
            //if (!HasValidateDetailData)
            //{
            //    ShowWarning("生产批号不能为空！");

            //    return;
            //}
            if (!this.Updated)
            {
                ShowWarning("还未保存！请先保存后在完成预入库！");
                return;
            }
            if (_inputOrderDetailsDatable == null || _inputOrderDetailsDatable.Rows.Count == 0)
            {
                ShowWarning("请至少输入一个入库明细！");
            }
            else
            {
                this.order.Status = InputStatus.待分配库位.ToString();
                InputOrderService.Instance.Update(order);
                DialogResult = System.Windows.Forms.DialogResult.OK;
                ShowMessage("完成预入库！");
                this.Close();
            }
        }
        private void gridViewInputOrderDetails_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            if (e.Column.FieldName == "LotsNumber")
            {
                //HasValidateDetailData = true;

                //if (string.IsNullOrWhiteSpace(e.CellValue.ToString()))
                //{
                //    e.Appearance.BackColor = Color.Red;
                //    HasValidateDetailData = false;
                //}
            }
        }
        
        private void ddlCompanies_EditValueChanged(object sender, EventArgs e)
        {
            _companyId = int.Parse(ddlCompanies.EditValue.ToString());
            InitProduct();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            InputOrderService.Instance.UpdateStatus(order.ID, InputStatus.待入库);
            ShowMessage("已退回到待入库状态");
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}