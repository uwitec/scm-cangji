using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class ViewPreDeliveryDetails : FormBase
    {
        private int _orderId;
        private int _companyId;
        public ViewPreDeliveryDetails(int orderId,int companyId)
            : base()
        {
            _orderId = orderId;
            _companyId = companyId;
            InitializeComponent();
            InitProduct();
            InitGrid();
        }

        private void InitProduct()
        {
            gcProducts.DataSource = BLL.Services.ProductService.Instance.GetProducts(_companyId);
        }

        private void InitGrid()
        {
            gridControlDeliveryOrerDetails.DataSource = BLL.Services.DeliveryOrderService.Instance.GetDeliveryOrderDetailsDataTable(_orderId);
        }
    }
}