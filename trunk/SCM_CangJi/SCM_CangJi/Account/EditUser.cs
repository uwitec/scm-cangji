using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.Lib;

namespace SCM_CangJi.Account
{
    public partial class EditUser : EditForm
    {

        FormType FormType { get; set; }
        
        public EditUser():this(FormType.Create)
        {
        }
        public EditUser(FormType formtype)
        {
            InitializeComponent();
            FormType = formtype;

            if (FormType == Lib.FormType.Create)
            {
                this.Text = "创建用户";
            }
            else
            {
                this.Text = "修改用户";
            }
            InitRoles();
            OnSave += new Action(EditUser_OnSave);

        }

        private void InitRoles()
        {
        }

        internal static EditUser GetInstance()
        {
            return new EditUser();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EditUser_OnSave();
        }

        void EditUser_OnSave()
        {
            SCM_CangJi.BLL.Services.AccountService.Instance.CreateUser(txtUserName.EditValue.ToString(), txtNewPassword1.EditValue.ToString(), "");
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

    }
}
