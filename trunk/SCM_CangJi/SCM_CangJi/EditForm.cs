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
        public event Action onSave;
        public EditForm()
        {
            InitializeComponent();
        }

        #region IEditForm Members

        public void Save(Action saveAction)
        {
            saveAction();
        }

        public void Save()
        {
            if (onSave != null)
                onSave();
        }


        public void SaveAndClose(Action saveAction)
        {
            Save(saveAction);
            this.Close();
        }

        #endregion
    }
}
