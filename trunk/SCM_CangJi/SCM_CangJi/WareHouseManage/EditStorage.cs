using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;
using SCM_CangJi.BLL;
using SCM_CangJi.BLL.Services;


namespace SCM_CangJi.WareHouseManage
{
    public partial class EditStorage : EditForm
    {
        private DataBaseConnection Conn = null;

        private int id;//数据库中自动KEY

        private string strStorageID;
        private string strStorageName;
        private string strStorageAddress;
        private string strStorageRemark;

        private TabStorageManage tabStorageMage;
        private STORAGEINFO updateStorage;

        ACTION actDataBase;

        public EditStorage(ACTION act, TabStorageManage storage)
        {
            id = -1;
            actDataBase = act;

            tabStorageMage = storage;

            if (Conn == null)
            {
                Conn = new DataBaseConnection();
            }

            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            bool isUpdate = true;

            switch (actDataBase)
            {
                case ACTION.INSERT:
                    if (textStorageID.EditValue.ToString() != "" ||
                        textStorageName.EditValue.ToString() != "" ||
                        textStorageAddress.EditValue.ToString() != "" ||
                        richStorageRemark.Text != "")
                    {
                        isUpdate = true;
                    }
                    else
                    {
                        isUpdate = false;

                        if (Conn != null)
                        {
                            Conn.Close();
                        }
                    }

                    break;

                case ACTION.UPDATE:
                    if (textStorageID.EditValue.ToString() != strStorageID ||
                        textStorageName.EditValue.ToString() != strStorageName ||
                        textStorageAddress.EditValue.ToString() != strStorageAddress ||
                        richStorageRemark.Text != strStorageRemark)
                    {
                        isUpdate = true;
                    }
                    else
                    {
                        isUpdate = false;

                        if (Conn != null)
                        {
                            Conn.Close();
                        }
                    }

                    break;

                case ACTION.DELETE:
                    isUpdate = false;
                    if (Conn != null)
                    {
                        Conn.Close();
                    }
                    break;
            }


            if (isUpdate == true)
            {
                DialogResult result = XtraMessageBox.Show("信息尚未处理，是否关闭？ ", "仓库管理", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (result == DialogResult.Yes)
                {
                    if (Conn != null)
                    {
                        Conn.Close();
                    }

                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        } 


        private void butSave_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {   
                switch(actDataBase)
                {
                    case ACTION.INSERT:
                        bool b = InsertDataBase();
                        if(b)//保存成功就转为更新
                        {
                            actDataBase = ACTION.UPDATE;
                            GetStorageData();
                            XtraMessageBox.Show("数据保存成功！");
                            this.Close();
                        }
                        
                        break;

                    case ACTION.UPDATE:
                        UpdateDataBase();
                        GetStorageData();
                        tabStorageMage.GetStorageData();
                        this.Close();
                        break;
                }

                
                //XtraMessageBox.Show(custDs.Tables[0].Rows[0]["仓库名称"].ToString());
            }
        }

        private void UpdateDataBase()
        {
            int count = -1;
            string str;
            str = "update Storages set [仓库编号]=" + "N'" + textStorageID.EditValue.ToString() + "', " +
                "[仓库名称]=" + "N'" + textStorageName.EditValue.ToString() + "', " +
                 "[仓库地址]=" + "N'" + textStorageAddress.EditValue.ToString() + "', " +
                  "[备注]=" + "N'" + richStorageRemark.Text + "' where id=" + id.ToString();
            
            count = Conn.Update(str);

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
            DataSet custDs = Conn.Query("select * from Storages where [仓库编号]='" + textStorageID.EditValue.ToString() + "'");

            int count = custDs.Tables[0].Rows.Count;
            if (count > 0)
            {
                XtraMessageBox.Show("该仓库编号已存在,请重新输入!");
                textStorageID.Select();
                return false;
            }

            String strSql = "insert Storages([仓库编号],[仓库名称],[仓库地址],[备注]) values("
                + "N'" + textStorageID.EditValue.ToString() + "',"
                + "N'" + textStorageName.EditValue.ToString() + "',"
                + "N'" + textStorageAddress.EditValue.ToString() + "',"
                + "N'" + richStorageRemark.Text + "')";

            count = Conn.Update(strSql);

            if (count == 0)
            {
                XtraMessageBox.Show("数据保存失败！");
                return false;
            }
            else
            {
                updateStorage.storageID = textStorageID.EditValue.ToString();
                updateStorage.storageName = textStorageName.EditValue.ToString();
                updateStorage.storageAddress = textStorageAddress.EditValue.ToString();
                updateStorage.storageRemark = richStorageRemark.Text;
                tabStorageMage.SetNextButtonVisible();
                tabStorageMage.GetStorageData();
            }

            return true;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StorageAddressTextChanged(object sender, EventArgs e)
        {
            
        }

        private void OnLoad(object sender, EventArgs e)
        {
            switch (actDataBase)
            {
                case ACTION.INSERT:                    
                    textStorageID.EditValue = "";
                    textStorageName.EditValue = "";
                    textStorageAddress.EditValue = "";
                    richStorageRemark.Text = "";

                    break;

                case ACTION.UPDATE:
                    updateStorage = tabStorageMage.GetClickStorageData();
                    id = updateStorage.id;
                    textStorageID.EditValue = updateStorage.storageID;
                    textStorageName.EditValue = updateStorage.storageName;
                    textStorageAddress.EditValue = updateStorage.storageAddress;
                    richStorageRemark.Text = updateStorage.storageRemark;
                    
                    GetStorageData();

                    break;
            }

            
        }

        public void GetStorageData()
        {
            strStorageID = textStorageID.EditValue.ToString();
            strStorageName = textStorageName.EditValue.ToString();
            strStorageAddress = textStorageAddress.EditValue.ToString();
            strStorageRemark = richStorageRemark.Text;
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            string str;
            int count = -1;

            DialogResult result = XtraMessageBox.Show("是否要删除数据？删除后将不能恢复！", "删除", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (result == DialogResult.No)
            {
                return;
            }

            str="delete Storages where id="+id.ToString();
            count = Conn.Update(str);

            if (count > 0)
            {
                XtraMessageBox.Show("删除成功！");
                actDataBase = ACTION.DELETE;
                tabStorageMage.SetLastButtonVisible();
                tabStorageMage.GetStorageData();
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("没找到要删除的信息！");
            }
        }
    }
}
