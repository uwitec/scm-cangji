/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 6/15/2011 9:30:17 PM
 * CLR版本： 4.0.30319.235
 * 命名空间名称： SCM_CangJi.StorageManage
 * 文件名： StorageSplitSetting
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
    public partial class StorageSplitSetting :FormBase
    {
        int _productStorageId = 0;
        object ProductStrorage = null;
        public StorageSplitSetting(object obj, int productStorageId)
        {
            _productStorageId = productStorageId;
            ProductStrorage = obj;
            this.myLog = SCM_CangJi.BLL.MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
        }

        private void StorageSplitSetting_Load(object sender, EventArgs e)
        {
            txtMessage.EditValue = string.Format(
@"商品:{0}，
品号：{1}，
当前库存：{2}，
可用库存：{3}，
库位：{4}",
               ProductStrorage.GetValue("品名"),
               ProductStrorage.GetValue("品号"),
               ProductStrorage.GetValue("当前库存数"),
               ProductStrorage.GetValue("实际可用数量"),
               ProductStrorage.GetValue("库位")
               );
            CommonService.BindDDLStorageArea(ddlStorageArea);

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                if (ShowQuestion("确实要确认移动吗")== System.Windows.Forms.DialogResult.OK)
                {

                    ProductStorageService.Instance.Split(int.Parse(txtSplitCount.EditValue.ToString()), _productStorageId, int.Parse(ddlStorageArea.EditValue.TrytoString()));
                    this.myLog.Info(string.Format("库存ID:{0}，商品号：{1},被移动【{2}】件到库位：{3}",
                        _productStorageId,
                        ProductStrorage.GetValue("品号"),
                        txtSplitCount.EditValue,
                        ddlStorageArea.Text));
                    ShowMessage("移库成功!");
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }
    }
}