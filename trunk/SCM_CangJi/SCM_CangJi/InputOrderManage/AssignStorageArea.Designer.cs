namespace SCM_CangJi.InputOrderManage
{
    partial class AssignStorageArea
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
            this.gcInputCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.btnCompleteAndConfirmInput = new DevExpress.XtraEditors.SimpleButton();
            this.btnCompleteAssign = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlInputOrerDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewInputOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProductChName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridStorageArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStorageArea = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcLotsNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStorageArea)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInputCount
            // 
            this.gcInputCount.Caption = "入库数量";
            this.gcInputCount.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gcInputCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcInputCount.FieldName = "InputCount";
            this.gcInputCount.Name = "gcInputCount";
            this.gcInputCount.OptionsColumn.AllowEdit = false;
            this.gcInputCount.Visible = true;
            this.gcInputCount.VisibleIndex = 4;
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
            this.panelControl1.Controls.Add(this.btnBack);
            this.panelControl1.Controls.Add(this.btnCompleteAndConfirmInput);
            this.panelControl1.Controls.Add(this.btnCompleteAssign);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(687, 81);
            this.panelControl1.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(239, 30);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "退回修改";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCompleteAndConfirmInput
            // 
            this.btnCompleteAndConfirmInput.Location = new System.Drawing.Point(121, 30);
            this.btnCompleteAndConfirmInput.Name = "btnCompleteAndConfirmInput";
            this.btnCompleteAndConfirmInput.Size = new System.Drawing.Size(102, 23);
            this.btnCompleteAndConfirmInput.TabIndex = 0;
            this.btnCompleteAndConfirmInput.Text = "完成分配并入库";
            this.btnCompleteAndConfirmInput.Click += new System.EventHandler(this.btnCompleteAndConfirmInput_Click);
            // 
            // btnCompleteAssign
            // 
            this.btnCompleteAssign.Location = new System.Drawing.Point(29, 30);
            this.btnCompleteAssign.Name = "btnCompleteAssign";
            this.btnCompleteAssign.Size = new System.Drawing.Size(75, 23);
            this.btnCompleteAssign.TabIndex = 0;
            this.btnCompleteAssign.Text = "完成分配";
            this.btnCompleteAssign.Click += new System.EventHandler(this.btnCompleteAssign_Click);
            // 
            // gridControlInputOrerDetails
            // 
            this.gridControlInputOrerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInputOrerDetails.Location = new System.Drawing.Point(0, 81);
            this.gridControlInputOrerDetails.MainView = this.gridViewInputOrderDetails;
            this.gridControlInputOrerDetails.Name = "gridControlInputOrerDetails";
            this.gridControlInputOrerDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcProducts,
            this.repositoryItemSpinEdit1,
            this.gcStorageArea});
            this.gridControlInputOrerDetails.Size = new System.Drawing.Size(687, 288);
            this.gridControlInputOrerDetails.TabIndex = 3;
            this.gridControlInputOrerDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInputOrderDetails});
            // 
            // gridViewInputOrderDetails
            // 
            this.gridViewInputOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductChName,
            this.gcProductNumber1,
            this.gcProductNumber2,
            this.gcSpec,
            this.gcInputCount,
            this.gridStorageArea,
            this.gcLotsNumber,
            this.gcProductDate,
            this.gcInputInvoice});
            styleFormatCondition1.Column = this.gcInputCount;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition1.Value1 = "1";
            styleFormatCondition1.Value2 = "99999999";
            this.gridViewInputOrderDetails.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridViewInputOrderDetails.GridControl = this.gridControlInputOrerDetails;
            this.gridViewInputOrderDetails.Name = "gridViewInputOrderDetails";
            this.gridViewInputOrderDetails.NewItemRowText = "点击添加新行";
            this.gridViewInputOrderDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewInputOrderDetails.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewInputOrderDetails.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewInputOrderDetails.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewInputOrderDetails.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewInputOrderDetails_RowUpdated);
            // 
            // gcProductChName
            // 
            this.gcProductChName.Caption = "商品";
            this.gcProductChName.ColumnEdit = this.gcProducts;
            this.gcProductChName.FieldName = "ProductId";
            this.gcProductChName.Name = "gcProductChName";
            this.gcProductChName.OptionsColumn.AllowEdit = false;
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
            // gridStorageArea
            // 
            this.gridStorageArea.Caption = "库位";
            this.gridStorageArea.ColumnEdit = this.gcStorageArea;
            this.gridStorageArea.FieldName = "StorageAreaId";
            this.gridStorageArea.Name = "gridStorageArea";
            this.gridStorageArea.Visible = true;
            this.gridStorageArea.VisibleIndex = 5;
            // 
            // gcStorageArea
            // 
            this.gcStorageArea.AutoHeight = false;
            this.gcStorageArea.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gcStorageArea.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("库位编号", "库位编号", 68, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库编号", "仓库编号", 55, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库名称", "仓库名称")});
            this.gcStorageArea.DisplayMember = "库位编号";
            this.gcStorageArea.Name = "gcStorageArea";
            this.gcStorageArea.NullText = "请选择...";
            this.gcStorageArea.ValueMember = "Id";
            // 
            // gcLotsNumber
            // 
            this.gcLotsNumber.Caption = "生产批号";
            this.gcLotsNumber.FieldName = "LotsNumber";
            this.gcLotsNumber.Name = "gcLotsNumber";
            this.gcLotsNumber.OptionsColumn.AllowEdit = false;
            this.gcLotsNumber.Visible = true;
            this.gcLotsNumber.VisibleIndex = 6;
            // 
            // gcProductDate
            // 
            this.gcProductDate.Caption = "生产日期";
            this.gcProductDate.FieldName = "ProductDate";
            this.gcProductDate.Name = "gcProductDate";
            this.gcProductDate.OptionsColumn.AllowEdit = false;
            this.gcProductDate.Visible = true;
            this.gcProductDate.VisibleIndex = 7;
            // 
            // gcInputInvoice
            // 
            this.gcInputInvoice.Caption = "备注";
            this.gcInputInvoice.FieldName = "Remark";
            this.gcInputInvoice.Name = "gcInputInvoice";
            this.gcInputInvoice.Visible = true;
            this.gcInputInvoice.VisibleIndex = 8;
            // 
            // gcSpec
            // 
            this.gcSpec.Caption = "规格";
            this.gcSpec.FieldName = "Spec";
            this.gcSpec.Name = "gcSpec";
            this.gcSpec.Visible = true;
            this.gcSpec.VisibleIndex = 3;
            // 
            // gcProductNumber2
            // 
            this.gcProductNumber2.Caption = "品号2";
            this.gcProductNumber2.FieldName = "ProductNumber2";
            this.gcProductNumber2.Name = "gcProductNumber2";
            this.gcProductNumber2.Visible = true;
            this.gcProductNumber2.VisibleIndex = 2;
            // 
            // gcProductNumber1
            // 
            this.gcProductNumber1.Caption = "品号1";
            this.gcProductNumber1.FieldName = "ProductNumber1";
            this.gcProductNumber1.Name = "gcProductNumber1";
            this.gcProductNumber1.Visible = true;
            this.gcProductNumber1.VisibleIndex = 1;
            // 
            // AssignStorageArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 369);
            this.Controls.Add(this.gridControlInputOrerDetails);
            this.Controls.Add(this.panelControl1);
            this.Name = "AssignStorageArea";
            this.Text = "分配库位";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcStorageArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraEditors.SimpleButton btnCompleteAssign;
        private DevExpress.XtraGrid.GridControl gridControlInputOrerDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInputOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductChName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridStorageArea;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcStorageArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotsNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputInvoice;
        private DevExpress.XtraEditors.SimpleButton btnCompleteAndConfirmInput;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber2;
        private DevExpress.XtraGrid.Columns.GridColumn gcSpec;

    }
}