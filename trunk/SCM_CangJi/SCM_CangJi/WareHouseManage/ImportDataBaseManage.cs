using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;

namespace SCM_CangJi.WareHouseManage
{
    public partial class ImportDataBaseManage : FormBase
    {
      

        ImportDataInfo importData;
        List<ImportDataInfo> listImportData;
        
        private string strConn;
        private string TargetTable;

        DataSet srcData = null;

        private OpenFileDialog openFileDialog;
        private DataBaseConnection dataConn = null;

        public ImportDataBaseManage()
        {
            TargetTable = "";

            InitializeVariable();
            InitializeComponent();
        }

        public ImportDataBaseManage(string tablename)
        {
            TargetTable = tablename;

            InitializeVariable();
            InitializeComponent();
        }

        private void InitializeVariable()
        {
            strConn = "";
            importData = new ImportDataInfo();
            listImportData = new List<ImportDataInfo>();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();

            ComBoxImportType.Properties.Items.Add("Excel");
            ComBoxImportType.Properties.Items.Add("Txt");
            ComBoxImportType.SelectedIndex = 0;

            dataConn = new DataBaseConnection();

            SetTargetTableControlValue();
            SetStoragesControlValue();

            buttonFile.Select();

            lookUpStorage.Visible = false;
            labelStorage.Visible = false;
            
            SetControlEnabled(false);
        }

        #region 设置控件值
        private void SetStoragesControlValue()
        {
            DataSet db = dataConn.Query("select 仓库名称 as '仓库名称',仓库编号 as '仓库编号' , id as '仓库自动ID' from Storages");
            int count = db.Tables[0].Rows.Count;
            if (count <= 0)
            {
                lookUpStorage.Properties.DataSource = null;
                return;
            }

            DataTable dataTabTmp = new DataTable();
            dataTabTmp.Clear();
            dataTabTmp.Columns.Add("仓库名称");
            dataTabTmp.Columns.Add("仓库编号");
            dataTabTmp.Columns.Add("仓库自动ID");

            DataRow tmpRow = dataTabTmp.NewRow();

            tmpRow["仓库名称"] = "--请选择--";
            tmpRow["仓库编号"] = "";
            tmpRow["仓库自动ID"] = "";

            dataTabTmp.Rows.Add(tmpRow);

            for (int i = 0; i < count; i++)
            {
                tmpRow = dataTabTmp.NewRow();

                tmpRow["仓库名称"] = db.Tables[0].Rows[i]["仓库名称"].ToString();
                tmpRow["仓库编号"] = db.Tables[0].Rows[i]["仓库编号"].ToString();
                tmpRow["仓库自动ID"] = db.Tables[0].Rows[i]["仓库自动ID"].ToString();

                dataTabTmp.Rows.Add(tmpRow);
            }

            lookUpStorage.Properties.Columns.Clear();
            lookUpStorage.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库名称", "仓库名称"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("仓库编号", "仓库编号")});
            lookUpStorage.Properties.DataSource = dataTabTmp;
            lookUpStorage.Properties.DisplayMember = "仓库名称";
            lookUpStorage.Properties.ValueMember = "仓库自动ID";
            
        }

        private void SetTargetTableControlValue()
        {
            DataSet db = dataConn.Query("select TableRemark as '目标数据表', TargetTable as '目标数据表名称' from ImportProfiles ");
            int count = db.Tables[0].Rows.Count;
            
            if (count <= 0)
            {
                lookUpDesTable.Properties.DataSource = null;
                return;
            }

            DataTable dataTabTmp = new DataTable();
            dataTabTmp.Clear();
            dataTabTmp.Columns.Add("目标数据表");
            dataTabTmp.Columns.Add("目标数据表名称");

            DataRow tmpRow;
            tmpRow = dataTabTmp.NewRow();

            tmpRow["目标数据表"] = "--请选择--";
            tmpRow["目标数据表名称"] = "";

            dataTabTmp.Rows.Add(tmpRow);

            for (int i = 0; i < count; i++)
            {
                tmpRow = dataTabTmp.NewRow();

                tmpRow["目标数据表"] = db.Tables[0].Rows[i]["目标数据表"].ToString();
                tmpRow["目标数据表名称"] = db.Tables[0].Rows[i]["目标数据表名称"].ToString();

                dataTabTmp.Rows.Add(tmpRow);
            }
            
            lookUpDesTable.Properties.DataSource = dataTabTmp;
            lookUpDesTable.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("目标数据表", "目标数据表")});

