namespace SCM_CangJi.WareHouseManage
{
    partial class ImportDataBase
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
            this.gridDataBase = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnConfrim = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnConfrim);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(589, 53);
            this.panelControl1.TabIndex = 0;
            // 
            // gridDataBase
            // 
            this.gridDataBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDataBase.Location = new System.Drawing.Point(0, 53);
            this.gridDataBase.MainView = this.gridView1;
            this.gridDataBase.Name = "gridDataBase";
            this.gridDataBase.Size = new System.Drawing.Size(589, 349);
            this.gridDataBase.TabIndex = 1;
            this.gridDataBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridDataBase;
            this.gridView1.Name = "gridView1";
            // 
            // btnConfrim
            // 
            this.btnConfrim.Location = new System.Drawing.Point(23, 12);
            this.btnConfrim.Name = "btnConfrim";
            this.btnConfrim.Size = new System.Drawing.Size(75, 23);
            this.btnConfrim.TabIndex = 0;
            this.btnConfrim.Text = "确认导入";
            this.btnConfrim.Click += new System.EventHandler(this.btnConfrim_Click);
            // 
            // ImportDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 402);
            this.Controls.Add(this.gridDataBase);
            this.Controls.Add(this.panelControl1);
            this.Name = "ImportDataBase";
            this.Text = "数据导入处理";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Resize += new System.EventHandler(this.onResize);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConfrim;
        private DevExpress.XtraGrid.GridControl gridDataBase;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;

    }
}