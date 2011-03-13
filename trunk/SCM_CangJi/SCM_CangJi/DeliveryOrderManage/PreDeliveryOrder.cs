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
        private int companyId = 0;
       
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
        }
        public PreDeliveryOrder(int orderId):base()
        {
            _orderId = orderId;
            InitializeComponent();
            InitData();
            InitProduct();
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
            }
            else
            {
                //SHP-20100305001
                lblDeliveryOrderNumber.Text = CommonService.Instance.GetOrderNumber(OrderType.DeliveryOrder);
                lblPreDeliveryDate.Text = DateTime.Now.ToShortDateString();
                //txtReachedDate.EditValue = DateTime.Now.Date;
            }
        }

      

        #region Delivery Base
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (_orderId > 0)
                {
                    SetOrderValue();
                    SetOrderDetailsValue();
                    DeliveryOrderService.Instance.Update(this.order);
                }
                else
                {
                    this.order = new DeliveryOrder();
                    SetOrderValue();
                    SetOrderDetailsValue();
                    DeliveryOrderService.Instance.Create(this.order);

                }
                Updated = true;
                DeliveryOrderList.Instance.InitGrid();
            }
        }
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            btnSaveAll_Click(sender, e);
            DialogResult = System.Windows.Forms.DialogResult.OK;
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
            this.order.DeliveryOrderNumber = lblDeliveryOrderNumber.Text;
            this.order.Invoice = txtInvoice.EditValue.TrytoString();
            this.order.PreDeliveryDate = DateTime.Parse(lblPreDeliveryDate.Text);
            this.order.ReachedDate = DateTime.Parse(txtReachedDate.EditValue.TrytoString());
        }

        private void ddlCompanies_Properties_EditValueChanged(object sender, EventArgs e)
        {
            companyId=int.Parse(ddlCompanies.EditValue.ToString());
            CommonService.BindDDLDeliveryAddress(ddlDeliveryAddress,companyId);
            if (_orderId > 0)
            {
                ddlDeliveryAddress.EditValue = order.DeliveryAddressId;
            }
        } 
        #endregion

        #region Delivery Detail

        private void InitProduct()
        {
            gcProducts.DataSource = ProductService.Instance.GetProducts(companyId);
        }

        private void InitOrderDetails()
        {
            gridControlDeliveryOrerDetails.DataSource = this.DeliveryOrderDetailsDatatable;
        }
        private void SetOrderDetailsValue()
        {
          
        }
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                EditDeliveryDetail editform = new EditDeliveryDetail(_orderId, companyId);
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
            gridViewDeliveryOrderDetails.AddNewRow();
            DataRow row= gridViewDeliveryOrderDetails.GetFocusedDataRow();
            SetRowValue(row, obj);
            gridViewDeliveryOrderDetails.UpdateCurrentRow();
            return this.order;
        }

       
        private void btnImport_Click(object sender, EventArgs e)
        {
            ShowMessage("还未实现！");
        }

        private void gridControlDeliveryOrerDetails_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewDeliveryOrderDetails.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int orderDetailId = (int)gridViewDeliveryOrderDetails.GetRowCellValue(hi.RowHandle, "Id");
                EditDeliveryDetail editform = new EditDeliveryDetail(_orderId, companyId, orderDetailId);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitOrderDetails();
                }
            }

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
       
        #endregion

        private void gridViewDeliveryOrderDetails_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            DataRow row = gridViewDeliveryOrderDetails.GetDataRow(e.RowHandle);
            row["DeliveryOrderId"] = this.order.Id;
            row["ProductStorageId"] = 0;
            row["AssignCount"] = 0;
        }

        private void gridViewDeliveryOrderDetails_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow row = (e.Row as DataRowView).Row;
            Updated = false;
           var detail= this.order.DeliveryOrderDetails.SingleOrDefault(o => o.Id.Equals(row["Id"]));
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
        private void SetValue(DataRow row, ref DeliveryOrderDetail detail)
        {
            detail.DeliveryCount = int.Parse(row["DeliveryCount"].ToString());
            detail.DeliveryOrderId = int.Parse(row["DeliveryOrderId"].ToString());
            detail.InputInvoice = row["InputInvoice"].ToString();
            detail.LotsNumber = row["LotsNumber"].ToString();
            detail.ProductId = int.Parse(row["ProductId"].ToString());
            detail.ProductStorageId = 0; 
        }
        private void SetRowValue(DataRow row, DeliveryOrderDetail detail)
        {
            row["DeliveryCount"] = detail.DeliveryCount;
            row["InputInvoice"] = detail.InputInvoice;
            row["LotsNumber"] = detail.LotsNumber;
            row["ProductId"] = detail.ProductId;
        }

      
    }
}