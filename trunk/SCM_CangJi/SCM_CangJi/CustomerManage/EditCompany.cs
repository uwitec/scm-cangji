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
using SCM_CangJi.BLL.Services;

namespace SCM_CangJi.CustomerManage
{
    public partial class EditCompany : EditForm
    {
        int _companyId = 0;
        private Company company;
        public EditCompany():this(0)
        {
        }
        public EditCompany(int companyId)
            : base()
        {
            _companyId = companyId;
            InitializeComponent();
            InitCompanyType();
            this.myLog = SCM_CangJi.BLL.MyLogManager.GetLogger(this.GetType());
            InitData();
        }

        private void InitCompanyType()
        {
            foreach (var item in Enum.GetNames(typeof(CompanyType)))
            {
                ddlCompanyType.Properties.Items.Add(item);
            }
            ddlCompanyType.Properties.AutoComplete = true;
            ddlCompanyType.Properties.CycleOnDblClick = true;
            ddlCompanyType.SelectedIndex = 0;
        }

        private void InitData()
        {
            if (_companyId == 0)
            {
                this.Text = "创建公司";
            }
            else
            {
                company = SCM_CangJi.BLL.Services.CompanyService.Instance.GetCompany(_companyId);
                txtCompanyName.EditValue = company.CompanyName;
                txtCompanyAddress.EditValue = company.CompanyAddress;
                ddlCompanyType.EditValue = (CompanyType)company.CompanyType;
                this.Text = string.Format("正在编辑：{0}", company.CompanyName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (_companyId > 0)
                {
                    company.CompanyAddress = txtCompanyAddress.EditValue.ToString();
                    company.CompanyName = txtCompanyName.EditValue.ToString();
                    company.CompanyType = (int)((CompanyType)Enum.Parse(typeof(CompanyType), ddlCompanyType.EditValue.ToString()));
                    CompanyService.Instance.Update(company);
                }
                else
                {
                    company = new Company();
                    company.CompanyAddress = txtCompanyAddress.EditValue.ToString();
                    company.CompanyName = txtCompanyName.EditValue.ToString();
                    company.CompanyType = (int)((CompanyType)Enum.Parse(typeof(CompanyType), ddlCompanyType.EditValue.ToString()));
                    CompanyService.Instance.Create(company);
                }
                myLog.Info(string.Format("{0}-{1}成功",this.Text, company.CompanyName));
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

    }
}