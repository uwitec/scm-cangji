using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using SCM_CangJi.DAL;

namespace SCM_CangJi.BLL.Security
{
    public  class SecurityContext
    {
        #region singleton
        static SecurityContext _current;
        public static SecurityContext Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SecurityContext();
                }
                return _current;
            }
        } 
        #endregion
        public MembershipUser CurrentyUser
        {
            get;
            set;
        }
        //List<Product> products;
        //public List<Product> Products
        //{
        //    get
        //    {
        //        if (products == null)
        //        {
        //            using (s)
        //            {
                        
        //            }
        //        }
        //        return products;
        //    }
        //}
        //public List<ProductType> ProductTypes
        //{
        //    get;
        //    set;
        //}
    }
  
}
