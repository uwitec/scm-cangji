using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.Lib;

namespace SCM_CangJi.InputOrderManage
{
    public partial class ConfirmInputOrder:FormBase
    {
        #region ISingleton<ConfirmInputOrder> Members
        private static ConfirmInputOrder _instance = null;
        public static ConfirmInputOrder Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ConfirmInputOrder();
                }
                return _instance;
            }
        }


        #endregion

        public ConfirmInputOrder()
        {
            this.myLog = SCM_CangJi.BLL.MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
            this.ProgressStart();
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            InitGrid();
            base.DoWork(sender, e);
        }
        private void InitGrid()
        {
            gridControlInputOrders.DataSource = InputOrderService.Instance.GetInputOrdersFull(Lib.InputStatus.已分配库位);
        }
        private void btnConfrimInput_Click(object sender, EventArgs e)
        {
            int RowHandle = gridViewInputOrders.GetFocusedDataSourceRowIndex();
            if (RowHandle >= 0)
            {
                int orderId = (int)gridViewInputOrders.GetRowCellValue(RowHandle, "ID");
                object inputNumber = gridViewInputOrders.GetRowCellValue(RowHandle, "InputOrderNumber");

                if (BLL.Services.InputOrderService.Instance.ConfirmInputOrder(orderId))
                {
                    this.myLog.Info(string.Format("入库单{0}确认入库成功", inputNumber));
                    ShowMessage("入库成功！");
                    InitGrid();
                }
                else
                {
                    ShowWarning("入库失败，请重试！");
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

       
    }
}