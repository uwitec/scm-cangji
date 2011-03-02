namespace SCM_CangJi
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.MDIManage = new SCM_CangJi.MyMDIManager(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barskins = new DevExpress.XtraBars.Bar();
            this.barskin = new DevExpress.XtraBars.BarSubItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.CloseWindow = new DevExpress.XtraBars.BarButtonItem();
            this.showWindows = new DevExpress.XtraBars.BarSubItem();
            this.showMenu = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem10 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem8 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.UserManagerGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.RolesManage = new DevExpress.XtraNavBar.NavBarItem();
            this.UsersManage = new DevExpress.XtraNavBar.NavBarItem();
            this.StorageManageGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.Intowarehouse = new DevExpress.XtraNavBar.NavBarItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MDIManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // MDIManage
            // 
            this.MDIManage.FixedPage = null;
            this.MDIManage.MdiParent = this;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barskins,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barSubItem4,
            this.barSubItem5,
            this.barSubItem6,
            this.barSubItem7,
            this.barSubItem8,
            this.barskin,
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barSubItem10,
            this.barButtonItem5,
            this.barButtonItem6,
            this.showMenu,
            this.barButtonItem7,
            this.CloseWindow,
            this.showWindows});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 21;
            this.barManager1.StatusBar = this.bar3;
            // 
            // barskins
            // 
            this.barskins.BarName = "皮肤";
            this.barskins.DockCol = 0;
            this.barskins.DockRow = 1;
            this.barskins.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barskins.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barskin)});
            this.barskins.Text = "皮肤";
            // 
            // barskin
            // 
            this.barskin.AccessibleDescription = "";
            this.barskin.Caption = "皮肤";
            this.barskin.Id = 8;
            this.barskin.Name = "barskin";
            // 
            // bar2
            // 
            this.bar2.BarName = "菜单栏";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem10)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "菜单栏";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "文件...";
            this.barSubItem1.Id = 0;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "注销登陆";
            this.barButtonItem1.Id = 9;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "关闭窗口";
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "退出系统";
            this.barButtonItem3.Id = 11;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "窗口..";
            this.barSubItem5.Id = 4;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.CloseWindow),
            new DevExpress.XtraBars.LinkPersistInfo(this.showWindows)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // CloseWindow
            // 
            this.CloseWindow.Caption = "关闭窗口";
            this.CloseWindow.Id = 18;
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CloseWindow_ItemClick);
            // 
            // showWindows
            // 
            this.showWindows.Caption = "显示窗口";
            this.showWindows.Id = 20;
            this.showWindows.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.showMenu)});
            this.showWindows.Name = "showWindows";
            // 
            // showMenu
            // 
            this.showMenu.Caption = "显示导航";
            this.showMenu.Id = 16;
            this.showMenu.Name = "showMenu";
            this.showMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.showMenu_ItemClick);
            // 
            // barSubItem10
            // 
            this.barSubItem10.Caption = "帮助...";
            this.barSubItem10.Id = 13;
            this.barSubItem10.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6)});
            this.barSubItem10.Name = "barSubItem10";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "关于";
            this.barButtonItem5.Id = 14;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "主页";
            this.barButtonItem6.Id = 15;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "状态栏";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "状态栏";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(601, 54);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 398);
            this.barDockControlBottom.Size = new System.Drawing.Size(601, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 54);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 344);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(601, 54);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 344);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "注销";
            this.barSubItem2.Id = 1;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "关闭";
            this.barSubItem3.Id = 2;
            this.barSubItem3.Name = "barSubItem3";
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "退出";
            this.barSubItem4.Id = 3;
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "帮助...";
            this.barSubItem6.Id = 5;
            this.barSubItem6.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem8)});
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barSubItem8
            // 
            this.barSubItem8.Caption = "主页";
            this.barSubItem8.Id = 7;
            this.barSubItem8.Name = "barSubItem8";
            // 
            // barSubItem7
            // 
            this.barSubItem7.Caption = "关于";
            this.barSubItem7.Id = 6;
            this.barSubItem7.Name = "barSubItem7";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 17;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.StorageManageGroup;
            this.navBarControl1.AllowSelectedLink = true;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.EachGroupHasSelectedLink = true;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.UserManagerGroup,
            this.StorageManageGroup});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.UsersManage,
            this.RolesManage,
            this.Intowarehouse});
            this.navBarControl1.Location = new System.Drawing.Point(0, 54);
            this.navBarControl1.Margin = new System.Windows.Forms.Padding(0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.NavigationPaneGroupClientHeight = 160;
            this.navBarControl1.NavigationPaneMaxVisibleGroups = 7;
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 140;
            this.navBarControl1.Size = new System.Drawing.Size(156, 344);
            this.navBarControl1.SmallImages = this.imageList2;
            this.navBarControl1.TabIndex = 16;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator();
            // 
            // UserManagerGroup
            // 
            this.UserManagerGroup.Caption = "用户管理";
            this.UserManagerGroup.Expanded = true;
            this.UserManagerGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.RolesManage),
            new DevExpress.XtraNavBar.NavBarItemLink(this.UsersManage)});
            this.UserManagerGroup.Name = "UserManagerGroup";
            // 
            // RolesManage
            // 
            this.RolesManage.Caption = "角色";
            this.RolesManage.LargeImageIndex = 2;
            this.RolesManage.Name = "RolesManage";
            this.RolesManage.SmallImageIndex = 1;
            // 
            // UsersManage
            // 
            this.UsersManage.Caption = "用户";
            this.UsersManage.Name = "UsersManage";
            this.UsersManage.SmallImageIndex = 5;
            // 
            // StorageManageGroup
            // 
            this.StorageManageGroup.Caption = "库存管理";
            this.StorageManageGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.Intowarehouse)});
            this.StorageManageGroup.Name = "StorageManageGroup";
            // 
            // Intowarehouse
            // 
            this.Intowarehouse.Caption = "入库";
            this.Intowarehouse.Name = "Intowarehouse";
            this.Intowarehouse.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.LinkClicked);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            this.imageList2.Images.SetKeyName(14, "");
            this.imageList2.Images.SetKeyName(15, "");
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(156, 54);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 344);
            this.splitterControl1.TabIndex = 21;
            this.splitterControl1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 425);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MDIManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyMDIManager MDIManage;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barskins;
        private DevExpress.XtraBars.BarSubItem barskin;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.XtraBars.BarSubItem barSubItem7;
        private DevExpress.XtraBars.BarSubItem barSubItem8;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem showMenu;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem CloseWindow;
        private DevExpress.XtraBars.BarSubItem showWindows;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup StorageManageGroup;
        private DevExpress.XtraNavBar.NavBarItem Intowarehouse;
        private DevExpress.XtraNavBar.NavBarGroup UserManagerGroup;
        private DevExpress.XtraNavBar.NavBarItem RolesManage;
        private DevExpress.XtraNavBar.NavBarItem UsersManage;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList3;

    }
}