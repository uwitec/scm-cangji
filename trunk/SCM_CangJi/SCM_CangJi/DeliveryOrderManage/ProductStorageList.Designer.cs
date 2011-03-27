namespace SCM_CangJi.DeliveryOrderManage
{
    partial class ProductStorageList
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControlProductStorages = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductStorages = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(632, 100);
            this.panelControl1.TabIndex = 1;
            // 
            // gridControlProductStorages
            // 
            this.gridControlProductStorages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductStorages.Location = new System.Drawing.Point(0, 100);
            this.gridControlProductStorages.MainView = this.gridViewProductStorages;
            this.gridControlProductStorages.Name = "gridControlProductStorages";
            this.gridControlProductStorages.Size = new System.Drawing.Size(632, 351);
            this.gridControlProductStorages.TabIndex = 2;
            this.gridControlProductStorages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductStorages});
            this.gridControlProductStorages.Click += new System.EventHandler(this.gridControlProductStorages_Click);
            // 
            // gridViewProductStorages
            // 
            this.gridViewProductStorages.GridControl = this.gridControlProductStorages;
            this.gridViewProductStorages.Name = "gridViewProductStorages";
            // 
            // ProductStorageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 451);
            this.Controls.Add(this.gridControlProductStorages);
            this.Controls.Add(this.panelControl1);
            this.Name = "ProductStorageList";
            this.Text = "ProductStorageList";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlProductStorages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductStorages;
    }
}