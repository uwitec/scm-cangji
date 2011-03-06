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
    //public partial class UserList : FormBase<UserList>
    public partial class UserList : FormBase
    {
        
        public UserList()
        {
            InitializeComponent();
            InitGrid();
        }

        private void InitGrid()
        {
            manGrid.DataSource = SCM_CangJi.BLL.Services.AccountService.Instance.GetUsers();
            //manGrid.MainView.PopulateColumns();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (EditUser.GetInstance().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XtraMessageBox.Show("创建用户成功！");
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (ChangePassword.GetInstance().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
        
    }
}
