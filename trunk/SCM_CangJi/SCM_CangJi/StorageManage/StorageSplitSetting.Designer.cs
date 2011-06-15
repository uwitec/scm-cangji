/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 6/15/2011 9:30:17 PM
 * CLR版本： 4.0.30319.235
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageSplitSetting
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
namespace SCM_CangJi.StorageManage
{
    partial class StorageSplitSetting
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSplitCount = new DevExpress.XtraEditors.SpinEdit();
            this.ddlStorageArea = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.txtMessage = new DevExpress.XtraEditors.TextEdit();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtSplitCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStorageArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(66, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "移动";
            // 
            // txtSplitCount
            // 
            this.txtSplitCount.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtSplitCount.Location = new System.Drawing.Point(107, 52);
            this.txtSplitCount.Name = "txtSplitCount";
            this.txtSplitCount.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtSplitCount.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            this.txtSplitCount.Properties.Mask.EditMask = "\\d{1,5}";
            this.txtSplitCount.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSplitCount.Size = new System.Drawing.Size(119, 21);
            this.txtSplitCount.TabIndex = 1;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "必须大于0";
            conditionValidationRule1.Value1 = "1";
            this.dxValidationProvider1.SetValidationRule(this.txtSplitCount, conditionValidationRule1);
            // 
            // ddlStorageArea
            // 
            this.ddlStorageArea.Location = new System.Drawing.Point(291, 52);
            this.ddlStorageArea.Name = "ddlStorageArea";
            this.ddlStorageArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlStorageArea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("库位编号", "库位编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库编号", "仓库编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库名称", "仓库名称")});
            this.ddlStorageArea.Properties.DisplayMember = "库位编号";
            this.ddlStorageArea.Properties.NullText = "请选择...";
            this.ddlStorageArea.Properties.ValueMember = "Id";
            this.ddlStorageArea.Size = new System.Drawing.Size(165, 21);
            this.ddlStorageArea.TabIndex = 2;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "请选择";
            this.dxValidationProvider1.SetValidationRule(this.ddlStorageArea, conditionValidationRule2);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(248, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "件到";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(381, 92);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 12);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(590, 21);
            this.txtMessage.TabIndex = 5;
            // 
            // StorageSplitSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 166);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.ddlStorageArea);
            this.Controls.Add(this.txtSplitCount);
            this.Controls.Add(this.labelControl1);
            this.Name = "StorageSplitSetting";
            this.Text = "移库设置";
            this.Load += new System.EventHandler(this.StorageSplitSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSplitCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlStorageArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SpinEdit txtSplitCount;
        private DevExpress.XtraEditors.LookUpEdit ddlStorageArea;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.TextEdit txtMessage;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
    }
}