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
using SCM_CangJi.BLL;
namespace SCM_CangJi.CustomerManage
{
    public partial class EditContact : EditForm
    {
        private int _contactId;
        private int _campanyId;
        private Contact contact = null;
        public EditContact(int companyId)
            : this(companyId, 0)
        {
        }

        public EditContact(int companyId,int contactId)
            : base()
        {
            this._contactId = contactId;
            _campanyId = companyId;
            InitializeComponent();
            InitData();
            
        }

        private void InitData()
        {
            if (_contactId > 0)
            {
                contact = BLL.Services.ContactService.Instance.GetContact(_contactId);
                txtName.EditValue = this.contact.Name;
                txtEmail.EditValue = this.contact.Email;
                ddlGender.EditValue = this.contact.Gender;
                txtPhone1.EditValue = this.contact.Phone1;
                txtPhone2.EditValue = this.contact.Phone2;
                txtPhone3.EditValue = this.contact.Phone3;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (contact != null)
                {
                    contact.Name = txtName.EditValue.ToString();
                    contact.Email = txtEmail.EditValue.TrytoString();
                    contact.Phone1 = txtPhone1.EditValue.TrytoString();
                    contact.Phone2 = txtPhone2.EditValue.TrytoString();
                    contact.Phone3 = txtPhone3.EditValue.TrytoString();
                    contact.Gender = ddlGender.EditValue.TrytoString();
                    BLL.Services.ContactService.Instance.Update(contact);
                }
                else
                {
                    contact = new Contact();
                    contact.CompanyId = this._campanyId;
                    contact.Name = txtName.EditValue.TrytoString();
                    contact.Email = txtEmail.EditValue.TrytoString();
                    contact.Phone1 = txtPhone1.EditValue.TrytoString();
                    contact.Phone2 = txtPhone2.EditValue.TrytoString();
                    contact.Phone3 = txtPhone3.EditValue.TrytoString();
                    contact.Gender = ddlGender.EditValue.TrytoString();
                    contact.IsActived = true;
                    BLL.Services.ContactService.Instance.Insert(contact);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}