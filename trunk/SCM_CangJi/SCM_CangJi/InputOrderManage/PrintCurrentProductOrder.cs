using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.Print;
using SCM_CangJi.DAL;
using System.Dynamic;

namespace SCM_CangJi.InputOrderManage
{
    public partial class PrintCurrentProductOrder : DevExpress.XtraEditors.XtraForm
    {
        private dynamic orderDetail=new ExpandoObject();
        bool _printImmediately = false;
        PrintSettingController print = null;
        List<int> _orderDetailIds = null;
        int _orderId;
        public PrintCurrentProductOrder(int orderId,bool printImmediately)
        {
            _printImmediately = printImmediately;
            _orderId = orderId;
            InitializeComponent();
            print = new PrintSettingController(this.gridControl1, "现品票");
            print.PrintHeader = "现品票";
            print.OnPrinted += () => { hasPrinted = true; };
            InitData();
        }
        
        bool hasPrinted = false;
        int i = 0;
            
        //private void PrintPreview()
        //{
        //    foreach (var orderDetailIds in _orderDetailIds)
        //    {

        //        orderDetail = BLL.Services.InputOrderService.Instance.GetInputOrderDetailsFullInfo(orderDetailIds);
        //        InitData();
        //        int k = 0;
        //        while (!hasPrinted)
        //        {
        //            if (k == 0)
        //                print.Preview();
        //            k++;

        //        }
        //        if (i > 0)
        //        {
        //            print.Print();
        //        }
        //        i++;
        //    }

        //}
        //private void Print()
        //{
        //    foreach (var orderDetailIds in _orderDetailIds)
        //    {
        //        orderDetail = BLL.Services.InputOrderService.Instance.GetInputOrderDetailFullInfo(orderDetailIds);
        //        InitData();
        //        print.Print();
        //    }
          
        //}
        private void InitData()
        {
           gridControl1.DataSource=  BLL.Services.InputOrderService.Instance.GetInputOrderDetailsFullInfo(_orderId);

            //txtArea.EditValue = orderDetail.AreaNumber;
            //txtBarCode.EditValue = orderDetail.BarCode;
            //txtCompayName.EditValue = orderDetail.CompanyName;
            //txtCount.EditValue=orderDetail.InputCount;
            //txtCurrentProductNumber.EditValue=orderDetail.CurrentProductNumber;
            //txtInputOrderNumber.EditValue = orderDetail.InputOrderNumber;
            //txtLotsNumber.EditValue = orderDetail.LotsNumber;
            //txtProductEngName.EditValue = orderDetail.ProductEngName;
            //txtProductNmber1.EditValue = orderDetail.ProductNumber1;
            //txtProductNumber2.EditValue = orderDetail.ProductNumber2;
            //txtProductZhName.EditValue = orderDetail.ProductChName;
            //txtWareHouseName.EditValue = orderDetail.WareHouseName;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
        private void PrintCurrentProductOrder_Load(object sender, EventArgs e)
        {
            if (_printImmediately)
            {
                print.Print();
            }
            else
            {
                print.Preview();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            print.Print();


        }

       
    }
}