using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class ProductStorageList : FormBase
    {
        #region ISingleton<ProductStorageList> Members
        private static ProductStorageList _instance = null;
        public static ProductStorageList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new ProductStorageList();
                }
                return _instance;
            }
        }


        #endregion

        private ProductStorageList()
        {
            InitializeComponent();
            ProgressStart();
        }


        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            InitGrid();
            base.DoWork(sender, e);
        }

        private void InitGrid()
        {
            gridControlProductStorages.DataSource = ProductStorageService.Instance.GetCurrentStorages(radioGroup1.EditValue.Equals(1));
        }
        private void ProductStorageList_Load(object sender, EventArgs e)
        {
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void btnExportExcle_Click(object sender, EventArgs e)
        {
            ExportExcle(this.gridViewProductStorages, "库存表.xls");
        }

        private void chkInclude0_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitGrid();
        }
    }
}
