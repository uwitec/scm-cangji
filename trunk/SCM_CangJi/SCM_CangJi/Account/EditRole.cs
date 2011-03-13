using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCM_CangJi.Account
{
    public partial class EditRole : EditForm
    {
        private Guid _roleID;
        public EditRole():this(Guid.Empty)
        {
           
        }
        public EditRole(Guid roleID)
        {
            _roleID = roleID;
            InitializeComponent();
            if (_roleID == Guid.Empty)
            {
                this.Text = "创建角色";
            }
            else
            {
                this.Text = "修改角色";
            }
            OnSave += new Action(EditRole_OnSave);
        }
        public 
        void EditRole_OnSave()
        {
            if(_roleID==Guid.Empty)
            SCM_CangJi.BLL.Services.AccountService.Instance.CreateRole(txtRoleName.EditValue.ToString());
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
                EditRole_OnSave();
        }
    }
}