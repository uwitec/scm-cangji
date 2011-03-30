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

namespace SCM_CangJi.InputOrderManage
{
    public partial class EditInputDetail : EditForm
    {
        private int _orderId;
        private int _orderDetailId;
        private int _companyId;
        private InputOrderDetail inputOrderDetail = null;

        public event Func<InputOrderDetail,InputOrder> OnInputDetailSaveing;

        public EditInputDetail(int orderId,int companyId)
            : this(orderId, companyId,0)
        {
        }

        public EditInputDetail(int orderId,int companyId, int orderDetailId)
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
                btnSave.Text = "修改";
                inputOrderDetail = InputOrderService.Instance.GetInputOrderDetail(_orderDetailId);
                ddlProducts.EditValue = inputOrderDetail.ProductId;
                txtInputCount.EditValue = inputOrderDetail.InputCount;
                txtRemark.EditValue = inputOrderDetail.Remark;
                txtLotsNumber.EditValue = inputOrderDetail.LotsNumber;
                txtProductDate.EditValue = inputOrderDetail.ProductDate;
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
                    inputOrderDetail = new InputOrderDetail();
                    SetOrderDetailValue();
                }
                InputOrder order = OnInputDetailSaveing(inputOrderDetail);

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void SetOrderDetailValue()
        {
            inputOrderDetail.InputOrderId = _orderId;
            inputOrderDetail.InputCount = int.Parse(txtInputCount.EditValue.TrytoString());
            inputOrderDetail.Remark = txtRemark.EditValue.TrytoString();
            inputOrderDetail.LotsNumber = txtLotsNumber.EditValue.TrytoString();
            inputOrderDetail.ProductId = int.Parse(ddlProducts.EditValue.TrytoString());
            if (txtProductDate.EditValue != null)
                inputOrderDetail.ProductDate = DateTime.Parse(txtProductDate.EditValue.TrytoString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}