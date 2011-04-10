using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;

namespace SCM_CangJi.BLL.Services
{
    public class ProductTypeService:BaseService<ProductTypeService>
    {
        public object GetProductTypes()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                result = (from a in context.ProductTypes
                          select new
                          {
                              a.Id,
                              类型名称=a.Name,
                          }).ToList();

            });
            return result;
        }
        public void Create(ProductType prodtuctType)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                context.ProductTypes.InsertOnSubmit(prodtuctType);
                context.SubmitChanges();

            });
        }
        public void Delete(int Id)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var prodtuctType = context.ProductTypes.SingleOrDefault(o => o.Id == Id);
                context.ProductTypes.DeleteOnSubmit(prodtuctType);
                context.SubmitChanges();

            });
        }
        public void Update(int Id, string name)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var prodtuctType = context.ProductTypes.SingleOrDefault(o => o.Id == Id);
                prodtuctType.Name = name;
                context.SubmitChanges();

            });
        }
        public ProductType GetProductType(string name)
        {
            return Using<CangJiDataDataContext, ProductType>(new CangJiDataDataContext(this.connectionString), context =>
              {
                  return context.ProductTypes.SingleOrDefault(o => o.Name == name.Trim());
              });
        }
        public bool HasProductType(string name)
        {
            return GetProductType(name) != null;
        }
    }
}
