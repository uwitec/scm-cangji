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
using SCM_CangJi.BLL;
namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class InAndOutHistory : FormBase
    {
        #region ISingleton<InAndOutHistory> Members
        private static InAndOutHistory _instance = null;
        public static InAndOutHistory Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new InAndOutHistory();
                }
                return _instance;
            }
        }


        #endregion

        public InAndOutHistory()
        {
            InitializeComponent();
        }

        private void InAndOutHistory_Load(object sender, EventArgs e)
        {
            
        }
        private void Search()
        {
            gridControlInputHistory.DataSource = InputOrderService.Instance.GetInputDetailsBy(txtProductCurrentNumber.EditValue.TrytoString(), txtProductNumber1.EditValue.TrytoString());
            gridControlDeliveryHistory.DataSource = DeliveryOrderService.Instance.GetDeliveryDetailsBy(txtProductCurrentNumber.EditValue.TrytoString(), txtProductNumber1.EditValue.TrytoString());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnExportInputHistrory_Click(object sender, EventArgs e)
        {
            this.ExportExcle(this.gridViewInputHistory,"入库历史.xls");
        }

        private void btnExportDeliveryHistory_Click(object sender, EventArgs e)
        {
            this.ExportExcle(this.gridViewDeliveryHistory, "出库历史.xls");
        }
    }
}