using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using SCM_CangJi.BLL;
using SCM_CangJi.Lib;
using DevExpress.XtraEditors;

namespace SCM_CangJi.WareHouseManage
{
    public partial class EditStorageRack : EditForm
    {
        private StorageRackManage rackManage = null;

        private DataBaseConnection dataConn = null;

        ACTION actDataBase;

        private StorageRack updateStorageRack;

        NavigationRackButton buttonNav = null;

        public EditStorageRack(ACTION act, int Rackid, string RackName, int StorageId)
        {   
            InitializeComponent();
            InitializeVariable();

            rackManage = null;
            actDataBase = act;
            updateStorageRack.id = Rackid;
            updateStorageRack.RackName = RackName;
            updateStorageRack.StorageID = StorageId;
        }

        public EditStorageRack(ACTION act, StorageRackManage rack)
        {
            rackManage = rack;
            actDataBase = act;

            InitializeComponent();
            InitializeVariable();
        }
        public void InitializeVariable()
        {
            dataConn = new DataBaseConnection();
            updateStorageRack = new StorageRack();

            if (buttonNav == null)
            {
                buttonNav = new NavigationRackButton();
                panelRackArea.Controls.Add(buttonNav);
                buttonNav.Click += new System.EventHandler(this.buttonNav_Click);
                buttonNav.CreateFrame(0, 0, 0, 30, Color.FromArgb(173, 209, 255), Color.FromArgb(101, 147, 201));
                buttonNav.AddButton("编辑库位信息", 0); 
            }
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butRackSave_Click(object sender, EventArgs e)
        {
            switch (actDataBase)
            {
                case ACTION.INSERT:
                    bool b = InsertDataBase();
                    if (b)//保存成功就转为更新
                    {
                        actDataBase = ACTION.UPDATE;
                        GetStorageRackId();

                        if (rackManage != null)
                        {
                            rackManage.ShowXtraGridView(updateStorageRack.StorageID);
                        }

                        XtraMessageBox.Show("数据保存成功，请为该货架添加库位信息！");
                        panelRackArea.Enabled = true;
                    }
                    break;

                case ACTION.UPDATE:
                    UpdateDataBase();
                    break;
            }
        }

        //获取控件值
        private void GetControlValue()
        {
            //textRackName.EditValue.ToString()
            updateStorageRack.RackName = textRackName.Text;
            updateStorageRack.RackStyleID = comRackType.SelectedValue.ToString();
            updateStorageRack.RackSaveAreaID = comRackArea.SelectedValue.ToString();
            updateStorageRack.Remark = richRackReMark.Text;
        }

        private void UpdateDataBase()
        {
            int count = -1;
            string sql;
            sql = "update StorageRacks set RackName=" + "N'" + textRackName.Text.Trim() + "', " +
                "RackTypeID=" +  comRackType.SelectedValue.ToString() + ", " +
                 "RackAreaID=" + comRackArea.SelectedValue.ToString() + ", " +
                  "Remark=" + "N'" + richRackReMark.Text.Trim() +
                  "' where id=" + updateStorageRack.id +
                  " and StorageID=" + updateStorageRack.StorageID;

            count = dataConn.Update(sql);

            if (count > 0)
            {
                XtraMessageBox.Show("更新成功！");
            }
            else
            {
                XtraMessageBox.Show("没找到要更新的信息！");
            }
        }

        private bool InsertDataBase()
        {
            //获取控件值
            GetControlValue();

            //查询数据库
            string sql = "select * from StorageRacks where StorageID='" +
                updateStorageRack.StorageID.ToString() + "' and RackName='" + updateStorageRack.RackName + "'";
            DataSet custDs = dataConn.Query(sql);
            
            int count = custDs.Tables[0].Rows.Count;
            if (count > 0)
            {
                XtraMessageBox.Show("该货架已存在,请重新输入!");
                textRackName.Select();
                return false;
            }

            sql = "insert StorageRacks(RackName, RackAreaID, RackTypeID, Remark, Row, StorageID) values("
                + "N'" + updateStorageRack.RackName.Trim() + "',"
                + updateStorageRack.RackSaveAreaID + ","
                + updateStorageRack.RackStyleID + ","
                + "N'" + updateStorageRack.Remark.Trim() + "',"
                + "1,"
                + updateStorageRack.StorageID.ToString() + ")"; ;
            
            count = dataConn.Update(sql);

            if (count == 0)
            {
                XtraMessageBox.Show("数据保存失败！");
                return false;
            }
            
            return true;
        }

        //获取保存到数据库中的货架编号
        private void GetStorageRackId()
        {
            string sql = "select id from StorageRacks where StorageID='" +
                updateStorageRack.StorageID.ToString() + "' and RackName='" + updateStorageRack.RackName + "'";
            DataSet da = dataConn.Query(sql);
            
            int count = da.Tables[0].Rows.Count;
            if (count > 0)
            {
                updateStorageRack.id = int.Parse(da.Tables[0].Rows[0][0].ToString());
            }
        }

        private void butRackDelete_Click(object sender, EventArgs e)
        {
            int count = -1;

            DialogResult result = XtraMessageBox.Show("是否要删除数据？删除后将不能恢复！", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.No)
            {
                return;
            }

            string sql;
            sql = "delete StorageRacks where id=" + updateStorageRack.id +
                " and StorageID=" + updateStorageRack.StorageID;
            count = dataConn.Update(sql);

            if (count > 0)
            {
                XtraMessageBox.Show("删除成功！");
                actDataBase = ACTION.DELETE;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("没找到要删除的信息！");
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //填充下拉列表框
            AddComboBoxInfo();
            if (rackManage != null)
            {
                updateStorageRack.StorageID = rackManage.GetStorageId(); //保存仓库ID
                updateStorageRack.StorageName = rackManage.GetStorageName();
            }
            
            switch (actDataBase)
            {
                case ACTION.INSERT:
                    this.Text = updateStorageRack.StorageName + "仓库货架管理";

                    break;

                case ACTION.UPDATE:
                    this.Text = "编辑 " + updateStorageRack.RackName + " 货架信息";
                    panelRackArea.Enabled = true;

                    string sql = "select RackName,(select TypeName from RackType where RackTypeID=id) as 货架类型,"
                        + "(select AreaType from RackArea where RackAreaID=id) as 存储区域, Remark,RackAreaID,RackTypeID "
                        + "from StorageRacks where Id=" + updateStorageRack.id.ToString() +" and "
                        + "StorageID="+updateStorageRack.StorageID.ToString();

                    DataSet da = dataConn.Query(sql);
                    int count = da.Tables[0].Rows.Count;
                    if (count <= 0)
                        return;

                    for (int i = 0; i < count; i++)
                    {
                        updateStorageRack.Remark = da.Tables[0].Rows[i]["RackName"].ToString();
                        updateStorageRack.RackStyleName = da.Tables[0].Rows[i]["货架类型"].ToString();
                        updateStorageRack.RackStyleID = da.Tables[0].Rows[i]["RackTypeID"].ToString();
                        updateStorageRack.RackSaveAreaName = da.Tables[0].Rows[i]["存储区域"].ToString();
                        updateStorageRack.RackSaveAreaID = da.Tables[0].Rows[i]["RackAreaID"].ToString();
                        updateStorageRack.RackName = da.Tables[0].Rows[i]["Remark"].ToString();
                    }

                    textRackName.Text = updateStorageRack.Remark;
                    comRackArea.Text = updateStorageRack.RackSaveAreaName;
                    comRackType.Text = updateStorageRack.RackStyleName;
                    richRackReMark.Text = updateStorageRack.RackName;

                    break;
            }

            GetStorageRackAreaData();
            
            if (buttonNav != null)
            {
                buttonNav.SetWindowPos(panelRackArea.Left + 2, 10, panelRackArea.Width - (panelRackArea.Left + 10), 30);
                ShowGridView();
            }
        }

        private void AddComboBoxInfo()
        {
            butRackSave.Enabled = true;
            DataSet da = dataConn.Query("select * from RackArea");
            int count = da.Tables[0].Rows.Count;
            if (count <= 0)
            {
                butRackSave.Enabled = false;
                return;
            }

            comRackArea.DataSource = da.Tables[0];
            comRackArea.DisplayMember = "AreaType";
            comRackArea.ValueMember = "id";

            
            da = dataConn.Query("select * from RackType");
            count = -1;
            count = da.Tables[0].Rows.Count;
            if (count <= 0)
            {
                butRackSave.Enabled = false;
                return;
            }

            comRackType.DataSource = da.Tables[0];
            comRackType.DisplayMember = "TypeName";
            comRackType.ValueMember = "id";
        }

        private void GetStorageRackAreaData()
        {
            ShowXtraGridView();
        }

        private void buttonNav_Click(object sender, EventArgs e)
        {
            EditStorageRackArea area = new EditStorageRackArea(updateStorageRack.id, updateStorageRack.RackName);
            area.ShowDialog();
            GetStorageRackAreaData();
        }

        #region DevExpress.XtraGrid

        DevExpress.XtraGrid.GridControl gridTab = null;
        DevExpress.XtraGrid.Views.Grid.GridView gridView = null;
        //DataGridView gridTab = null;
        public void ShowXtraGridView()
        {
            if (gridTab == null)
            {
                //gridTab = new DataGridView();
                gridTab = new DevExpress.XtraGrid.GridControl();
                gridTab.DoubleClick += new System.EventHandler(gridDoubleClick);
                gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
                gridTab.MainView = gridView;
                gridView.OptionsBehavior.Editable = false;
                gridView.GridControl = gridTab;
                panelRackArea.Controls.Add(gridTab);
            }
            
            DataBaseConnection dataConn = new DataBaseConnection();

            DataSet da;
            string sql = "select Id as '库位自动编号',[库位编号],[备注] from StorageAreas where StorageRackId=" + updateStorageRack.id;
            da = dataConn.Query(sql);

            int count = da.Tables[0].Rows.Count;
            if (count <= 0)
            {
                gridTab.DataSource = null;
                buttonNav.SetBuottonName(0, "增加库位");
                return;
            }

            gridTab.DataSource = da.Tables[0];
            buttonNav.SetBuottonName(0, "编辑库位信息");
        }
        private void gridDoubleClick(object sender, EventArgs e)
        {
            
        }

        private void ShowGridView()
        {
            if (gridTab != null)
            {
                gridTab.Top = buttonNav.Bottom + 1;
                gridTab.Left = buttonNav.Left;
                gridTab.Width = panelRackArea.Width - gridTab.Left - 8;
                gridTab.Height = panelRackArea.Height - (gridTab.Top + 10);
            }
        }
        #endregion
    }
}
