using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Linq;
using System.Linq;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
using SCM_CangJi.WareHouseManage;
using SCM_CangJi.DAL;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using SCM_CangJi.Commom;
using SCM_CangJi.BLL.Services;

namespace SCM_CangJi.InputOrderManage
{
    public partial class ImportInputDetails: ImportDataBase
    {
        Dictionary<string, ValidateValue> validateResult;
        PreInputOrder preInputForm;
        IEnumerable<StorageArea> StorageAreas = null;
        IEnumerable<Product> Products = null;
        public ImportInputDetails(IntPtr formObject, DataSet data, List<ImportDataInfo> importDataStruct)
            : base(formObject, data, importDataStruct)
        {
            InitializeComponent();
            this.Text = "商品信息导入";

            preInputForm = Control.FromHandle(_formObject) as PreInputOrder;
            this.Updated = false;
            validateResult = new Dictionary<string, ValidateValue>();
            this.Load += new EventHandler(ImportInputDetailst_Load);
        }





        void ImportInputDetailst_Load(object sender, EventArgs e)
        {
            Products = ProductService.Instance.GetProductsEntities(this.preInputForm.CompanyId);
            StorageAreas = StorageAreaService.Instance.StorageAreas;
            InputDetailStyleFormatCondition cn;
            foreach (var item in _importDataStruct)
            {
                cn = new InputDetailStyleFormatCondition(this, preInputForm.CompanyId, preInputForm.OrderId);
                cn.OnCheckValue += new CheckValue(cn_OnCheckValue);
                cn.Appearance.BackColor = Color.Red;
                cn.Appearance.ForeColor = Color.White;
                ImportingGridView.FormatConditions.Add(cn);
            }
            ImportingGridView.BestFitColumns();

        }

        void cn_OnCheckValue(string key, ValidateValue val)
        {
            if (validateResult.ContainsKey(key))
            {
                validateResult[key] = val;
            }
            else
            {
                validateResult.Add(key, val);
            }
        }

     
        public override bool CheckData(DataTable srcData)
        {
            bool result = true;
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("不能导入，数据验证失败");

            foreach (var item in validateResult.Values)
            {
                if (item.ValidateReslut == false)
                {
                    sb.AppendLine(item.Message);

                    result = false;
                }
            }
            if (!result)
            {
                ShowWarning(sb.ToString());
            }
            return result;
        }
        public override void ImportToDataBase(DataTable srcData, List<ImportDataInfo> dataStruct)
        {
            List<InputOrderDetail> InputOrderDetailsAdding = new List<InputOrderDetail>();
            foreach (DataRow item in arrangeSrcData.Rows)
            {
                InputOrderDetail detail = new InputOrderDetail();
                detail.CompanyId = preInputForm.CompanyId;
                detail.InputOrderId=preInputForm.OrderId;
                foreach (ImportDataInfo datainfo in dataStruct)
                {
                    if (datainfo.DestField == "ProductId")
                    {

                        detail.ProductId = GetProduct(item[datainfo.SrcField].TrytoString()).Id;
                    }
                    else if(datainfo.DestField == "StorageAreaId")
                    {
                        StorageArea  area= GetStorageArea(item[datainfo.SrcField].TrytoString());
                        if (area != null)
                        {
                            detail.StorageAreaId = area.Id;
                        }
                    }
                    else
                    {
                        CommonUtil.SetProperValue(item, datainfo, ref detail);
                    }
                }
                InputOrderDetailsAdding.Add(detail);
            }
            InputOrderService.Instance.CreateDetail(InputOrderDetailsAdding);
            ShowMessage("入库明细导入成功!");
            this.Updated = true;
        }
        private Product GetProduct(string productNumber1)
        {
            return this.Products.FirstOrDefault(o => o.ProductNumber1 == productNumber1);
        }
        public StorageArea GetStorageArea(string areaName)
        {
            return this.StorageAreas.SingleOrDefault(o => o.库位编号.Equals(areaName));
        }
    }
    public delegate void CheckValue(string key, ValidateValue val);
    public class InputDetailStyleFormatCondition : StyleFormatCondition
    {
        public event CheckValue OnCheckValue;
        ImportInputDetails importForm;
        int companyId;
        int orderId;
        public InputDetailStyleFormatCondition(ImportInputDetails form, int company,int order)
            : base(FormatConditionEnum.Equal)
        {
            importForm = form;
            companyId = company;
            orderId = order;
        }
        public override bool CheckValue(object column, object val, object row)
        {
            //此处需要优化性能
            bool result= false;
            ValidateValue validateValue = new ValidateValue();
            string message = string.Empty;
            GridColumn gc = column as GridColumn;
            if (gc.Name.Contains("ProductId"))
            {
                if (!ProductService.Instance.HasProduct(companyId, val.TrytoString()))
                {
                    message = string.Format("商品：【{0}】不存在！", val);
                    result = true;
                }
            }
            if (gc.Name.Contains("ProductDate"))
            {
                DateTime date = DateTime.MinValue;
                if (!string.IsNullOrWhiteSpace(val.TrytoString()))
                {
                    if (!DateTime.TryParse(val.TrytoString(), out date))
                    {
                        message = "生产日期格式错误";
                        result = true;
                    }
                }
            }
            if (gc.Name.Contains("InputCount"))
            {
                int count = 0;
                if (!int.TryParse(val.TrytoString(), out count))
                {
                    message = "入库数量必须为数字";
                    result = true;
                }
            }
            if (OnCheckValue != null)
            {
                validateValue.ValidateReslut = !result;
                validateValue.Message = message;
                OnCheckValue(gc.Name + row.TrytoString(), validateValue);
            }
            return result;;
        }
        

    }
}