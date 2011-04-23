namespace SCM_CangJi.InputOrderManage
{
    partial class ConfirmInputOrder
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
            this.gridStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlInputOrders = new DevExpress.XtraGrid.GridControl();
            this.gridViewInputOrders = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcDeliveryOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPreDeliveryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeliveryAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnterUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnConfrimInput = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridStatus
            // 
            this.gridStatus.Caption = "单据状态";
            this.gridStatus.FieldName = "Status";
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.Visible = true;
            this.gridStatus.VisibleIndex = 6;
            // 
            // gridInvoice
            // 
            this.gridInvoice.Caption = "发票号码";
            this.gridInvoice.FieldName = "Invoice";
            this.gridInvoice.Name = "gridInvoice";
            this.gridInvoice.Visible = true;
            this.gridInvoice.VisibleIndex = 5;
            // 
            // gridControlInputOrders
            // 
            this.gridControlInputOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInputOrders.Location = new System.Drawing.Point(0, 80);
            this.gridControlInputOrders.MainView = this.gridViewInputOrders;
            this.gridControlInputOrders.Name = "gridControlInputOrders";
            this.gridControlInputOrders.Size = new System.Drawing.Size(707, 396);
            this.gridControlInputOrders.TabIndex = 5;
            this.gridControlInputOrders.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInputOrders});
            // 
            // gridViewInputOrders
            // 
            this.gridViewInputOrders.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcDeliveryOrderNumber,
            this.gcCompanyName,
            this.gridPreDeliveryDate,
            this.gridDeliveryAddress,
            this.gcEnterUser,
            this.gridInvoice,
            this.gridStatus});
            this.gridViewInputOrders.GridControl = this.gridControlInputOrders;
            this.gridViewInputOrders.Name = "gridViewInputOrders";
            this.gridViewInputOrders.OptionsBehavior.Editable = false;
            this.gridViewInputOrders.OptionsView.EnableAppearanceEvenRow = true;
            // 
            // gcDeliveryOrderNumber
            // 
            this.gcDeliveryOrderNumber.Caption = "入库单号";
            this.gcDeliveryOrderNumber.FieldName = "InputOrderNumber";
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
            this.gridPreDeliveryDate.FieldName = "PreInputDate";
            this.gridPreDeliveryDate.Name = "gridPreDeliveryDate";
            this.gridPreDeliveryDate.Visible = true;
            this.gridPreDeliveryDate.VisibleIndex = 2;
            // 
            // gridDeliveryAddress
            // 
            this.gridDeliveryAddress.Caption = "发货地";
            this.gridDeliveryAddress.FieldName = "FromWhere";
            this.gridDeliveryAddress.Name = "gridDeliveryAddress";
            this.gridDeliveryAddress.Visible = true;
            this.gridDeliveryAddress.VisibleIndex = 3;
            // 
            // gcEnterUser
            // 
            this.gcEnterUser.Caption = "入库人";
            this.gcEnterUser.FieldName = "EnterUser";
            this.gcEnterUser.Name = "gcEnterUser";
            this.gcEnterUser.Visible = true;
            this.gcEnterUser.VisibleIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(146, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnConfrimInput);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(707, 80);
            this.panelControl1.TabIndex = 4;
            // 
            // btnConfrimInput
            // 
            this.btnConfrimInput.Location = new System.Drawing.Point(34, 24);
            this.btnConfrimInput.Name = "btnConfrimInput";
            this.btnConfrimInput.Size = new System.Drawing.Size(91, 23);
            this.btnConfrimInput.TabIndex = 0;
            this.btnConfrimInput.Text = "确认入库";
            this.btnConfrimInput.Click += new System.EventHandler(this.btnConfrimInput_Click);
            // 
            // ConfirmInputOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 476);
            this.Controls.Add(this.gridControlInputOrders);
            this.Controls.Add(this.panelControl1);
            this.Name = "ConfirmInputOrder";
            this.Text = "入库确认";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn gridStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridInvoice;
        private DevExpress.XtraGrid.GridControl gridControlInputOrders;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInputOrders;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeliveryOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gridPreDeliveryDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeliveryAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnterUser;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConfrimInput;
    }
}