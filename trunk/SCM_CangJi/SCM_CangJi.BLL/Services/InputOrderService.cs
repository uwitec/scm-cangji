using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.Lib;
using SCM_CangJi.DAL;
using System.Data;

namespace SCM_CangJi.BLL.Services
{
    public class InputOrderService:BaseService<InputOrderService>
    {
        public object GetInputOrders(InputStatus status)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = (from o in db.InputOrders.Where(o => o.Status == status.ToString())
                          select new
                          {
                              o.Company.CompanyName,
                              o.CompanyId,
                              o.ID,
                              o.InputOrderNumber,
                              o.Invoice,
                              o.PreInputDate,
                              o.FromWhere,
                              o.EnterUser,
                              o.Status,
                              StorageAreaId=0
                          }).ToList();
            });
            return reslut;
        }
        public DataTable GetInputOrderDetailsDataTable(int orderId)
        {
            DataTable reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = (from o in db.InputOrderDetails.Where(o => o.InputOrderId == orderId)
                          select o).ToDataTable(db);
            });
            return reslut;
        }
        public IEnumerable<InputOrderDetail> GetInputOrderDetails(int orderId)
        {
            IEnumerable<InputOrderDetail> reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = db.InputOrderDetails.Where(o => o.InputOrderId == orderId).ToList();
            });
            return reslut;
        }
        public InputOrder GetInputOrder(int orderId)
        {
            InputOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                reslut.InputOrderDetails.Load();
            });
            return reslut;
        }
        public InputOrder GetInputOrderFullInfo(int orderId)
        {
            InputOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                reslut.InputOrderDetails.Load();
                int id = reslut.Company.Id;
            });
            return reslut;
        }
        public void Update(InputOrder order)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var inputOrder = db.InputOrders.SingleOrDefault(o => o.ID == order.ID);
                if (order.InputOrderDetails != null)
                {
                    inputOrder.CompanyId = order.CompanyId;
                    inputOrder.InputOrderNumber = order.InputOrderNumber;
                    inputOrder.Invoice = order.Invoice;
                    inputOrder.PreInputDate = order.PreInputDate;
                    inputOrder.FromWhere = order.FromWhere;
                    inputOrder.EnterConfirmUser = order.EnterConfirmUser;
                    inputOrder.EnterDate = order.EnterDate;
                    inputOrder.EnterUser = order.EnterUser;
                    inputOrder.Status = order.Status;
                    foreach (var item in order.InputOrderDetails)
                    {
                        var orderdetail = db.InputOrderDetails.SingleOrDefault(o => o.ID == item.ID);
                        if (item.ID > 0)
                        {
                            orderdetail.InputCount = item.InputCount;
                            orderdetail.ProductId = item.ProductId;
                            orderdetail.ProductDate = item.ProductDate;
                            orderdetail.LotsNumber = item.LotsNumber;
                            orderdetail.CurrentProductNumber = item.CurrentProductNumber;
                        }
                        else
                        {
                            orderdetail = new InputOrderDetail();
                            orderdetail.InputCount = item.InputCount;
                            orderdetail.ProductId = item.ProductId;
                            orderdetail.ProductDate = item.ProductDate;
                            orderdetail.LotsNumber = item.LotsNumber;
                            orderdetail.CurrentProductNumber = item.CurrentProductNumber;
                            orderdetail.InputOrderId = item.InputOrderId;
                            orderdetail.CompanyId = item.CompanyId;
                            db.InputOrderDetails.InsertOnSubmit(orderdetail);
                        }
                    }
                }

                db.SubmitChanges();
            });
        }


        public void Create(InputOrder deliveryOrder)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                db.InputOrders.InsertOnSubmit(deliveryOrder);
                db.SubmitChanges();
            });
        }

        public bool Delete(int orderId, out string message)
        {
            bool reslut = true;
            string m = "删除成功";
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var order = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                InputStatus status = (InputStatus)Enum.Parse(typeof(InputStatus), order.Status);
                switch (status)
                {
                    case InputStatus.待分配库位:
                    case InputStatus.已入库:
                        reslut = false;
                        m = string.Format("删除失败！【0】单据不能删除", status.ToString());
                        break;
                    case InputStatus.待入库:
                    case InputStatus.作废:
                        db.InputOrderDetails.DeleteAllOnSubmit(order.InputOrderDetails);
                        db.InputOrders.DeleteOnSubmit(order);
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
                var orderDetail = db.InputOrderDetails.SingleOrDefault(o => o.ID == orderdetailId);
                if (orderDetail != null)
                {
                    db.InputOrderDetails.DeleteOnSubmit(orderDetail);
                    db.SubmitChanges();
                }
            });
            return reslut;
        }

        public InputOrderDetail GetInputOrderDetail(int orderDetailId)
        {
            InputOrderDetail reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = db.InputOrderDetails.SingleOrDefault(o => o.ID == orderDetailId);
                int id = reslut.Product.Id;
            });
            return reslut;
        }

        public void UpdateDetail(InputOrderDetail deliveryOrderDetail)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var reslut = db.InputOrderDetails.SingleOrDefault(o => o.ID == deliveryOrderDetail.ID);
                reslut.InputCount = deliveryOrderDetail.InputCount;
                reslut.InputOrderId = deliveryOrderDetail.InputOrderId;
                reslut.LotsNumber = deliveryOrderDetail.LotsNumber;
                reslut.ProductDate = deliveryOrderDetail.ProductDate;
                reslut.ProductId = deliveryOrderDetail.ProductId;
                reslut.CurrentProductNumber = deliveryOrderDetail.CurrentProductNumber;
                db.SubmitChanges();
            });
        }

        public void CreateDetail(InputOrderDetail deliveryOrderDetail)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                db.InputOrderDetails.InsertOnSubmit(deliveryOrderDetail);
                db.SubmitChanges();
            });
        }

        public void CompleteAssignStorageArea(int _orderId, IEnumerable<InputOrderDetail> _assignedInputDetails)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                foreach (var item in _assignedInputDetails)
                {
                    var detail = db.InputOrderDetails.SingleOrDefault(o => o.ID==item.ID);
                    detail.StorageAreaId = item.StorageAreaId;
                }
                db.SubmitChanges();
            });
        }

        public void UpdateStatus(int orderId, InputStatus inputStatus)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                var order = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                order.Status = inputStatus.ToString();
                db.SubmitChanges();
            });
        }

        public object GetInputOrdersFull(InputStatus inputStatus)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), db =>
            {
                reslut = (from o in db.InputOrders.Where(o => o.Status == inputStatus.ToString())
                          select new
                          {
                              o.Company.CompanyName,
                              o.CompanyId,
                              o.ID,
                              o.InputOrderNumber,
                              o.Invoice,
                              o.PreInputDate,
                              o.FromWhere,
                              o.EnterUser,
                              o.Status,
                              入库明细 = (from c in o.InputOrderDetails
                                       select new
                                       {
                                           品号 = c.Product.ProductNumber1,
                                           中文品名 = c.Product.ProductChName,
                                           英文品名 = c.Product.ProductEngName,
                                           入库数量 = c.InputCount,
                                           生产日期 = c.ProductDate,
                                           批号 = c.LotsNumber,
                                           //库位编号 = GetArea(c, db),
                                       }).ToList(),
                          }).ToList();
            });
            return reslut;
        }

        private string GetArea(InputOrderDetail c, CangJiDataDataContext db)
        {
            if (!c.StorageAreaId.HasValue)
                return null;
            var area = db.StorageAreas.SingleOrDefault(o => o.Id == c.StorageAreaId);
            return area.库位编号;
        }

       
    }
}
