using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using SCM_CangJi.Lib;

namespace SCM_CangJi.WareHouseManage
{
    public partial class StorageManageView : XtraForm
    {
        int formX;
        int formY;
        int formWidth;
        int formHeight;

        Panel parentPanel = null;
        ButtonEx butAdd = null;
        ButtonEx butEdit = null;

        public StorageManageView(Panel parent)
        {
            parentPanel = parent;

            InitializeVariable();
            InitializeComponent();
        }

        private void InitializeVariable()
        {
            formX = 0;
            formY = 0;
            formWidth = 0;
            formHeight = 0;
            
            butAdd = new ButtonEx();
            butEdit = new ButtonEx();
        }

        public void SetWindowsPos(int x, int y, int w, int h)
        {
            formX = x;
            formY = y;
            formWidth = w;
            formHeight = h;

            this.Left = formX;
            this.Top = formY;
            this.Height = formHeight;
            this.Width = formWidth;
            
            Show();
        }

        private void StorageManageView_Load(object sender, EventArgs e)
        {
            this.Left = formX;
            this.Height = formHeight;
            this.Width = formWidth;

            buttArrow.CreateWindow("ARROW", 30, 8, 20, 20, ButtonEx.STYLE.ARROW);

            if (butAdd != null)
            {
                this.tabStorageMage.Controls.Add(butAdd);
                butAdd.Click += new System.EventHandler(this.butAdd_Click);
                butAdd.CreateWindow("添加", 60, 8, 50, 20, ButtonEx.STYLE.BUTTON);
                butAdd.Show();
            }

            if (butEdit != null)
            {
                this.tabStorageMage.Controls.Add(butEdit);
                butEdit.Click += new System.EventHandler(this.butEdit_Click);
                butEdit.CreateWindow("修改", 120, 8, 50, 20, ButtonEx.STYLE.BUTTON);
                butEdit.Show();
            }

            tabStorageMage.Dock = DockStyle.Fill;
            /*
             * //通过设置该属性窗口最大时获取它们的坐标会不对,用SetWindowsPos进行调整
            tabStorageMage.Dock = DockStyle.Fill;
             * */
            
            tabStorageMage.AddTabItem("仓库管理", "001");
            tabStorageMage.GetStorageData();
            
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.Yellow);
            Rectangle rect = new Rectangle(0, 0, formWidth, formHeight);
            e.Graphics.FillRectangle(blueBrush, rect);
        }

        private void OnResize(object sender, EventArgs e)
        {
            //调整Tab位置
            tabStorageMage.SetTabXOffset(100);
            tabStorageMage.SetWindowsPos(1, 10, formWidth, formHeight);
            tabStorageMage.Invalidate();
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            EditStorage editStorage = new EditStorage(ACTION.INSERT, tabStorageMage);
            editStorage.ShowDialog();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            if (tabStorageMage.GetClickPosition() >= 0)
            {
                EditStorage editStorage = new EditStorage(ACTION.UPDATE, tabStorageMage);
                editStorage.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("请先选中要修改的数据！");
            }

        }
    }
}
