namespace SCM_CangJi.BaseInfo
{
    partial class ProductTypeList
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtProductTypeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlProductTypes = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductTypes = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductTypeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtProductTypeName);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(528, 67);
            this.panelControl1.TabIndex = 0;
            // 
            // txtProductTypeName
            // 
            this.txtProductTypeName.Location = new System.Drawing.Point(129, 26);
            this.txtProductTypeName.Name = "txtProductTypeName";
            this.txtProductTypeName.Size = new System.Drawing.Size(160, 21);
            this.txtProductTypeName.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "不能够为空";
            this.dxValidationProvider1.SetValidationRule(this.txtProductTypeName, conditionValidationRule1);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(51, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "商品类型名：";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(318, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControlProductTypes
            // 
            this.gridControlProductTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductTypes.Location = new System.Drawing.Point(0, 67);
            this.gridControlProductTypes.MainView = this.gridViewProductTypes;
            this.gridControlProductTypes.Name = "gridControlProductTypes";
            this.gridControlProductTypes.Size = new System.Drawing.Size(528, 238);
            this.gridControlProductTypes.TabIndex = 1;
            this.gridControlProductTypes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductTypes});
            this.gridControlProductTypes.DoubleClick += new System.EventHandler(this.gridControlProductTypes_DoubleClick);
            // 
            // gridViewProductTypes
            // 
            this.gridViewProductTypes.GridControl = this.gridControlProductTypes;
            this.gridViewProductTypes.Name = "gridViewProductTypes";
            this.gridViewProductTypes.OptionsBehavior.Editable = false;
            this.gridViewProductTypes.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridViewProductTypes_ShowGridMenu);
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // ProductTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 305);
            this.Controls.Add(this.gridControlProductTypes);
            this.Controls.Add(this.panelControl1);
            this.Name = "ProductTypeList";
            this.Text = "商品类型维护";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductTypeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlProductTypes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductTypes;
        private DevExpress.XtraEditors.TextEdit txtProductTypeName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}