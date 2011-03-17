namespace SCM_CangJi.DeliveryOrderManage
{
    partial class AutoAssignStorage
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gcDeliveryCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCompleteAssign = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDeliveryOrerDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewDeliveryOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProductChName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcAssignCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotsNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductDate = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDeliveryCount
            // 
            this.gcDeliveryCount.Caption = "出库数量";
            this.gcDeliveryCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDeliveryCount.FieldName = "DeliveryCount";
            this.gcDeliveryCount.Name = "gcDeliveryCount";
            this.gcDeliveryCount.Visible = true;
            this.gcDeliveryCount.VisibleIndex = 1;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "n0";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.btnCompleteAssign);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(622, 81);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(148, 30);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnCompleteAssign
            // 
            this.btnCompleteAssign.Location = new System.Drawing.Point(49, 30);
            this.btnCompleteAssign.Name = "btnCompleteAssign";
            this.btnCompleteAssign.Size = new System.Drawing.Size(75, 23);
            this.btnCompleteAssign.TabIndex = 0;
            this.btnCompleteAssign.Text = "完成分配";
            this.btnCompleteAssign.Click += new System.EventHandler(this.btnCompleteAssign_Click);
            // 
            // gridControlDeliveryOrerDetails
            // 
            this.gridControlDeliveryOrerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDeliveryOrerDetails.Location = new System.Drawing.Point(0, 81);
            this.gridControlDeliveryOrerDetails.MainView = this.gridViewDeliveryOrderDetails;
            this.gridControlDeliveryOrerDetails.Name = "gridControlDeliveryOrerDetails";
            this.gridControlDeliveryOrerDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcProducts,
            this.repositoryItemSpinEdit1});
            this.gridControlDeliveryOrerDetails.Size = new System.Drawing.Size(622, 302);
            this.gridControlDeliveryOrerDetails.TabIndex = 1;
            this.gridControlDeliveryOrerDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryOrderDetails});
            // 
            // gridViewDeliveryOrderDetails
            // 
            this.gridViewDeliveryOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductChName,
            this.gcDeliveryCount,
            this.gcAssignCount,
            this.gcInputInvoice,
            this.gcLotsNumber,
            this.gcProductDate});
            styleFormatCondition1.Column = this.gcDeliveryCount;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition1.Value1 = "1";
            styleFormatCondition1.Value2 = "99999999";
            this.gridViewDeliveryOrderDetails.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridViewDeliveryOrderDetails.GridControl = this.gridControlDeliveryOrerDetails;
            this.gridViewDeliveryOrderDetails.Name = "gridViewDeliveryOrderDetails";
            this.gridViewDeliveryOrderDetails.NewItemRowText = "点击添加新行";
            this.gridViewDeliveryOrderDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDeliveryOrderDetails.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewDeliveryOrderDetails.OptionsBehavior.Editable = false;
            this.gridViewDeliveryOrderDetails.OptionsNavigation.AutoFocusNewRow = true;
            // 
            // gcProductChName
            // 
            this.gcProductChName.Caption = "商品";
            this.gcProductChName.ColumnEdit = this.gcProducts;
            this.gcProductChName.FieldName = "ProductId";
            this.gcProductChName.Name = "gcProductChName";
            this.gcProductChName.Visible = true;
            this.gcProductChName.VisibleIndex = 0;
            // 
            // gcProducts
            // 
            this.gcProducts.AutoHeight = false;
            this.gcProducts.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gcProducts.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductChName", "品名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductEngName", "英文名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumber1", "品号1"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumber2", "品号2")});
            this.gcProducts.DisplayMember = "ProductChName";
            this.gcProducts.Name = "gcProducts";
            this.gcProducts.NullText = "请选择...";
            this.gcProducts.ValueMember = "ProductId";
            // 
            // gcAssignCount
            // 
            this.gcAssignCount.Caption = "分配数量";
            this.gcAssignCount.FieldName = "AssignCount";
            this.gcAssignCount.Name = "gcAssignCount";
            this.gcAssignCount.Visible = true;
            this.gcAssignCount.VisibleIndex = 2;
            // 
            // gcInputInvoice
            // 
            this.gcInputInvoice.Caption = "入库发票号";
            this.gcInputInvoice.FieldName = "InputInvoice";
            this.gcInputInvoice.Name = "gcInputInvoice";
            this.gcInputInvoice.Visible = true;
            this.gcInputInvoice.VisibleIndex = 3;
            // 
            // gcLotsNumber
            // 
            this.gcLotsNumber.Caption = "生产批号";
            this.gcLotsNumber.FieldName = "LotsNumber";
            this.gcLotsNumber.Name = "gcLotsNumber";
            this.gcLotsNumber.Visible = true;
            this.gcLotsNumber.VisibleIndex = 4;
            // 
            // gcProductDate
            // 
            this.gcProductDate.Caption = "生产日期";
            this.gcProductDate.FieldName = "ProductDate";
            this.gcProductDate.Name = "gcProductDate";
            this.gcProductDate.Visible = true;
            this.gcProductDate.VisibleIndex = 5;
            // 
            // AutoAssignStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 383);
            this.Controls.Add(this.gridControlDeliveryOrerDetails);
            this.Controls.Add(this.panelControl1);
            this.Name = "AutoAssignStorage";
            this.Text = "库存分配情况";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlDeliveryOrerDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductChName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeliveryCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotsNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcAssignCount;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnCompleteAssign;

    }
}