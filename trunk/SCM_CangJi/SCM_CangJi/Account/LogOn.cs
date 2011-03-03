using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCM_CangJi.Account
{
    public partial class LogOn : XtraForm
    {
        public LogOn()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (SCM_CangJi.BLL.Services.AccountService.Instance.ValidateUser(txtUserName.EditValue.ToString(), txtPassword.EditValue.ToString()))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("登录失败！用户或者密码错误！");
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;

            }
        }
    }
}
