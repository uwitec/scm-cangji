namespace SCM_CangJi.DeliveryOrderManage
{
    partial class ImportDetails
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
            this.btnCompleted = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlImportPorfile = new DevExpress.XtraGrid.GridControl();
            this.gridViewImportProfile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTarget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlTarget = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ddlSource = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcSourceIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlImportPorfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewImportProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnCompleted);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(627, 66);
            this.panelControl1.TabIndex = 0;
            // 
            // btnCompleted
            // 
            this.btnCompleted.Location = new System.Drawing.Point(23, 24);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(107, 23);
            this.btnCompleted.TabIndex = 0;
            this.btnCompleted.Text = "匹配完成并导入";
            this.btnCompleted.Click += new System.EventHandler(this.btnCompleted_Click);
            // 
            // gridControlImportPorfile
            // 
            this.gridControlImportPorfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlImportPorfile.Location = new System.Drawing.Point(0, 66);
            this.gridControlImportPorfile.MainView = this.gridViewImportProfile;
            this.gridControlImportPorfile.Name = "gridControlImportPorfile";
            this.gridControlImportPorfile.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ddlTarget,
            this.ddlSource});
            this.gridControlImportPorfile.Size = new System.Drawing.Size(627, 444);
            this.gridControlImportPorfile.TabIndex = 1;
            this.gridControlImportPorfile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewImportProfile});
            // 
            // gridViewImportProfile
            // 
            this.gridViewImportProfile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTarget,
            this.gcSource,
            this.gcSourceIndex});
            this.gridViewImportProfile.GridControl = this.gridControlImportPorfile;
            this.gridViewImportProfile.Name = "gridViewImportProfile";
            this.gridViewImportProfile.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridViewImportProfile.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridViewImportProfile_ShowGridMenu);
            this.gridViewImportProfile.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewImportProfile_InitNewRow);
            this.gridViewImportProfile.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridViewImportProfile_RowUpdated);
            // 
            // gcTarget
            // 
            this.gcTarget.Caption = "目标列";
            this.gcTarget.ColumnEdit = this.ddlTarget;
            this.gcTarget.FieldName = "Target";
            this.gcTarget.Name = "gcTarget";
            this.gcTarget.Visible = true;
            this.gcTarget.VisibleIndex = 0;
            // 
            // ddlTarget
            // 
            this.ddlTarget.AutoHeight = false;
            this.ddlTarget.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlTarget.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "字段名")});
            this.ddlTarget.DisplayMember = "Name";
            this.ddlTarget.Name = "ddlTarget";
            this.ddlTarget.NullText = "请选择...";
            this.ddlTarget.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ddlTarget.ValueMember = "Name";
            // 
            // gcSource
            // 
            this.gcSource.Caption = "源数据列";
            this.gcSource.ColumnEdit = this.ddlSource;
            this.gcSource.FieldName = "Source";
            this.gcSource.Name = "gcSource";
            this.gcSource.Visible = true;
            this.gcSource.VisibleIndex = 1;
            // 
            // ddlSource
            // 
            this.ddlSource.AutoHeight = false;
            this.ddlSource.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlSource.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ColumnName", "源列名")});
            this.ddlSource.DisplayMember = "ColumnName";
            this.ddlSource.Name = "ddlSource";
            this.ddlSource.NullText = "请选择...";
            this.ddlSource.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ddlSource.ValueMember = "ColumnName";
            // 
            // gcSourceIndex
            // 
            this.gcSourceIndex.Caption = "源列序号";
            this.gcSourceIndex.FieldName = "SourceIndex";
            this.gcSourceIndex.Name = "gcSourceIndex";
            this.gcSourceIndex.Visible = true;
            this.gcSourceIndex.VisibleIndex = 2;
            // 
            // ImportDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 510);
            this.Controls.Add(this.gridControlImportPorfile);
            this.Controls.Add(this.panelControl1);
            this.Name = "ImportDetails";
            this.Text = "ImportDetails";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlImportPorfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewImportProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlImportPorfile;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewImportProfile;
        private DevExpress.XtraEditors.SimpleButton btnCompleted;
        private DevExpress.XtraGrid.Columns.GridColumn gcTarget;
        private DevExpress.XtraGrid.Columns.GridColumn gcSource;
        private DevExpress.XtraGrid.Columns.GridColumn gcSourceIndex;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlTarget;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ddlSource;


    }
}