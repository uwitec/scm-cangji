using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SCM_CangJi.CustomerManage
{
    public partial class CompanyList :FormBase
    {
        #region ISingleton<ComanyList> Members
        private static readonly Lazy<CompanyList> _instance = new Lazy<CompanyList>(() => new CompanyList());
        public static CompanyList Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion

        private CompanyList()
        {
            InitializeComponent();
            InitGrid();
        }

        private void InitGrid()
        {
            gridControlCompany.DataSource = SCM_CangJi.BLL.Services.CompanyService.Instance.GetAllCompany();
        }

    }
}