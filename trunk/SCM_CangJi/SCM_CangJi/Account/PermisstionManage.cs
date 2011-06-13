/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 6/13/2011 8:31:58 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.Account
 * 文件名： PermisstionManage
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.DAL;
using DevExpress.XtraNavBar;
using System.Linq;
using System.Data.Linq;
using SCM_CangJi.BLL;
namespace SCM_CangJi.Account
{
    public partial class PermisstionManage : FormBase
    {
        frmMain mainForm = null;

        #region ISingleton<PermisstionManage> Members
        private static PermisstionManage _instance = null;
        public static PermisstionManage Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new PermisstionManage();
                }
                return _instance;
            }
        }


        #endregion
        private PermisstionManage()
        {
            this.myLog = MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
        }

        private void PermisstionManage_Load(object sender, EventArgs e)
        {
            mainForm = this.MdiParent as frmMain;
            InitMemuList();
            InitRoles();
        }

        private void InitMemuList()
        {
            chkMenus.DataSource = mainForm.LeftMenu.Items;
            chkMenus.DisplayMember = "Caption";
            chkMenus.ValueMember = "Name";
        }

        private void InitRoles()
        {
            ddlRoles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ddlRoles.Properties.DataSource = AccountService.Instance.GetRoles();
        }
    

        private void chkAll_EditValueChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                chkMenus.CheckAll();
            }
            else
            {
                chkMenus.UnCheckAll();
            }

        }
        private void ddlRoles_EditValueChanged(object sender, EventArgs e)
        {
            IEnumerable<string> pers = AccountService.Instance.GetPermisstions(new Guid(ddlRoles.EditValue.ToString())).Select(o=>o.MenuName);
            for (int i = 0; i < mainForm.LeftMenu.Items.Count; i++)
            {
                chkMenus.SetItemChecked(i, pers.Contains(chkMenus.GetItemValue(i)));
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlRoles.EditValue == null)
            {
                ShowMessage("请选择一个角色！");
                return;
            }
            List<string> list = new List<string>();
            for (int i = 0; i < mainForm.LeftMenu.Items.Count; i++)
            {
                if (chkMenus.GetItemCheckState(i) == CheckState.Checked)
                    list.Add(chkMenus.GetItemValue(i).ToString());
            }
            AccountService.Instance.AddPermissions(list.ToArray(), new Guid(ddlRoles.EditValue.ToString()));
            this.myLog.Info(string.Format("把角色【{0}】的权限修改为{1}", ddlRoles.Properties.GetDisplayText(ddlRoles.EditValue), string.Join(",", list.ToArray())));
            ShowMessage("权限修改成功！");
        }
    }
}