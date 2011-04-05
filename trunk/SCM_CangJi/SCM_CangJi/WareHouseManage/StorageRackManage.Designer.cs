namespace SCM_CangJi.WareHouseManage
{
    partial class StorageRackManage
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttArrow = new ButtonEx();
            this.buttRackType = new ButtonEx();
            this.buttRackArea = new ButtonEx();            
                
            this.SuspendLayout();
            // 
            // StorageRackManage
            
            this.Controls.Add(this.buttArrow);
            buttArrow.Click += new System.EventHandler(this.buttArrow_Click);
            buttArrow.CreateWindow("ARROW", 30, 8, 20, 20, ButtonEx.STYLE.ARROW);

            this.Controls.Add(this.buttRackType);
            buttRackType.Click += new System.EventHandler(this.buttRackType_Click);
            buttRackType.CreateWindow("创建货架类型", 60, 8, 20, ButtonEx.STYLE.BUTTON);

            this.Controls.Add(this.buttRackArea);
            buttRackArea.Click += new System.EventHandler(this.buttRackArea_Click);
            buttRackArea.CreateWindow("创建存储区域", 170, 8, 20, ButtonEx.STYLE.BUTTON);
            
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);
        }

        #endregion

        private ButtonEx buttArrow;
        private ButtonEx buttRackType;
        private ButtonEx buttRackArea;
    }
}
