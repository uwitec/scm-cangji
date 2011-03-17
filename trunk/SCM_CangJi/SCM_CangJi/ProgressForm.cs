using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.Base;

namespace SCM_CangJi
{
    public partial class ProgressForm : XtraForm
    {
        public event Action OnProgressCancel;

        public ProgressForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (OnProgressCancel != null)
            {
                OnProgressCancel();
            }
        }
    }
}
