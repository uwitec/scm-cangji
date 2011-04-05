using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCM_CangJi.BLL;
using SCM_CangJi.Lib;
using DevExpress.XtraEditors;

namespace SCM_CangJi.WareHouseManage
{
    public partial class EditRackArea : EditForm
    {
        DataTable dataTabTmp = null;
        private DataBaseConnection dataConn = null;

        //保存当前列被修改前的信息
        private DataGridViewCell viewEqualCell = null;  //保存当前列被修改前的列
        private string curEditValue;    //保存当前列被修改前的值
        private int curEditCol; //当前列
        private int curEditRow; //当前行

        private int idMax;

        public EditRackArea()
        {
            InitializeVariable();
            InitializeComponent();
        }

        public void InitializeVariable()
        {
            //添加表头
            dataTabTmp = new DataTable();
            if (dataTabTmp == null)
                return;
            dataTabTmp.Columns.Add("Id");
            dataTabTmp.Columns.Add("AreaName");
            dataTabTmp.Columns.Add("DataBaseAct");
            
            //连接数据库
            dataConn = new DataBaseConnection();
            if (dataConn != null)
            {
                string sql="select * from RackArea";
                GetDataInfo(sql);
                idMax = GetId("select max(Id) from RackArea");
            }
        }

        private int GetId(string sql)
        {
            int id = 1;

            DataSet da = dataConn.Query(sql);
            string str = da.Tables[0].Rows[0][0].ToString();
            if (str.Equals("") || str==null)
                return id;
                        
            id = int.Parse(str);

            return id;
        }

        private void GetDataInfo(string sql)
        {
            DataSet da = dataConn.Query(sql);
            int count = da.Tables[0].Rows.Count;
            if (count <= 0)
                return;

            dataTabTmp.Clear();
            for (int i = 0; i < count; i++)
            {
                DataRow tmpDr = dataTabTmp.NewRow();
                string id = da.Tables[0].Rows[i]["Id"].ToString();
                tmpDr["Id"] = id;
                tmpDr["AreaName"] = da.Tables[0].Rows[i]["AreaType"].ToString();

                dataTabTmp.Rows.Add(tmpDr);
            }
        }

        public void ShowDataInfo()
        {
            if (dataTabTmp == null || dataTabTmp.Rows.Count == 0)
            {
                return;
            }
                        
            //列的个数设置
            this.RackTypeGridView.ColumnCount = 2;

            //初始化列，清除残余信息
            this.RackTypeGridView.Columns.Clear();
            
            //设置列头信息
            this.RackTypeGridView.Columns.Add("Id", "类型ID");
            //this.RackTypeGridView.Columns[0].Width = 80;
            this.RackTypeGridView.Columns[0].Visible = false;
            this.RackTypeGridView.Columns.Add("AreaName", "区域名称");
            this.RackTypeGridView.Columns[1].Width = 240;
            this.RackTypeGridView.Columns.Add("DataBaseAct", "数据库操作");
            this.RackTypeGridView.Columns[2].Visible = false;

            //设置行
            this.RackTypeGridView.Rows.Add(dataTabTmp.Rows.Count);
            
            //添加每一行
            for (int i = 0; i < dataTabTmp.Rows.Count; i++)
            {
                this.RackTypeGridView.Rows[i].Cells["Id"].Value =
                        dataTabTmp.Rows[i]["Id"].ToString();
                this.RackTypeGridView.Rows[i].Cells[0].ReadOnly = true;

                this.RackTypeGridView.Rows[i].Cells["AreaName"].Value =
                        dataTabTmp.Rows[i]["AreaName"].ToString();

                this.RackTypeGridView.Rows[i].Cells["DataBaseAct"].Value =
                        dataTabTmp.Rows[i]["DataBaseAct"].ToString();
            }

            //设置显示最后一行
            RackTypeGridView.FirstDisplayedScrollingRowIndex = RackTypeGridView.Rows.Count - 1;
            RackTypeGridView.Rows[RackTypeGridView.Rows.Count - 1].Selected = true;
            RackTypeGridView.Rows[0].Selected = false;

            curEditRow = RackTypeGridView.Rows.Count - 1;
        }

