/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 6/13/2011 8:31:58 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.Account
 * 文件名： PermisstionManage
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
namespace SCM_CangJi.Account
{
    partial class PermisstionManage
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkMenus = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.ddlRoles = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMenus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRoles.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(79, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "请选择角色：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(76, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkMenus
            // 
            this.chkMenus.Location = new System.Drawing.Point(184, 63);
            this.chkMenus.Name = "chkMenus";
            this.chkMenus.Size = new System.Drawing.Size(293, 445);
            this.chkMenus.TabIndex = 3;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(76, 61);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "全选/全不选";
            this.chkAll.Size = new System.Drawing.Size(102, 19);
            this.chkAll.TabIndex = 4;
            this.chkAll.EditValueChanged += new System.EventHandler(this.chkAll_EditValueChanged);
            // 
            // ddlRoles
            // 
            this.ddlRoles.Location = new System.Drawing.Point(184, 27);
            this.ddlRoles.Name = "ddlRoles";
            this.ddlRoles.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlRoles.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("RoleName", "角色")});
            this.ddlRoles.Properties.DisplayMember = "RoleName";
            this.ddlRoles.Properties.NullText = "请选择...";
            this.ddlRoles.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.ddlRoles.Properties.ValueMember = "RoleId";
            this.ddlRoles.Size = new System.Drawing.Size(293, 21);
            this.ddlRoles.TabIndex = 1;
            this.ddlRoles.EditValueChanged += new System.EventHandler(this.ddlRoles_EditValueChanged);
            // 
            // PermisstionManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 544);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.chkMenus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ddlRoles);
            this.Name = "PermisstionManage";
            this.Text = "权限设置";
            this.Load += new System.EventHandler(this.PermisstionManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkMenus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRoles.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.CheckedListBoxControl chkMenus;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraEditors.LookUpEdit ddlRoles;

    }
}