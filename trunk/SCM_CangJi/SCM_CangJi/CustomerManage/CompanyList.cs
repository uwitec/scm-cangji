using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.DAL;

namespace SCM_CangJi.CustomerManage
{
    public partial class CompanyList : FormBase
    {
        #region ISingleton<CompanyList> Members
        private static CompanyList _instance = null;
        public static CompanyList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new CompanyList();
                }
                return _instance;
            }
        }


        #endregion

        private CompanyList()
        {
            InitializeComponent();
            InitCompanyGrid();
        }


        private void InitTabs(int companyId)
        {
            InitContact(companyId);
            InitProduct(companyId);
            InitDeliverAddress(companyId);
        }



        private void CompanyList_Load(object sender, EventArgs e)
        {

        }

        #region 公司相关
       public int CompanyId = 0;
        private void InitCompanyGrid()
        {
            gridControlCompany.DataSource = SCM_CangJi.BLL.Services.CompanyService.Instance.GetAllCompany();
        }



        private void gridViewCompany_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;

            CompanyId = (int)gridViewCompany.GetRowCellValue(e.FocusedRowHandle, "Id");
            InitTabs(CompanyId);
        }


        private void gridControlCompany_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewCompany.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                CompanyId = (int)gridViewCompany.GetRowCellValue(hi.RowHandle, "Id");
                EditCompany editform = new EditCompany(CompanyId);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitCompanyGrid();
                }
            }
        }

        private void btnCreateCompany_Click(object sender, EventArgs e)
        {
            EditCompany editform = new EditCompany();
            if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitCompanyGrid();
            }
        }

        private void btnRefrash_Click(object sender, EventArgs e)
        {
            InitCompanyGrid();
        }
        int companyrowhandle = -1;
        private void gridViewCompany_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {

            if (e.MenuType == GridMenuType.Row)
            {
                companyrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemCreate = new DXMenuItem("新建", new EventHandler(btnCreateCompany_Click));
                DXMenuItem menuItemDelete = new DXMenuItem("删除", new EventHandler(DeleteCompany));
                DXMenuItem menuItemRefrash = new DXMenuItem("刷新", new EventHandler(btnRefrash_Click));
                e.Menu.Items.Add(menuItemCreate);
                e.Menu.Items.Add(menuItemDelete);
                e.Menu.Items.Add(menuItemRefrash);

                companyrowhandle = e.HitInfo.RowHandle;
            }
        }


        protected void DeleteCompany(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("确实要删除？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                int companyid = (int)gridViewCompany.GetRowCellValue(companyrowhandle, "Id");
                if (BLL.Services.CompanyService.Instance.Delete(companyid))
                {
                    gridViewCompany.DeleteSelectedRows();
                }
            }
        }

        #endregion

        #region 联系人  

        private void InitContact(int companyId)
        {
            gridControlContacts.DataSource = SCM_CangJi.BLL.Services.ContactService.Instance.GetContacts(companyId);

        }
        int contactrowhandle = -1;
        private void gridViewContacts_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                companyrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemCreate = new DXMenuItem("新建", new EventHandler(btnCreateContact_Click));
                e.Menu.Items.Add(menuItemCreate);


                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                    {
                        if (XtraMessageBox.Show("确实要删除？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            int contaciId = (int)gridViewContacts.GetRowCellValue(contactrowhandle, "Id");
                            if (BLL.Services.ContactService.Instance.Delete(contaciId))
                            {
                                gridViewContacts.DeleteSelectedRows();
                            }
                        }
                    });
                e.Menu.Items.Add(menuItemDelete);
                DXMenuItem menuItemrefrash = new DXMenuItem("刷新", (s, en) =>
                    {
                        InitContact(CompanyId);
                    });
                e.Menu.Items.Add(menuItemrefrash);

                contactrowhandle = e.HitInfo.RowHandle;
            }
        }
        private void gridControlContacts_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewContacts.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int contactId = (int)gridViewContacts.GetRowCellValue(hi.RowHandle, "Id");
                EditContact editform = new EditContact(CompanyId, contactId);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitContact(CompanyId);
                }
            }
        }
        private void btnCreateContact_Click(object sender, EventArgs e)
        {
            EditContact editform = new EditContact(CompanyId);
            if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitContact(CompanyId);
            }
        }
        #endregion

        #region 商品

        private void InitProduct(int companyId)
        {
            gridControlProduct.DataSource = ProductService.Instance.GetProducts(companyId);
        }

        private void gridControlProduct_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewProduct.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int productId = (int)gridViewProduct.GetRowCellValue(hi.RowHandle, "Id");
                EditProduct editform = new EditProduct(CompanyId, productId);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitProduct(CompanyId);
                }
            }
        }
        int productrowhandle = -1;

        private void gridViewProduct_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                productrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemCreate = new DXMenuItem("新建",new EventHandler(btnCreateProduct_Click));
                e.Menu.Items.Add(menuItemCreate);


                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                {
                    if (XtraMessageBox.Show("确实要删除？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        int productId = (int)gridViewProduct.GetRowCellValue(productrowhandle, "Id");
                        if (BLL.Services.ProductService.Instance.Delete(productId))
                        {
                            gridViewProduct.DeleteSelectedRows();
                        }
                    }
                });
                e.Menu.Items.Add(menuItemDelete);
                DXMenuItem menuItemrefrash = new DXMenuItem("刷新", (s, en) =>
                {
                    InitProduct(CompanyId);
                });
                e.Menu.Items.Add(menuItemrefrash);

                productrowhandle = e.HitInfo.RowHandle;
            }
        }
        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            EditProduct editform = new EditProduct(CompanyId);
            if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitProduct(CompanyId);
            }
        }
        private void btnImportProduct_Click(object sender, EventArgs e)
        {
            WareHouseManage.ImportDataBaseManage importForm = new WareHouseManage.ImportDataBaseManage(this.Handle, Lib.Constains.Products);
            if (importForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitProduct(this.CompanyId);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Company company = CompanyService.Instance.GetCompany(this.CompanyId);
            this.ExportExcle(this.gridViewProduct, company.CompanyName + "_商品表.xls");
        }
        #endregion

        #region 送货地址

        private void InitDeliverAddress(int companyId)
        {
            gridControlDeliverAddress.DataSource = DeliverAddressService.Instance.GetAddresses(companyId);
        }


        private void gridControlDeliverAddress_DoubleClick(object sender, EventArgs e)
        {
            GridHitInfo hi = gridViewDeliverAddress.CalcHitInfo((sender as Control).PointToClient(Control.MousePosition));

            if (hi.RowHandle >= 0)
            {
                int productId = (int)gridViewDeliverAddress.GetRowCellValue(hi.RowHandle, "Id");
                EditDeliverAddress editform = new EditDeliverAddress(CompanyId, productId);
                if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    InitDeliverAddress(CompanyId);
                }
            }
        }

        private void gridViewDeliverAddress_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                productrowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();

                DXMenuItem menuItemCreate = new DXMenuItem("新建", new EventHandler(btnCreateDeliverAddress_Click));
                e.Menu.Items.Add(menuItemCreate);


                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                {
                    if (XtraMessageBox.Show("确实要删除？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        int addressId = (int)gridViewDeliverAddress.GetRowCellValue(productrowhandle, "Id");
                        if (BLL.Services.DeliverAddressService.Instance.Delete(addressId))
                        {
                            gridViewDeliverAddress.DeleteSelectedRows();
                        }
                    }
                });
                e.Menu.Items.Add(menuItemDelete);
                DXMenuItem menuItemrefrash = new DXMenuItem("刷新", (s, en) =>
                {
                    InitDeliverAddress(CompanyId);
                });
                e.Menu.Items.Add(menuItemrefrash);

                productrowhandle = e.HitInfo.RowHandle;
            }
        }

        private void btnCreateDeliverAddress_Click(object sender, EventArgs e)
        {
            EditDeliverAddress editform = new EditDeliverAddress(CompanyId);
            if (editform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InitDeliverAddress(CompanyId);
            }

        }
        #endregion

      

      
    }
}