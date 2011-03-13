using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;

namespace SCM_CangJi.BLL.Services
{
    public class ProductService:BaseService<ProductService>
    {
        public object GetProducts(int companyId)
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
            {
                var company = context.Companies.SingleOrDefault(o => o.Id == companyId);
                result = (from p in company.Products
                          select new
                          {
                              p.BarCode,
                              p.Company.CompanyName,
                              p.CompanyId,
                             CurrencyName= p.CurrencyUnit==null?"":p.CurrencyUnit.CurrencyName,
                              ProductId= p.Id,
                              p.Id,
                              p.LayeredCount,
                              p.Height,
                              p.Length,
                              p.PreWorningDays,
                              p.ProductChName,
                              p.ProductEngName,
                              p.ProductNumber1,
                              p.ProductNumber2,
                              ProductTypeName= p.ProductType==null?"": p.ProductType.Name,
                              p.SecurityCount,
                              p.ShelfLife,
                              p.UnitPrice,
                              p.Spec,
                              p.Volume,
                              p.Weight,
                          }).ToList();

            });
            return result;
        }

        public bool Delete(int productId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var product = db.Products.SingleOrDefault(o => o.Id == productId);
                db.Products.DeleteOnSubmit(product);
                db.SubmitChanges(0);
            });
            return true;
        }

        public Product GetProduct(int productId)
        {
            Product product = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                product = db.Products.SingleOrDefault(o => o.Id == productId);
            });
            return product;
        }

        public void Update(Product product)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var p = db.Products.SingleOrDefault(o => o.Id == product.Id);
                p.BarCode = product.BarCode;
                p.CompanyId = product.CompanyId;
                p.CurrencyUnitId = product.CurrencyUnitId;
                p.Height = product.Height;
                p.LayeredCount = product.LayeredCount;
                p.Length = product.Length;
                p.PreWorningDays = product.PreWorningDays;
                p.ProductChName = product.ProductChName;
                p.ProductEngName = product.ProductEngName;
                p.ProductNumber1 = product.ProductNumber1;
                p.ProductNumber2 = product.ProductNumber2;
                p.ProductTypeId = product.ProductTypeId;
                p.SecurityCount = product.SecurityCount;
                p.ShelfLife = product.ShelfLife;
                p.Spec = product.Spec;
                p.UnitPrice = product.UnitPrice;
                p.Volume = product.Volume;
                p.Weight = product.Weight;
                p.Width = product.Width;
                db.SubmitChanges();
            });
        }

        public void Create(Product product)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
           {
               db.Products.InsertOnSubmit(product);
               db.SubmitChanges(0);
           });
        }
    }
}
