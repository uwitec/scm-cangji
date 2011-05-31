using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
namespace SCM_CangJi.BaseInfo
{
    public partial class ProductTypeList :FormBase
    {
        #region ISingleton<ProductTypeList> Members
        private static ProductTypeList _instance = null;
        public static ProductTypeList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ProductTypeList();
                }
                return _instance;
            }
        }


        #endregion
        public ProductTypeList()
            : base()
        {
            this.myLog = MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            gridControlProductTypes.DataSource = BLL.Services.ProductTypeService.Instance.GetProductTypes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                BLL.Services.ProductTypeService.Instance.Create(new DAL.ProductType() { Name = txtProductTypeName.EditValue.TrytoString() });
                myLog.Info("添加了一个商品类型，" + txtProductTypeName.EditValue.TrytoString());
                txtProductTypeName.EditValue = string.Empty;
                InitData();
            }
        }

        private void gridControlProductTypes_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewProductTypes.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int Id = (int)gridViewProductTypes.GetRowCellValue(hi.RowHandle, "Id");
              
            }
        }
        int orderrowhandle;
        private void gridViewProductTypes_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                orderrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                {
                    if (ShowQuestion("确实要删除吗?") == System.Windows.Forms.DialogResult.OK)
                    {
                        int orderId = (int)gridViewProductTypes.GetRowCellValue(orderrowhandle, "Id");
                        object name = gridViewProductTypes.GetRowCellValue(orderrowhandle, "类型名称");
                        BLL.Services.ProductTypeService.Instance.Delete(orderId);
                     
                        myLog.Info(string.Format("删除了一个商品类型，{0}", name));
                        InitData();

                    }
                });
                e.Menu.Items.Add(menuItemDelete);
            }
            DXMenuItem menuItemrefrash = new DXMenuItem("刷新", (s, en) =>
            {
                InitData();
            });
            e.Menu.Items.Add(menuItemrefrash);

            orderrowhandle = e.HitInfo.RowHandle;
        }
    }
}