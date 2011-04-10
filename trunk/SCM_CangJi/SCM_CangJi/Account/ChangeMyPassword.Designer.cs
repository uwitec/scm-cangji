namespace SCM_CangJi.Account
{
    partial class ChangeMyPassword
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
            DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule compareAgainstControlValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.txtNewPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.txtNewPassword1 = new DevExpress.XtraEditors.TextEdit();
            this.txtOldPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPassword2
            // 
            this.txtNewPassword2.Location = new System.Drawing.Point(124, 101);
            this.txtNewPassword2.Name = "txtNewPassword2";
            this.txtNewPassword2.Properties.PasswordChar = '*';
            this.txtNewPassword2.Size = new System.Drawing.Size(140, 21);
            this.txtNewPassword2.TabIndex = 16;
            compareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.NotEquals;
            compareAgainstControlValidationRule1.ErrorText = "两次新密码输入不一致";
            this.dxValidationProvider1.SetValidationRule(this.txtNewPassword2, compareAgainstControlValidationRule1);
            // 
            // txtNewPassword1
            // 
            this.txtNewPassword1.Location = new System.Drawing.Point(124, 72);
            this.txtNewPassword1.Name = "txtNewPassword1";
            this.txtNewPassword1.Properties.PasswordChar = '*';
            this.txtNewPassword1.Size = new System.Drawing.Size(140, 21);
            this.txtNewPassword1.TabIndex = 15;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.txtNewPassword1, conditionValidationRule1);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(124, 43);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(140, 21);
            this.txtOldPassword.TabIndex = 14;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "不能为空";
            this.dxValidationProvider1.SetValidationRule(this.txtOldPassword, conditionValidationRule2);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(35, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 14);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "重复新密码：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(59, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "新密码：";
            // 
            // dxValidationProvider1
            // 
            this.dxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "旧密码：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(189, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "确认修改";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ChangeMyPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 184);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNewPassword2);
            this.Controls.Add(this.txtNewPassword1);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Name = "ChangeMyPassword";
            this.Text = "密码修改";
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNewPassword2;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.TextEdit txtNewPassword1;
        private DevExpress.XtraEditors.TextEdit txtOldPassword;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}