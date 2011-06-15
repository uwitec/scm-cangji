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
            this.components = new System.ComponentModel.Container();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.btnExportExcle = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlProductStorages = new DevExpress.XtraGrid.GridControl();
            this.gridViewProductStorages = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.radioGroup1);
            this.panelControl1.Controls.Add(this.btnExportExcle);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(632, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // radioGroup1
            // 
            this.radioGroup1.EditValue = 2;
            this.radioGroup1.Location = new System.Drawing.Point(201, 6);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "全部"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "库存大于0")});
            this.radioGroup1.Size = new System.Drawing.Size(201, 35);
            this.radioGroup1.TabIndex = 4;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // btnExportExcle
            // 
            this.btnExportExcle.Location = new System.Drawing.Point(102, 12);
            this.btnExportExcle.Name = "btnExportExcle";
            this.btnExportExcle.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcle.TabIndex = 3;
            this.btnExportExcle.Text = "导出";
            this.btnExportExcle.Click += new System.EventHandler(this.btnExportExcle_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(21, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gridControlProductStorages
            // 
            this.gridControlProductStorages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductStorages.Location = new System.Drawing.Point(0, 47);
            this.gridControlProductStorages.MainView = this.gridViewProductStorages;
            this.gridControlProductStorages.Name = "gridControlProductStorages";
            this.gridControlProductStorages.Size = new System.Drawing.Size(632, 404);
            this.gridControlProductStorages.TabIndex = 2;
            this.gridControlProductStorages.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProductStorages});
            // 
            // gridViewProductStorages
            // 
            this.gridViewProductStorages.GridControl = this.gridControlProductStorages;
            this.gridViewProductStorages.Name = "gridViewProductStorages";
            this.gridViewProductStorages.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewProductStorages.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(this.gridViewProductStorages_ShowGridMenu);
            // 
            // ProductStorageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 451);
            this.Controls.Add(this.gridControlProductStorages);
            this.Controls.Add(this.panelControl1);
            this.Name = "ProductStorageList";
            this.Text = "库存列表";
            this.Load += new System.EventHandler(this.ProductStorageList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProductStorages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControlProductStorages;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProductStorages;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExportExcle;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}