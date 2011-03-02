using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCM_CangJi.BLL.Security
{
    public class SecurityContext
    {
        #region singleton
        static SecurityContext _current;
        public static SecurityContext Current
        {
            get
            {
                if (_current != null)
                {
                    _current = new SecurityContext();
                }
                return _current;
            }
        } 
        #endregion
        public SecurityUser CurrentyUser
        {
            get;
            set;
        }
    }
  
}
