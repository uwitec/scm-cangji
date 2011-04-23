using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
namespace SCM_CangJi.CustomerManage
{
    public partial class EditProduct : EditForm
    {
        private int _companyId;
        private int _productId;
        private Product _product;
        public EditProduct(int CompanyId)
            : this(CompanyId, 0)
        {
        }

        public EditProduct(int CompanyId, int productId)
        {
            // TODO: Complete member initialization
            this._companyId = CompanyId;
            this._productId = productId;
            InitializeComponent();
            InitProductType();
            InitCurrencyUnit();
            InitData();
        }

        private void InitCurrencyUnit()
        {
            ddlCurrencyUnits.Properties.DataSource = CommonService.Instance.GetAllCurrencyUnit();
            ddlCurrencyUnits.EditValue = 1;
        }

        private void InitProductType()
        {
            ddlProductType.Properties.DataSource = CommonService.Instance.GetAllProductType();
            ddlProductType.EditValue = 10;
        }

        private void InitData()
        {
            if (this._productId > 0)
            {
                this._product = ProductService.Instance.GetProduct(_productId);
                txtCodeBar.EditValue = this._product.BarCode;
                txtHeight.EditValue = this._product.Height;
                txtLayeredCount.EditValue = this._product.LayeredCount;
                txtLength.EditValue = this._product.Length;
                txtPreWorningDays.EditValue = this._product.PreWorningDays;
                txtProductChName.EditValue = this._product.ProductChName;
                txtProductEngName.EditValue = this._product.ProductEngName;
                txtProductNumber1.EditValue = this._product.ProductNumber1;
                txtProductNumber2.EditValue = this._product.ProductNumber2;
                txtSecurityCount.EditValue = this._product.SecurityCount;
                txtShelfLife.EditValue = this._product.ShelfLife;
                txtSpec.EditValue = this._product.Spec;
                txtUnitPrice.EditValue = this._product.UnitPrice;
                txtVolume.EditValue = this._product.Volume;
                txtWeight.EditValue = this._product.Weight;
                txtWidth.EditValue = this._product.Width;
                txtBrand.EditValue = this._product.Brand;
                ddlCurrencyUnits.EditValue = this._product.CurrencyUnitId;
                ddlProductType.EditValue = this._product.ProductTypeId;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_productId > 0)
            {

                SetProductValue();
                ProductService.Instance.Update(_product);
            }
            else
            {
                _product = new Product();
                SetProductValue();
                ProductService.Instance.Create(_product);

            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void SetProductValue()
        {
            this._product.BarCode = txtCodeBar.EditValue.TrytoString();
            this._product.Height = int.Parse(txtHeight.EditValue.TrytoString());
            this._product.LayeredCount = int.Parse(txtLayeredCount.EditValue.TrytoString());
            this._product.Length = int.Parse(txtLength.EditValue.TrytoString());
            this._product.PreWorningDays = int.Parse(txtPreWorningDays.EditValue.TrytoString());
            this._product.ProductChName = txtProductChName.EditValue.TrytoString();
            this._product.ProductEngName = txtProductEngName.EditValue.TrytoString();
            this._product.ProductNumber1 = txtProductNumber1.EditValue.TrytoString();
            this._product.ProductNumber2 = txtProductNumber2.EditValue.TrytoString();
            this._product.SecurityCount = int.Parse(txtSecurityCount.EditValue.TrytoString());
            this._product.ShelfLife = int.Parse(txtShelfLife.EditValue.TrytoString());
            this._product.Spec = txtSpec.EditValue.TrytoString();
            if (txtUnitPrice.EditValue != null)
            {
                this._product.UnitPrice = decimal.Parse(txtUnitPrice.EditValue.TrytoString());
            }
            this._product.Volume = int.Parse(txtVolume.EditValue.TrytoString());
            this._product.Weight = int.Parse(txtWeight.EditValue.TrytoString());
            this._product.Width = int.Parse(txtWidth.EditValue.TrytoString());
            this._product.CurrencyUnitId = int.Parse(ddlCurrencyUnits.EditValue.TrytoString());
            this._product.ProductTypeId = int.Parse(ddlProductType.EditValue.TrytoString());
            this._product.CompanyId = this._companyId;
            this._product.Brand = this.txtBrand.EditValue.TrytoString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}