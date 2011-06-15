using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;
using System.Data;
using System.Data.Linq;
using System.Data.Common;
using System.Collections;
using System.ComponentModel;

namespace SCM_CangJi.BLL
{
    public static class Extentions
    {
        public static string TrytoString(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            return obj.ToString();
        }
        public static object ToViewModel(this DeliveryOrderDetail o)
        {
            return new
            {
                o.AssignCount,
                o.DeliveryCount,
                o.DeliveryOrder.DeliveryOrderNumber,
                o.DeliveryOrderId,
                o.Id,
                ProductChName = o.Product == null ? "" : o.Product.ProductChName,
                ProductEngName = o.Product == null ? "" : o.Product.ProductEngName,
                o.Product.ProductNumber1,
                o.Product.ProductNumber2,
                CurrentProductNumber = o.ProductStorage == null ? "" : o.ProductStorage.CurrentProductNumber,
                ProductType = o.Product == null ? "" : o.Product.ProductType.ToString(),
                SecurityCount = o.ProductStorage == null ? 0 : o.Product.SecurityCount,
                Area = o.ProductStorage == null ? 0 : o.ProductStorage.AreaId,
                Spec = o.Product != null ? o.Product.Spec : "",
                o.Product,
                ProductStorage = o.ProductStorage != null ? o.ProductStorage : null,
                ProductDate = o.ProductDate,
                LotsNumber = o.LotsNumber
            };
        }


        public static DataTable ToDataTable(this IQueryable source, DataContext db)
        {
            try
            {
                //将 LinqToSQL查询传递给 GetCommand（）以获取DbCommand对象
                DbCommand cmd = db.GetCommand(source);
                //打开数据库链接，这里可以进一步扩展，比如传递进来自己定义的继承自 DbConnection 的对象
                if (db.Connection.State == ConnectionState.Closed)
                    db.Connection.Open();
                //声明 DataTable 对象
                DataTable dt = new DataTable();
                //调用DataTable 对象的 Load方法 ，从 DbDataReader 对象加载数据。
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            finally
            {

                //关闭DbConnection 链接
                db.Connection.Close();
            }

        }

        public static object GetValue(this object item,string propertyName)
        {
            PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(item);
            PropertyDescriptor property = pdc.Find(propertyName, true);
            return property.GetValue(item);
        }
    }

    public class ProductImportInfo : IDataErrorInfo
    {
        Hashtable propertyErrors;
        string _productError;
        DataRow _row;
        public ProductImportInfo(DataRow row)
        {
            propertyErrors = new Hashtable();
            _row = row;
        }
        public string 中文品名 { get; set; }
        public string 英文品名 { get; set; }
        public string 品号1 { get; set; }
        public string 品号2 { get; set; }
        public string 规格 { get; set; }
        public string 条形码 { get; set; }
        public string 商品类型 { get; set; }
        #region IDataErrorInfo Members

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                return GetColumnError(columnName);
            }
        }
        public void ClearErrors()
        {
            SetColumnError("中文品名", "");
            SetColumnError("英文品名", "");
            SetColumnError("品号1", "");
            SetColumnError("品号2", "");
            SetColumnError("规格", "");
            SetColumnError("条形码", "");
            SetColumnError("商品类型", "");
            ProductError = "";
        }

        //Sets an error for an item's property
        public void SetColumnError(string elem, string error)
        {
            if (propertyErrors.ContainsKey(elem))
            {
                if ((string)propertyErrors[elem] == error) return;
                propertyErrors[elem] = error;
            }
        }
        //Gets an error for an item's property
        public string GetColumnError(string elem)
        {
            if (propertyErrors.ContainsKey(elem))
                return (string)propertyErrors[elem];
            else
                return "";
        }
        //Returns an error description set for the current item
        string IDataErrorInfo.Error
        {
            get { return ProductError; }
        }
        //Gets and sets an error for the current item
        public string ProductError
        {
            get { return _productError; }
            set
            {
                if (_productError == value) return;
                _productError = value;
            }
        }
        #endregion
    }
}
