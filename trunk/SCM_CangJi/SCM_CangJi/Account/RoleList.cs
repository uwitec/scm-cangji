using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;

namespace SCM_CangJi.Account
{
    public partial class RoleList : FormBase
    {
        #region ISingleton<RoleList> Members
        private static RoleList _instance = null;
        public static RoleList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new RoleList();
                }
                return _instance;
            }
        }

        #endregion
        private RoleList()
        {
            InitializeComponent();
            InitGrid();
        }


        private void InitGrid()
        {
            gridRoles.DataSource = SCM_CangJi.BLL.Services.AccountService.Instance.GetRoles();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            EditRole roleForm = new EditRole();
            if (roleForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ShowMessage("创建成功！");
                InitGrid();
            }
        }


        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                if (XtraMessageBox.Show("确定要删除该角色", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    string message = "";
                    if (SCM_CangJi.BLL.Services.AccountService.Instance.DeleteRole(gridView1.FocusedValue.ToString(), out message))
                    {
                        InitGrid();
                    }
                    XtraMessageBox.Show(message);
                }
            }
        }
        private void ShowDataRow(DataRow dr, string fs, Color c)
        {
            string s = "";
            if (dr != null)
            {
                object[] items = dr.ItemArray;
                foreach (object o in items)
                    s = (s == "" ? "" : s + "; ") + o.ToString();
            }
        }

    }
}