        public bool Equal(string colname, string value)
        {
            string str;
            bool IsEq = false;
            for (int i = 0; i < RackTypeGridView.Rows.Count; i++)
            {
                str = RackTypeGridView.Rows[i].Cells[colname].Value.ToString();
                if (str.Equals(value))
                {
                    RackTypeGridView.FirstDisplayedScrollingRowIndex = i;
                    RackTypeGridView.Rows[i].Selected = true;

                    IsEq = true;
                }
                else
                {
                    RackTypeGridView.Rows[i].Selected = false;
                }
            }

            return IsEq;
        }
        
        public bool Equal(string colname, string value, int curRow)
        {
            string str;
            bool IsEq = false;
            for (int i = 0; i < RackTypeGridView.Rows.Count; i++)
            {
                str = RackTypeGridView.Rows[i].Cells[colname].Value.ToString();
                if (str.Equals(value) && i != curRow)
                {
                    IsEq = true;
                }
            }

            return IsEq;
        }

        private void AddDataInfo(string sValue, ACTION act)
        {
            sValue = sValue.Trim();
            if (!sValue.Equals(""))
            {
                if (Equal("AreaName", sValue))
                {
                    XtraMessageBox.Show(sValue+" 已被添加!");
                    return;
                }

                idMax += 1;

                DataRow tmpDr = dataTabTmp.NewRow();
                tmpDr["Id"] = idMax.ToString();
                tmpDr["AreaName"] = sValue;
                tmpDr["DataBaseAct"] = act;
                dataTabTmp.Rows.Add(tmpDr);
                textAreaName.Text = "";

                ShowDataInfo();
            }
        }

        private void butAdd_Click(object sender, EventArgs e)
        {
            if (dataTabTmp == null)
                return;

            AddDataInfo(textAreaName.Text, ACTION.INSERT);
            textAreaName.Focus();
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            UpdateDataBase();
            GetDataInfo("select * from RackArea");
            ShowDataInfo();
        }

        private void UpdateDataBase()
        {
            string str = "";
            string act = "";
            string id = "";
            int count = -1;
            for (int i = 0; i < RackTypeGridView.Rows.Count; i++)
            {
                act = RackTypeGridView.Rows[i].Cells["DataBaseAct"].Value.ToString();
                id = RackTypeGridView.Rows[i].Cells["Id"].Value.ToString();

                if (act == "INSERT")
                {
                    str = "insert into RackArea(AreaType) values(N'" + RackTypeGridView.Rows[i].Cells["AreaName"].Value.ToString() + "')";
                    count = dataConn.Update(str);

                    if (count < 0)
                    {
                        XtraMessageBox.Show("数据添加失败！");
                    }
                    else
                    {
                        RackTypeGridView.Rows[i].Cells["DataBaseAct"].Value = "";
                    }
                }

                if (act == "UPDATE")
                {
                    str = "update RackArea set AreaType=N'" + RackTypeGridView.Rows[i].Cells["AreaName"].Value.ToString() + "' where id=" + id;
                    count = dataConn.Update(str);

                    if (count < 0)
                    {
                        XtraMessageBox.Show("数据更新失败！");
                    }
                    else
                    {
                        RackTypeGridView.Rows[i].Cells["DataBaseAct"].Value = "";
                        curEditValue = "";
                    }
                }
            }

            if (count > 0)
            {
                XtraMessageBox.Show("数据保存成功！");
            }
            RackTypeGridView.EndEdit();
        }

        private void OnCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (view == null)
                return;

            string str = "";
            bool IsError = false;

