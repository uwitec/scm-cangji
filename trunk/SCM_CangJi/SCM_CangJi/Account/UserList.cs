using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using SCM_CangJi.BLL.Services;

namespace SCM_CangJi.Account
{
    //public partial class UserList : FormBase<UserList>
    public partial class UserList : FormBase
    {
        #region ISingleton<UserList> Members
        private static UserList _instance = null;
        public static UserList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new UserList();
                }
                return _instance;
            }
        }

        #endregion
        private UserList()
        {
            InitializeComponent();
            InitRole();
            InitGrid();
        }

        private void InitGrid()
        {
            manGrid.DataSource = SCM_CangJi.BLL.Services.AccountService.Instance.GetUsers();
            //manGrid.MainView.PopulateColumns();
        }

        private void InitRole()
        {
            repositoryItemLookUpEdit1.DataSource = SCM_CangJi.BLL.Services.AccountService.Instance.GetRoles();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (EditUser.GetInstance().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XtraMessageBox.Show("创建用户成功！");
                InitGrid();
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (ChangePassword.GetInstance().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XtraMessageBox.Show("修改密码成功！");
            }
        }
        int orderrowhandle = -1;
        private void gridViewUsers_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                orderrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                      {
                          if (XtraMessageBox.Show("该动作将会删除相关明细列表，确实要删除吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                          {
                              string userName = gridViewUsers.GetRowCellValue(e.HitInfo.RowHandle, "UserName").ToString();
                              //AccountService.Instance.DeleteUser(userName);
                          }
                      });
                e.Menu.Items.Add(menuItemDelete);

                orderrowhandle = e.HitInfo.RowHandle;
            }
        }


       
    }
}
