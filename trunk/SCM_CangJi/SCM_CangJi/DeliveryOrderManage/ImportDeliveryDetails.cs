using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.DAL;
using System.Reflection;
using SCM_CangJi.BLL.Services;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using SCM_CangJi.Lib;
using SCM_CangJi.WareHouseManage;
using SCM_CangJi.Commom;
using SCM_CangJi.BLL;
namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class ImportDeliveryDetails : ImportDataBase
    {
        Dictionary<string, ValidateValue> validateResult;
        PreDeliveryOrder preDeliveryForm;
        IEnumerable<Product> Products = null;
        List<DeliveryOrderDetail> DeliveryOrderDetailsAdding = null;
        List<ImportDataInfo> dataStruct = null;
        public ImportDeliveryDetails(IntPtr formObject, DataSet data, List<ImportDataInfo> importDataStruct)
            : base(formObject, data, importDataStruct)
        {
            InitializeComponent();
            this.Text = "出库明细导入";
            dataStruct = importDataStruct;
            preDeliveryForm = Control.FromHandle(_formObject) as PreDeliveryOrder;
            this.Updated = false;
            validateResult = new Dictionary<string, ValidateValue>();
            this.Load += new EventHandler(ImportDeliveryDetailst_Load);
        }

        void ImportDeliveryDetailst_Load(object sender, EventArgs e)
        {
            Products = ProductService.Instance.GetProductsEntities(this.preDeliveryForm.CompanyId);
        }
        
        public override bool CheckData(DataTable srcData)
        {
            DeliveryOrderDetailsAdding = new List<DeliveryOrderDetail>();

            bool result = true;
            foreach (DataRow row in srcData.Rows)
            {
                DeliveryOrderDetail detail = new DeliveryOrderDetail();
                detail.DeliveryOrderId = preDeliveryForm.OrderId;
                foreach (ImportDataInfo datainfo in dataStruct)
                {
                    if (!result)
                        break;
                    if (datainfo.DestField == "ProductId")
                    {
                        string productNumber1 = row[datainfo.SrcField].TrytoString();
                        Product product = GetProduct(productNumber1);
                        if (product != null)
                        {
                            detail.ProductId = product.Id;
                        }
                        else
                        {
                            ShowWarning(string.Format("商品号：{0} 不存在！", productNumber1));
                            result = false;
                            break;
                        }
                    }
                    else if (Constains.Filed_DeliveryCount == datainfo.DestField)
                    {
                        int deliveryCount = 0;
                        if (int.TryParse(row[datainfo.SrcField].TrytoString(), out deliveryCount))
                        {
                            detail.DeliveryCount = deliveryCount;
                        }
                        else
                        {
                            ShowWarning("出库数量格式有误！");
                            result = false;
                            break;
                        }
                    }
                    else if (Constains.Filed_InputInvoice == datainfo.DestField)
                    {
                        detail.InputInvoice = row[datainfo.SrcField].TrytoString();
                    }
                    else if (Constains.Filed_LotsNumber == datainfo.DestField)
                    {
                        detail.LotsNumber = row[datainfo.SrcField].TrytoString();
                    }
                    else if (Constains.Filed_CustomerPo == datainfo.DestField)
                    {
                        detail.CustomerPo = row[datainfo.SrcField].TrytoString();
                    }
                    else if (Constains.Filed_CurrentProductNumber == datainfo.DestField)
                    {
                        detail.CurrentProductNumber = row[datainfo.SrcField].TrytoString();
                    }
                    else if (Constains.Filed_ProductDate == datainfo.DestField)
                    {
                        DateTime ProductDate = DateTime.MinValue;
                        if (DateTime.TryParse(row[datainfo.SrcField].TrytoString(), out ProductDate))
                        {
                            detail.ProductDate = ProductDate;
                        }
                        else
                        {
                            ShowWarning("生产日期格式有误！");
                            result = false;
                            break;
                        }
                    }

                    //CommonUtil.SetProperValue(row, datainfo, ref detail);
                }
                DeliveryOrderDetailsAdding.Add(detail);
            }
            return result;
        }
  
        public override void ImportToDataBase(DataTable srcData, List<ImportDataInfo> dataStruct)
        {
            
            DeliveryOrderService.Instance.CreateDetail(DeliveryOrderDetailsAdding);
            ShowMessage("出库明细导入成功!");
            this.Updated = true;
        }

        private Product GetProduct(string productNumber1)
        {
            return this.Products.FirstOrDefault(o => o.ProductNumber1 == productNumber1);
        }
        private void Check(DataTable srcData)
        {
            for (int i = 0; i < srcData.Rows.Count; i++)
            {
                if (srcData.Columns[Constains.Filed_DeliveryCount] != null)
                {
                }
                if (srcData.Columns[Constains.Filed_InputInvoice] != null)
                {
                }
                if (srcData.Columns[Constains.Filed_LotsNumber] != null)
                {
                }
                if (srcData.Columns[Constains.Filed_ProductDate] != null)
                {
                }
                if (srcData.Columns[Constains.Filed_ProductId] != null)
                {
                }
            }

        }
     
    }
}