            if (view.CurrentCell.Value == null)
            {
                view.CurrentCell.ErrorText = "不能为空";
                XtraMessageBox.Show("不能为空");
                RackTypeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = curEditValue;
                IsError = true;
            }
            else
            {
                str = view.CurrentCell.Value.ToString().Trim();
                if (str == "")
                {
                   view.CurrentCell.ErrorText = "不能为空";
                   XtraMessageBox.Show("不能为空");
                   RackTypeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = curEditValue;
                   IsError = true;
                }
                else
                {
                    if (Equal("AreaName", str, e.RowIndex))
                    {
                        view.CurrentCell.ErrorText = "添加的类型已存在";
                        XtraMessageBox.Show("添加的货架类型已存在");
                        RackTypeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = curEditValue;
                        IsError = true;
                    }
                    else
                    {
                        view.CurrentCell.ErrorText = "";
                        IsError = false;
                    }
                     
                }
            }

            if (IsError == true)
            {
                viewEqualCell = view.CurrentCell;
                RackTypeGridView.CurrentCell = viewEqualCell;
            }
            else
            {
                viewEqualCell = null;
            }

            str = RackTypeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string update = RackTypeGridView.Rows[e.RowIndex].Cells["DataBaseAct"].Value.ToString();

            if (!curEditValue.Equals(str) && !update.Equals("INSERT"))
            {
                RackTypeGridView.Rows[e.RowIndex].Cells["DataBaseAct"].Value = ACTION.UPDATE;
            }
        }
        
        private void OnLoad(object sender, EventArgs e)
        {
            ShowDataInfo();
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            if (viewEqualCell == null)
            {
                return;
            }

            try
            {
                this.RackTypeGridView.CurrentCell = this.viewEqualCell;
                this.RackTypeGridView.CurrentCell.Selected = true;
                this.RackTypeGridView.BeginEdit(true);
            }
            catch (Exception)
            {

            }

        }

        private void OnCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            curEditCol = e.ColumnIndex;
            curEditRow = e.RowIndex;
            curEditValue = RackTypeGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            bool isUpdate = CheckUpdate();

            if (isUpdate == true)
            {
                DialogResult result = XtraMessageBox.Show("信息尚未处理，是否关闭？ ", "货架类型管理", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    if (dataConn != null)
                    {
                        dataConn.Close();
                    }

                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private bool CheckUpdate()
        {
            string str;
            for (int i = 0; i < RackTypeGridView.Rows.Count; i++)
            {
                str = RackTypeGridView.Rows[i].Cells["DataBaseAct"].Value.ToString();
                if (str!="")
                {
                    return true;
                }
            }
            
            //没进行过任何操作
            if (curEditValue == "" || curEditValue == null)
                return false;

            //检查焦点没离开是否有改动
            if (curEditRow < 0) return false; 
            RackTypeGridView.EndEdit();
            str = RackTypeGridView.Rows[curEditRow].Cells[curEditCol].Value.ToString();

            if (!str.Equals(curEditValue))
            {
                return true;
            }
            
            return false;
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            DeleteDataBase();
        }

        private void DeleteDataBase()
        {
            string sql = "";
            string id = "";

            int count = -1;

            if (curEditRow < 0)
                return;

            id = RackTypeGridView.Rows[curEditRow].Cells["id"].Value.ToString();
            if (id.Equals(""))
                return;

            DialogResult result = XtraMessageBox.Show("是否要删除数据？删除后将不能恢复！", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.No)
            {
                return;
            }

            //删除数据库
            sql = "delete RackArea where id=" + id;
            count = dataConn.Update(sql);

            //删除GridView中的数据
            RackTypeGridView.Rows.RemoveAt(curEditRow);

            //DataTable中的数据
            int deleterow = FindDataTable(id);
            if (deleterow >= 0)
            {
                dataTabTmp.Rows.RemoveAt(deleterow);
            }

            curEditRow -= 1;
            if (curEditRow < 0) return;

            RackTypeGridView.FirstDisplayedScrollingRowIndex = curEditRow;
            RackTypeGridView.Rows[curEditRow].Selected = true;
        }

        private int FindDataTable(string value)
        {
            string id;
            for (int i = 0; i < dataTabTmp.Rows.Count; i++)
            {
                id = dataTabTmp.Rows[i]["Id"].ToString();
                if (id.Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            curEditRow = e.RowIndex;
        }

    }
}
