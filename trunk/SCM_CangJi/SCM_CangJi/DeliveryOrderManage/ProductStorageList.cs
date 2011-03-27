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
        }

        private void gridControlProductStorages_Click(object sender, EventArgs e)
        {
            gridControlProductStorages.DataSource = ProductStorageService.Instance.GetCurrentStorages();
        }
    }
}
