/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/18/2011 8:09:30 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageChange
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
namespace SCM_CangJi.StorageManage
{
    partial class StorageChange
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlProductStorages = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductStorages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCompanyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductChName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProductNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBarCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrentProductNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInvoice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrentCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUsableCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStorageArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStorageArea = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcProductDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStorageArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(859, 82);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(20, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(101, 27);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridControlProductStorages
            // 
            this.gridControlProductStorages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductStorages.Location = new System.Drawing.Point(0, 82);
            this.gridControlProductStorages.MainView = this.gridViewProductStorages;
            this.gridControlProductStorages.Name = "gridControlProductStorages";
            this.gridControlProductStorages.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gridStorageArea,
            this.repositoryItemDateEdit1});
            this.gridControlProductStorages.Size = new System.Drawing.Size(859, 412);
            this.gridControlProductStorages.TabIndex = 3;
            this.gridControlProductStorages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductStorages});
            // 
            // gridViewProductStorages
            // 
            this.gridViewProductStorages.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCompanyName,
            this.gcProductChName,
            this.gcProductNumber1,
            this.gcBarCode,
            this.gcCurrentProductNumber,
            this.gcInvoice,
            this.gcCurrentCount,
            this.gcUsableCount,
            this.gcStorageArea,
            this.gcProductDate});
            this.gridViewProductStorages.GridControl = this.gridControlProductStorages;
            this.gridViewProductStorages.Name = "gridViewProductStorages";
            this.gridViewProductStorages.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewProductStorages.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewProductStorages_CellValueChanged);
            // 
            // gcCompanyName
            // 
            this.gcCompanyName.Caption = "公司名";
            this.gcCompanyName.FieldName = "CompanyName";
            this.gcCompanyName.Name = "gcCompanyName";
            this.gcCompanyName.OptionsColumn.AllowEdit = false;
            this.gcCompanyName.Visible = true;
            this.gcCompanyName.VisibleIndex = 0;
            // 
            // gcProductChName
            // 
            this.gcProductChName.Caption = "品名";
            this.gcProductChName.FieldName = "ProductChName";
            this.gcProductChName.Name = "gcProductChName";
            this.gcProductChName.OptionsColumn.AllowEdit = false;
            this.gcProductChName.Visible = true;
            this.gcProductChName.VisibleIndex = 1;
            // 
            // gcProductNumber1
            // 
            this.gcProductNumber1.Caption = "品号";
            this.gcProductNumber1.FieldName = "ProductNumber1";
            this.gcProductNumber1.Name = "gcProductNumber1";
            this.gcProductNumber1.OptionsColumn.AllowEdit = false;
            this.gcProductNumber1.Visible = true;
            this.gcProductNumber1.VisibleIndex = 3;
            // 
            // gcBarCode
            // 
            this.gcBarCode.Caption = "条形码";
            this.gcBarCode.FieldName = "BarCode";
            this.gcBarCode.Name = "gcBarCode";
            this.gcBarCode.OptionsColumn.AllowEdit = false;
            this.gcBarCode.Visible = true;
            this.gcBarCode.VisibleIndex = 2;
            // 
            // gcCurrentProductNumber
            // 
            this.gcCurrentProductNumber.Caption = "现品票号";
            this.gcCurrentProductNumber.FieldName = "CurrentProductNumber";
            this.gcCurrentProductNumber.Name = "gcCurrentProductNumber";
            this.gcCurrentProductNumber.OptionsColumn.AllowEdit = false;
            this.gcCurrentProductNumber.Visible = true;
            this.gcCurrentProductNumber.VisibleIndex = 4;
            // 
            // gcInvoice
            // 
            this.gcInvoice.Caption = "入库发票";
            this.gcInvoice.FieldName = "Invoice";
            this.gcInvoice.Name = "gcInvoice";
            this.gcInvoice.OptionsColumn.AllowEdit = false;
            this.gcInvoice.Visible = true;
            this.gcInvoice.VisibleIndex = 5;
            // 
            // gcCurrentCount
            // 
            this.gcCurrentCount.Caption = "当前库存";
            this.gcCurrentCount.FieldName = "CurrentCount";
            this.gcCurrentCount.Name = "gcCurrentCount";
            this.gcCurrentCount.Visible = true;
            this.gcCurrentCount.VisibleIndex = 6;
            // 
            // gcUsableCount
            // 
            this.gcUsableCount.Caption = "可用库存";
            this.gcUsableCount.FieldName = "UsableCount";
            this.gcUsableCount.Name = "gcUsableCount";
            this.gcUsableCount.Visible = true;
            this.gcUsableCount.VisibleIndex = 7;
            // 
            // gcStorageArea
            // 
            this.gcStorageArea.Caption = "库位";
            this.gcStorageArea.ColumnEdit = this.gridStorageArea;
            this.gcStorageArea.FieldName = "AreaId";
            this.gcStorageArea.Name = "gcStorageArea";
            this.gcStorageArea.Visible = true;
            this.gcStorageArea.VisibleIndex = 9;
            // 
            // gridStorageArea
            // 
            this.gridStorageArea.AutoHeight = false;
            this.gridStorageArea.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridStorageArea.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("库位编号", "库位编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库编号", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库名称", "仓库名称")});
            this.gridStorageArea.DisplayMember = "库位编号";
            this.gridStorageArea.Name = "gridStorageArea";
            this.gridStorageArea.ValueMember = "Id";
            // 
            // gcProductDate
            // 
            this.gcProductDate.Caption = "到期日期";
            this.gcProductDate.ColumnEdit = this.repositoryItemDateEdit1;
            this.gcProductDate.FieldName = "ProductDate";
            this.gcProductDate.Name = "gcProductDate";
            this.gcProductDate.Visible = true;
            this.gcProductDate.VisibleIndex = 8;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // StorageChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 494);
            this.Controls.Add(this.gridControlProductStorages);
            this.Controls.Add(this.panelControl1);
            this.Name = "StorageChange";
            this.Text = "库存变更";
            this.Load += new System.EventHandler(this.StorageChange_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridStorageArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlProductStorages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductStorages;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCompanyName;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductChName;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn gcBarCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrentProductNumber;
        private DevExpress.XtraGrid.Columns.GridColumn gcInvoice;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrentCount;
        private DevExpress.XtraGrid.Columns.GridColumn gcUsableCount;
        private DevExpress.XtraGrid.Columns.GridColumn gcStorageArea;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gridStorageArea;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraGrid.Columns.GridColumn gcProductDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}