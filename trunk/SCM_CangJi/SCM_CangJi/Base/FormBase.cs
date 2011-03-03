using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Security;
using System.Web.Security;

namespace SCM_CangJi
{
    /// <summary>
    /// 普通Form 基类
    /// </summary>
    public partial class FormBase : XtraForm
    {
        public MembershipUser User
        {
            get
            {
                return SecurityContext.Current.CurrentyUser;
            }
        }

        public FormBase()
        {
            InitializeComponent();
        }
        public bool CheckPremission()
        {
            return true;
        }

    }
}
