using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;

namespace SCM_CangJi.WareHouseManage
{
    public partial class ImportDataBase : FormBase
    {
        private DataSet srcData;
        private List<ImportDataInfo> _importDataStruct;
        public ImportDataBase(DataSet data,List<ImportDataInfo> importDataStruct)
        {
            srcData = data;
            _importDataStruct = importDataStruct;
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (srcData != null)
            {
                gridDataBase.DataSource = srcData.Tables[0];
            }
        }

        private void onResize(object sender, EventArgs e)
        {
        }

        private void btnConfrim_Click(object sender, EventArgs e)
        {
            if (CheckData(srcData))
            {
                //写库
                ImportToDataBase(srcData,_importDataStruct);
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public virtual bool CheckData(DataSet srcData)
        {
            return true;
        }
        public virtual void ImportToDataBase(DataSet srcData,List<ImportDataInfo> dataStruct)
        {
        }
    }
}
