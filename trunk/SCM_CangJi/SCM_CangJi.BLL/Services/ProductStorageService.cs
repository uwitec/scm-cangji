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
                    int index = 0;
                    BuildDeliveryDetails(groupedDetails, db, ref result);

                });
                
            });
            return result;
        }

        private void BuildDeliveryDetails(IGrouping<int, DeliveryOrderDetail> groupedDetails, CangJiDataDataContext db, ref List<AssignedDeliveryOrderDetail> result)
        {
            //已分配的数量
            int hasAssignedCount = 0;
            foreach (var detail in groupedDetails)
            {
                int index = 0;
                
                BuildDeliveryDetails(index, ref hasAssignedCount, detail, db, ref result);
                //已分配的数量
                if (detail.DeliveryCount == hasAssignedCount)
                {
                    continue;
                }
                else
                {
                    //库存不足的处理
                }
                hasAssignedCount = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="hasAssignedCount">已经分配的数量</param>
        /// <param name="detail"></param>
        /// <param name="db"></param>
        /// <param name="result"></param>
        private void BuildDeliveryDetails(int index, ref int hasAssignedCount, DeliveryOrderDetail detail, CangJiDataDataContext db, ref List<AssignedDeliveryOrderDetail> result)
        {
            var productStorages = db.ProductStorages.Where(o => o.ProductId == detail.ProductId).OrderBy(o => o.EntryDate).Skip(10 * index).Take(10);
            bool AssignedCompleted = productStorages.Count() <= 0;
            //还需要的分配数量
            foreach (var item in productStorages)
            {
                //还需数量大于已分配数量时，继续分配
                int remainAssignCount = detail.DeliveryCount - hasAssignedCount;
                if (remainAssignCount > 0)
                {
                    //该条库存数量足够
                    if (item.CurrentCount >= remainAssignCount)
                    {
                        result.Add(new AssignedDeliveryOrderDetail()
                        {
                            AssignCount = remainAssignCount,
                            DeliveryOrderId = detail.DeliveryOrderId,
                            DeliveryCount = detail.DeliveryCount,
                            InputInvoice = detail.InputInvoice,
                            LotsNumber = detail.LotsNumber,
                            ProductDate = detail.ProductDate,
                            ProductId = detail.ProductId,
                            ProductStorageId = item.Id
                        });
                        hasAssignedCount += remainAssignCount;
                        AssignedCompleted=true;
                        break;
                    }
                    else//该条库存数量不足
                    {
                        result.Add(new AssignedDeliveryOrderDetail()
                        {
                             AssignCount=item.CurrentCount,
                             DeliveryOrderId=detail.DeliveryOrderId,
                             DeliveryCount=detail.DeliveryCount,
                             InputInvoice=detail.InputInvoice,
                             LotsNumber=detail.LotsNumber,
                             ProductDate=detail.ProductDate,
                             ProductId=detail.ProductId,
                             ProductStorageId=item.Id
                        });
                        hasAssignedCount += item.CurrentCount;
                        continue;
                    }
                }
                else
                {
                    AssignedCompleted = true;
                    break;
                }
               
            }
            if (!AssignedCompleted)
            {
                index++;
                BuildDeliveryDetails(index, ref hasAssignedCount, detail, db, ref result);
            }
           
        }
    }
}
