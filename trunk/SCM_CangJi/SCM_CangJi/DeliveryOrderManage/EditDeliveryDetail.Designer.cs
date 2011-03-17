namespace SCM_CangJi.DeliveryOrderManage
{
    partial class EditDeliveryDetail
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
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtDeliveryCount = new DevExpress.XtraEditors.SpinEdit();
            this.ddlProducts = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotsNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtInputInvoice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProducts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotsNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputInvoice.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // txtDeliveryCount
            // 
            this.txtDeliveryCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDeliveryCount.Location = new System.Drawing.Point(373, 42);
            this.txtDeliveryCount.Name = "txtDeliveryCount";
            this.txtDeliveryCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtDeliveryCount.Properties.Mask.EditMask = "n0";
            this.txtDeliveryCount.Size = new System.Drawing.Size(168, 21);
            this.txtDeliveryCount.TabIndex = 3;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Between;
            conditionValidationRule1.ErrorText = "出库数量必须大于0";
            conditionValidationRule1.Value1 = 1;
            conditionValidationRule1.Value2 = 99999999;
            this.dxValidationProvider1.SetValidationRule(this.txtDeliveryCount, conditionValidationRule1);
            // 
            // ddlProducts
            // 
            this.ddlProducts.Location = new System.Drawing.Point(100, 41);
            this.ddlProducts.Name = "ddlProducts";
            this.ddlProducts.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlProducts.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductChName", "品名"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumber1", "品号1"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductNumber2", "品号2")});
            this.ddlProducts.Properties.DisplayMember = "ProductChName";
            this.ddlProducts.Properties.NullText = "请选择...";
            this.ddlProducts.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ddlProducts.Properties.ValueMember = "Id";
            this.ddlProducts.Size = new System.Drawing.Size(170, 21);
            this.ddlProducts.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.ddlProducts, conditionValidationRule2);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(195, 178);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "增加";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProductDate
            // 
            this.txtProductDate.EditValue = null;
            this.txtProductDate.Location = new System.Drawing.Point(100, 129);
            this.txtProductDate.Name = "txtProductDate";
            this.txtProductDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtProductDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtProductDate.Size = new System.Drawing.Size(170, 21);
            this.txtProductDate.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(32, 136);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "生产日期：";
            // 
            // txtLotsNumber
            // 
            this.txtLotsNumber.Location = new System.Drawing.Point(373, 89);
            this.txtLotsNumber.Name = "txtLotsNumber";
            this.txtLotsNumber.Size = new System.Drawing.Size(168, 21);
            this.txtLotsNumber.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(305, 91);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "生产批号：";
            // 
            // txtInputInvoice
            // 
            this.txtInputInvoice.Location = new System.Drawing.Point(100, 89);
            this.txtInputInvoice.Name = "txtInputInvoice";
            this.txtInputInvoice.Size = new System.Drawing.Size(170, 21);
            this.txtInputInvoice.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(32, 91);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "入库发票：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(305, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "出库数量：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "出库商品：";
            // 
            // EditDeliveryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 252);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtProductDate);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtLotsNumber);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtInputInvoice);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDeliveryCount);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ddlProducts);
            this.Controls.Add(this.labelControl1);
            this.Name = "EditDeliveryDetail";
            this.Text = "EditDeliveryDetail";
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDeliveryCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProducts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotsNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputInvoice.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit ddlProducts;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit txtDeliveryCount;
        private DevExpress.XtraEditors.TextEdit txtInputInvoice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtLotsNumber;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DateEdit txtProductDate;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}