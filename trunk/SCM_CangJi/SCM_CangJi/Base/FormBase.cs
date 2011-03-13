using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Security;
using System.Web.Security;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

namespace SCM_CangJi
{
    /// <summary>
    /// 普通Form 基类
    /// </summary>
    public partial class FormBase : XtraForm
    {
        public MembershipUser User
        {
            get
            {
                return SecurityContext.Current.CurrentyUser;
            }
        }
        private bool _updated = true;
        public bool Updated
        {
            get
            {
                return _updated;
            }
            set
            {
                if (!value)
                {
                    if (_updated)
                    {
                        this.Text = string.Format("{0}---未保存", this.Text);
                    }
                }
                else
                {
                    this.Text = this.Text.Replace("---未保存", "");
                }
                _updated = value;
            }
        }
      
        public FormBase()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormBase_FormClosing);
        }

        void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Updated)
            {
                if (XtraMessageBox.Show("数据未保存，确实要关闭吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;

                }
                else
                {
                }
            }
        }
       
        public bool CheckPremission()
        {
            return true;
        }
        public void ShowMessage(string message)
        {
            XtraMessageBox.Show(message);
        }
        //public virtual void ShowMenu(GridView gridview, GridHitInfo hi)
        //{
        //    GridViewMenu menus = null;
        //    if (hi.RowHandle >= 0)
        //    {
        //        menus = new GridViewMenu(gridview);
        //        DXMenuItem deletemenu = new DXMenuItem();
        //        deletemenu.Caption = "删除";
        //        deletemenu.Click += new EventHandler(deletemenu_Click);
        //        DXMenuItemCollection menucollection = new DXMenuItemCollection();
        //        menus.Init(hi);
        //        menus.Show(hi.HitPoint);
        //    }
        //}
    }
}
