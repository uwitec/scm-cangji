using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCM_CangJi.Lib
{
   public enum FormType
    {
       Detail,
       List,
       Create,
       Update
    }
   public enum CompanyType
   {
       供应商=1,
       客户=2,
   }
   public enum DeliveryStatus
   {
       待出库,
       待分配库存,
       已分配库存,
       已出库,
       已发货,
       已送达,
       作废
   }
   public enum InputStatus
   {
       待入库,
       待分配库位,
       已入库,
       作废
   }
   public enum OrderType
   {
       DeliveryOrder=1,
       InputOrder=2,
   }
   public enum OrderNubmerStatus
   {
       Used=1,
   }
}
