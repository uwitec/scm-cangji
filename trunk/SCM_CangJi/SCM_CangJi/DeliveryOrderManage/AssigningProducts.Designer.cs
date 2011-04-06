namespace SCM_CangJi.DeliveryOrderManage
{
    partial class AssigningProducts
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
            this.gridViewDeliveryDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlDeliveryOrders = new DevExpress.XtraGrid.GridControl();
            this.gridViewDeliveryOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDeliveryOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPreDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeliveryAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridReachedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnAssign = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewDeliveryDetails
            // 
            this.gridViewDeliveryDetails.GridControl = this.gridControlDeliveryOrders;
            this.gridViewDeliveryDetails.Name = "gridViewDeliveryDetails";
            // 
            // gridControlDeliveryOrders
            // 
            this.gridControlDeliveryOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDeliveryOrders.Location = new System.Drawing.Point(0, 80);
            this.gridControlDeliveryOrders.MainView = this.gridViewDeliveryOrders;
            this.gridControlDeliveryOrders.Name = "gridControlDeliveryOrders";
            this.gridControlDeliveryOrders.Size = new System.Drawing.Size(613, 292);
            this.gridControlDeliveryOrders.TabIndex = 2;
            this.gridControlDeliveryOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryOrders,
            this.gridViewDeliveryDetails});
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnAssign);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(613, 80);
            this.panelControl1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "预出库有误";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(127, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(34, 24);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(76, 23);
            this.btnAssign.TabIndex = 0;
            this.btnAssign.Text = "分配";
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // AssigningProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 372);
            this.Controls.Add(this.gridControlDeliveryOrders);
            this.Controls.Add(this.panelControl1);
            this.Name = "AssigningProducts";
            this.Text = "待分配单据";
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnAssign;
        private DevExpress.XtraGrid.GridControl gridControlDeliveryOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryOrders;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeliveryOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridPreDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeliveryAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridReachedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gridStatus;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryDetails;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}