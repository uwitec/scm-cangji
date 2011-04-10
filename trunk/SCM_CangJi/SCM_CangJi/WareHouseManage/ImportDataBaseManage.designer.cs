namespace SCM_CangJi.WareHouseManage
{
    partial class ImportDataBaseManage
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
            this.ComBoxImportType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonFile = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.comBoxSrcTable = new DevExpress.XtraEditors.ComboBoxEdit();
            this.butSave = new DevExpress.XtraEditors.SimpleButton();
            this.butImport = new DevExpress.XtraEditors.SimpleButton();
            this.butColse = new DevExpress.XtraEditors.SimpleButton();
            this.labelStorage = new DevExpress.XtraEditors.LabelControl();
            this.lookUpStorage = new DevExpress.XtraEditors.LookUpEdit();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape4 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.gridData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpDesTable = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ComBoxImportType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxSrcTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStorage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDesTable.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ComBoxImportType
            // 
            this.ComBoxImportType.Location = new System.Drawing.Point(70, 12);
            this.ComBoxImportType.Name = "ComBoxImportType";
            this.ComBoxImportType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComBoxImportType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.ComBoxImportType.Size = new System.Drawing.Size(158, 21);
            this.ComBoxImportType.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "数据源:";
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(234, 12);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonFile.Size = new System.Drawing.Size(371, 21);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.OnButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "源数据表:";
            // 
            // comBoxSrcTable
            // 
            this.comBoxSrcTable.Location = new System.Drawing.Point(70, 46);
            this.comBoxSrcTable.Name = "comBoxSrcTable";
            this.comBoxSrcTable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxSrcTable.Properties.NullText = "--没有数据表--";
            this.comBoxSrcTable.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comBoxSrcTable.Size = new System.Drawing.Size(211, 21);
            this.comBoxSrcTable.TabIndex = 3;
            this.comBoxSrcTable.SelectedValueChanged += new System.EventHandler(this.OnSelectedValueChanged);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(449, 98);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(132, 23);
            this.butSave.TabIndex = 6;
            this.butSave.Text = "保存为默认值";
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butImport
            // 
            this.butImport.Location = new System.Drawing.Point(416, 365);
            this.butImport.Name = "butImport";
            this.butImport.Size = new System.Drawing.Size(75, 23);
            this.butImport.TabIndex = 7;
            this.butImport.Text = "导入";
            this.butImport.Click += new System.EventHandler(this.butImport_Click);
            // 
            // butColse
            // 
            this.butColse.Location = new System.Drawing.Point(506, 365);
            this.butColse.Name = "butColse";
            this.butColse.Size = new System.Drawing.Size(75, 23);
            this.butColse.TabIndex = 8;
            this.butColse.Text = "退出";
            this.butColse.Click += new System.EventHandler(this.butColse_Click);
            // 
            // labelStorage
            // 
            this.labelStorage.Location = new System.Drawing.Point(12, 103);
            this.labelStorage.Name = "labelStorage";
            this.labelStorage.Size = new System.Drawing.Size(52, 14);
            this.labelStorage.TabIndex = 9;
            this.labelStorage.Text = "选择仓库:";
            // 
            // lookUpStorage
            // 
            this.lookUpStorage.EditValue = "";
            this.lookUpStorage.Location = new System.Drawing.Point(70, 100);
            this.lookUpStorage.Name = "lookUpStorage";
            this.lookUpStorage.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpStorage.Properties.NullText = "--没有数据--";
            this.lookUpStorage.Size = new System.Drawing.Size(211, 21);
            this.lookUpStorage.TabIndex = 5;
            this.lookUpStorage.EditValueChanged += new System.EventHandler(this.OnEditValueChanged);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape4,
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(617, 402);
            this.shapeContainer1.TabIndex = 11;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape4
            // 
            this.rectangleShape4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this.rectangleShape4.Enabled = false;
            this.rectangleShape4.Location = new System.Drawing.Point(5, 5);
            this.rectangleShape4.Name = "rectangleShape4";
            this.rectangleShape4.Size = new System.Drawing.Size(707, 81);
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.rectangleShape3.Enabled = false;
            this.rectangleShape3.Location = new System.Drawing.Point(6, 6);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(705, 79);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.rectangleShape2.Enabled = false;
            this.rectangleShape2.Location = new System.Drawing.Point(6, 92);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(705, 370);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this.rectangleShape1.Enabled = false;
            this.rectangleShape1.Location = new System.Drawing.Point(5, 91);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(707, 372);
            // 
            // gridData
            // 
            this.gridData.Location = new System.Drawing.Point(12, 127);
            this.gridData.MainView = this.gridView1;
            this.gridData.Name = "gridData";
            this.gridData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridData.Size = new System.Drawing.Size(593, 232);
            this.gridData.TabIndex = 12;
            this.gridData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(320, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 14);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "目标数据表:";
            // 
            // lookUpDesTable
            // 
            this.lookUpDesTable.EditValue = "";
            this.lookUpDesTable.Location = new System.Drawing.Point(390, 46);
            this.lookUpDesTable.Name = "lookUpDesTable";
            this.lookUpDesTable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDesTable.Properties.NullText = "--请选择--";
            this.lookUpDesTable.Size = new System.Drawing.Size(215, 21);
            this.lookUpDesTable.TabIndex = 4;
            this.lookUpDesTable.EditValueChanged += new System.EventHandler(this.OnEditValue);
            // 
            // ImportDataBaseManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 402);
            this.Controls.Add(this.lookUpDesTable);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.gridData);
            this.Controls.Add(this.lookUpStorage);
            this.Controls.Add(this.labelStorage);
            this.Controls.Add(this.butColse);
            this.Controls.Add(this.butImport);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.comBoxSrcTable);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ComBoxImportType);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportDataBaseManage";
            this.Text = "数据导入管理";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.ComBoxImportType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxSrcTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpStorage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDesTable.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit ComBoxImportType;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonFile;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxSrcTable;
        private DevExpress.XtraEditors.SimpleButton butSave;
        private DevExpress.XtraEditors.SimpleButton butImport;
        private DevExpress.XtraEditors.SimpleButton butColse;
        private DevExpress.XtraEditors.LabelControl labelStorage;
        private DevExpress.XtraEditors.LookUpEdit lookUpStorage;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private DevExpress.XtraGrid.GridControl gridData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape4;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private DevExpress.XtraEditors.LookUpEdit lookUpDesTable;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;

    }
}