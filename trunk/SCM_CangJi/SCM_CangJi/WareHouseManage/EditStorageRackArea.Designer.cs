namespace SCM_CangJi.WareHouseManage
{
    partial class EditStorageRackArea
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
            this.butAdd = new System.Windows.Forms.Button();
            this.textRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.butClose = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butSave = new System.Windows.Forms.Button();
            this.AreaGridView = new System.Windows.Forms.DataGridView();
            this.textAreaName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.AreaGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(241, 9);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(64, 27);
            this.butAdd.TabIndex = 4;
            this.butAdd.Text = "添加";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // textRemark
            // 
            this.textRemark.Location = new System.Drawing.Point(68, 49);
            this.textRemark.Name = "textRemark";
            this.textRemark.Size = new System.Drawing.Size(237, 22);
            this.textRemark.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 10;
            this.label2.Text = "备注:";
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(222, 312);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(67, 23);
            this.butClose.TabIndex = 7;
            this.butClose.Text = "退出";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(151, 311);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(67, 23);
            this.butDelete.TabIndex = 6;
            this.butDelete.Text = "删除";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.butDelete_Click);
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(80, 311);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(67, 23);
            this.butSave.TabIndex = 5;
            this.butSave.Text = "保存";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // AreaGridView
            // 
            this.AreaGridView.AllowUserToAddRows = false;
            this.AreaGridView.AllowUserToDeleteRows = false;
            this.AreaGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.AreaGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AreaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AreaGridView.Location = new System.Drawing.Point(9, 84);
            this.AreaGridView.Name = "AreaGridView";
            this.AreaGridView.RowTemplate.Height = 23;
            this.AreaGridView.Size = new System.Drawing.Size(299, 220);
            this.AreaGridView.TabIndex = 5;
            this.AreaGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.OnCellBeginEdit);
            this.AreaGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellClick);
            this.AreaGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnCellEndEdit);
            this.AreaGridView.SelectionChanged += new System.EventHandler(this.OnSelectionChanged);
            // 
            // textAreaName
            // 
            this.textAreaName.Location = new System.Drawing.Point(68, 12);
            this.textAreaName.Name = "textAreaName";
            this.textAreaName.Size = new System.Drawing.Size(161, 22);
            this.textAreaName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "库位名称:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(319, 351);
            this.shapeContainer1.TabIndex = 8;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.rectangleShape2.Enabled = false;
            this.rectangleShape2.Location = new System.Drawing.Point(6, 81);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(304, 260);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(221)))), ((int)(((byte)(230)))));
            this.rectangleShape1.Enabled = false;
            this.rectangleShape1.Location = new System.Drawing.Point(5, 80);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(306, 262);
            // 
            // EditStorageRackArea
            // 
            this.AcceptButton = this.butAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 351);
            this.Controls.Add(this.textRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.AreaGridView);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.textAreaName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.Name = "EditStorageRackArea";
            this.Text = "货架库位管理";
            this.Load += new System.EventHandler(this.OnLoad);
            ((System.ComponentModel.ISupportInitialize)(this.AreaGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAreaName;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.DataGridView AreaGridView;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button butDelete;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textRemark;
    }
}