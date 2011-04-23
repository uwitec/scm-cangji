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
    public partial class PrintCurrentProductOrder :FormBase
    {
        private dynamic orderDetail=new ExpandoObject();
        bool _printImmediately = false;
        PrintSettingController print = null;
        int _orderId;
        private bool _canConfirmInput=false;
        private bool hasInputted = false;
        public PrintCurrentProductOrder(int orderId, bool printImmediately)
                      : base()
        {
            _printImmediately = printImmediately;
            _orderId = orderId;
            InitializeComponent();
            print = new PrintSettingController(this.gridControl1, "现品票");
            print.PrintHeader = "现品票";
            //print.OnPrinted += new Action(print_OnPrinted);
            InitData();
        }

        public PrintCurrentProductOrder(int orderId, bool printImmediately, bool canConfirmInput):this(orderId,printImmediately)
        {
            this._canConfirmInput = canConfirmInput;
        }
     
        void print_OnPrinted()
        {
            if (_canConfirmInput)
            {
                if (!hasInputted)
                {
                    if (BLL.Services.InputOrderService.Instance.ConfirmInputOrder(_orderId))
                    {
                        hasInputted = true;
                        ShowMessage("入库成功！");
                    }
                    else
                    {
                        ShowMessage("入库失败！");
                        return;
                    }
                }
            }
            else
            {
                BLL.Services.InputOrderService.Instance.UpdateStatus(_orderId, Lib.InputStatus.已分配库位);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        
        private void InitData()
        {
           gridControl1.DataSource=  BLL.Services.InputOrderService.Instance.GetInputOrderDetailsFullInfo(_orderId);
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
            print.Preview();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}