using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SCM_CangJi.DAL;
using System.Data.Linq;
using SCM_CangJi.Lib;
namespace SCM_CangJi.BLL.Services
{
    public class ProductStorageService:BaseService<ProductStorageService>
    {
        public object GetProducStorages(int companyId)
        {
            throw new NotImplementedException();
        }

        #region 自动分配
        public List<AssignedDeliveryOrderDetail> AutoAssign(int orderId)
        {
            List<AssignedDeliveryOrderDetail> result = new List<AssignedDeliveryOrderDetail>();
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                List<Queue<ProductStorage>> assigningList = new List<Queue<ProductStorage>>();
                List<ProductStorage> assignedList = new List<ProductStorage>();

                db.DeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId).GroupBy(o => o.ProductId).ToList().ForEach(groupedDetails =>
                {
                    //针对每种待分配商品
                    BuildDeliveryDetails(groupedDetails, db, ref result);

                });

            });
            return result;
        }

        private bool BuildDeliveryDetails(IGrouping<int, DeliveryOrderDetail> groupedDetails, CangJiDataDataContext db, ref List<AssignedDeliveryOrderDetail> result)
        {
            //已分配的数量
            int hasAssignedCount = 0;
            bool isSucess = true;
            foreach (var detail in groupedDetails)
            {
                if (detail.Product.ProductNumber1 == "10101010101151")
                {
                    System.Diagnostics.Debug.Assert(true);
                }
                int index = 0;

                bool AssignedCompleted = BuildDeliveryDetails(index, ref hasAssignedCount, detail, db, ref result);
                //已分配的数量
                if (detail.DeliveryCount == hasAssignedCount)
                {
                    continue;
                }
                else
                {
                    if (!AssignedCompleted)
                    {
                        isSucess = false;
                        //库存不足，缺失数量显示
                        result.Add(new AssignedDeliveryOrderDetail()
                        {
                            AssignCount = 0,//-(detail.DeliveryCount - hasAssignedCount),
                            DeliveryOrderId = detail.DeliveryOrderId,
                            DeliveryCount = detail.DeliveryCount,
                            InputInvoice = detail.InputInvoice,
                            LotsNumber = detail.LotsNumber,
                            ProductDate = detail.ProductDate,
                            ProductId = detail.ProductId,
                            CustomerPo = detail.CustomerPo,
                            //ProductStorageId = null,
                            //StorageAreaId = "无",
                            CurrentProductNumber = "",
                            IsSucess = false
                        });
                    }
                }
                hasAssignedCount = 0;
            }
            return isSucess;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="hasAssignedCount">已经分配的数量</param>
        /// <param name="detail"></param>
        /// <param name="db"></param>
        /// <param name="result"></param>
        private bool BuildDeliveryDetails(int index, ref int hasAssignedCount, DeliveryOrderDetail detail, CangJiDataDataContext db, ref List<AssignedDeliveryOrderDetail> result)
        {
            var condition = ConditionBuilder.True<ProductStorage>();
            condition = condition.And(o => o.ProductId == detail.ProductId && o.UsableCount > 0
                && o.StorageArea.StorageRack.IsLocked == false);
            if (!string.IsNullOrWhiteSpace(detail.InputInvoice))
            {
                condition = condition.And(o => o.InputOrderDetail.InputOrder.Invoice == detail.InputInvoice);
            }
            if (!string.IsNullOrWhiteSpace(detail.LotsNumber))
            {
                condition = condition.And(o => o.LotsNumber.Trim() == detail.LotsNumber);
            }
            var productStorages = db.ProductStorages.Where(condition)
                .OrderBy(o => o.EntryDate).Skip(10 * index).Take(10);
            bool AssignedCompleted = false;
            int perhasAssignedCount = 0;
            //还需要的分配数量
            foreach (var item in productStorages)
            {
                //还需数量大于已分配数量时，继续分配
                int remainAssignCount = detail.DeliveryCount - hasAssignedCount;
                if (remainAssignCount > 0)
                {
                    //该条可用库存数量足够
                    if (item.UsableCount >= remainAssignCount)
                    {
                        result.Add(new AssignedDeliveryOrderDetail()
                        {
                            AssignCount = remainAssignCount,
                            DeliveryOrderId = detail.DeliveryOrderId,
                            DeliveryCount = detail.DeliveryCount,
                            InputInvoice = detail.InputInvoice,
                            LotsNumber = item.LotsNumber,
                            ProductDate = item.ProductDate,
                            ProductId = detail.ProductId,
                            ProductStorageId = item.Id,
                            StorageAreaId = item.AreaId,
                            CustomerPo = detail.CustomerPo,
                            CurrentProductNumber = item.CurrentProductNumber
                        });
                        hasAssignedCount += remainAssignCount;
                        perhasAssignedCount += remainAssignCount;
                        AssignedCompleted = true;
                        break;
                    }
                    else//该条库存数量不足
                    {
                        AssignedDeliveryOrderDetail assignDetail = new AssignedDeliveryOrderDetail()
                        {
                            AssignCount = hasAssignedCount == 0 ? (item.UsableCount - hasAssignedCount) : item.UsableCount,
                            DeliveryOrderId = detail.DeliveryOrderId,
                            DeliveryCount = detail.DeliveryCount,
                            InputInvoice = detail.InputInvoice,
                            LotsNumber = item.LotsNumber,
                            ProductDate = item.ProductDate,
                            ProductId = detail.ProductId,
                            ProductStorageId = item.Id,
                            StorageAreaId = item.AreaId,
                            CustomerPo = detail.CustomerPo,
                            CurrentProductNumber = item.CurrentProductNumber
                        };
                        result.Add(assignDetail);
                        perhasAssignedCount += assignDetail.AssignCount;// (item.UsableCount );
                        hasAssignedCount += assignDetail.AssignCount;//(item.UsableCount );
                        continue;
                    }
                }
                else
                {
                    AssignedCompleted = true;
                    break;
                }

            }
            if (productStorages.Count() > 0 && AssignedCompleted == false)
            {
                index++;
                AssignedCompleted = BuildDeliveryDetails(index, ref hasAssignedCount, detail, db, ref result);
            }
            return AssignedCompleted;
        }

        #endregion

        #region 数据获取
        public object GetCurrentStorages(bool incloudZero)
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var conditon = ConditionBuilder.True<ProductStorage>();
                if (incloudZero == false)
                {
                    conditon = conditon.And(o => o.CurrentCount > 0);
                }
                result = (from ps in db.ProductStorages.Where(conditon)
                          where ps.Status==(int)StoreStatus.Avilable
                          orderby ps.EntryDate ascending
                          select new
                          {
                              公司名 = ps.Company.CompanyName,
                              品名 = ps.Product.ProductChName,
                              品号 = ps.Product.ProductNumber1,
                              条形码 = ps.Product.BarCode,
                              现品号 = ps.CurrentProductNumber,
                              入库发票号 = ps.InputOrderDetail.InputOrder.Invoice,
                              当前库存数 = ps.CurrentCount,
                              实际可用数量 = ps.UsableCount,
                              库位 = ps.StorageArea.StorageRack.RackName + "--" + ps.StorageArea.库位编号
                          }).ToList();
            });
            return result;
        }

        public string GetArea(int? areaId)
        {
            if (!areaId.HasValue)
                return "未分配";
            string result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var ps = db.StorageAreas.SingleOrDefault(o => o.Id == areaId);
                if (ps == null)
                {
                    result = "未分配";
                }
                else
                {
                    result = ps.StorageRack.RackName + "--" + ps.库位编号;
                }
            });
            return result;
        }

        public int GetProductStorageWoringCount()
        {
            return Using<CangJiDataDataContext,int>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var products = db.ProductStorages.Where(o => o.ProductDate.HasValue
                    && o.Product.PreWorningDays > 0
                    && DateTime.Now.Date.AddDays(o.Product.PreWorningDays) > o.ProductDate.Value.Date
                    && o.Status == (int)StoreStatus.Avilable
                    && o.CurrentCount > 0);
                return products.Count();
            });
        }
        public object GetProductStorageWoring()
        {
            return Using<CangJiDataDataContext, object>(new CangJiDataDataContext(this.connectionString), db =>
            {
                object products = (from ps in db.ProductStorages.Where(o => o.ProductDate.HasValue
                    &&o.Product.PreWorningDays>0
                    &&DateTime.Now.Date.AddDays(o.Product.PreWorningDays)>o.ProductDate.Value.Date
                    &&o.Status==(int)StoreStatus.Avilable
                    &&o.CurrentCount>0)
                    select new
                          {
                              公司名 = ps.Company.CompanyName,
                              品名 = ps.Product.ProductChName,
                              品号 = ps.Product.ProductNumber1,
                              条形码 = ps.Product.BarCode,
                              现品号 = ps.CurrentProductNumber,
                              入库发票号 = ps.InputOrderDetail.InputOrder.Invoice,
                              当前库存数 = ps.CurrentCount,
                              实际可用数量 = ps.UsableCount,
                              生产日期=ps.ProductDate,
                              到期天数=(ps.ProductDate.Value.Date-DateTime.Now.Date).Days,
                              库位 = ps.StorageArea.StorageRack.RackName + "--" + ps.StorageArea.库位编号
                          }).ToList();
                return products;
            });
        }
        #endregion

        #region 库存变更

        public DataTable GetCurrentStoragesDT(bool incloudZero)
        {
            DataTable result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var conditon = ConditionBuilder.True<ProductStorage>();
                if (incloudZero == false)
                {
                    conditon = conditon.And(o => o.CurrentCount > 0);
                }
                result = (from ps in db.ProductStorages.Where(conditon)
                          where ps.Status == (int)StoreStatus.Avilable
                          orderby ps.EntryDate ascending
                          select new
                          {
                              ps.Id,
                              CompanyName = ps.Company.CompanyName,
                              ProductChName = ps.Product.ProductChName,
                              ProductNumber1 = ps.Product.ProductNumber1,
                              BarCode = ps.Product.BarCode,
                              CurrentProductNumber = ps.CurrentProductNumber,
                              Invoice = ps.InputOrderDetail.InputOrder.Invoice,
                              CurrentCount = ps.CurrentCount,
                              UsableCount = ps.UsableCount,
                              AreaId = ps.AreaId
                          }).ToDataTable(db);
            });
            return result;
        }

        public DataTable GetChangingStorages()
        {
            DataTable result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                result = (from psc in db.ProductStorageChanges
                          where psc.ProductStorage.Status == (int)StoreStatus.Changing
                          &&psc.Status==(int)ChangeStatus.Changing
                          orderby psc.ProductStorage.EntryDate ascending
                          select new
                          {
                              psc.ID,
                              公司名 = psc.ProductStorage.Company.CompanyName,
                              品名 = psc.ProductStorage.Product.ProductChName,
                              品号 = psc.ProductStorage.Product.ProductNumber1,
                              现品票号 = psc.ProductStorage.CurrentProductNumber,
                              入库发票 = psc.ProductStorage.InputOrderDetail.InputOrder.Invoice,
                              当前库存_修改 = psc.CurrentCount,
                              当前库存_原始 = psc.CurrentCount_Org,
                              可用库存_修改 = psc.UsableCount,
                              可用库存_原始 = psc.UsableCount_Org,
                              原库位 = psc.ProductStorage.StorageArea.StorageRack.RackName + "--" + psc.ProductStorage.StorageArea.库位编号,
                              修改库位 = psc.StorageArea.StorageRack.RackName + "--" + psc.StorageArea.库位编号
                          }).ToDataTable(db);
            });
            return result;
        }
        public void UpdateProductStorages(List<ProductStorageChange> list)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
           {
               foreach (var item in list)
               {
                   var ps = db.ProductStorages.SingleOrDefault(o => o.Id == item.ProductStorageID);
                   if (ps != null)
                   {
                       ProductStorageChange psc = new ProductStorageChange();
                       psc.ProductStorageID = ps.Id;
                       psc.AreaId = item.AreaId;
                       psc.AreaId_Org = ps.AreaId;
                       psc.CurrentCount = item.CurrentCount;
                       psc.CurrentCount_Org = ps.CurrentCount;
                       psc.EntryDate = ps.EntryDate;
                       psc.EntryDate_Org = ps.EntryDate;
                       psc.LotsNumber = ps.LotsNumber;
                       psc.LotsNumber_Org = ps.LotsNumber;
                       psc.OriginalCount = ps.OriginalCount;
                       psc.OriginalCount_Org = ps.OriginalCount;
                       psc.ProductDate = ps.ProductDate;
                       psc.ProductDate_Org = ps.ProductDate;
                       psc.ProductStorageID = ps.Id;
                       psc.UpdateDate = DateTime.Now;
                       psc.UsableCount = item.UsableCount;
                       psc.UsableCount_Org = ps.UsableCount;
                       psc.Status = (int)ChangeStatus.Changing;
                       db.ProductStorageChanges.InsertOnSubmit(psc);
                   }
                   ps.Status = (int)StoreStatus.Changing;
               }
               db.SubmitChanges();
           });
        }

        public void ConfirmProductStorageChange(List<int> changeIds)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
           {
               foreach (var changeId in changeIds)
               {
                   var changing = db.ProductStorageChanges.SingleOrDefault(o => o.ID == changeId);
                   if (changing != null)
                   {
                       changing.ProductStorage.Status = (int)StoreStatus.Avilable;
                       changing.ProductStorage.AreaId = changing.AreaId;
                       changing.ProductStorage.CurrentCount = changing.CurrentCount;
                       changing.ProductStorage.UsableCount = changing.UsableCount;
                       changing.Status = (int)ChangeStatus.Changed;
                   }
               }
               db.SubmitChanges();
           });
        }
        public void CancelProductStorageChange(List<int> changeIds)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                foreach (var changeId in changeIds)
                {
                    var changing = db.ProductStorageChanges.SingleOrDefault(o => o.ID == changeId);
                    if (changing != null)
                    {
                        changing.ProductStorage.AreaId = changing.AreaId_Org;
                        changing.ProductStorage.CurrentCount = changing.CurrentCount_Org;
                        changing.ProductStorage.UsableCount = changing.UsableCount_Org;
                        changing.Status = (int)ChangeStatus.Changed;
                        changing.ProductStorage.Status = (int)StoreStatus.Avilable;

                    }
                }
                db.SubmitChanges();

            });
        }
        #endregion

       
    }
}
