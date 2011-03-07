using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL.Services;
using System.Web.Security;

namespace SCM_CangJi.Account
{
    public partial class EditUser : EditForm
    {
        Guid _userID;
        
        public EditUser():this(Guid.Empty)
        {
        }
        public EditUser(Guid userID)
        {
            InitializeComponent();
            _userID = userID;

            if (_userID ==Guid.Empty)
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
            foreach (var item in BLL.Services.AccountService.Instance.GetAllRoles())
            {
                ddlRoles.Properties.Items.Add(item);
            }
            ddlRoles.Properties.AutoComplete = true;
            ddlRoles.Properties.CycleOnDblClick = true;
            ddlRoles.SelectedIndex = 0;
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
            MembershipCreateStatus createStatue=AccountService.Instance.CreateUser(txtUserName.EditValue.ToString(), txtNewPassword1.EditValue.ToString(), "");
            if (createStatue != MembershipCreateStatus.Success)
            {
                XtraMessageBox.Show(AccountValidation.ErrorCodeToString(createStatue),"", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Roles.AddUsersToRole(new string[] { txtUserName.EditValue.ToString() }, ddlRoles.SelectedItem.ToString());
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

    }
}
