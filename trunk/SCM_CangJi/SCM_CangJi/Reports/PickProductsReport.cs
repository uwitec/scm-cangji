using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.DAL;
using DevExpress.XtraReports.Parameters;
namespace SCM_CangJi.Reports
{
    public partial class PickProductsReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PickProductsReport()
        {
            InitializeComponent();
        }
        public void InitDetailsBasedonXRTable()
        {
            //DataSet ds = new DataSet();
            //ReportDataSet rds = new ReportDataSet();
            //DeliveryOrderService.Instance.GetAssignedDeliveryOrderDetails
            //ds.Tables.Add(DeliveryOrderService.Instance.GetDeliveryOrderDetailsDataTable(_orderId));
            //this.DataSource = ;
            //int colCount = ds.Tables[0].Columns.Count;
            //int colWidth = (PageWidth - (Margins.Left + Margins.Right)) / colCount;
            
        }
    }
}
