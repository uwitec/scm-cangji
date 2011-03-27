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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;

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
        private bool _updated = true;
       
        public bool Updated
        {
            get
            {
                return _updated;
            }
            set
            {
                if (!value)
                {
                    if (_updated)
                    {
                        this.Text = string.Format("{0}---未保存", this.Text);
                    }
                }
                else
                {
                    this.Text = this.Text.Replace("---未保存", "");
                }
                _updated = value;
            }
        }
        private ProgressForm _progressForm;
        BackgroundWorker _bw;
        public FormBase()
        {
            InitializeComponent();
        }

        public virtual void ProgressStart()
        {
            this.FormClosing += new FormClosingEventHandler(FormBase_FormClosing);
            _progressForm = new ProgressForm();
            _progressForm.OnProgressCancel += new Action(ProgressCancel);

            _bw = new BackgroundWorker();
            _bw.WorkerReportsProgress = true;
            _bw.WorkerSupportsCancellation = true;
            _bw.ProgressChanged += new ProgressChangedEventHandler(_bw_ProgressChanged);
            _bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bw_RunWorkerCompleted);
            _bw.DoWork += new DoWorkEventHandler(DoWork);

            _bw.RunWorkerAsync();
            _progressForm.ShowDialog();
        }
        void ProgressCancel()
        {
            _bw.CancelAsync();
            _progressForm.Close();
        }
        protected virtual void _bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                XtraMessageBox.Show("You canceled");
            else if (e.Error != null)
                XtraMessageBox.Show("error:" + e.Error.Message);
            else
            {
                _progressForm.Close();
                _bw = null;
            }

        }

       protected virtual void _bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
       protected virtual string CloseingMessage()
       {
           return "数据未保存";
       }
       protected virtual void DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
        }
        void FormBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Updated)
            {
                if (XtraMessageBox.Show(string.Format("{0}，确实要关闭吗？",CloseingMessage()), "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;

                }
                else
                {
                }
            }
        }
        public bool CheckUpdatedStatus()
        {
            if (!Updated)
            {
                if (XtraMessageBox.Show("数据未保存，确实要关闭吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Cancel)
                {
                    return false;
                }
            }
            return true;
        }
        public bool CheckPremission()
        {
            return true;
        }
        public void ShowMessage(string message)
        {
            XtraMessageBox.Show(message);
        }
        public void ShowWarning(string message)
        {
            XtraMessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public DialogResult ShowQuestion(string message)
        {
            return XtraMessageBox.Show(message, "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
      
    }
}
