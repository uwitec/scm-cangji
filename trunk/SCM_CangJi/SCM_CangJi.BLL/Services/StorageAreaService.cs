using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;

namespace SCM_CangJi.BLL.Services
{
    public class StorageAreaService:BaseService<StorageAreaService>
    {

        public  object GetSrorageArea()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
            {
                result = (from a in context.StorageAreas
                          select new
                          {
                              a.库位编号,
                              a.Id,
                              a.StorageRack.Storage.仓库编号,
                              a.StorageRack.Storage.仓库名称
                          }).ToList();

            });
            return result;
        }
    }
}
