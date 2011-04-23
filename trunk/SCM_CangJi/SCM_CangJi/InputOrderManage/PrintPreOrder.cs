using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
using SCM_CangJi.Print;
namespace SCM_CangJi.InputOrderManage
{
    public partial class PrintPreOrder : FormBase
    {
        private int _orderId;
        PrintSettingController print = null;
        InputOrder order = null;
        public PrintPreOrder(int orderId)
            : base()
        {
            _orderId = orderId;
            InitializeComponent();
            print = new PrintSettingController(this.gridControlInputOrerDetails, "入库单");
            gridViewInputOrderDetails.OptionsView.RowAutoHeight = true;
            print.OnPrinted += new Action(print_OnPrinted);
            order = InputOrderService.Instance.GetInputOrderFullInfo(_orderId);
            print.PrintHeader = "入库单（发票号：" + order.Invoice+")";
            InitData();
            InitDetail();
        }

        void print_OnPrinted()
        {
            
        }

     
        private void InitData()
        {
            txtCompany.EditValue = order.Company.CompanyName;
            txtEnterUser.EditValue = order.EnterUser;
            txtFromWhere.EditValue = order.FromWhere;
            txtInputOrderNumber.EditValue = order.InputOrderNumber;
            txtInvoice.EditValue = order.Invoice;
            txtPreInputDate.EditValue = order.PreInputDate.ToShortDateString();
            
        }
        private void InitDetail()
        {
            gridControlInputOrerDetails.DataSource = InputOrderService.Instance.GetInputOrderDetailsFullInfo(_orderId);
        }

        private void PrintPreOrder_Load(object sender, EventArgs e)
        {
            print.Preview();
        }

        private void gridViewInputOrderDetails_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {
            
        }
    }
}