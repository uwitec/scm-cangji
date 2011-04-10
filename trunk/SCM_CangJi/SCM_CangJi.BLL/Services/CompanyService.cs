using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;

namespace SCM_CangJi.BLL.Services
{
    public class CompanyService : BaseService<CompanyService>
    {
        public void Create(Company company)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
                {
                    context.Companies.InsertOnSubmit(company);
                    context.SubmitChanges();
                });
        }
        public object GetAllCompany()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                result = (from c in context.Companies
                          select new
                          {
                              c.Id,
                              c.CompanyName,
                              c.CompanyAddress,
                              CompanyType=(CompanyType)c.CompanyType
                          }).ToList();
            });
            return result;
        }

        public Company GetCompany(int companyId)
        {
            Company result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                result = context.Companies.SingleOrDefault(o => o.Id == companyId);
            });
            return result;
        }

        public void Update(Company company)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var c = context.Companies.SingleOrDefault(o => o.Id == company.Id);
                c.CompanyAddress = company.CompanyAddress;
                c.CompanyName = company.CompanyName;
                c.CompanyType = company.CompanyType;
                context.SubmitChanges();
            });
        }

        public bool Delete(int companyid)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var result = context.Companies.SingleOrDefault(o => o.Id == companyid);
                context.Companies.DeleteOnSubmit(result);
                context.SubmitChanges();
            });
            return true;
        }
    }
}
