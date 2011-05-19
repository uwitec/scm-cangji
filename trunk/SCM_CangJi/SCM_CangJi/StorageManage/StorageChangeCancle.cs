/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/18/2011 8:21:45 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageChangeCancle
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
using SCM_CangJi.BLL;
namespace SCM_CangJi.StorageManage
{
    public partial class StorageChangeCancle :FormBase // Base.SingletonFormBase<StorageChangeCancle>
    {
        #region ISingleton<StorageChangeCancle> Members
        private static StorageChangeCancle _instance = null;
        public static StorageChangeCancle Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new StorageChangeCancle();
                }
                return _instance;
            }
        }


        #endregion
        public StorageChangeCancle()
            :base()
        {
            this.ProgressStart();
        }
        protected override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitializeComponent();

            base.DoWork(sender, e);
            InitGrid();

        }

        private void InitGrid()
        {
            ;
            gridControlProductStorages.DataSource = ProductStorageService.Instance.GetChangingStorages();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           int[] rowhandlers= gridViewProductStorages.GetSelectedRows();
           if (rowhandlers == null || rowhandlers.Length == 0)
           {
               ShowMessage("请选择需要取消的行！");
               return;
           }
           List<int> changingIds = new List<int>();
           foreach (int rowhandler in rowhandlers)
           {
               int changingId = 0;
               int.TryParse(gridViewProductStorages.GetRowCellValue(rowhandler, "ID").TrytoString(), out changingId);
               if (changingId > 0)
               {
                   changingIds.Add(changingId);
               }
           }
           ProductStorageService.Instance.CancelProductStorageChange(changingIds);
           ShowMessage("变更取消成功！");
           InitGrid();
        }
    }
}