using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars;
using SCM_CangJi.BLL.Security;
using DevExpress.XtraTab.ViewInfo;
using SCM_CangJi.Account;
using SCM_CangJi.CustomerManage;
using SCM_CangJi.DeliveryOrderManage;
namespace SCM_CangJi
{
    public partial class frmMain : XtraForm
    {
        private void SetFocus(FormBase form)
        {
            form.MdiParent = this;
            form.Show();
            if (form.CanFocus && !form.Focused)
            {
                form.Focus();
            }

        }

        public frmMain()
        {
            InitializeComponent();
            InitSkin();
            InitMenu();
            InitStatusBar();
        }

        private void InitStatusBar()
        {
            statusbar_Userinfo.Caption =string.Format("欢迎您：{0}",SecurityContext.Current.CurrentyUser.UserName);
        }

        private void InitMenu()
        {

        }
        private void InitSkin()
        {
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                BarButtonItem item = new BarButtonItem(barManager1, cnt.SkinName);
                barskin.AddItem(item);
                item.ItemClick += new ItemClickEventHandler(OnSkinClick);
            }
        }
        void OnSkinClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
            barManager1.GetController().PaintStyleName = "Skin";
            barskin.Caption = e.Item.Caption;
            barskin.Hint = barskin.Caption;
            barskin.ImageIndex = -1;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            MDIManage.SetFixedForm(new StartPage());
        }

        #region 工具栏
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new About()).ShowDialog(this);
        }

        private void showMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MainMenus.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            SCM_CangJi.Lib.Utils.OpenMasterWebPage();
        }

        private void CloseWindow_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        } 
        #endregion


        #region 导航

        #region 用户
        private void UsersManage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(UserList.Instance);
        }
        private void RolesManage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(RoleList.Instance);
        } 
        #endregion

        #region 基本信息
        private void CompanyInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(CompanyList.Instance);
        } 
        #endregion

        #region 入库
        private void PreIntowarehouse_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(new InputOrderManage.PreInputOrder());
        }
        private void nvaInputOrders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(InputOrderManage.InputOrderList.Instance);
        }
        private void AssignStorageArea_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(InputOrderManage.AssignedAreaList.Instance);
        }

       
        #endregion

        #region 出库
        private void navDeliveryOrders_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(DeliveryOrderManage.DeliveryOrderList.Instance);
        }

        private void PreOutWoreHouse_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(new DeliveryOrderManage.PreDeliveryOrder());
        }
        private void AssignStorage_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(DeliveryOrderManage.AssigningProducts.Instance);

        }
        private void OutWareHouseConfirm_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(ConfirmDeliveryOrder.Instance);
        } 
        #endregion

        #region 库存
        private void StorageInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(ProductStorageList.Instance);

        } 
        #endregion
        #endregion


        #region 双击关闭
        private int clickTick = -1;
        private BaseTabHitInfo lastTab = null;//保存上次的tab页
        private void MDIManage_MouseDown(object sender, MouseEventArgs e)
        {
            BaseTabHitInfo hi = this.MDIManage.CalcHitInfo(new Point(e.X, e.Y));
            if (hi.HitTest == XtraTabHitTest.PageHeader)
            {
                if (this.clickTick == -1
                   || (Environment.TickCount - this.clickTick) > SystemInformation.DoubleClickTime
                   || this.lastTab == null
                   || this.lastTab.Page.Text != hi.Page.Text)
                {
                    this.clickTick = Environment.TickCount;
                    this.lastTab = hi;
                }
                else
                {
                    if ((Environment.TickCount - this.clickTick) < SystemInformation.DoubleClickTime)
                    {
                        if (null != this.ActiveMdiChild)
                        {
                            this.ActiveMdiChild.Close();
                        }
                    }
                }
            }
        } 
        #endregion

       

       

       

       

        

    }
}
