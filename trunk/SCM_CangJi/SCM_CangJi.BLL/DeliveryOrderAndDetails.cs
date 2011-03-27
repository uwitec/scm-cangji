using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data;
using System.Collections;
using DevExpress.XtraGrid;
namespace SCM_CangJi.BLL
{
    public class RelationListRecords  //: ArrayList, IRelationList
    {
       // int _orderId = 0;
       // public RelationListRecords(int orderId)
       // {
       //     _orderId = orderId;
       //     Add(new RelationListRecord("OrderList"));
       // }
       // string IRelationList.GetRelationName(int index, int relationIndex)
       // {
       //     if (index != GridControl.InvalidRowHandle)
       //         return ((RelationListRecord)this[index]).Name;
       //     else return "";
       // }

       // int IRelationList.RelationCount
       // {
       //     get { return 1; }
       // }

       //public virtual  IList IRelationList.GetDetailList(int index, int relationIndex)
       // {
       //     switch (((RelationListRecord)this[index]).Name)
       //     {
       //         case "OrderDetails":
       //             return Services.DeliveryOrderService.Instance.GetDeliveryOrderDetails(1).ToList();
       //     }
       //     return null;
       // }

       // bool IRelationList.IsMasterRowEmpty(int index, int relationIndex)
       // {
       //     return false;
       // }

       // public virtual new RelationListRecord this[int index]
       // {
       //     get
       //     {
       //         return (RelationListRecord)(base[index]);
       //     }
       // }
    }
    public class RelationListRecord
    {
        private string fName;

        public string Name
        {
            get { return fName; }
            set { fName = value; }
        }

        public RelationListRecord(string fName)
        {
            this.fName = fName;
        }
    }

}
