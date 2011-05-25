﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.Lib;
using SCM_CangJi.DAL;
using System.Data;
using System.Dynamic;

namespace SCM_CangJi.BLL.Services
{
    public class InputOrderService:BaseService<InputOrderService>
    {
        public object GetInputOrders(InputStatus status)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = (from o in db.InputOrders.Where(o => status==InputStatus.all|| o.Status == status.ToString()).OrderByDescending(o=>o.PreInputDate)
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var deteils = from o in db.InputOrderDetails.Where(o => o.InputOrderId == orderId)
                              join s in db.StorageAreas
                              on o.StorageAreaId equals s.Id
                              into x
                              from y in x.DefaultIfEmpty()
                              select new
                              {
                                  o.CompanyId,
                                  o.CurrentProductNumber,
                                  o.ID,
                                  o.InputCount,
                                  o.Product.Brand,
                                  o.InputOrderId,
                                  o.Product.ProductNumber1,
                                  o.Product.ProductNumber2,
                                  o.Product.Spec,
                                  o.ProductDate,
                                  o.ProductId,
                                  o.LotsNumber,
                                  o.Remark,
                                  o.StorageAreaId,
                                  StorageArea = !o.StorageAreaId.HasValue ? "未分配" :y.StorageRack.RackName + "--" + y.库位编号
                              };
                reslut = deteils.ToDataTable(db);
            });
            return reslut;
        }
        public IEnumerable<InputOrderDetail> GetInputOrderDetails(int orderId)
        {
            IEnumerable<InputOrderDetail> reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.InputOrderDetails.Where(o => o.InputOrderId == orderId).ToList();
            });
            return reslut;
        }
        public InputOrder GetInputOrder(int orderId)
        {
            InputOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                reslut.InputOrderDetails.Load();
            });
            return reslut;
        }
        public InputOrder GetInputOrderFullInfo(int orderId)
        {
            InputOrder reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                reslut.InputOrderDetails.Load();
                int id = reslut.Company.Id;
            });
            return reslut;
        }
        public void Update(InputOrder order)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
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
                            orderdetail.Remark = item.Remark;
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
                            orderdetail.Remark = item.Remark;
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.InputOrders.InsertOnSubmit(deliveryOrder);
                db.SubmitChanges();
            });
        }

        public bool Delete(int orderId, out string message)
        {
            bool reslut = true;
            string m = "删除成功";
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                reslut = db.InputOrderDetails.SingleOrDefault(o => o.ID == orderDetailId);
                int id = reslut.Product.Id;
            });
            return reslut;
        }
        public object GetInputOrderDetailsFullInfo(int orderlId)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var resultTem = from d in db.InputOrderDetails.Where(o => o.InputOrderId == orderlId)

                                join area in db.StorageAreas
                                     on d.StorageAreaId equals area.Id
                                     into x
                                from y in x.DefaultIfEmpty()
                                select new
                                {
                                    CompanyName = d.Company.CompanyName,
                                    CurrentProductNumber = d.CurrentProductNumber,
                                    InputCount = d.InputCount.ToString(),
                                    InputOrderNumber = d.InputOrder.InputOrderNumber,
                                    LotsNumber = d.LotsNumber,
                                    d.Remark,
                                    BarCode = d.Product.BarCode,
                                    Brand=d.Product.Brand,
                                    Invoice=d.InputOrder.Invoice,
                                    ProductChName = d.Product.ProductChName,
                                    ProductEngName = d.Product.ProductEngName,
                                    ProductNumber1 = d.Product.ProductNumber1,
                                    ProductNumber2 = d.Product.ProductNumber2,
                                    AreaNumber = y==null ? "未分配" : y.StorageRack.RackName + "--" + y.库位编号,
                                    WareHouseName = "（" + y.StorageRack.Storage.仓库编号 + "）" + y.StorageRack.Storage.仓库名称,
                                };
                reslut=resultTem.ToList();
            });
            return reslut;
        }
        public dynamic GetInputOrderDetailFullInfo(int orderDetailId)
        {
            dynamic reslut = new System.Dynamic.ExpandoObject();
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var detail = db.InputOrderDetails.SingleOrDefault(o => o.ID == orderDetailId);
                var area = db.StorageAreas.SingleOrDefault(o => o.Id == detail.StorageAreaId);
                reslut.CompanyName = detail.Company.CompanyName;
                reslut.CurrentProductNumber = detail.CurrentProductNumber;
                reslut.InputCount = detail.InputCount;
                reslut.InputOrderNumber = detail.InputOrder.InputOrderNumber;
                reslut.LotsNumber = detail.LotsNumber;
                reslut.Remark = detail.Remark;
                reslut.BarCode = detail.Product.BarCode;
                reslut.ProductChName = detail.Product.ProductChName;
                reslut.ProductEngName = detail.Product.ProductEngName;
                reslut.ProductNumber1 = detail.Product.ProductNumber1;
                reslut.ProductNumber2 = detail.Product.ProductNumber2;
                reslut.AreaNumber = area.库位编号;
                reslut.WareHouseName = "（" + area.StorageRack.Storage.仓库编号 + "）" + area.StorageRack.Storage.仓库名称;
            });
            return reslut;
        }
        public void UpdateDetail(InputOrderDetail deliveryOrderDetail)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
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
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.InputOrderDetails.InsertOnSubmit(deliveryOrderDetail);
                db.SubmitChanges();
            });
        }
        public void CreateDetail(List<InputOrderDetail> deliveryOrderDetails)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                db.InputOrderDetails.InsertAllOnSubmit(deliveryOrderDetails);
                db.SubmitChanges();
            });
        }
        public void CompleteAssignStorageArea(int _orderId, IEnumerable<InputOrderDetail> _assignedInputDetails)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                foreach (var item in _assignedInputDetails)
                {
                    var detail = db.InputOrderDetails.SingleOrDefault(o => o.ID==item.ID);
                    detail.StorageAreaId = item.StorageAreaId;
                    detail.CurrentProductNumber = CommonService.Instance.GetOrderNumber(OrderType.CurrentProductOrder);
                }
                db.SubmitChanges();
            });
        }

        public void UpdateStatus(int orderId, InputStatus inputStatus)
        {
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var order = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                order.Status = inputStatus.ToString();
                db.SubmitChanges();
            });
        }
        public object GetInputOrdersFull(InputStatus inputStatus)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
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
                                           品号1 = c.Product.ProductNumber1,
                                           品号2 = c.Product.ProductNumber2,
                                           规格 = c.Product.Spec,
                                           中文品名 = c.Product.ProductChName,
                                           英文品名 = c.Product.ProductEngName,
                                           入库数量 = c.InputCount,
                                           库位 = GetArea(c, db),
                                           到期日期 = c.ProductDate,
                                           批号 = c.LotsNumber,
                                       }).ToList(),
                          }).ToList();
            });
            return reslut;
        }

        private string GetArea(InputOrderDetail c, CangJiDataDataContext db)
        {
            if (!c.StorageAreaId.HasValue)
                return "未分配";
            string result = null;

            var ps = db.StorageAreas.SingleOrDefault(o => o.Id == c.StorageAreaId);

            result = ps.StorageRack.Storage.仓库名称 + "--" + ps.StorageRack.RackName + "--" + ps.库位编号;
            return result; ;
        }



        public bool ConfirmInputOrder(int orderId)
        {
            bool result=false;
            try
            {
                Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
                {
                    var inputorder = db.InputOrders.SingleOrDefault(o => o.ID == orderId);
                    inputorder.Status = Lib.InputStatus.已入库.ToString();
                    inputorder.EnterDate=DateTime.Now;
                    inputorder.EnterConfirmUser=Security.SecurityContext.Current.CurrentyUser.UserName;
                    foreach (var inputDetail in inputorder.InputOrderDetails)
                    {
                        ProductStorage ps = new ProductStorage();
                        ps.AreaId = inputDetail.StorageAreaId.Value;
                        ps.CompanyId = inputDetail.CompanyId;
                        ps.CurrentCount = inputDetail.InputCount;
                        ps.CurrentProductNumber = inputDetail.CurrentProductNumber;
                        ps.EntryDate = inputorder.EnterDate.Value;
                        ps.EntryUser = Security.SecurityContext.Current.CurrentyUser.UserName;
                        ps.InputDetailId = inputDetail.ID;
                        ps.LotsNumber = inputDetail.LotsNumber;
                        ps.OriginalCount = inputDetail.InputCount;
                        ps.ProductId = inputDetail.ProductId;
                        if (inputDetail.ProductDate.HasValue)
                            ps.ProductDate = inputDetail.ProductDate.Value;
                        ps.UpdateDate =DateTime.Now;
                        ps.UpdateUser = Security.SecurityContext.Current.CurrentyUser.UserName;
                        ps.UsableCount = inputDetail.InputCount;
                        ps.Status = (int)StoreStatus.Avilable;
                        db.ProductStorages.InsertOnSubmit(ps);
                    }

                    db.SubmitChanges();
                    result=true;
                });
            }
            catch
            {
            }
            return result;
        }

        public object GetInputDetailsBy(string productCurrentNuber, string ProductNumber1)
        {
            object reslut = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var rel = from s in db.ProductStorages
                          join c in db.InputOrderDetails
                          on s.InputDetailId equals c.ID
                          where c.InputOrder.Status == InputStatus.已入库.ToString()
                          && (productCurrentNuber == "" || c.CurrentProductNumber == productCurrentNuber)
                          && (ProductNumber1 == "" || c.Product.ProductNumber1 == ProductNumber1)
                          orderby s.EntryDate descending
                          select new
                          {
                              现品票 = s.CurrentProductNumber,
                              品号1 = c.Product.ProductNumber1,
                              品号2 = c.Product.ProductNumber2,
                              规格 = c.Product.Spec,
                              中文品名 = c.Product.ProductChName,
                              英文品名 = c.Product.ProductEngName,
                              入库数量 = c.InputCount,
                              入库时间 = s.EntryDate,
                              //库位 = GetArea(c, db),
                              到期日期 = c.ProductDate,
                              批号 = c.LotsNumber,
                              入库发票 = c.InputOrder.Invoice,
                              实际库存 = s.CurrentCount,
                              可用库存 = s.UsableCount,
                          };
                reslut = rel.ToList();
            });
            return reslut;
        }
    }
}
