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
    public partial class PickProductsOrder : DevExpress.XtraEditors.XtraUserControl
    {
        private DeliveryOrder order;
        public PickProductsOrder(int orderId)
        {
            InitializeComponent();
            order = BLL.Services.DeliveryOrderService.Instance.GetDeliveryOrderFullInfo(orderId);
            InitData();
            Print();

        }

        private void Print()
        {
            PrintSettingController print = new PrintSettingController(this.layoutControl1, "拣品单");
            print.Preview();
        }

        private void InitData()
        {
            gridControlAssignDetails.DataSource = order.AssignedDeliveryOrderDetails;
        }

     
    }
}
