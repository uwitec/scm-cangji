/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/18/2011 8:22:02 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageChangeConfirm
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
namespace SCM_CangJi.StorageManage
{
    partial class StorageChangeConfirm
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
            this.gridControlProductStorages = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductStorages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlProductStorages
            // 
            this.gridControlProductStorages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductStorages.Location = new System.Drawing.Point(0, 82);
            this.gridControlProductStorages.MainView = this.gridViewProductStorages;
            this.gridControlProductStorages.Name = "gridControlProductStorages";
            this.gridControlProductStorages.Size = new System.Drawing.Size(861, 365);
            this.gridControlProductStorages.TabIndex = 7;
            this.gridControlProductStorages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductStorages});
            // 
            // gridViewProductStorages
            // 
            this.gridViewProductStorages.GridControl = this.gridControlProductStorages;
            this.gridViewProductStorages.Name = "gridViewProductStorages";
            this.gridViewProductStorages.OptionsSelection.MultiSelect = true;
            this.gridViewProductStorages.OptionsView.EnableAppearanceEvenRow = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnConfirm);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(861, 82);
            this.panelControl1.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(20, 27);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确认变更";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
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
            // StorageChangeConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 447);
            this.Controls.Add(this.gridControlProductStorages);
            this.Controls.Add(this.panelControl1);
            this.Name = "StorageChangeConfirm";
            this.Text = "变更确认";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProductStorages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductStorages;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;

    }
}