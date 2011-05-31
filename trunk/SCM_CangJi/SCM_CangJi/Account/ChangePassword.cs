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
    public partial class ChangePassword : EditForm
    {
        public ChangePassword()
        {
            this.myLog = SCM_CangJi.BLL.MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
            this.OnSaveAndClose += new Action(ChangePassword_OnSaveAndClose);
        }

        void ChangePassword_OnSaveAndClose()
        {
            if (SCM_CangJi.BLL.Services.AccountService.Instance.ChangePassword(txtUserName.Text, txtOldPassword.Text, txtNewPassword1.Text))
            {
                myLog.Info("修改密码成功");
                DevExpress.XtraEditors.XtraMessageBox.Show("密码修改成功！");
                DialogResult = DialogResult.OK;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("密码修改失败！","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void btnSave_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ChangePassword_OnSaveAndClose();
        }



        internal static ChangePassword GetInstance()
        {
            return new ChangePassword();
        }
    }
}