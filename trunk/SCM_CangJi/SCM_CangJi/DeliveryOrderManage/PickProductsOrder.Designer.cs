namespace SCM_CangJi.DeliveryOrderManage
{
    partial class PickProductsOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControlAssignDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewAssignDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlProducts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.现品号名称 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.数量 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.库位 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.生产批号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.生产日期 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.入库发票 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtReachDate = new DevExpress.XtraEditors.TextEdit();
            this.txtCompanyName = new DevExpress.XtraEditors.TextEdit();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoice = new DevExpress.XtraEditors.TextEdit();
            this.txtDeliveryOrderNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAssignDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssignDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReachDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryOrderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControlAssignDetails);
            this.layoutControl1.Controls.Add(this.txtReachDate);
            this.layoutControl1.Controls.Add(this.txtCompanyName);
            this.layoutControl1.Controls.Add(this.txtAddress);
            this.layoutControl1.Controls.Add(this.txtInvoice);
            this.layoutControl1.Controls.Add(this.txtDeliveryOrderNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 26);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(858, 402);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControlAssignDetails
            // 
            this.gridControlAssignDetails.Location = new System.Drawing.Point(12, 108);
            this.gridControlAssignDetails.MainView = this.gridViewAssignDetails;
            this.gridControlAssignDetails.Name = "gridControlAssignDetails";
            this.gridControlAssignDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlProducts});
            this.gridControlAssignDetails.Size = new System.Drawing.Size(834, 282);
            this.gridControlAssignDetails.TabIndex = 12;
            this.gridControlAssignDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAssignDetails});
            // 
            // gridViewAssignDetails
            // 
            this.gridViewAssignDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductName,
            this.现品号名称,
            this.数量,
            this.库位,
            this.生产批号,
            this.生产日期,
            this.入库发票});
            this.gridViewAssignDetails.GridControl = this.gridControlAssignDetails;
            this.gridViewAssignDetails.Name = "gridViewAssignDetails";
            this.gridViewAssignDetails.OptionsBehavior.Editable = false;
            this.gridViewAssignDetails.OptionsBehavior.ReadOnly = true;
            this.gridViewAssignDetails.OptionsView.ShowGroupPanel = false;
            this.gridViewAssignDetails.PaintStyleName = "Web";
            // 
            // gcProductName
            // 
            this.gcProductName.Caption = "商品名称";
            this.gcProductName.ColumnEdit = this.ddlProducts;
            this.gcProductName.FieldName = "ProductId";
            this.gcProductName.Name = "gcProductName";
            this.gcProductName.Visible = true;
            this.gcProductName.VisibleIndex = 0;
            this.gcProductName.Width = 174;
            // 
            // ddlProducts
            // 
            this.ddlProducts.AutoHeight = false;
            this.ddlProducts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlProducts.DisplayMember = "ProductChName";
            this.ddlProducts.Name = "ddlProducts";
            this.ddlProducts.ValueMember = "Id";
            // 
            // 现品号名称
            // 
            this.现品号名称.Caption = "现品票号";
            this.现品号名称.FieldName = "CurrentProductNumber";
            this.现品号名称.Name = "现品号名称";
            this.现品号名称.Visible = true;
            this.现品号名称.VisibleIndex = 1;
            this.现品号名称.Width = 104;
            // 
            // 数量
            // 
            this.数量.Caption = "数量";
            this.数量.FieldName = "AssignCount";
            this.数量.Name = "数量";
            this.数量.Visible = true;
            this.数量.VisibleIndex = 2;
            this.数量.Width = 91;
            // 
            // 库位
            // 
            this.库位.Caption = "库位";
            this.库位.FieldName = "StorageArea";
            this.库位.Name = "库位";
            this.库位.Visible = true;
            this.库位.VisibleIndex = 3;
            this.库位.Width = 104;
            // 
            // 生产批号
            // 
            this.生产批号.Caption = "生产批号";
            this.生产批号.FieldName = "LotsNumber";
            this.生产批号.Name = "生产批号";
            this.生产批号.Visible = true;
            this.生产批号.VisibleIndex = 4;
            this.生产批号.Width = 82;
            // 
            // 生产日期
            // 
            this.生产日期.Caption = "生产日期";
            this.生产日期.FieldName = "ProductDate";
            this.生产日期.Name = "生产日期";
            this.生产日期.OptionsColumn.FixedWidth = true;
            this.生产日期.Visible = true;
            this.生产日期.VisibleIndex = 5;
            this.生产日期.Width = 99;
            // 
            // 入库发票
            // 
            this.入库发票.Caption = "入库发票";
            this.入库发票.FieldName = "InputInvoice";
            this.入库发票.Name = "入库发票";
            this.入库发票.Visible = true;
            this.入库发票.VisibleIndex = 6;
            this.入库发票.Width = 120;
            // 
            // txtReachDate
            // 
            this.txtReachDate.Location = new System.Drawing.Point(503, 58);
            this.txtReachDate.Name = "txtReachDate";
            this.txtReachDate.Size = new System.Drawing.Size(343, 21);
            this.txtReachDate.StyleController = this.layoutControl1;
            this.txtReachDate.TabIndex = 11;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Location = new System.Drawing.Point(503, 33);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(343, 21);
            this.txtCompanyName.StyleController = this.layoutControl1;
            this.txtCompanyName.TabIndex = 10;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(76, 83);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(770, 21);
            this.txtAddress.StyleController = this.layoutControl1;
            this.txtAddress.TabIndex = 8;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(76, 58);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(359, 21);
            this.txtInvoice.StyleController = this.layoutControl1;
            this.txtInvoice.TabIndex = 6;
            // 
            // txtDeliveryOrderNumber
            // 
            this.txtDeliveryOrderNumber.Location = new System.Drawing.Point(76, 33);
            this.txtDeliveryOrderNumber.Name = "txtDeliveryOrderNumber";
            this.txtDeliveryOrderNumber.Size = new System.Drawing.Size(359, 21);
            this.txtDeliveryOrderNumber.StyleController = this.layoutControl1;
            this.txtDeliveryOrderNumber.TabIndex = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "拣品单";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem1,
            this.layoutControlItem4,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(858, 402);
            this.layoutControlGroup1.Text = "订单信息";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDeliveryOrderNumber;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(427, 25);
            this.layoutControlItem2.Text = "订单号：";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtInvoice;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(427, 25);
            this.layoutControlItem3.Text = "发票：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtAddress;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(838, 25);
            this.layoutControlItem5.Text = "送货地址：";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCompanyName;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(427, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(411, 25);
            this.layoutControlItem1.Text = "公司名：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtReachDate;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(427, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(411, 25);
            this.layoutControlItem4.Text = "送达日期：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(60, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridControlAssignDetails;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(838, 286);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "重新打印";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(858, 26);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 428);
            this.barDockControlBottom.Size = new System.Drawing.Size(858, 22);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 26);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 402);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(858, 26);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 402);
            // 
            // PickProductsOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 450);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PickProductsOrder";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAssignDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAssignDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReachDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompanyName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryOrderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtReachDate;
        private DevExpress.XtraEditors.TextEdit txtCompanyName;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.TextEdit txtInvoice;
        private DevExpress.XtraEditors.TextEdit txtDeliveryOrderNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl gridControlAssignDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAssignDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductName;
        private DevExpress.XtraGrid.Columns.GridColumn 现品号名称;
        private DevExpress.XtraGrid.Columns.GridColumn 数量;
        private DevExpress.XtraGrid.Columns.GridColumn 库位;
        private DevExpress.XtraGrid.Columns.GridColumn 生产批号;
        private DevExpress.XtraGrid.Columns.GridColumn 生产日期;
        private DevExpress.XtraGrid.Columns.GridColumn 入库发票;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlProducts;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;

    }
}
