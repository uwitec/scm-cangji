/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/20/2011 10:06:36 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageWorning
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
namespace SCM_CangJi.StorageManage
{
    partial class StorageWorning
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlProductStorages
            // 
            this.gridControlProductStorages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductStorages.Location = new System.Drawing.Point(0, 0);
            this.gridControlProductStorages.MainView = this.gridViewProductStorages;
            this.gridControlProductStorages.Name = "gridControlProductStorages";
            this.gridControlProductStorages.Size = new System.Drawing.Size(737, 418);
            this.gridControlProductStorages.TabIndex = 6;
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
            // StorageWorning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 418);
            this.Controls.Add(this.gridControlProductStorages);
            this.Name = "StorageWorning";
            this.Text = "快过期库存";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlProductStorages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductStorages;
    }
}