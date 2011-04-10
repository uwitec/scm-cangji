﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;
using DevExpress.XtraEditors;
using SCM_CangJi.Lib;
namespace SCM_CangJi.BLL.Services
{
    public class CommonService:BaseService<CommonService>
    {

        public object GetAllCurrencyUnit()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                result = db.CurrencyUnits.ToList();

            });
            return result;
        }

        public object GetAllProductType()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                result = db.ProductTypes.ToList();

            });
            return result;
        }
        public static void BindDDLCompany(LookUpEditBase ddl)
        {
            ddl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ddl.Properties.DataSource = CompanyService.Instance.GetAllCompany();
        }
        public static void BindDDLStorageArea(LookUpEditBase ddl)
        {
            ddl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ddl.Properties.DataSource = StorageAreaService.Instance.GetSrorageArea();
        }
        public static void BindDDLDeliveryAddress(LookUpEditBase ddl, int companyId)
        {
            ddl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ddl.Properties.DataSource = DeliverAddressService.Instance.GetAddresses(companyId);
        }
        public static void BindDDLStorages(LookUpEditBase ddl, int companyId)
        {
            ddl.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            ddl.Properties.DataSource = ProductStorageService.Instance.GetProducStorages(companyId);
        }
        public string GetOrderNumber(OrderType orderType)
        {

            string result = "{0}{1}"; //orderType == OrderType.DeliveryOrder ? "SHP-{0}{1}" : "REC-{0}{1}";
            switch (orderType)
            {
                case OrderType.DeliveryOrder:
                    result = "SHP-{0}{1}";
                    break;
                case OrderType.InputOrder:
                    result = "REC-{0}{1}";
                    break;
                case OrderType.CurrentProductOrder:
                    result = "{0}{1}";
                    break;
                default:
                    break;
            }
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), db =>
            {
                var ordrnumbers = db.OrderNumbers.Where(o => o.OrderType == (int)orderType&&o.CreateDate.Date==DateTime.Now.Date);
                result = string.Format(result, DateTime.Now.ToString("yyMMdd"), (ordrnumbers.Count()+1).ToString("000000"));
                OrderNumber ordernumber = new OrderNumber();
                ordernumber.CreateDate = DateTime.Now;
                ordernumber.OrderType = (int)orderType;
                ordernumber.OrderNamrber = result;
                ordernumber.Status=(int)OrderNubmerStatus.Used;
                db.OrderNumbers.InsertOnSubmit(ordernumber);
                db.SubmitChanges();
            });
            return result;
        }

        public static void BindDDLStorageArea(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit gcStorageArea)
        {
            gcStorageArea.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gcStorageArea.DataSource = StorageAreaService.Instance.GetSrorageArea();
        }

        public bool UpdateDB(string sql)
        {
          return  Using<CangJiDataDataContext,bool>(new CangJiDataDataContext(this.connectionString), db =>
           {
               db.ExecuteCommand(sql, "");
               return true;
           });
        }
    }
}
