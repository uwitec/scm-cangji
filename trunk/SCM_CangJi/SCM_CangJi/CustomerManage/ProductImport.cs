using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
using DevExpress.XtraEditors;
using SCM_CangJi.WareHouseManage;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
using SCM_CangJi.BLL.Services;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using SCM_CangJi.DAL;
using System.Reflection;
using SCM_CangJi.Commom;
namespace SCM_CangJi.CustomerManage
{
    public partial class ProductImport : ImportDataBase
    {
        Dictionary<string, ValidateValue> validateResult;
        CompanyList companyForm;
        IEnumerable<Product> AllProducts;
        public ProductImport(IntPtr formObject, DataSet data, List<ImportDataInfo> importDataStruct)
            : base(formObject, data, importDataStruct)
        {
            this.myLog = SCM_CangJi.BLL.MyLogManager.GetLogger(this.GetType());
            InitializeComponent();
            this.Text = "商品信息导入";
          
            companyForm = Control.FromHandle(_formObject) as CompanyList;
            this.Updated = false;
            validateResult = new Dictionary<string, ValidateValue>();
            this.Load += new EventHandler(ProductImport_Load);
        }

      



        void ProductImport_Load(object sender, EventArgs e)
        {
            ProductStyleFormatCondition cn;
            AllProducts = ProductService.Instance.GetProductsEntities(companyForm.CompanyId); 
            foreach (var item in _importDataStruct)
            {
                //cn = new ProductStyleFormatCondition(this, companyForm.CompanyId);
                //cn.OnCheckValue += new CheckValue(cn_OnCheckValue);
                //cn.Appearance.BackColor = Color.Red;
                //cn.Appearance.ForeColor = Color.White;
                //ImportingGridView.FormatConditions.Add(cn);
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

        #region 放弃
        //void ImportingGridView_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        //{
        //    ColumnView view = sender as ColumnView;
        //    DataRow row = ((e.Row) as DataRowView).Row;
        //    DataRowView rowview = (e.Row) as DataRowView;
        //    #region 数据有效性

        //    #region 商品是否存在
        //    e.Valid = CheckRow(e.RowHandle, view);
        //    #endregion
        //    #endregion

        //}
        //void ImportingGridView_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        //{
        //    if (e.Valid == false && this.ImportingGridView.FocusedColumn.FieldName == "品号(ProductNumber1)")
        //    {
        //        e.ErrorText = "该品号已经存在！";

        //    }
        //}

        //void ImportingGridView_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        //{
        //    if (XtraMessageBox.Show("您所填写的内容不符合规则\n　要放弃您刚才对此项所做的更改吗？", "您所编辑的内容不符合规则", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        e.ExceptionMode = ExceptionMode.Ignore;
        //    }
        //    else
        //    {
        //        e.ExceptionMode = ExceptionMode.NoAction;
        //    }
        //}


        //private bool CheckRow(int RowHandle, ColumnView view)
        //{

        //    bool checkResult = true;
        //    string productNumber1 = view.GetRowCellValue(RowHandle, "品号(ProductNumber1)").TrytoString();
        //    string prductTypeName = view.GetRowCellValue(RowHandle, "商品类型(ProductTypeId)").TrytoString();
        //    if (ProductService.Instance.HasProduct(companyForm.CompanyId, productNumber1))
        //    {
        //        GridColumn gc = view.Columns["品号(ProductNumber1)"];

        //        ImportingGridView.SetColumnError(gc, "该品号已经存在");
        //        checkResult = false;
        //    }
        //    if (checkResult)
        //    {
        //        if (!ProductTypeService.Instance.HasProductType(prductTypeName))
        //        {
        //            GridColumn gc = view.Columns["商品类型(ProductTypeId)"];
        //            ImportingGridView.SetColumnError(gc, "商品类型不存在");
        //            checkResult = false;
        //        }
        //    }
        //    result = checkResult;
        //    return checkResult;

        //} 
        #endregion

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
            List<Product> productListAdding = new List<Product>();
            foreach (DataRow item in arrangeSrcData.Rows)
            {
                if (this.AllProducts.FirstOrDefault(o => o.ProductNumber1 == item[dataStruct.First(d=>d.DestField=="ProductNumber1").SrcField].TrytoString()) != null)
                {
                    continue;   
                }
                Product p = new Product();
                p.CompanyId = companyForm.CompanyId;
                foreach (ImportDataInfo datainfo in dataStruct)
                {
                    if (datainfo.DestField == "ProductTypeId")
                    {

                        p.ProductTypeId = ProductTypeService.Instance.GetProductType(item[datainfo.SrcField].TrytoString()).Id;
                    }
                    else
                    {
                        CommonUtil.SetProperValue(item, datainfo, ref p);
                    }
                }
                productListAdding.Add(p);
            }
            ProductService.Instance.Create(productListAdding);
            myLog.Info("商品导入成功");

            ShowMessage("商品导入成功!");
            this.Updated = true;
        }
       
    }

    public delegate void CheckValue(string key, ValidateValue val);
    public class ProductStyleFormatCondition : StyleFormatCondition
    {
        public event CheckValue OnCheckValue;
        ProductImport importForm;
        int companyId;
        public ProductStyleFormatCondition(ProductImport form ,int company)
            : base(FormatConditionEnum.Equal)
        {
            importForm = form;
            companyId = company;
            
        }
        public override bool CheckValue(object column, object val, object row)
        {
            //此处需要优化性能
            bool result= false;
            ValidateValue validateValue = new ValidateValue();
            string message = string.Empty;
            GridColumn gc = column as GridColumn;
            if (gc.Name.Contains("ProductNumber1"))
            {
                if (ProductService.Instance.HasProduct(companyId, val.TrytoString()))
                {
                    message = string.Format("商品号：【{0}】已存在！", val);
                    result = true;
                }
            }
            if (gc.Name.Contains("ProductTypeId"))
            {
                if (!ProductTypeService.Instance.HasProductType(val.TrytoString()))
                {
                    message = string.Format("商品类型：【{0}】不存在！", val);
                    result = true;
                }
            }
            if (gc.Name.Contains("SecurityCount"))
            {
                int count = 0;
                if (!int.TryParse(val.TrytoString(),out count))
                {
                    message = "安全库存必须为数字";
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