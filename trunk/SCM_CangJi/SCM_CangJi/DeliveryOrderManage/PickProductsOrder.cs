using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using SCM_CangJi.Print;
using SCM_CangJi.DAL;

namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class PickProductsOrder :XtraForm //DevExpress.XtraEditors.XtraUserControl
    {
        private DeliveryOrder order;
        bool _printImmediately = false;
        public PickProductsOrder(int orderId,bool printImmediately)
        {
            _printImmediately = printImmediately;
            InitializeComponent();
            order = BLL.Services.DeliveryOrderService.Instance.GetDeliveryOrderFullInfo(orderId);
            InitData();
            InitProduct();
            if (_printImmediately)
            {
                Print();
            }
            else
            {
                PrintPreview();
            }

        }

        private void InitProduct()
        {
            ddlProducts.DataSource = BLL.Services.ProductService.Instance.GetProducts(order.CompanyId);
        }

        private void PrintPreview()
        {
            PrintSettingController print = new PrintSettingController(this.layoutControl1, "拣品单");
            print.PrintHeader = "拣品单";
            print.Preview();
        }
        private void Print()
        {
            PrintSettingController print = new PrintSettingController(this.layoutControl1, "拣品单");
            print.PrintHeader = "拣品单";
            print.Print();
        }
        private void InitData()
        {
            txtAddress.EditValue = order.DeliverAddress.Address;
            txtCompanyName.EditValue = order.Company.CompanyName;
            txtDeliveryOrderNumber.EditValue = order.DeliveryOrderNumber;
            txtInvoice.EditValue = order.Invoice;
            txtReachDate.EditValue = order.ReachedDate.ToShortDateString();
            gridControlAssignDetails.DataSource = BLL.Services.DeliveryOrderService.Instance.GetAssignedDetails(order.Id);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintPreview();
        }

     
    }
}
