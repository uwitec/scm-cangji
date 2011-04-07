namespace SCM_CangJi.DeliveryOrderManage
{
    partial class DeliveryOrderList
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreate = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDeliveryOrders = new DevExpress.XtraGrid.GridControl();
            this.gridViewDeliveryOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDeliveryOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPreDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeliveryAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridReachedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportExcle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnExportExcle);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnCreate);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(610, 80);
            this.panelControl1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(146, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(34, 24);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(91, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "创建预出库单";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // gridControlDeliveryOrders
            // 
            this.gridControlDeliveryOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDeliveryOrders.Location = new System.Drawing.Point(0, 80);
            this.gridControlDeliveryOrders.MainView = this.gridViewDeliveryOrders;
            this.gridControlDeliveryOrders.Name = "gridControlDeliveryOrders";
            this.gridControlDeliveryOrders.Size = new System.Drawing.Size(610, 322);
            this.gridControlDeliveryOrders.TabIndex = 1;
            this.gridControlDeliveryOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryOrders});
            this.gridControlDeliveryOrders.DoubleClick += new System.EventHandler(this.gridControlDeliveryOrders_DoubleClick);
            // 
            // gridViewDeliveryOrders
            // 
            this.gridViewDeliveryOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDeliveryOrderNumber,
            this.gcCompanyName,
            this.gridPreDeliveryDate,
            this.gridDeliveryAddress,
            this.gridReachedDate,
            this.gridInvoice,
            this.gridStatus});
            this.gridViewDeliveryOrders.GridControl = this.gridControlDeliveryOrders;
            this.gridViewDeliveryOrders.Name = "gridViewDeliveryOrders";
            this.gridViewDeliveryOrders.OptionsBehavior.Editable = false;
            this.gridViewDeliveryOrders.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDeliveryOrders.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridViewDeliveryOrders_ShowGridMenu);
            // 
            // gcDeliveryOrderNumber
            // 
            this.gcDeliveryOrderNumber.Caption = "出库单号";
            this.gcDeliveryOrderNumber.FieldName = "DeliveryOrderNumber";
            this.gcDeliveryOrderNumber.Name = "gcDeliveryOrderNumber";
            this.gcDeliveryOrderNumber.Visible = true;
            this.gcDeliveryOrderNumber.VisibleIndex = 0;
            // 
            // gcCompanyName
            // 
            this.gcCompanyName.Caption = "所属客户";
            this.gcCompanyName.FieldName = "CompanyName";
            this.gcCompanyName.Name = "gcCompanyName";
            this.gcCompanyName.Visible = true;
            this.gcCompanyName.VisibleIndex = 1;
            // 
            // gridPreDeliveryDate
            // 
            this.gridPreDeliveryDate.Caption = "制单日期";
            this.gridPreDeliveryDate.FieldName = "PreDeliveryDate";
            this.gridPreDeliveryDate.Name = "gridPreDeliveryDate";
            this.gridPreDeliveryDate.Visible = true;
            this.gridPreDeliveryDate.VisibleIndex = 2;
            // 
            // gridDeliveryAddress
            // 
            this.gridDeliveryAddress.Caption = "送货地址";
            this.gridDeliveryAddress.FieldName = "DeliveryAddress";
            this.gridDeliveryAddress.Name = "gridDeliveryAddress";
            this.gridDeliveryAddress.Visible = true;
            this.gridDeliveryAddress.VisibleIndex = 3;
            // 
            // gridReachedDate
            // 
            this.gridReachedDate.Caption = "送达日期";
            this.gridReachedDate.FieldName = "ReachedDate";
            this.gridReachedDate.Name = "gridReachedDate";
            this.gridReachedDate.Visible = true;
            this.gridReachedDate.VisibleIndex = 4;
            // 
            // gridInvoice
            // 
            this.gridInvoice.Caption = "发票号码";
            this.gridInvoice.FieldName = "Invoice";
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Visible = true;
            this.gridInvoice.VisibleIndex = 5;
            // 
            // gridStatus
            // 
            this.gridStatus.Caption = "单据状态";
            this.gridStatus.FieldName = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.Visible = true;
            this.gridStatus.VisibleIndex = 6;
            // 
            // btnExportExcle
            // 
            this.btnExportExcle.Location = new System.Drawing.Point(244, 24);
            this.btnExportExcle.Name = "btnExportExcle";
            this.btnExportExcle.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcle.TabIndex = 2;
            this.btnExportExcle.Text = "导出";
            this.btnExportExcle.Click += new System.EventHandler(this.btnExportExcle_Click);
            // 
            // DeliveryOrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 402);
            this.Controls.Add(this.gridControlDeliveryOrders);
            this.Controls.Add(this.panelControl1);
            this.Name = "DeliveryOrderList";
            this.Text = "出库单列表";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnCreate;
        private DevExpress.XtraGrid.GridControl gridControlDeliveryOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryOrders;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeliveryOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridPreDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeliveryAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridReachedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gridStatus;
        private DevExpress.XtraEditors.SimpleButton btnExportExcle;
    }
}