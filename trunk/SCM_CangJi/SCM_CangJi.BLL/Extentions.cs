using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;
using System.Data;
using System.Data.Linq;
using System.Data.Common;

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
    }
}
