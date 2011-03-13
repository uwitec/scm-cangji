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
       已分配货物,
       已出库,
       已发货,
       已送达,
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
