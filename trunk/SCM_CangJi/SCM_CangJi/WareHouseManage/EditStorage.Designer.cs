namespace SCM_CangJi.WareHouseManage
{
    partial class EditStorage
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
            if (Conn != null)
            {
                Conn.Close();
            }

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textStorageID = new DevExpress.XtraEditors.TextEdit();
            this.textStorageName = new DevExpress.XtraEditors.TextEdit();
            this.textStorageAddress = new DevExpress.XtraEditors.TextEdit();
            this.richStorageRemark = new System.Windows.Forms.RichTextBox();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.butSave = new System.Windows.Forms.Button();
            this.butClose = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "仓库编号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "仓库名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "仓库地址:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "备注:";
            // 
            // textStorageID
            // 
            this.textStorageID.Location = new System.Drawing.Point(73, 30);
            this.textStorageID.Name = "textStorageID";
            this.textStorageID.Size = new System.Drawing.Size(169, 21);
            this.textStorageID.TabIndex = 4;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.textStorageID, conditionValidationRule1);
            // 
            // textStorageName
            // 
            this.textStorageName.Location = new System.Drawing.Point(350, 30);
            this.textStorageName.Name = "textStorageName";
            this.textStorageName.Size = new System.Drawing.Size(245, 21);
            this.textStorageName.TabIndex = 5;
            this.dxValidationProvider1.SetValidationRule(this.textStorageName, conditionValidationRule1);
            // 
            // textStorageAddress
            // 
            this.textStorageAddress.Location = new System.Drawing.Point(73, 63);
            this.textStorageAddress.Name = "textStorageAddress";
            this.textStorageAddress.Size = new System.Drawing.Size(522, 21);
            this.textStorageAddress.TabIndex = 6;
            this.dxValidationProvider1.SetValidationRule(this.textStorageAddress, conditionValidationRule1);
            this.textStorageAddress.TextChanged += new System.EventHandler(this.StorageAddressTextChanged);
            // 
            // richStorageRemark
            // 
            this.richStorageRemark.Location = new System.Drawing.Point(73, 95);
            this.richStorageRemark.Name = "richStorageRemark";
            this.richStorageRemark.Size = new System.Drawing.Size(522, 103);
            this.richStorageRemark.TabIndex = 7;
            this.richStorageRemark.Text = "";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(139, 217);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 23);
            this.butSave.TabIndex = 8;
            this.butSave.Text = "保存";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(389, 217);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 9;
            this.butClose.Text = "关闭";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(265, 217);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 10;
            this.butDelete.Text = "删除";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // EditStorage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 273);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.richStorageRemark);
            this.Controls.Add(this.textStorageAddress);
            this.Controls.Add(this.textStorageName);
            this.Controls.Add(this.textStorageID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "EditStorage";
            this.Text = "仓库管理";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private DevExpress.XtraEditors.TextEdit textStorageID;
        private DevExpress.XtraEditors.TextEdit textStorageName;
        private DevExpress.XtraEditors.TextEdit textStorageAddress;
        private System.Windows.Forms.RichTextBox richStorageRemark;

        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butDelete;

        
    }
}