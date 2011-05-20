/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/20/2011 10:06:36 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageWorning
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;

namespace SCM_CangJi.StorageManage
{
    public partial class StorageWorning : FormBase
    {
        #region ISingleton<StorageWorning> Members
        private static StorageWorning _instance = null;
        public static StorageWorning Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new StorageWorning();
                }
                return _instance;
            }
        }


        #endregion
       
        public StorageWorning()
            :base()
        {
            this.ProgressStart();
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeComponent();
            base.DoWork(sender, e);
            InitGrid();
        }

        private void InitGrid()
        {
            gridControlProductStorages.DataSource = ProductStorageService.Instance.GetProductStorageWoring();
        }
    }
}