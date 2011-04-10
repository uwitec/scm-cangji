using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace SCM_CangJi.WareHouseManage
{
    public partial class ImportDataBase : FormBase
    {
        private DataSet srcData;    //源数据表
        protected DataTable arrangeSrcData;   //整理好的源数据表，跟GridView控件绑定，要检查也用它
        protected List<ImportDataInfo> _importDataStruct;//存放要写进数据库中的数据库表、目标表字段和源数据表字段的对应关系
        protected IntPtr _formObject;   //保存传递过来的窗体实例
        public GridControl ImportingGridControl
        {
           get
            {
                return this.gridDataBase;
            }
        }
        public GridView ImportingGridView
        {
            get
            {
                return this.gridView1;
            }
        }
        public ImportDataBase(IntPtr formObject, DataSet data, List<ImportDataInfo> importDataStruct):base()
        {
            srcData = data;
            _formObject = formObject;
            _importDataStruct = importDataStruct;

            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (srcData != null)
            {
                //调用方法对源数据表进行整理，整理成完整的数据表格式
                ImportDataManage();
            }
        }

        #region 调用方法对源数据表进行整理，整理成完整的数据表格式
        private void ImportDataManage()
        {
            ImportDataInfo update = new ImportDataInfo();
            arrangeSrcData = new DataTable();
            arrangeSrcData.Clear();

            //用源数据表的第一行作为表的字段
            for (int i = 0; i < _importDataStruct.Count; i++)
            {
                string srcField = srcData.Tables[0].Rows[0][_importDataStruct[i].SrcField].ToString();

                //如果添加2个相同的列，会异常。解决的方法是源数据字段后面在加上目的数据库中的字段
                arrangeSrcData.Columns.Add(srcField + "(" + _importDataStruct[i].DestField + ")");
            }

            DataRow tmpRow;
            /*
             * 获取源数据表中的信息,从源数据表中第2行获取，第一行是作为字段用的不获取            
             * 嵌套了2个for循环
             * 第一个循环、取出行号；
             * 第二个循环、根据取出的行号循环取出每列的数据
             * */
            for (int row = 1; row < srcData.Tables[0].Rows.Count; row++)
            {
                tmpRow = arrangeSrcData.NewRow();
                bool isAllEmpty = true;                
                for (int col = 0; col < _importDataStruct.Count; col++)
                {
                    string strData = srcData.Tables[0].Rows[row][_importDataStruct[col].SrcField].ToString();
                    tmpRow[col]= strData;
                    if (!string.IsNullOrWhiteSpace(strData))
                    {
                        isAllEmpty = false;
                    }
                }
                if (!isAllEmpty)
                {
                    arrangeSrcData.Rows.Add(tmpRow);
                }
            }

            //所有数据都整理好之后要将_importDataStruct结构中的SrcField（源数据表字段）修改成新的字段名
            for (int i = 0; i < _importDataStruct.Count; i++)
            {
                //用源数据表字段的第一行修改结构中的 SrcField 的值
                string srcField = srcData.Tables[0].Rows[0][_importDataStruct[i].SrcField].ToString();
                srcField = srcField + "(" + _importDataStruct[i].DestField + ")";

                update = _importDataStruct[i];
                update.SrcField = srcField;
                _importDataStruct[i] = update;
            }

            gridDataBase.DataSource = arrangeSrcData;
                
        }
        protected virtual void BindGrid()
        {
            gridDataBase.DataSource = arrangeSrcData;
        }
        private void GridValidate()
        {
            btnConfrim.Enabled = CheckData(arrangeSrcData);
        }
        #endregion

        private void onResize(object sender, EventArgs e)
        {
        }

        private void btnConfrim_Click(object sender, EventArgs e)
        {
            if (CheckData(arrangeSrcData))  
            {
                /*
                 * 转化成InputOrderManage的对象，通过它获取导入时缺少的一些关键信息，                
                 * 需要在InputOrderManage写对应的获取方法
                 * InputOrderManage.PreInputOrder InputOrderForm = (InputOrderManage.PreInputOrder)Control.FromHandle(_formObject);
                 * */
                //InputOrderManage.PreInputOrder InputOrderForm = (InputOrderManage.PreInputOrder)Control.FromHandle(_formObject);
                
                //写库
                ImportToDataBase(arrangeSrcData, _importDataStruct); //arrangeSrcData是整理好的源数据表，跟GridView控件绑定，要检查也用它
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public virtual bool CheckData(DataTable srcData)//参数修改了，将原来的DataSet类型换成了DataTable类型
        {
            return true;
        }
        
        //参数修改了，将原来的DataSet类型换成了DataTable类型
        public virtual void ImportToDataBase(DataTable srcData, List<ImportDataInfo> dataStruct)
        {
            //演示从整理好的srcData中取出数据，可以根据需要修改
            for (int row = 0; row < srcData.Rows.Count; row++)
            {
                for (int col = 0; col < _importDataStruct.Count; col++)
                {
                    XtraMessageBox.Show("将 第" + row.ToString()+ "行的 " + srcData.Rows[row][col].ToString().Trim() +
                        " 信息写到 "+ _importDataStruct[col].TableName+" 数据表中的 "+
                        _importDataStruct[col].DestField+" 字段中");
                }
            }
        }

    }
}
