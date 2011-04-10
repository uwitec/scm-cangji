using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using SCM_CangJi.BLL;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
namespace SCM_CangJi.BLL.Services
{
    public class DeliveryOrderService:BaseService<DeliveryOrderService>
    {
        public object GetDeliveryOrders(DeliveryStatus status)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = (from o in db.DeliveryOrders.Where(o => status==DeliveryStatus.all||o.Status == status.ToString())
                          select new
                          {
                              o.Company.CompanyName,
                              o.CompanyId,
                              o.Id,
                              DeliveryAddress = o.DeliverAddress.Address,
                              o.DeliveryOrderNumber,
                              o.Invoice,
                              o.PreDeliveryDate,
                              o.ReachedDate,
                              o.Status
                          }).ToList();
            });
            return reslut;
        }

        public object GetDeliveryOrdersView(DeliveryStatus status)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = (from o in db.DeliveryOrders.Where(o => o.Status == status.ToString())
                          select new
                          {
                              o.Company.CompanyName,
                              o.CompanyId,
                              o.Id,
                              DeliveryAddress = o.DeliverAddress.Address,
                              o.DeliveryOrderNumber,
                              o.Invoice,
                              o.PreDeliveryDate,
                              o.ReachedDate,
                              o.Status,
                              预出库明细 = (from c in o.DeliveryOrderDetails
                                       select new
                                       {
                                           品号1 = c.Product.ProductNumber1,
                                           品号2 = c.Product.ProductNumber2,
                                           中文品名 = c.Product.ProductChName,
                                           英文品名 = c.Product.ProductEngName,
                                           规格 = c.Product.Spec,
                                           出库数量 = c.DeliveryCount,
                                           生产日期 = c.ProductDate,
                                           入库发票号 = c.InputInvoice,
                                           批号 = c.LotsNumber,
                                       }).ToList(),
                              库存分配明细 = (from c in o.AssignedDeliveryOrderDetails
                                        select new
                                        {
                                            品号1 = c.Product.ProductNumber1,
                                            品号2 = c.Product.ProductNumber2,
                                            中文品名 = c.Product.ProductChName,
                                            英文品名 = c.Product.ProductEngName,
                                            现品票号 = c.CurrentProductNumber,
                                            规格 = c.Product.Spec,
                                            出库数量 = c.DeliveryCount,
                                            分配数量 = c.AssignCount,
                                            生产日期 = c.ProductDate,
                                            入库发票号 = c.InputInvoice,
                                            批号 = c.LotsNumber,
                                            库位=GetArea(db,c.StorageAreaId)
                                        }).ToList(),
                          }).ToList();
            });
            return reslut;
        }
        public object GetAssignedDeliveryOrderDetails(int orderId)
        {
            return Using<CangJiDataDataContext, object>(new CangJiDataDataContext(this.connectionString), db =>
              {
                  object reslut = null;
                  var order = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                  reslut = (from c in order.AssignedDeliveryOrderDetails
                            select new
                            {
                                品号1 = c.Product.ProductNumber1,
                                品号2 = c.Product.ProductNumber2,
                                中文品名 = c.Product.ProductChName,
                                英文品名 = c.Product.ProductEngName,
                                规格 = c.Product.Spec,
                                现品票号 = c.CurrentProductNumber,
                                出库数量 = c.DeliveryCount,
                                分配数量 = c.AssignCount,
                                生产日期 = c.ProductDate,
                                入库发票号 = c.InputInvoice,
                                批号 = c.LotsNumber,
                                库位 = GetArea(db, c.StorageAreaId)
                            }).ToList();
                  return reslut;
              });
        }
        private string GetArea(CangJiDataDataContext db, int? StorageAreaId)
        {
            if (!StorageAreaId.HasValue)
                return "未分配";
            string result = null;

            var ps = db.StorageAreas.SingleOrDefault(o => o.Id == StorageAreaId);

            result = ps.StorageRack.Storage.仓库名称 + "--" + ps.StorageRack.RackName + "--" + ps.库位编号;
            return result; ;
        }

       
        public DataTable GetDeliveryOrderDetailsDataTable(int orderId)
        {
            DataTable reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = (from o in db.DeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId)
                          select o.ToViewModel()).ToDataTable(db);
            });
            return reslut;
        }
        public IEnumerable<DeliveryOrderDetail> GetDeliveryOrderDetails(int orderId)
        {
            IEnumerable<DeliveryOrderDetail> reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.DeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId).ToList();
            });
            return reslut;
        }
        public DeliveryOrder GetDeliveryOrder(int orderId)
        {
            DeliveryOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                reslut.DeliveryOrderDetails.Load();
            });
            return reslut;
        }
        public DeliveryOrder GetDeliveryOrderFullInfo(int orderId)
        {
            DeliveryOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                reslut.DeliveryOrderDetails.Load();
                int id= reslut.Company.Id;
                id = reslut.DeliverAddress.Id;
                reslut.AssignedDeliveryOrderDetails.Load();
            });
            return reslut;
        }
        public void Update(DeliveryOrder order)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var deliveryOrder = db.DeliveryOrders.SingleOrDefault(o => o.Id == order.Id);
                if (order.DeliveryOrderDetails != null)
                {
                    deliveryOrder.CompanyId = order.CompanyId;
                    deliveryOrder.DeliveryAddressId = order.DeliveryAddressId;
                    deliveryOrder.DeliveryOrderNumber = order.DeliveryOrderNumber;
                    deliveryOrder.Invoice = order.Invoice;
                    deliveryOrder.PreDeliveryDate = order.PreDeliveryDate;
                    deliveryOrder.ReachedDate = order.ReachedDate;
                    deliveryOrder.Status = order.Status;
                    foreach (var item in order.DeliveryOrderDetails)
                    {
                        var orderdetail = db.DeliveryOrderDetails.SingleOrDefault(o => o.Id == item.Id);
                        if (item.Id > 0)
                        {
                            orderdetail.AssignCount = item.AssignCount;
                            orderdetail.DeliveryCount = item.DeliveryCount;
                            orderdetail.ProductId = item.ProductId;
                            orderdetail.ProductDate = item.ProductDate;
                            orderdetail.InputInvoice = item.InputInvoice;
                            orderdetail.LotsNumber = item.LotsNumber;
                            orderdetail.ProductStorageId = item.ProductStorageId;
                        }
                        else
                        {
                            orderdetail = new DeliveryOrderDetail();
                            orderdetail.DeliveryCount = item.DeliveryCount;
                            orderdetail.ProductId = item.ProductId;
                            orderdetail.ProductDate = item.ProductDate;
                            orderdetail.InputInvoice = item.InputInvoice;
                            orderdetail.LotsNumber = item.LotsNumber;
                            orderdetail.ProductStorageId = item.ProductStorageId;
                            orderdetail.DeliveryOrderId = item.DeliveryOrderId;
                            db.DeliveryOrderDetails.InsertOnSubmit(orderdetail);
                        }
                    }
                }

                db.SubmitChanges();
            });
        }
        

        public void Create(DeliveryOrder deliveryOrder)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.DeliveryOrders.InsertOnSubmit(deliveryOrder);
                db.SubmitChanges();
            });
        }

        public bool Delete(int orderId, out string message)
        {
            bool reslut = true;
            string m = "删除成功";
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
             {
                 var order = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                 DeliveryStatus status=(DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), order.Status);
                 switch (status)
                 {
                     case DeliveryStatus.已出库:
                     case DeliveryStatus.已发货:
                     case DeliveryStatus.待分配库存:
                     case DeliveryStatus.已分配库存:
                     case DeliveryStatus.已送达:
                         reslut = false;
                         m = string.Format("删除失败！【0】单据不能删除",status.ToString());
                         break;
                     case DeliveryStatus.待出库:
                     case DeliveryStatus.作废:
                         db.DeliveryOrderDetails.DeleteAllOnSubmit(order.DeliveryOrderDetails);
                         db.DeliveryOrders.DeleteOnSubmit(order);
                         db.SubmitChanges();
                         break;
                 }
                 
             });
            message = m;
            return reslut;
        }

        public bool DeleteDetail(int orderdetailId, out string message)
        {
            bool reslut = true;
            string m = "删除成功";
            message = m;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var orderDetail = db.DeliveryOrderDetails.SingleOrDefault(o => o.Id == orderdetailId);
                if (orderDetail != null)
                {
                    db.DeliveryOrderDetails.DeleteOnSubmit(orderDetail);
                    db.SubmitChanges();
                }
            });
            return reslut;
        }

        public DeliveryOrderDetail GetDeliveryOrderDetail(int orderDetailId)
        {
            DeliveryOrderDetail reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.DeliveryOrderDetails.SingleOrDefault(o => o.Id == orderDetailId);
                int id = reslut.Product.Id;
            });
            return reslut;
        }

        public void UpdateDetail(DeliveryOrderDetail deliveryOrderDetail)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var reslut = db.DeliveryOrderDetails.SingleOrDefault(o => o.Id == deliveryOrderDetail.Id);
                reslut.AssignCount = deliveryOrderDetail.AssignCount;
                reslut.DeliveryCount = deliveryOrderDetail.DeliveryCount;
                reslut.DeliveryOrderId = deliveryOrderDetail.DeliveryOrderId;
                reslut.InputInvoice = deliveryOrderDetail.InputInvoice;
                reslut.LotsNumber = deliveryOrderDetail.LotsNumber;
                reslut.ProductDate = deliveryOrderDetail.ProductDate;
                reslut.ProductId = deliveryOrderDetail.ProductId;
                reslut.ProductStorageId = deliveryOrderDetail.ProductStorageId;
                db.SubmitChanges();
            });
        }

        public void CreateDetail(DeliveryOrderDetail deliveryOrderDetail)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.DeliveryOrderDetails.InsertOnSubmit(deliveryOrderDetail);
                db.SubmitChanges();
            });
        }

        public DataTable GetAssignedDetails(int orderId)
        {
            DataTable dt = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                dt = db.VewAssingedDeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId).ToDataTable(db);
            });
            return dt;
        }


        public void CreateAssignedDetails(int orderId, IEnumerable<AssignedDeliveryOrderDetail> _assignedDeliveryDetails)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.AssignedDeliveryOrderDetails.InsertAllOnSubmit(_assignedDeliveryDetails);
                _assignedDeliveryDetails.GroupBy(o => o.ProductStorageId)
                    .ToList()
                    .ForEach(groupDetails
                        =>
                        {
                            var storage = db.ProductStorages.SingleOrDefault(o => o.Id == groupDetails.Key);
                            foreach (var item in groupDetails)
                            {
                                storage.UsableCount -= item.AssignCount;
                            }
                            
                        });
                var or = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                or.Status = Lib.DeliveryStatus.已分配库存.ToString();
                db.SubmitChanges();
            });
        }
        //减少可用库存
        public void DecreaseUseableStorage(int orderId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var assignedDetails = db.AssignedDeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId);
                var order = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                order.Status = Lib.DeliveryStatus.已分配库存.ToString();
                db.SubmitChanges();
            });
        }
        public void UpdateStatus(int orderId, DeliveryStatus deliveryStatus)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var or = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                or.Status = deliveryStatus.ToString();
                db.SubmitChanges();
            });
        }

        public void ConfirmOutput(int orderId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var or = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                or.Status =DeliveryStatus.已发货.ToString();
                foreach (var item in or.AssignedDeliveryOrderDetails)
                {
                    item.ProductStorage.CurrentCount = item.ProductStorage.UsableCount;
                }
                db.SubmitChanges();
            });
        }

        public void CancelAssigedDetails(int orderId)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var or = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                or.Status = DeliveryStatus.待分配库存.ToString();
                foreach (var item in or.AssignedDeliveryOrderDetails)
                {
                    item.ProductStorage.UsableCount += item.AssignCount;
                }
                db.AssignedDeliveryOrderDetails.DeleteAllOnSubmit(or.AssignedDeliveryOrderDetails);
                db.SubmitChanges();
            });
        }
    }
}
