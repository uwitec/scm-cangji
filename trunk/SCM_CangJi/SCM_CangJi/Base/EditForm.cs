using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCM_CangJi
{
    public partial class EditForm : FormBase, IEditForm
    {
        public event Action OnSave;
        public event Action OnSaveAndClose;
        public EditForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        #region IEditForm Members

        public void Save(Action saveAction)
        {
            saveAction();
        }

        public void Save()
        {
            if (OnSave != null)
                OnSave();
        }


        public void SaveAndClose(Action saveAction)
        {
            if (OnSaveAndClose != null)
            {
                Save(saveAction);
                this.Close();
            }
        }

        #endregion
    }
}
