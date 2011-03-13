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
namespace SCM_CangJi.CustomerManage
{
    public partial class EditDeliverAddress:EditForm
    {
        private int _companyId;
        private int _addressId;
        private DeliverAddress deliverAddress;
        public EditDeliverAddress(int CompanyId)
            : this(CompanyId, 0)
        {

        }

        public EditDeliverAddress(int CompanyId, int addressId)
            : base()
        {
            // TODO: Complete member initialization
            this._companyId = CompanyId;
            this._addressId = addressId;
            this.deliverAddress = BLL.Services.DeliverAddressService.Instance.GetAddress(addressId);
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            if (_addressId > 0)
            {
                txtAddress.EditValue = this.deliverAddress.Address;
                txtAddressCode.EditValue = this.deliverAddress.AddressCode;
                txtAddressName.EditValue = this.deliverAddress.AddressName;
                txtDeliverDays.EditValue = this.deliverAddress.DeliverDays;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_addressId > 0)
            {

                SetAddressValue();
                DeliverAddressService.Instance.Update(deliverAddress);
            }
            else
            {
                this.deliverAddress = new DeliverAddress();
                SetAddressValue();
                DeliverAddressService.Instance.Create(deliverAddress);

            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SetAddressValue()
        {
            this.deliverAddress.Address = txtAddress.EditValue.TrytoString();
            this.deliverAddress.AddressCode = txtAddressCode.EditValue.TrytoString();
            this.deliverAddress.AddressName = txtAddressName.EditValue.TrytoString();
            this.deliverAddress.DeliverDays = int.Parse(txtDeliverDays.EditValue.TrytoString());
            this.deliverAddress.CompanyId = this._companyId;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}