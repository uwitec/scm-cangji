/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 6/3/2011 9:43:11 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi
 * 文件名： LogList
 *
 *QQ ：  286575355
 *Email： kuchen1984@126.com
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.BLL.Services;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
namespace SCM_CangJi
{
    public partial class LogList : FormBase
    {
        #region ISingleton<LogList> Members
        private static LogList _instance = null;
        public static LogList Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new LogList();
                }
                return _instance;
            }
        }
        #endregion

        public LogList()
        {
            InitializeComponent();
        }

        private void LogList_Load(object sender, EventArgs e)
        {
            this.ProgressStart();
        }
        protected override void DoWork(object sender, DoWorkEventArgs e)
        {
            base.DoWork(sender, e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime? from = null;
            DateTime? to = null;
            if (txtDateFrom.EditValue != null)
            {
                from = (DateTime)txtDateFrom.EditValue;
            }
            if (dateTo.EditValue != null)
            {
                to = (DateTime)dateTo.EditValue;
            }
            this.gridControlLog.DataSource = SCM_CangJi.BLL.Services.LogServices.Instance.GetLogs(from,
                to,
                txtUserName.EditValue.TrytoString(),
                txtMessage.EditValue.TrytoString());
        }

        
    }
}