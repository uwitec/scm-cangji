namespace SCM_CangJi.CustomerManage
{
    partial class CompanyList
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCreateCompany = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlCompany = new DevExpress.XtraGrid.GridControl();
            this.gridViewCompany = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gridControlCompany);
            this.splitContainerControl1.Panel1.Controls.Add(this.panelControl2);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(648, 464);
            this.splitContainerControl1.SplitterPosition = 294;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(348, 201);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton2);
            this.panelControl2.Controls.Add(this.btnCreateCompany);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(294, 78);
            this.panelControl2.TabIndex = 0;
            // 
            // btnCreateCompany
            // 
            this.btnCreateCompany.Location = new System.Drawing.Point(22, 25);
            this.btnCreateCompany.Name = "btnCreateCompany";
            this.btnCreateCompany.Size = new System.Drawing.Size(75, 23);
            this.btnCreateCompany.TabIndex = 0;
            this.btnCreateCompany.Text = "创建公司";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(129, 25);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "simpleButton2";
            // 
            // gridControlCompany
            // 
            this.gridControlCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCompany.Location = new System.Drawing.Point(0, 78);
            this.gridControlCompany.MainView = this.gridViewCompany;
            this.gridControlCompany.Name = "gridControlCompany";
            this.gridControlCompany.Size = new System.Drawing.Size(294, 386);
            this.gridControlCompany.TabIndex = 1;
            this.gridControlCompany.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewCompany});
            // 
            // gridViewCompany
            // 
            this.gridViewCompany.GridControl = this.gridControlCompany;
            this.gridViewCompany.Name = "gridViewCompany";
            // 
            // CompanyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 464);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "CompanyList";
            this.Text = "ComanyList";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gridControlCompany;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCompany;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnCreateCompany;
        private DevExpress.XtraEditors.PanelControl panelControl1;

    }
}