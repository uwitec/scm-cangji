namespace SCM_CangJi.InputOrderManage
{
    partial class EditInputDetail
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule3 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.txtInputCount = new DevExpress.XtraEditors.SpinEdit();
            this.ddlProducts = new DevExpress.XtraEditors.LookUpEdit();
            this.txtLotsNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtRemark = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProducts.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotsNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(322, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "增加";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtProductDate
            // 
            this.txtProductDate.EditValue = null;
            this.txtProductDate.Location = new System.Drawing.Point(117, 96);
            this.txtProductDate.Name = "txtProductDate";
            this.txtProductDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtProductDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtProductDate.Size = new System.Drawing.Size(170, 21);
            this.txtProductDate.TabIndex = 20;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(49, 103);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "生产日期：";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Manual;
            // 
            // txtInputCount
            // 
            this.txtInputCount.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtInputCount.Location = new System.Drawing.Point(390, 49);
            this.txtInputCount.Name = "txtInputCount";
            this.txtInputCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtInputCount.Properties.Mask.EditMask = "n0";
            this.txtInputCount.Size = new System.Drawing.Size(168, 21);
            this.txtInputCount.TabIndex = 15;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Between;
            conditionValidationRule2.ErrorText = "出库数量必须大于0";
            conditionValidationRule2.Value1 = 1;
            conditionValidationRule2.Value2 = 99999999;
            this.dxValidationProvider1.SetValidationRule(this.txtInputCount, conditionValidationRule2);
            // 
            // ddlProducts
            // 
            this.ddlProducts.Location = new System.Drawing.Point(117, 48);
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
            this.ddlProducts.TabIndex = 12;
            conditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule3.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.ddlProducts, conditionValidationRule3);
            // 
            // txtLotsNumber
            // 
            this.txtLotsNumber.Location = new System.Drawing.Point(390, 96);
            this.txtLotsNumber.Name = "txtLotsNumber";
            this.txtLotsNumber.Size = new System.Drawing.Size(168, 21);
            this.txtLotsNumber.TabIndex = 18;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(322, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "生产批号：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(117, 140);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(170, 21);
            this.txtRemark.TabIndex = 16;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(49, 142);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "备注：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(322, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "入库数量：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(51, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "入库商品：";
            // 
            // EditInputDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 263);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtProductDate);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtLotsNumber);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtInputCount);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ddlProducts);
            this.Controls.Add(this.labelControl1);
            this.Name = "EditInputDetail";
            this.Text = "EditInputDetail";
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInputCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlProducts.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotsNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.DateEdit txtProductDate;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.SpinEdit txtInputCount;
        private DevExpress.XtraEditors.LookUpEdit ddlProducts;
        private DevExpress.XtraEditors.TextEdit txtLotsNumber;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtRemark;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}