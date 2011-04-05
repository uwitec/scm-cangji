namespace SCM_CangJi.WareHouseManage
{
    partial class EditRackArea
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
            this.label1 = new System.Windows.Forms.Label();
            this.textAreaName = new System.Windows.Forms.TextBox();
            this.butAdd = new System.Windows.Forms.Button();
            this.RackTypeGridView = new System.Windows.Forms.DataGridView();
            this.butSave = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.butClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RackTypeGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "区域名称:";
            // 
            // textAreaName
            // 
            this.textAreaName.Location = new System.Drawing.Point(68, 12);
            this.textAreaName.Name = "textAreaName";
            this.textAreaName.Size = new System.Drawing.Size(161, 22);
            this.textAreaName.TabIndex = 2;
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(241, 9);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(64, 27);
            this.butAdd.TabIndex = 3;
            this.butAdd.Text = "添加";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // RackTypeGridView
            // 
            this.RackTypeGridView.AllowUserToAddRows = false;
            this.RackTypeGridView.AllowUserToDeleteRows = false;
            this.RackTypeGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.RackTypeGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RackTypeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RackTypeGridView.Location = new System.Drawing.Point(9, 48);
            this.RackTypeGridView.Name = "RackTypeGridView";
            this.RackTypeGridView.RowTemplate.Height = 23;
            this.RackTypeGridView.Size = new System.Drawing.Size(299, 173);
            this.RackTypeGridView.TabIndex = 5;
            this.RackTypeGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.OnCellBeginEdit);
            this.RackTypeGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
            this.RackTypeGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellEndEdit);
            this.RackTypeGridView.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(80, 226);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(67, 23);
            this.butSave.TabIndex = 6;
            this.butSave.Text = "保存";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(151, 226);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(67, 23);
            this.butDelete.TabIndex = 7;
            this.butDelete.Text = "删除";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(316, 261);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.rectangleShape2.Enabled = false;
            this.rectangleShape2.Location = new System.Drawing.Point(6, 44);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(304, 209);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this.rectangleShape1.Enabled = false;
            this.rectangleShape1.Location = new System.Drawing.Point(5, 43);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(306, 211);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(222, 227);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(67, 23);
            this.butClose.TabIndex = 9;
            this.butClose.Text = "退出";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // EditRackArea
            // 
            this.AcceptButton = this.butAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 261);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.RackTypeGridView);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.textAreaName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.Name = "EditRackArea";
            this.Text = "货架区域类型信息";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.RackTypeGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAreaName;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridView RackTypeGridView;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butDelete;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.Button butClose;
    }
}