using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SCM_CangJi.DAL;
using System.Data.Linq;
namespace SCM_CangJi.BLL.Services
{
    public class ProductStorageService:BaseService<ProductStorageService>
    {
        public object GetProducStorages(int companyId)
        {
            throw new NotImplementedException();
        }
   
        public List<AssignedDeliveryOrderDetail> AutoAssign(int orderId)
        {
            List<AssignedDeliveryOrderDetail> result = new List<AssignedDeliveryOrderDetail>();
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                List<Queue<ProductStorage>> assigningList=new List<Queue<ProductStorage>>();
                List<ProductStorage> assignedList=new List<ProductStorage>();

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
                int index = 0;
                
               bool AssignedCompleted= BuildDeliveryDetails(index, ref hasAssignedCount, detail, db, ref result);
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
                            AssignCount = -(detail.DeliveryCount - hasAssignedCount),
                            DeliveryOrderId = detail.DeliveryOrderId,
                            DeliveryCount = detail.DeliveryCount,
                            InputInvoice = detail.InputInvoice,
                            LotsNumber = detail.LotsNumber,
                            ProductDate = detail.ProductDate,
                            ProductId = detail.ProductId,
                            ProductStorageId = 0,
                            //StorageAreaId = "无",
                            CurrentProductNumber = "",
                            IsSucess=false
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
            var productStorages = db.ProductStorages.Where(o => o.ProductId == detail.ProductId&&o.UsableCount>0).OrderBy(o => o.EntryDate).Skip(10 * index).Take(10);
            bool AssignedCompleted =false;
            int perhasAssignedCount = 0;
            //还需要的分配数量
            foreach (var item in productStorages)
            {
                //还需数量大于已分配数量时，继续分配
                int remainAssignCount = detail.DeliveryCount - perhasAssignedCount;
                if (remainAssignCount > 0)
                {
                    //该条可用库存数量足够
                    if (item.UsableCount  >= remainAssignCount)
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
                            StorageAreaId=item.AreaId,
                            CurrentProductNumber=item.CurrentProductNumber
                        });
                        hasAssignedCount += remainAssignCount;
                        perhasAssignedCount += remainAssignCount;
                        AssignedCompleted=true;
                        break;
                    }
                    else//该条库存数量不足
                    {
                        result.Add(new AssignedDeliveryOrderDetail()
                        {
                             AssignCount=perhasAssignedCount==0?(item.UsableCount-hasAssignedCount):item.UsableCount,
                             DeliveryOrderId=detail.DeliveryOrderId,
                             DeliveryCount=detail.DeliveryCount,
                             InputInvoice=detail.InputInvoice,
                             LotsNumber = item.LotsNumber,
                             ProductDate = item.ProductDate,
                             ProductId=detail.ProductId,
                             ProductStorageId=item.Id,
                             StorageAreaId=item.AreaId,
                            CurrentProductNumber=item.CurrentProductNumber
                        });
                        perhasAssignedCount += (item.UsableCount );
                        hasAssignedCount += (item.UsableCount );
                        continue;
                    }
                }
                else
                {
                    AssignedCompleted = true;
                    break;
                }
               
            }
            if (productStorages.Count() > 0)
            {
                index++;
                BuildDeliveryDetails(index, ref hasAssignedCount, detail, db, ref result);
            }
            return AssignedCompleted;
        }

        public object GetCurrentStorages()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                result = (from ps in db.ProductStorages
                          orderby ps.EntryDate ascending
                          select new
                          {
                              公司名 = ps.Company.CompanyName,
                              品名 = ps.Product.ProductChName,
                              品号 = ps.Product.ProductNumber1,
                              条形码 = ps.Product.BarCode,
                              现品号 = ps.CurrentProductNumber,
                              当前库存数 = ps.CurrentCount,
                              实际可用数量 = ps.UsableCount,
                              库位 = ps.StorageArea.StorageRack.Storage.仓库名称 + "--" + ps.StorageArea.StorageRack.RackName + "--" + ps.StorageArea.库位编号
                          }).ToList();
            });
            return result;
        }

        public string GetArea(int? areaId)
        {
            if (!areaId.HasValue)
                return "未分配";
            string result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var ps = db.StorageAreas.SingleOrDefault(o => o.Id == areaId);

                result = ps.StorageRack.Storage.仓库名称 + "--" + ps.StorageRack.RackName + "--" + ps.库位编号;
            });
            return result;
        }
    }
}
