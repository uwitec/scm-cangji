using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL;

namespace SCM_CangJi.Account
{
    public partial class ChangeMyPassword : FormBase
    {
        public ChangeMyPassword()
        {
            this.myLog = MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SCM_CangJi.BLL.Services.AccountService.Instance.ChangePassword(BLL.Security.SecurityContext.Current.CurrentyUser.UserName, txtOldPassword.Text, txtNewPassword1.Text))
            {
                myLog.Info("修改密码成功");
                ShowMessage("修改密码成功！");
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        
    }
}