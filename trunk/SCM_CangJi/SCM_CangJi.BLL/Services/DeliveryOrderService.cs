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
        public object GetDeliveryOrders()
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = (from o in db.DeliveryOrders
                          select new
                          {
                              o.Company.CompanyName,
                              o.Id,
                             DeliveryAddress =o.DeliverAddress.Address,
                             o.DeliveryOrderNumber,
                             o.Invoice,
                             o.PreDeliveryDate,
                             o.ReachedDate,
                             o.Status
                          }).ToList();
            });
            return reslut;
        }

        public DataTable GetDeliveryOrderDetailsDataTable(int orderId)
        {
            DataTable reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                //var order = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                //reslut = (from o in order.DeliveryOrderDetails
                //          select o.ToViewModel()).;
                reslut = (from o in db.DeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId)
                          select o.ToViewModel()).ToDataTable(db);
            });
            return reslut;
        }
        public IEnumerable<DeliveryOrderDetail> GetDeliveryOrderDetails(int orderId)
        {
            IEnumerable<DeliveryOrderDetail> reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                //var order = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                //reslut = (from o in order.DeliveryOrderDetails
                //          select o.ToViewModel()).;
                reslut = db.DeliveryOrderDetails.Where(o => o.DeliveryOrderId == orderId).ToList();
            });
            return reslut;
        }
        public DeliveryOrder GetDeliveryOrder(int orderId)
        {
            DeliveryOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                reslut.DeliveryOrderDetails.Load();
            });
            return reslut;
        }

        public void Update(DeliveryOrder order)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                db.DeliveryOrders.InsertOnSubmit(deliveryOrder);
                db.SubmitChanges();
            });
        }

        public bool Delete(int orderId, out string message)
        {
            bool reslut = true;
            string m = "删除成功";
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
             {
                 var order = db.DeliveryOrders.SingleOrDefault(o => o.Id == orderId);
                 DeliveryStatus status=(DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), order.Status);
                 switch (status)
                 {
                     case DeliveryStatus.已出库:
                     case DeliveryStatus.已发货:
                     case DeliveryStatus.已分配货物:
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = db.DeliveryOrderDetails.SingleOrDefault(o => o.Id == orderDetailId);
                int id = reslut.Product.Id;
            });
            return reslut;
        }

        public void UpdateDetail(DeliveryOrderDetail deliveryOrderDetail)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                db.DeliveryOrderDetails.InsertOnSubmit(deliveryOrderDetail);
                db.SubmitChanges();
            });
        }
    }
}
