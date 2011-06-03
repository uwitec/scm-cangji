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
using SCM_CangJi.WareHouseManage;
using SCM_CangJi.BaseInfo;
namespace SCM_CangJi
{
    public partial class frmMain : XtraForm
    {
        private void SetFocus(FormBase form)
        {
            #region meicunzhi
            StoragePanel.Visible = false;
            #endregion
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
            InitStoragePanel();
            InitSkin();
            InitMenu();
            InitStatusBar();
            this.Icon = SCM_CangJi.Properties.Resources.favicon;
        }

        #region meicunzhi
        private void InitStoragePanel()
        {
            StoragePanel = new System.Windows.Forms.Panel();
            StoragePanel.Visible = false;
            StorageView = new SCM_CangJi.WareHouseManage.StorageManageView(StoragePanel);

            // 
            // StorageView
            // 
            this.StorageView.AutoSize = true;
            this.StorageView.ClientSize = new System.Drawing.Size(332, 55);
            this.StorageView.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StorageView.Location = new System.Drawing.Point(0, 150);
            this.StorageView.MaximizeBox = false;
            this.StorageView.MinimizeBox = false;
            this.StorageView.Name = "StorageView";
            this.StorageView.Text = "StorageManageView";
            this.StorageView.Visible = false;
        }
        #endregion

        private void InitStatusBar()
        {
            statusbar_Userinfo.Caption =string.Format("欢迎您：{0}",SecurityContext.Current.CurrentyUser.UserName);
            int woringCount = BLL.Services.ProductStorageService.Instance.GetProductStorageWoringCount();
            if (woringCount > 0)
            {
                barWorning1.Caption = string.Format("库存警告：有{0}条库存快到期", woringCount);
            }
        }

        private void InitMenu()
        {
          
        }

        void changepasswordItem_ItemClick(object sender, ItemClickEventArgs e)
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
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            new ChangeMyPassword().ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Hide();
            SecurityContext.Current.CurrentyUser = null;
            if (new LogOn().ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }
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
        private void ProjectCategory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(ProductTypeList.Instance);
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
        private void IntoWareHouseConfirm_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(InputOrderManage.ConfirmInputOrder.Instance);
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

        private void navProductInOutHistory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(InAndOutHistory.Instance);
        }

        private void StorageChange_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(StorageManage.StorageChange.Instance);
        }
        private void ChangeCancle_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(StorageManage.StorageChangeCancle.Instance);

        }

        private void ChangeConfirm_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(StorageManage.StorageChangeConfirm.Instance);

        }
        #endregion

        #region 日志

        private void Systemlog_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            this.SetFocus(LogList.Instance);
        }
        #endregion

        #region meicunzhi 仓库
        private void WareHouseInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //XtraMessageBox.Show("left=" + this.Left.ToString() + "Top=" + this.Top.ToString() + "Height=" + this.Height.ToString() + "w=" + this.Width.ToString());
            if (StoragePanel.Visible == false)
            {
                StorageView.TopLevel = false;
                StorageView.SetWindowsPos(this.splitterControl1.Left, 1, (this.Width - this.splitterControl1.Left), this.splitterControl1.Height);

                StoragePanel.Dock = DockStyle.Fill;
                StoragePanel.Visible = true;
                StoragePanel.Controls.Add(StorageView);
                this.Controls.Add(StoragePanel);
            }

        }
        #endregion
        #endregion
        #region meicunzhi
        private void OnResize(object sender, EventArgs e)
        {
            if (StoragePanel.Visible == true)
            {
                StorageView.SetWindowsPos(this.splitterControl1.Left, 1, (this.Width - this.splitterControl1.Left), this.splitterControl1.Height);
            }
        }
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

        private void barWorning1_ItemDoubleClick(object sender, ItemClickEventArgs e)
        {
            (new StorageManage.StorageWorning()).ShowDialog();
        }

     

       

      

        

        

       

       

       

       

       

       

        

    }
}
