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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
                {
                    context.Companies.InsertOnSubmit(company);
                    context.SubmitChanges();
                });
        }
        public object GetAllCompany()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
            {
                result = (from c in context.Companies
                          select new
                          {
                              c.CompanyName,
                              c.CompnayAddress,
                              CompanyType=(CompanyType)c.CompanyType
                          }).ToList();
            });
            return result;
        }
    }
}