            lookUpDesTable.Properties.DisplayMember = "目标数据表";
            lookUpDesTable.Properties.ValueMember = "目标数据表名称";

            if (TargetTable != "")
            {
                lookUpDesTable.EditValue = TargetTable;
                lookUpDesTable.Enabled = false;
            }

        }

        private void SetStoragesAreaImportView(DataTable dataTabTmp)
        {
            string sql = "select TableName,TableId, ColumnName as '字段名', case when IsNull=1 then N'能' else N'不能' end as '是否为空', description as '字段说明',ColumnId, "
                            + "case when TypeName='nvarchar'  then TypeName+'（'+rtrim(Length/2)+'）' else TypeName+'（'+rtrim(Length)+'）' end as '类型（长度）',SourceColumnName as '导入字段'"
                            + " from View_ImportTargetDataMetas where tablename='StorageRacks' and description is not null";
            DataSet db = dataConn.Query(sql);
            Add(db, dataTabTmp);

            sql = "select TableName,TableId, ColumnName as '字段名', description as '字段说明',case when IsNull=1 then N'能' else N'不能' end as '是否为空', ColumnId, "
                            + "case when TypeName='nvarchar'  then TypeName+'（'+rtrim(Length/2)+'）' else TypeName+'（'+rtrim(Length)+'）' end as '类型（长度）',SourceColumnName as '导入字段'"
                            + " from View_ImportTargetDataMetas where tablename='StorageAreas' and description is not null";
            db = dataConn.Query(sql);
            Add(db, dataTabTmp);


            gridData.DataSource = dataTabTmp;
        }

        private void Add(DataSet db, DataTable dataTabTmp)
        {
            int count = db.Tables[0].Rows.Count;
            if (count <= 0)
            {
                lookUpDesTable.Properties.DataSource = null;
                return;
            }

            DataRow tmpRow;

            for (int i = 0; i < count; i++)
            {
                tmpRow = dataTabTmp.NewRow();

                tmpRow["TableName"] = db.Tables[0].Rows[i]["TableName"].ToString();
                tmpRow["TableId"] = db.Tables[0].Rows[i]["TableId"].ToString();
                tmpRow["是否为空"] = db.Tables[0].Rows[i]["是否为空"].ToString();
                tmpRow["字段名"] = db.Tables[0].Rows[i]["字段名"].ToString();
                tmpRow["字段说明"] = db.Tables[0].Rows[i]["字段说明"].ToString();
                tmpRow["ColumnId"] = db.Tables[0].Rows[i]["ColumnId"].ToString();
                tmpRow["类型（长度）"] = db.Tables[0].Rows[i]["类型（长度）"].ToString();
                tmpRow["导入字段"] = db.Tables[0].Rows[i]["导入字段"].ToString();

                dataTabTmp.Rows.Add(tmpRow);
            }
        }

        private void SetControlEnabled(bool isNo)
        {
            butSave.Enabled = isNo;
            butImport.Enabled = isNo;
        }
        #endregion

        private void OnButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {   
            string fileType = "";
           
            switch (ComBoxImportType.Text)
            {
                case "Excel":
                    fileType = "Excel文件(*.xls)|*.xls";
                    break;

                case "Txt":
                    fileType = "文本文件(*.txt)|*.txt";
                    break;
            }

            openFileDialog.Filter = fileType;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                buttonFile.Text = fileName;

                strConn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" +
                    fileName + "; Extended Properties='Excel 8.0;IMEX=1;HDR=NO;'";
                OleDbConnection conn = new OleDbConnection(strConn);

                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
                comBoxSrcTable.SelectedIndex = 1;

                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                
                comBoxSrcTable.Properties.Items.Clear();
                
                if (dt.Rows.Count<=0)
                {
                    return;
                }

                string strTab = " ";
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strTab = dt.Rows[i]["Table_Name"].ToString();
                    comBoxSrcTable.Properties.Items.Add(strTab);
                }
                comBoxSrcTable.SelectedIndex = 0;

                conn.Close();
                conn.Dispose(); 
            }
        }

        private void OnSelectedValueChanged(object sender, EventArgs e)
        {
            if (strConn.Equals(""))
                return;
           
            if (TargetTable!="")
            {
                ShowImportInfo();
            }
        }

        private void ShowImportInfo()
        {
            string strSql = " ";
            string strTab = comBoxSrcTable.Text;
            OleDbDataAdapter oleData = null;

            if (strConn.Equals("") )
                return;

            strSql = "select * from [" + strTab + "]";
            try
            {
                oleData = new OleDbDataAdapter(strSql, strConn);

                if (srcData != null)
                {
                    srcData.Clear();
                }
                srcData = new DataSet();

                oleData.Fill(srcData, "[" + strTab + "]");
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

            DataTable dataTabTmp = new DataTable();
            dataTabTmp.Clear();
            dataTabTmp.Columns.Add("TableName");
            dataTabTmp.Columns.Add("TableId");
            dataTabTmp.Columns.Add("字段名");
            dataTabTmp.Columns.Add("字段说明");
            dataTabTmp.Columns.Add("是否为空");
            dataTabTmp.Columns.Add("ColumnId");
            dataTabTmp.Columns.Add("类型（长度）");
            dataTabTmp.Columns.Add("导入字段");

            //显示数据窗口
            if (dataConn != null)
            {
                switch (TargetTable)
                {
                    case "StorageAreas"://导入库位数据需要向2张表进行导入
                        SetStoragesAreaImportView(dataTabTmp);

                        lookUpStorage.Visible = true;
                        labelStorage.Visible = true;
                        break;

                    default:
                        string sql = "select TableName,TableId, ColumnName as '字段名', description as '字段说明',case when IsNull=1 then N'能' else N'不能' end as '是否为空', ColumnId, "
                            + "case when TypeName='nvarchar'  then TypeName+'（'+rtrim(Length/2)+'）' else TypeName+'（'+rtrim(Length)+'）' end as '类型（长度）',SourceColumnName as '导入字段'"
                            + " from View_ImportTargetDataMetas where tablename='" + TargetTable + "' and is_identity<>1 and description is not null";
                        DataSet db = dataConn.Query(sql);
                        gridData.DataSource = db.Tables[0];

                        lookUpStorage.Visible = false;
                        labelStorage.Visible = false;
                        break;
                }

                if (gridView1.RowCount>0)
                {
                    SetControlEnabled(true);
                }
                else
                {
                    SetControlEnabled(false);
                }

                //设置导入字段下拉框
                DataTable dataSrcTabTmp = new DataTable();
                dataSrcTabTmp.Clear();
                dataSrcTabTmp.Columns.Add("字段名称");
                dataSrcTabTmp.Columns.Add("字段标题");
                
                DataRow tmpRow;
                //tmpRow = dataSrcTabTmp.NewRow();

                //tmpRow["字段名称"] = "--请选择要导入的字段--";
                //tmpRow["字段标题"] = "";

                //dataSrcTabTmp.Rows.Add(tmpRow);

                for (int i = 0; i < srcData.Tables[0].Columns.Count; i++)
                {
                    tmpRow = dataSrcTabTmp.NewRow();
                    tmpRow["字段名称"] = srcData.Tables[0].Rows[0][i].ToString();
                    tmpRow["字段标题"] = srcData.Tables[0].Columns[i].ToString();

                    dataSrcTabTmp.Rows.Add(tmpRow);
                }

                repositoryItemLookUpEdit1.Columns.Clear();
                repositoryItemLookUpEdit1.DataSource = dataSrcTabTmp;
                //repositoryItemLookUpEdit1.NullText = "--请选择要导入的字段--";
                //控制字段的显示
                repositoryItemLookUpEdit1.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("字段名称", 50, "字段名称"));    
                repositoryItemLookUpEdit1.DisplayMember = "字段名称";
                repositoryItemLookUpEdit1.ValueMember = "字段标题";
                gridView1.Columns["导入字段"].ColumnEdit = repositoryItemLookUpEdit1;
                
                //设置显示状态
                gridView1.Columns["TableName"].Visible = false;
                gridView1.Columns["TableId"].Visible = false;
                gridView1.Columns["ColumnId"].Visible = false;
                                
                //gridView1.OptionsBehavior.Editable = false;
                gridView1.Columns["字段名"].OptionsColumn.ReadOnly = true;
                gridView1.Columns["字段说明"].OptionsColumn.ReadOnly = true;
                gridView1.Columns["是否为空"].OptionsColumn.ReadOnly = true;
                gridView1.Columns["是否为空"].Width = 70;
                gridView1.Columns["类型（长度）"].OptionsColumn.ReadOnly = true;
                gridView1.Columns["类型（长度）"].Width = 100;
                gridView1.Columns["导入字段"].OptionsColumn.ReadOnly = false;                
            }
        }

        private void OnEditValueChanged(object sender, EventArgs e)
        {            
            
        }

        private void butImport_Click(object sender, EventArgs e)
        {
            switch (lookUpDesTable.EditValue.ToString().Trim())
            {
                case "StorageAreas":
                    //检查仓库是否选中
                    bool isOk = ImportStorageAreasData();
                    if (isOk == false)
                        return;

                    //检查不为空的数据项是否全选中
                    isOk = CheckImportData();
                    if (isOk == false)
                        return;
                    /*
                    string sqlStorageRack = "";            
                    string sqlStorageAreas = "";
                    List<string> srcRackField = new List<string>();
                    List<string> srcAreaField = new List<string>();
                    SetImportTableInfo("StorageRacks", ref sqlStorageRack, ref srcRackField, gridView1);
                    SetImportTableInfo("StorageAreas", ref sqlStorageAreas, ref srcAreaField, gridView1);

                    List<ImportDataInfo> listStorageAreasData = new List<ImportDataInfo>();
                    List<ImportDataInfo> listStorageRacksData = new List<ImportDataInfo>();
                    SetImportTableInfo("StorageRacks", ref listStorageRacksData, gridView1);
                    SetImportTableInfo("StorageAreas", ref listStorageAreasData, gridView1);
                    */
                    ImportDataBase ImprotWnd = new ImportDataBase(srcData, listImportData);
                    ImprotWnd.ShowDialog();
                    
                    break;

                default:
                    //检查不为空的数据项是否全选中
                    isOk = CheckImportData();
                    if (isOk == false)
                        return;

                    //读取要导入的字段结构List<ImportDataInfo> listImportData;
                    SetImportTableInfo(TargetTable, gridView1);
                    
                    //显示数据导入处理窗口
                    ImportDataBase ImprotWnd1 = new ImportDataBase(srcData, listImportData);
                    if (ImprotWnd1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    break;
            }
        }

        private bool ImportStorageAreasData()
        {
            if (lookUpStorage.EditValue.ToString().Trim().Equals(""))
            {
                MessageBox.Show("请选择要导入的仓库！");
                lookUpStorage.Focus();
                return false;
            }
            return true;
        }

        private void butColse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OnEditValue(object sender, EventArgs e)
        {
            TargetTable = lookUpDesTable.EditValue.ToString().Trim();

            if (!TargetTable.Equals(""))
            {
                ShowImportInfo();
            }
            else
            {
                lookUpStorage.Visible = false;
                labelStorage.Visible = false;

                SetControlEnabled(false);
                gridData.DataSource = null;
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        { 
            
            MessageBox.Show(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "导入字段").ToString());
        }

        private bool CheckImportData()
        {
            string sql = "";

            string str = "";
            string field = "";
            //检查不为空的数据项是否选择了导入项
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                str = gridView1.GetRowCellValue(i, "是否为空").ToString();
                if (str.Equals("不能"))
                {
                    str = gridView1.GetRowCellValue(i, "导入字段").ToString();
                    
                    if (str.Equals("") || str.Equals("null"))
                    {
                        field = gridView1.GetRowCellValue(i, "字段名").ToString();
                        if (!gridView1.GetRowCellValue(i, "字段说明").ToString().Equals(""))
                        {
                            field += "(" + gridView1.GetRowCellValue(i, "字段说明").ToString() + ")";
                        }
                        gridView1.FocusedRowHandle = i;
                        MessageBox.Show(field+"信息不能为空！");
                        return false;
                    }

                    if (sql.Equals(""))
                    {
                        sql = "(" + str + " is null or " + str + "='') ";
                    }
                    else
                    {
                        sql += "or (" + str + " is null or " + str + "='') ";
                    }
                }
            }

            //检查不能为空的字段在源数据表中是否有空的数据
            DataRow[] update_row = srcData.Tables[0].Select(sql);
            if (update_row.Length > 0)
            {
                MessageBox.Show("要导入的数据文件中有字段为空请检查！");
                return false;
            }

            return true;
        }
        
        private void SetImportTableInfo(string destTable, DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            SetImportTableInfo(destTable,ref listImportData, gridview);
        }

        private void SetImportTableInfo(string destTable, ref  List<ImportDataInfo> imData, DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            string tableName = "";
            string destField = "";
            string Importstr = "";

            DevExpress.XtraGrid.Views.Grid.GridView gridDataView = gridview;
            
            //清空已经有的记录
            imData.Clear();

            for (int i = 0; i < gridDataView.RowCount; i++)
            {
                Importstr = gridDataView.GetRowCellValue(i, "导入字段").ToString();

                if (!Importstr.Equals("") && !Importstr.Equals("null"))
                {
                    tableName = gridView1.GetRowCellValue(i, "TableName").ToString();
                    destField = gridView1.GetRowCellValue(i, "字段名").ToString();

                    if (tableName.Equals(destTable))
                    {
                        //srcField.Add(Importstr);
                        importData.TableName = tableName;
                        importData.SrcField = Importstr;
                        importData.DestField = destField;
                        imData.Add(importData);
                    }
                }
            }
        }

        private void SetImportTableInfo(string destTable, ref string destSql, ref List<string> srcField, DevExpress.XtraGrid.Views.Grid.GridView gridview)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridDataView = gridview;
            string tableName = "";
            string destField = "";
            string Importstr = "";

            for (int i = 0; i < gridDataView.RowCount; i++)
            {
                Importstr = gridDataView.GetRowCellValue(i, "导入字段").ToString();

                if (!Importstr.Equals("") && !Importstr.Equals("null"))
                {
                    tableName = gridView1.GetRowCellValue(i, "TableName").ToString();
                    destField = gridView1.GetRowCellValue(i, "字段名").ToString();

                    if (tableName.Equals(destTable))
                    {
                        srcField.Add(Importstr);
                        if (destSql.Equals(""))
                        {
                            destSql = "insert into " + destTable + "(" + destField;
                        }
                        else
                        {
                            destSql += ", " + destField;
                        }
                    }
                }
            }
            destSql += ")";

        }

        private bool CheckRackData()
        {
            string tableName = "";
            string desField = "";

            string sqlStorageRack = "";
            
            string sqlStorageAreas = "";
            List<string> sourRackField = new List<string>();
            List<string> sourAreaField = new List<string>();
                       
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string Importstr = gridView1.GetRowCellValue(i, "导入字段").ToString();

                if (!Importstr.Equals("") && !Importstr.Equals("null"))
                {
                    tableName = gridView1.GetRowCellValue(i, "TableName").ToString();
                    desField = gridView1.GetRowCellValue(i, "字段名").ToString();

                    if (tableName.Equals("StorageRacks"))
                    {
                        sourRackField.Add(Importstr);
                        if (sqlStorageRack.Equals(""))
                        {
                            sqlStorageRack = "insert into " + tableName + "(" + desField;
                        }
                        else
                        {
                            sqlStorageRack += ", " + desField;
                        }
                    }

                    if (tableName.Equals("StorageAreas"))
                    {
                        sourAreaField.Add(Importstr);
                        if (sqlStorageAreas.Equals(""))
                        {
                            sqlStorageAreas = "insert into " + tableName + "(" + desField;
                        }
                        else
                        {
                            sqlStorageAreas += ", " + desField;
                        }
                    }
                }
            }

            sqlStorageRack += ")";
            sqlStorageAreas += ")";
            MessageBox.Show(sqlStorageRack);
            MessageBox.Show(sqlStorageAreas);

            return true;
        }
    }
}
