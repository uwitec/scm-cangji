/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/18/2011 8:09:30 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageChange
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
using SCM_CangJi.DAL;
using SCM_CangJi.BLL;
using System.Linq;
using System.Data.Linq;
namespace SCM_CangJi.StorageManage
{
    public partial class StorageChange : FormBase//Base.SingletonFormBase<StorageChange>
    {
        List<ProductStorageChange> _productStorageChangingList;
        public List<ProductStorageChange> ProductStorageChangingList
        {
            get{
                if (_productStorageChangingList == null)
                {
                    _productStorageChangingList = new List<ProductStorageChange>();
                }
                return _productStorageChangingList;
            }
        }

        #region ISingleton<StorageChange> Members
        private static StorageChange _instance = null;
        public static StorageChange Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new StorageChange();
                }
                return _instance;
            }
        }


        #endregion
        public StorageChange()
            : base()
        {
            this.ProgressStart();

        }
        protected override string CloseingMessage()
        {
            return "变更数据还未保存";
        }
        protected override void DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            InitializeComponent();

            gridViewProductStorages.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(gridViewProductStorages_RowUpdated);
            base.DoWork(sender, e);
            InitGrid();
            CommonService.BindDDLStorageArea(gridStorageArea);

        }

        void gridViewProductStorages_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
           
        }
        private void StorageChange_Load(object sender, EventArgs e)
        {
        }
        private void InitGrid()
        {
            bindingSource1.DataSource =
ProductStorageService.Instance.GetCurrentStoragesDT(true);
            gridControlProductStorages.DataSource = bindingSource1;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!Updated)
            {
                if (ShowQuestion(this.CloseingMessage()+",确实要刷新吗？") == System.Windows.Forms.DialogResult.OK)
                {
                    InitGrid();
                    this.Updated = true;
                }
            }
            else
            {
                InitGrid();
            }
        }

        private void gridViewProductStorages_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.Updated = false;
            int intRowHandle = e.RowHandle;
            int currentCount = 0;
            int.TryParse(gridViewProductStorages.GetRowCellValue(intRowHandle, "CurrentCount").TrytoString(), out currentCount);
            int useableCount = 0;
            int.TryParse(gridViewProductStorages.GetRowCellValue(intRowHandle, "UsableCount").TrytoString(), out useableCount);
            int areaId = 0;
            int.TryParse(gridViewProductStorages.GetRowCellValue(intRowHandle, "AreaId").TrytoString(), out areaId);
            int Id = 0;
            int.TryParse(gridViewProductStorages.GetRowCellValue(intRowHandle, "Id").TrytoString(), out Id);
            SetUpatingStorage(Id,currentCount, useableCount, areaId);
        }

        private void SetUpatingStorage(int id,int currentCount, int useableCount, int areaId)
        {
            if (id > 0)
            {
                bool isNew=false;
                ProductStorageChange psc = this.ProductStorageChangingList.SingleOrDefault();
                if (psc == null)
                {
                    isNew=true;
                    psc = new ProductStorageChange();
                }
                psc.ProductStorageID = id;
                psc.CurrentCount = currentCount;
                psc.UsableCount = useableCount;
                psc.AreaId = areaId;
                if (isNew)
                {
                    this.ProductStorageChangingList.Add(psc);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProductStorageService.Instance.UpdateProductStorages(this.ProductStorageChangingList);
            this.Updated = true;
            InitGrid();
        }
    }
}