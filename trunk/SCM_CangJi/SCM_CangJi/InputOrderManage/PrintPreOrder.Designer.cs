namespace SCM_CangJi.InputOrderManage
{
    partial class PrintPreOrder
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtFromWhere = new DevExpress.XtraEditors.TextEdit();
            this.txtInvoice = new DevExpress.XtraEditors.TextEdit();
            this.txtEnterUser = new DevExpress.XtraEditors.TextEdit();
            this.txtCompany = new DevExpress.XtraEditors.TextEdit();
            this.gridControlInputOrerDetails = new DevExpress.XtraGrid.GridControl();
            this.gridViewInputOrderDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcProductChName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSpec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLotsNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProducts = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.txtPreInputDate = new DevExpress.XtraEditors.TextEdit();
            this.txtInputOrderNumber = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromWhere.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnterUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrerDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreInputDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputOrderNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInputCount
            // 
            this.gcInputCount.AppearanceCell.Options.UseTextOptions = true;
            this.gcInputCount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInputCount.AppearanceHeader.Options.UseTextOptions = true;
            this.gcInputCount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcInputCount.Caption = "入库数量";
            this.gcInputCount.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gcInputCount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcInputCount.FieldName = "InputCount";
            this.gcInputCount.Name = "gcInputCount";
            this.gcInputCount.Visible = true;
            this.gcInputCount.VisibleIndex = 5;
            this.gcInputCount.Width = 89;
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
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtFromWhere);
            this.layoutControl1.Controls.Add(this.txtInvoice);
            this.layoutControl1.Controls.Add(this.txtEnterUser);
            this.layoutControl1.Controls.Add(this.txtCompany);
            this.layoutControl1.Controls.Add(this.gridControlInputOrerDetails);
            this.layoutControl1.Controls.Add(this.txtPreInputDate);
            this.layoutControl1.Controls.Add(this.txtInputOrderNumber);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(854, 730);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtFromWhere
            // 
            this.txtFromWhere.Location = new System.Drawing.Point(505, 62);
            this.txtFromWhere.Name = "txtFromWhere";
            this.txtFromWhere.Size = new System.Drawing.Size(337, 21);
            this.txtFromWhere.StyleController = this.layoutControl1;
            this.txtFromWhere.TabIndex = 9;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(88, 62);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(337, 21);
            this.txtInvoice.StyleController = this.layoutControl1;
            this.txtInvoice.TabIndex = 8;
            // 
            // txtEnterUser
            // 
            this.txtEnterUser.Location = new System.Drawing.Point(505, 37);
            this.txtEnterUser.Name = "txtEnterUser";
            this.txtEnterUser.Size = new System.Drawing.Size(337, 21);
            this.txtEnterUser.StyleController = this.layoutControl1;
            this.txtEnterUser.TabIndex = 7;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(88, 37);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(337, 21);
            this.txtCompany.StyleController = this.layoutControl1;
            this.txtCompany.TabIndex = 6;
            // 
            // gridControlInputOrerDetails
            // 
            this.gridControlInputOrerDetails.Location = new System.Drawing.Point(12, 104);
            this.gridControlInputOrerDetails.MainView = this.gridViewInputOrderDetails;
            this.gridControlInputOrerDetails.Name = "gridControlInputOrerDetails";
            this.gridControlInputOrerDetails.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcProducts,
            this.repositoryItemSpinEdit1});
            this.gridControlInputOrerDetails.Size = new System.Drawing.Size(830, 614);
            this.gridControlInputOrerDetails.TabIndex = 1;
            this.gridControlInputOrerDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInputOrderDetails});
            // 
            // gridViewInputOrderDetails
            // 
            this.gridViewInputOrderDetails.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcProductChName,
            this.gridColumn2,
            this.gcProductNumber1,
            this.gcProductNumber2,
            this.gcSpec,
            this.gcInputCount,
            this.gridColumn1,
            this.gcLotsNumber,
            this.gcProductDate});
            styleFormatCondition1.Column = this.gcInputCount;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition1.Value1 = "1";
            styleFormatCondition1.Value2 = "99999999";
            this.gridViewInputOrderDetails.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gridViewInputOrderDetails.GridControl = this.gridControlInputOrerDetails;
            this.gridViewInputOrderDetails.Name = "gridViewInputOrderDetails";
            this.gridViewInputOrderDetails.NewItemRowText = "点击添加新行";
            this.gridViewInputOrderDetails.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewInputOrderDetails.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewInputOrderDetails.OptionsCustomization.AllowRowSizing = true;
            this.gridViewInputOrderDetails.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewInputOrderDetails.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewInputOrderDetails.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewInputOrderDetails.OptionsView.RowAutoHeight = true;
            this.gridViewInputOrderDetails.OptionsView.ShowGroupPanel = false;
            this.gridViewInputOrderDetails.PaintStyleName = "Web";
            this.gridViewInputOrderDetails.CalcRowHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridViewInputOrderDetails_CalcRowHeight);
            // 
            // gcProductChName
            // 
            this.gcProductChName.Caption = "商品";
            this.gcProductChName.FieldName = "ProductChName";
            this.gcProductChName.Name = "gcProductChName";
            this.gcProductChName.Visible = true;
            this.gcProductChName.VisibleIndex = 0;
            this.gcProductChName.Width = 176;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "品牌";
            this.gridColumn2.FieldName = "Brand";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 104;
            // 
            // gcProductNumber1
            // 
            this.gcProductNumber1.Caption = "品号1";
            this.gcProductNumber1.FieldName = "ProductNumber1";
            this.gcProductNumber1.Name = "gcProductNumber1";
            this.gcProductNumber1.OptionsColumn.AllowEdit = false;
            this.gcProductNumber1.Visible = true;
            this.gcProductNumber1.VisibleIndex = 2;
            this.gcProductNumber1.Width = 107;
            // 
            // gcProductNumber2
            // 
            this.gcProductNumber2.Caption = "品号2";
            this.gcProductNumber2.FieldName = "ProductNumber2";
            this.gcProductNumber2.Name = "gcProductNumber2";
            this.gcProductNumber2.Visible = true;
            this.gcProductNumber2.VisibleIndex = 3;
            this.gcProductNumber2.Width = 90;
            // 
            // gcSpec
            // 
            this.gcSpec.Caption = "规格";
            this.gcSpec.FieldName = "Spec";
            this.gcSpec.Name = "gcSpec";
            this.gcSpec.Visible = true;
            this.gcSpec.VisibleIndex = 4;
            this.gcSpec.Width = 52;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "库位";
            this.gridColumn1.FieldName = "AreaNumber";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 91;
            // 
            // gcLotsNumber
            // 
            this.gcLotsNumber.Caption = "生产批号";
            this.gcLotsNumber.FieldName = "LotsNumber";
            this.gcLotsNumber.Name = "gcLotsNumber";
            this.gcLotsNumber.Visible = true;
            this.gcLotsNumber.VisibleIndex = 7;
            this.gcLotsNumber.Width = 106;
            // 
            // gcProductDate
            // 
            this.gcProductDate.Caption = "生产日期";
            this.gcProductDate.FieldName = "ProductDate";
            this.gcProductDate.Name = "gcProductDate";
            this.gcProductDate.Width = 88;
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
            // txtPreInputDate
            // 
            this.txtPreInputDate.Location = new System.Drawing.Point(505, 12);
            this.txtPreInputDate.Name = "txtPreInputDate";
            this.txtPreInputDate.Size = new System.Drawing.Size(337, 21);
            this.txtPreInputDate.StyleController = this.layoutControl1;
            this.txtPreInputDate.TabIndex = 5;
            // 
            // txtInputOrderNumber
            // 
            this.txtInputOrderNumber.Location = new System.Drawing.Point(88, 12);
            this.txtInputOrderNumber.Name = "txtInputOrderNumber";
            this.txtInputOrderNumber.Size = new System.Drawing.Size(337, 21);
            this.txtInputOrderNumber.StyleController = this.layoutControl1;
            this.txtInputOrderNumber.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(854, 730);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtInputOrderNumber;
            this.layoutControlItem1.CustomizationFormText = "入库单编号：";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(417, 25);
            this.layoutControlItem1.Text = "入库单编号：";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPreInputDate;
            this.layoutControlItem2.CustomizationFormText = "制单日期:";
            this.layoutControlItem2.Location = new System.Drawing.Point(417, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(417, 25);
            this.layoutControlItem2.Text = "制单日期:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtCompany;
            this.layoutControlItem3.CustomizationFormText = "发票号码：";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(417, 25);
            this.layoutControlItem3.Text = "所属公司：";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEnterUser;
            this.layoutControlItem4.CustomizationFormText = "入库人：";
            this.layoutControlItem4.Location = new System.Drawing.Point(417, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(417, 25);
            this.layoutControlItem4.Text = "入库人：";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtInvoice;
            this.layoutControlItem5.CustomizationFormText = "发票号码：";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(417, 25);
            this.layoutControlItem5.Text = "发票号码：";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtFromWhere;
            this.layoutControlItem6.CustomizationFormText = "发货地：";
            this.layoutControlItem6.Location = new System.Drawing.Point(417, 50);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(417, 25);
            this.layoutControlItem6.Text = "发货地：";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(72, 14);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.gridControlInputOrerDetails;
            this.layoutControlItem7.CustomizationFormText = "入库明细：";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 75);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(834, 635);
            this.layoutControlItem7.Text = "入库明细：";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(72, 14);
            // 
            // PrintPreOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 730);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PrintPreOrder";
            this.Text = "入库单";
            this.Load += new System.EventHandler(this.PrintPreOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFromWhere.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInvoice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEnterUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCompany.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputOrerDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreInputDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputOrderNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtFromWhere;
        private DevExpress.XtraEditors.TextEdit txtInvoice;
        private DevExpress.XtraEditors.TextEdit txtEnterUser;
        private DevExpress.XtraEditors.TextEdit txtCompany;
        private DevExpress.XtraEditors.TextEdit txtPreInputDate;
        private DevExpress.XtraEditors.TextEdit txtInputOrderNumber;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraGrid.GridControl gridControlInputOrerDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInputOrderDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductChName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcProducts;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn gcSpec;
        private DevExpress.XtraGrid.Columns.GridColumn gcInputCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gcLotsNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}