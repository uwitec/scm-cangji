namespace SCM_CangJi.DeliveryOrderManage
{
    partial class ConfirmDeliveryOrder
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridViewOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewOrderDetails
            // 
            this.gridViewOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridViewOrderDetails.GridControl = this.gridControlDeliveryOrders;
            this.gridViewOrderDetails.Name = "gridViewOrderDetails";
            this.gridViewOrderDetails.OptionsView.EnableAppearanceEvenRow = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "出库数量";
            this.gridColumn1.FieldName = "DeliveryCount";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridControlDeliveryOrders
            // 
            this.gridControlDeliveryOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.LevelTemplate = this.gridViewOrderDetails;
            gridLevelNode2.RelationName = "Level1";
            this.gridControlDeliveryOrders.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControlDeliveryOrders.Location = new System.Drawing.Point(0, 80);
            this.gridControlDeliveryOrders.MainView = this.gridViewDeliveryOrders;
            this.gridControlDeliveryOrders.Name = "gridControlDeliveryOrders";
            this.gridControlDeliveryOrders.Size = new System.Drawing.Size(838, 365);
            this.gridControlDeliveryOrders.TabIndex = 2;
            this.gridControlDeliveryOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryOrders,
            this.gridViewOrderDetails});
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
            this.panelControl1.Controls.Add(this.btnBack);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnConfirm);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(838, 80);
            this.panelControl1.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(146, 24);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "退回修改";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(238, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(34, 24);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(91, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确认出库";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // ConfirmDeliveryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 445);
            this.Controls.Add(this.gridControlDeliveryOrders);
            this.Controls.Add(this.panelControl1);
            this.Name = "ConfirmDeliveryOrder";
            this.Text = "出库确认";
            this.Load += new System.EventHandler(this.ConfirmDeliveryOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrderDetails;
        private DevExpress.XtraGrid.GridControl gridControlDeliveryOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryOrders;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeliveryOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridPreDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeliveryAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridReachedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gridStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnBack;
    }
}