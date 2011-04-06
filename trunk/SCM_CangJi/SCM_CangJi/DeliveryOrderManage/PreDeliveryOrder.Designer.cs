namespace SCM_CangJi.DeliveryOrderManage
{
    partial class PreDeliveryOrder
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.gcDeliveryCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btn = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreCompletedAndAssign = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAndClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAll = new DevExpress.XtraEditors.SimpleButton();
            this.txtReachedDate = new DevExpress.XtraEditors.DateEdit();
            this.txtInvoice = new DevExpress.XtraEditors.TextEdit();
            this.ddlDeliveryAddress = new DevExpress.XtraEditors.LookUpEdit();
            this.ddlCompanies = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPreDeliveryDate = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblDeliveryOrderNumber = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddDetail = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlDeliveryOrerDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewDeliveryOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProductChName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcInputInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotsNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReachedDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReachedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDeliveryAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanies.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDeliveryCount
            // 
            this.gcDeliveryCount.Caption = "出库数量";
            this.gcDeliveryCount.ColumnEdit = this.repositoryItemSpinEdit1;
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
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btn);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnPreCompletedAndAssign);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSaveAndClose);
            this.splitContainerControl1.Panel1.Controls.Add(this.btnSaveAll);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtReachedDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.txtInvoice);
            this.splitContainerControl1.Panel1.Controls.Add(this.ddlDeliveryAddress);
            this.splitContainerControl1.Panel1.Controls.Add(this.ddlCompanies);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblPreDeliveryDate);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainerControl1.Panel1.Controls.Add(this.lblDeliveryOrderNumber);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl6);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControlDeliveryOrerDetails);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(643, 476);
            this.splitContainerControl1.SplitterPosition = 170;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(194, 132);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 7;
            this.btn.Text = "完成预出库";
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPreCompletedAndAssign
            // 
            this.btnPreCompletedAndAssign.Location = new System.Drawing.Point(275, 132);
            this.btnPreCompletedAndAssign.Name = "btnPreCompletedAndAssign";
            this.btnPreCompletedAndAssign.Size = new System.Drawing.Size(138, 23);
            this.btnPreCompletedAndAssign.TabIndex = 8;
            this.btnPreCompletedAndAssign.Text = "完成预出库并分配库存";
            this.btnPreCompletedAndAssign.Click += new System.EventHandler(this.btnPreCompleted_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Location = new System.Drawing.Point(113, 132);
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAndClose.TabIndex = 6;
            this.btnSaveAndClose.Text = "保存并关闭";
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Location = new System.Drawing.Point(32, 132);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAll.TabIndex = 5;
            this.btnSaveAll.Text = "保存";
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // txtReachedDate
            // 
            this.txtReachedDate.EditValue = null;
            this.txtReachedDate.Location = new System.Drawing.Point(355, 105);
            this.txtReachedDate.Name = "txtReachedDate";
            this.txtReachedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtReachedDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtReachedDate.Size = new System.Drawing.Size(149, 21);
            this.txtReachedDate.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.txtReachedDate, conditionValidationRule1);
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(98, 105);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(146, 21);
            this.txtInvoice.TabIndex = 3;
            // 
            // ddlDeliveryAddress
            // 
            this.ddlDeliveryAddress.Location = new System.Drawing.Point(355, 70);
            this.ddlDeliveryAddress.Name = "ddlDeliveryAddress";
            this.ddlDeliveryAddress.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlDeliveryAddress.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AddressName", "地址名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("AddressCode", "地址代码"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Address", "具体地址")});
            this.ddlDeliveryAddress.Properties.DisplayMember = "AddressName";
            this.ddlDeliveryAddress.Properties.NullText = "请选择...";
            this.ddlDeliveryAddress.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ddlDeliveryAddress.Properties.ValueMember = "Id";
            this.ddlDeliveryAddress.Size = new System.Drawing.Size(149, 21);
            this.ddlDeliveryAddress.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.ddlDeliveryAddress, conditionValidationRule2);
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
            this.ddlCompanies.Properties.EditValueChanged += new System.EventHandler(this.ddlCompanies_Properties_EditValueChanged);
            this.ddlCompanies.Size = new System.Drawing.Size(146, 21);
            this.ddlCompanies.TabIndex = 1;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.ddlCompanies, conditionValidationRule3);
            // 
            // lblPreDeliveryDate
            // 
            this.lblPreDeliveryDate.Location = new System.Drawing.Point(355, 43);
            this.lblPreDeliveryDate.Name = "lblPreDeliveryDate";
            this.lblPreDeliveryDate.Size = new System.Drawing.Size(97, 14);
            this.lblPreDeliveryDate.TabIndex = 1;
            this.lblPreDeliveryDate.Text = "lblPreDeliveryDate";
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
            // lblDeliveryOrderNumber
            // 
            this.lblDeliveryOrderNumber.Location = new System.Drawing.Point(98, 43);
            this.lblDeliveryOrderNumber.Name = "lblDeliveryOrderNumber";
            this.lblDeliveryOrderNumber.Size = new System.Drawing.Size(127, 14);
            this.lblDeliveryOrderNumber.TabIndex = 1;
            this.lblDeliveryOrderNumber.Text = "lblDeliveryOrderNumber";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(289, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "制单日期：";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(289, 108);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "出库日期：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(289, 73);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "送货地址：";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(32, 108);
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
            this.labelControl1.Text = "出库单号：";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.btnImport);
            this.panelControl1.Controls.Add(this.btnAddDetail);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(643, 38);
            this.panelControl1.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(12, 9);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(40, 24);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "明细";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(139, 10);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "从文件导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(58, 10);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddDetail.TabIndex = 9;
            this.btnAddDetail.Text = "增加明细";
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // gridControlDeliveryOrerDetails
            // 
            this.gridControlDeliveryOrerDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDeliveryOrerDetails.Location = new System.Drawing.Point(0, 0);
            this.gridControlDeliveryOrerDetails.MainView = this.gridViewDeliveryOrderDetails;
            this.gridControlDeliveryOrerDetails.Name = "gridControlDeliveryOrerDetails";
            this.gridControlDeliveryOrerDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcProducts,
            this.repositoryItemSpinEdit1});
            this.gridControlDeliveryOrerDetails.Size = new System.Drawing.Size(643, 300);
            this.gridControlDeliveryOrerDetails.TabIndex = 0;
            this.gridControlDeliveryOrerDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryOrderDetails});
            this.gridControlDeliveryOrerDetails.DoubleClick += new System.EventHandler(this.gridControlDeliveryOrerDetails_DoubleClick);
            // 
            // gridViewDeliveryOrderDetails
            // 
            this.gridViewDeliveryOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductChName,
            this.gcDeliveryCount,
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
            this.gridViewDeliveryOrderDetails.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDeliveryOrderDetails.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDeliveryOrderDetails.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridViewDeliveryOrderDetails_ShowGridMenu);
            this.gridViewDeliveryOrderDetails.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewDeliveryOrderDetails_InitNewRow);
            this.gridViewDeliveryOrderDetails.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewDeliveryOrderDetails_RowUpdated);
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
            // gcInputInvoice
            // 
            this.gcInputInvoice.Caption = "入库发票号";
            this.gcInputInvoice.FieldName = "InputInvoice";
            this.gcInputInvoice.Name = "gcInputInvoice";
            this.gcInputInvoice.Visible = true;
            this.gcInputInvoice.VisibleIndex = 2;
            // 
            // gcLotsNumber
            // 
            this.gcLotsNumber.Caption = "生产批号";
            this.gcLotsNumber.FieldName = "LotsNumber";
            this.gcLotsNumber.Name = "gcLotsNumber";
            this.gcLotsNumber.Visible = true;
            this.gcLotsNumber.VisibleIndex = 3;
            // 
            // gcProductDate
            // 
            this.gcProductDate.Caption = "生产日期";
            this.gcProductDate.FieldName = "ProductDate";
            this.gcProductDate.Name = "gcProductDate";
            this.gcProductDate.Visible = true;
            this.gcProductDate.VisibleIndex = 4;
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // PreDeliveryOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 476);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "PreDeliveryOrder";
            this.Text = "预出库";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtReachedDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReachedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlDeliveryAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlCompanies.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryOrerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblDeliveryOrderNumber;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit ddlDeliveryAddress;
        private DevExpress.XtraEditors.LookUpEdit ddlCompanies;
        private DevExpress.XtraEditors.LabelControl lblPreDeliveryDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit txtReachedDate;
        private DevExpress.XtraEditors.TextEdit txtInvoice;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnSaveAll;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraGrid.GridControl gridControlDeliveryOrerDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryOrderDetails;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SimpleButton btnImport;
        private DevExpress.XtraEditors.SimpleButton btnAddDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductChName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeliveryCount;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotsNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcProducts;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.SimpleButton btnSaveAndClose;
        private DevExpress.XtraEditors.SimpleButton btnPreCompletedAndAssign;
        private DevExpress.XtraEditors.SimpleButton btn;

    }
}