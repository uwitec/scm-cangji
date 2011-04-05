namespace SCM_CangJi.WareHouseManage
{
    partial class StorageManageView
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
            this.tabStorageMage = new SCM_CangJi.WareHouseManage.TabStorageManage();
            this.buttArrow = new SCM_CangJi.WareHouseManage.ButtonEx(parentPanel);
            this.tabStorageMage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabStorageMage
            // 
            this.tabStorageMage.Controls.Add(this.buttArrow);
            this.tabStorageMage.Location = new System.Drawing.Point(12, 12);
            this.tabStorageMage.Name = "tabStorageMage";
            this.tabStorageMage.Size = new System.Drawing.Size(317, 40);
            this.tabStorageMage.TabIndex = 1;
            // 
            // buttArrow
            // 
            //this.buttArrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttArrow.Location = new System.Drawing.Point(3, 3);
            this.buttArrow.Name = "buttArrow";
            this.buttArrow.Size = new System.Drawing.Size(36, 30);
            this.buttArrow.TabIndex = 3;
            // 
            // StorageManageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(341, 310);
            this.Controls.Add(this.tabStorageMage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StorageManageView";
            this.Text = "StorageManageView";
            this.Load += new System.EventHandler(this.StorageManageView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Resize += new System.EventHandler(this.OnResize);
            this.tabStorageMage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabStorageManage tabStorageMage;
        private ButtonEx buttArrow;

        //private System.Windows.Forms.Button button1;

    }
}