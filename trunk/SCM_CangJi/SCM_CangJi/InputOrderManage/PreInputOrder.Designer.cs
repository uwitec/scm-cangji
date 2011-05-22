namespace SCM_CangJi.InputOrderManage
{
    partial class PreInputOrder
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
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.gcInputCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnPreComplete = new DevExpress.XtraEditors.SimpleButton();
            this.gcProductChName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridViewInputOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcBrand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotsNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInputInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlInputOrerDetails = new DevExpress.XtraGrid.GridControl();
            this.btnAddDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAll = new DevExpress.XtraEditors.SimpleButton();
            this.txtInvoice = new DevExpress.XtraEditors.TextEdit();
            this.ddlCompanies = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPreInputDate = new DevExpress.XtraEditors.LabelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblInputOrderNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.txtFromWhere = new DevExpress.XtraEditors.TextEdit();
            this.lblEnterUser = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromWhere.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInputCount
            // 
            this.gcInputCount.Caption = "入库数量";
            this.gcInputCount.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gcInputCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcInputCount.FieldName = "InputCount";
            this.gcInputCount.Name = "gcInputCount";
            this.gcInputCount.Visible = true;
            this.gcInputCount.VisibleIndex = 5;
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
            // btnPreComplete
            // 
            this.btnPreComplete.Location = new System.Drawing.Point(113, 152);
            this.btnPreComplete.Name = "btnPreComplete";
            this.btnPreComplete.Size = new System.Drawing.Size(75, 23);
            this.btnPreComplete.TabIndex = 7;
            this.btnPreComplete.Text = "完成预入库";
            this.btnPreComplete.Click += new System.EventHandler(this.btnPreComplete_Click);
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
            // gridViewInputOrderDetails
            // 
            this.gridViewInputOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductChName,
            this.gcBrand,
            this.gcProductNumber1,
            this.gcProductNumber2,
            this.gcSpec,
            this.gcInputCount,
            this.gridColumn1,
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
            this.gridViewInputOrderDetails.OptionsPrint.UsePrintStyles = true;
            this.gridViewInputOrderDetails.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewInputOrderDetails.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridViewInputOrderDetails_RowCellStyle);
            this.gridViewInputOrderDetails.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridViewInputOrderDetails_ShowGridMenu);
            this.gridViewInputOrderDetails.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewInputOrderDetails_InitNewRow);
            this.gridViewInputOrderDetails.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewInputOrderDetails_RowUpdated);
            // 
            // gcBrand
            // 
            this.gcBrand.Caption = "品牌";
            this.gcBrand.FieldName = "Brand";
            this.gcBrand.Name = "gcBrand";
            this.gcBrand.OptionsColumn.AllowEdit = false;
            this.gcBrand.Visible = true;
            this.gcBrand.VisibleIndex = 1;
            // 
            // gcProductNumber1
            // 
            this.gcProductNumber1.Caption = "品号1";
            this.gcProductNumber1.FieldName = "ProductNumber1";
            this.gcProductNumber1.Name = "gcProductNumber1";
            this.gcProductNumber1.OptionsColumn.AllowEdit = false;
            this.gcProductNumber1.Visible = true;
            this.gcProductNumber1.VisibleIndex = 2;
            // 
            // gcProductNumber2
            // 
            this.gcProductNumber2.Caption = "品号2";
            this.gcProductNumber2.FieldName = "ProductNumber2";
            this.gcProductNumber2.Name = "gcProductNumber2";
            this.gcProductNumber2.OptionsColumn.AllowEdit = false;
            this.gcProductNumber2.Visible = true;
            this.gcProductNumber2.VisibleIndex = 3;
            // 
            // gcSpec
            // 
            this.gcSpec.Caption = "规格";
            this.gcSpec.FieldName = "Spec";
            this.gcSpec.Name = "gcSpec";
            this.gcSpec.Visible = true;
            this.gcSpec.VisibleIndex = 4;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "库位";
            this.gridColumn1.FieldName = "StorageArea";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gcLotsNumber
            // 
            this.gcLotsNumber.Caption = "生产批号";
            this.gcLotsNumber.FieldName = "LotsNumber";
            this.gcLotsNumber.Name = "gcLotsNumber";
            this.gcLotsNumber.Visible = true;
            this.gcLotsNumber.VisibleIndex = 7;
            // 
            // gcProductDate
            // 
            this.gcProductDate.Caption = "到期日期";
            this.gcProductDate.FieldName = "ProductDate";
            this.gcProductDate.Name = "gcProductDate";
            this.gcProductDate.Visible = true;
            this.gcProductDate.VisibleIndex = 8;
            // 
            // gcInputInvoice
            // 
            this.gcInputInvoice.Caption = "备注";
            this.gcInputInvoice.FieldName = "Remark";
            this.gcInputInvoice.Name = "gcInputInvoice";
            this.gcInputInvoice.Visible = true;
            this.gcInputInvoice.VisibleIndex = 9;
            // 
            // gridControlInputOrerDetails
            // 
            this.gridControlInputOrerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInputOrerDetails.Location = new System.Drawing.Point(0, 0);
            this.gridControlInputOrerDetails.MainView = this.gridViewInputOrderDetails;
            this.gridControlInputOrerDetails.Name = "gridControlInputOrerDetails";
            this.gridControlInputOrerDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcProducts,
            this.repositoryItemSpinEdit1});
            this.gridControlInputOrerDetails.Size = new System.Drawing.Size(634, 331);
            this.gridControlInputOrerDetails.TabIndex = 0;
            this.gridControlInputOrerDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInputOrderDetails});
            this.gridControlInputOrerDetails.DoubleClick += new System.EventHandler(this.gridControlInputOrerDetails_DoubleClick);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(101, 10);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddDetail.TabIndex = 9;
            this.btnAddDetail.Text = "增加明细";
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(32, 152);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAll.TabIndex = 5;
            this.btnSaveAll.Text = "保存";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(98, 109);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(171, 21);
            this.txtInvoice.TabIndex = 3;
            // 
            // ddlCompanies
            // 
            this.ddlCompanies.Location = new System.Drawing.Point(98, 70);
            this.ddlCompanies.Name = "ddlCompanies";
            this.ddlCompanies.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlCompanies.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CompanyName", "公司名称")});
            this.ddlCompanies.Properties.DisplayMember = "CompanyName";
            this.ddlCompanies.Properties.NullText = "请选择...";
            this.ddlCompanies.Properties.ValueMember = "Id";
            this.ddlCompanies.Size = new System.Drawing.Size(171, 21);
            this.ddlCompanies.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.ddlCompanies, conditionValidationRule1);
            this.ddlCompanies.EditValueChanged += new System.EventHandler(this.ddlCompanies_EditValueChanged);
            // 
            // lblPreInputDate
            // 
            this.lblPreInputDate.Location = new System.Drawing.Point(355, 43);
            this.lblPreInputDate.Name = "lblPreInputDate";
            this.lblPreInputDate.Size = new System.Drawing.Size(85, 14);
            this.lblPreInputDate.TabIndex = 1;
            this.lblPreInputDate.Text = "lblPreInputDate";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(182, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "从文件导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(12, 3);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(80, 24);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "基本信息";
            // 
            // lblInputOrderNumber
            // 
            this.lblInputOrderNumber.Location = new System.Drawing.Point(98, 43);
            this.lblInputOrderNumber.Name = "lblInputOrderNumber";
            this.lblInputOrderNumber.Size = new System.Drawing.Size(115, 14);
            this.lblInputOrderNumber.TabIndex = 1;
            this.lblInputOrderNumber.Text = "lblInputOrderNumber";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(289, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "制单日期：";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(12, 9);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(80, 24);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "入库明细";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnBack);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnPreComplete);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSaveAll);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtFromWhere);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtInvoice);
            this.splitContainerControl1.Panel1.Controls.Add(this.ddlCompanies);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblEnterUser);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPreInputDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblInputOrderNumber);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl9);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControlInputOrerDetails);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(634, 527);
            this.splitContainerControl1.SplitterPosition = 190;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(32, 152);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "退回修改";
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtFromWhere
            // 
            this.txtFromWhere.Location = new System.Drawing.Point(355, 109);
            this.txtFromWhere.Name = "txtFromWhere";
            this.txtFromWhere.Size = new System.Drawing.Size(175, 21);
            this.txtFromWhere.TabIndex = 4;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "发货地不能为空!";
            this.dxValidationProvider1.SetValidationRule(this.txtFromWhere, conditionValidationRule2);
            // 
            // lblEnterUser
            // 
            this.lblEnterUser.Location = new System.Drawing.Point(355, 73);
            this.lblEnterUser.Name = "lblEnterUser";
            this.lblEnterUser.Size = new System.Drawing.Size(65, 14);
            this.lblEnterUser.TabIndex = 1;
            this.lblEnterUser.Text = "lblEnterUser";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(301, 112);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "发货地：";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(301, 72);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(48, 14);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "入库人：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(32, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "发票号码：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(32, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "所属公司：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "入库单号：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.btnImport);
            this.panelControl1.Controls.Add(this.btnAddDetail);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(634, 38);
            this.panelControl1.TabIndex = 1;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(263, 9);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印入库单";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // PreInputOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 527);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PreInputOrder";
            this.Text = "入库单";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFromWhere.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPreComplete;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductChName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcProducts;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInputOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotsNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductDate;
        private DevExpress.XtraGrid.GridControl gridControlInputOrerDetails;
        private DevExpress.XtraEditors.SimpleButton btnAddDetail;
        private DevExpress.XtraEditors.SimpleButton btnSaveAll;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit txtInvoice;
        private DevExpress.XtraEditors.LookUpEdit ddlCompanies;
        private DevExpress.XtraEditors.LabelControl lblPreInputDate;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl lblInputOrderNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtFromWhere;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl lblEnterUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber1;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber2;
        private DevExpress.XtraGrid.Columns.GridColumn gcSpec;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn gcBrand;
    }
}