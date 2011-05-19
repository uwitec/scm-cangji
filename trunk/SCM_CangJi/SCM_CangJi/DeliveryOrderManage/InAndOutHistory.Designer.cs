namespace SCM_CangJi.DeliveryOrderManage
{
    partial class InAndOutHistory
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
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtProductNumber1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtProductCurrentNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlInputHistory = new DevExpress.XtraGrid.GridControl();
            this.gridViewInputHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnExportInputHistrory = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlDeliveryHistory = new DevExpress.XtraGrid.GridControl();
            this.gridViewDeliveryHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnExportDeliveryHistory = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductNumber1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCurrentNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.txtProductNumber1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtProductCurrentNumber);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(806, 76);
            this.panelControl1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(585, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtProductNumber1
            // 
            this.txtProductNumber1.Location = new System.Drawing.Point(360, 21);
            this.txtProductNumber1.Name = "txtProductNumber1";
            this.txtProductNumber1.Size = new System.Drawing.Size(193, 21);
            this.txtProductNumber1.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(306, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "品号：";
            // 
            // txtProductCurrentNumber
            // 
            this.txtProductCurrentNumber.Location = new System.Drawing.Point(74, 21);
            this.txtProductCurrentNumber.Name = "txtProductCurrentNumber";
            this.txtProductCurrentNumber.Size = new System.Drawing.Size(193, 21);
            this.txtProductCurrentNumber.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "现品票：";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 76);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(806, 372);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControlInputHistory);
            this.xtraTabPage1.Controls.Add(this.panelControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(799, 342);
            this.xtraTabPage1.Text = "入库历史";
            // 
            // gridControlInputHistory
            // 
            this.gridControlInputHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInputHistory.Location = new System.Drawing.Point(0, 42);
            this.gridControlInputHistory.MainView = this.gridViewInputHistory;
            this.gridControlInputHistory.Name = "gridControlInputHistory";
            this.gridControlInputHistory.Size = new System.Drawing.Size(799, 300);
            this.gridControlInputHistory.TabIndex = 1;
            this.gridControlInputHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInputHistory});
            // 
            // gridViewInputHistory
            // 
            this.gridViewInputHistory.GridControl = this.gridControlInputHistory;
            this.gridViewInputHistory.Name = "gridViewInputHistory";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnExportInputHistrory);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(799, 42);
            this.panelControl2.TabIndex = 0;
            // 
            // btnExportInputHistrory
            // 
            this.btnExportInputHistrory.Location = new System.Drawing.Point(10, 14);
            this.btnExportInputHistrory.Name = "btnExportInputHistrory";
            this.btnExportInputHistrory.Size = new System.Drawing.Size(75, 23);
            this.btnExportInputHistrory.TabIndex = 0;
            this.btnExportInputHistrory.Text = "导出";
            this.btnExportInputHistrory.Click += new System.EventHandler(this.btnExportInputHistrory_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gridControlDeliveryHistory);
            this.xtraTabPage2.Controls.Add(this.panelControl3);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(799, 342);
            this.xtraTabPage2.Text = "出库历史";
            // 
            // gridControlDeliveryHistory
            // 
            this.gridControlDeliveryHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDeliveryHistory.Location = new System.Drawing.Point(0, 42);
            this.gridControlDeliveryHistory.MainView = this.gridViewDeliveryHistory;
            this.gridControlDeliveryHistory.Name = "gridControlDeliveryHistory";
            this.gridControlDeliveryHistory.Size = new System.Drawing.Size(799, 300);
            this.gridControlDeliveryHistory.TabIndex = 2;
            this.gridControlDeliveryHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDeliveryHistory});
            // 
            // gridViewDeliveryHistory
            // 
            this.gridViewDeliveryHistory.GridControl = this.gridControlDeliveryHistory;
            this.gridViewDeliveryHistory.Name = "gridViewDeliveryHistory";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnExportDeliveryHistory);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(799, 42);
            this.panelControl3.TabIndex = 0;
            // 
            // btnExportDeliveryHistory
            // 
            this.btnExportDeliveryHistory.Location = new System.Drawing.Point(10, 13);
            this.btnExportDeliveryHistory.Name = "btnExportDeliveryHistory";
            this.btnExportDeliveryHistory.Size = new System.Drawing.Size(75, 23);
            this.btnExportDeliveryHistory.TabIndex = 0;
            this.btnExportDeliveryHistory.Text = "导出";
            this.btnExportDeliveryHistory.Click += new System.EventHandler(this.btnExportDeliveryHistory_Click);
            // 
            // InAndOutHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 448);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "InAndOutHistory";
            this.Text = "出入库历史查询";
            this.Load += new System.EventHandler(this.InAndOutHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductNumber1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProductCurrentNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInputHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInputHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDeliveryHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDeliveryHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControlInputHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInputHistory;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnExportInputHistrory;
        private DevExpress.XtraGrid.GridControl gridControlDeliveryHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDeliveryHistory;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton btnExportDeliveryHistory;
        private DevExpress.XtraEditors.TextEdit txtProductCurrentNumber;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtProductNumber1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}