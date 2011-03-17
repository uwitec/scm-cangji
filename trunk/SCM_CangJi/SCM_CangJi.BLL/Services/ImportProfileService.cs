using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
using System.Data;
namespace SCM_CangJi.BLL.Services
{
    public class ImportProfileService : BaseService<ImportProfileService>
    {
        public IEnumerable<ImportProfile> GetImportProfile(OrderType orderType)
        {
            IEnumerable<ImportProfile> result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                result = db.ImportProfiles.Where(o => o.OrderType == (int)orderType).ToList();
            });
          return  result;
        }
        public DataTable GetImportProfileDT(OrderType orderType)
        {
            DataTable result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                result = db.ImportProfiles.Where(o => o.OrderType == (int)orderType).ToDataTable(db);
            });
            return result;
        }

        public bool Delete(int profileId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var result = db.ImportProfiles.SingleOrDefault(o => o.Id == profileId);
                if (result != null)
                {
                    db.ImportProfiles.DeleteOnSubmit(result);
                    db.SubmitChanges();
                }
            });
            return true;
        }
    }
}
