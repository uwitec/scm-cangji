using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.DAL;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class EditDeliveryDetail : EditForm
    {
        private int _orderId;
        private int _orderDetailId;
        private int _companyId;
        private DeliveryOrderDetail deliveryOrderDetail = null;

        public event Func<DeliveryOrderDetail,DeliveryOrder> OnDeliveryDetailSaveing;

        public EditDeliveryDetail(int orderId,int companyId)
            : this(orderId, companyId,0)
        {
        }

        public EditDeliveryDetail(int orderId,int companyId, int orderDetailId)
            : base()
        {
            this._orderId = orderId;
            this._orderDetailId = orderDetailId;
            this._companyId = companyId;
            InitializeComponent();
            InitData();
            InitProduct();
        }

        private void InitProduct()
        {
            ddlProducts.Properties.DataSource = ProductService.Instance.GetProducts(_companyId);
        }

        private void InitData()
        {
            if (_orderDetailId > 0)
            {
                deliveryOrderDetail = DeliveryOrderService.Instance.GetDeliveryOrderDetail(_orderDetailId);
                ddlProducts.EditValue = deliveryOrderDetail.ProductId;
                txtDeliveryCount.EditValue = deliveryOrderDetail.DeliveryCount;
                txtInputInvoice.EditValue = deliveryOrderDetail.InputInvoice;
                txtLotsNumber.EditValue = deliveryOrderDetail.LotsNumber;
                txtProductDate.EditValue = deliveryOrderDetail.ProductDate;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
               
                if (_orderDetailId > 0)
                {
                    SetOrderDetailValue();
                }
                else
                {
                    deliveryOrderDetail = new DeliveryOrderDetail();
                    SetOrderDetailValue();
                }
                DeliveryOrder order = OnDeliveryDetailSaveing(deliveryOrderDetail);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetOrderDetailValue()
        {
            deliveryOrderDetail.DeliveryOrderId = _orderId;
            deliveryOrderDetail.DeliveryCount = int.Parse(txtDeliveryCount.EditValue.TrytoString());
            deliveryOrderDetail.InputInvoice = txtInputInvoice.EditValue.TrytoString();
            deliveryOrderDetail.LotsNumber = txtLotsNumber.EditValue.TrytoString();
            deliveryOrderDetail.ProductId = int.Parse(ddlProducts.EditValue.TrytoString());
            if (txtProductDate.EditValue != null)
                deliveryOrderDetail.ProductDate = DateTime.Parse(txtProductDate.EditValue.TrytoString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}