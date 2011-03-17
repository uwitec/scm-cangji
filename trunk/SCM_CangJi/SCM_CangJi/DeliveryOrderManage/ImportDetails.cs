using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCM_CangJi.DAL;
using System.Reflection;
using SCM_CangJi.BLL.Services;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using SCM_CangJi.Lib;

namespace SCM_CangJi.DeliveryOrderManage
{
    public partial class ImportDetails :FormBase
    {
        public event Action<IEnumerable<DeliveryOrderDetail>> OnImported;
        private int _companyId;
        private IEnumerable<DeliveryOrderDetail> details;
        private string[][] datas;
        private DataTable _importProfiles;
        public DataTable ImportProfileDT {
            get
            {
                if (_importProfiles == null)
                {
                    _importProfiles =
ImportProfileService.Instance.GetImportProfileDT(Lib.OrderType.DeliveryOrder);
                }
               return _importProfiles;
            }
        }
        public ImportDetails(int _companyId)
        {
            this._companyId = _companyId;
            InitializeComponent();
            InitGrid();
            InitTarget();
            InitSource();
        }

        private void InitSource()
        {
            object objs=DataHandler.PromptAndImportEntities(out datas);
            ddlSource.DataSource = objs;
        }

        private void InitGrid()
        {
            gridControlImportPorfile.DataSource = this.ImportProfileDT;
        }

        private void InitTarget()
        {
            ddlTarget.DataSource = typeof(DeliveryOrderDetail).GetProperties();
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {
            if (OnImported != null)
            {
                OnImported(details);
            }
        }

        private void gridViewImportProfile_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DataRow row = gridViewImportProfile.GetDataRow(e.RowHandle);
            row["Id"] = 0;
            row["Target"] = string.Empty;
            row["Source"] = string.Empty;
            row["CompanyId"] = this._companyId;
            row["OrderType"] = OrderType.DeliveryOrder;
            row["SourceIndex"] = OrderType.DeliveryOrder;
        }
        private void gridViewImportProfile_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRow row = (e.Row as DataRowView).Row;
        }
        private void SetValue(DataRow row, ref ImportProfile profile)
        {
            profile.OrderType = (int)OrderType.DeliveryOrder;
            profile.CompanyId = _companyId;
            profile.Source = row["Source"].ToString() ;
            profile.Target = row["Target"].ToString();
            profile.SourceIndex = int.Parse(row["SourceIndex"].ToString());
        }
        private void SetRowValue(DataRow row, ImportProfile profile)
        {
            row["Id"] = profile.Id;
            row["Target"] = profile.Target;
            row["Source"] = profile.Source;
            row["CompanyId"] = this._companyId;
            row["OrderType"] = OrderType.DeliveryOrder;
            row["SourceIndex"] = OrderType.DeliveryOrder;
        }

        int rowhandle = -1;
        private void gridViewImportProfile_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                rowhandle = -1;
                // Delete existing menu items, if any.
                e.Menu.Items.Clear();


                DXMenuItem menuItemDelete = new DXMenuItem("删除", (s, en) =>
                {
                    if (XtraMessageBox.Show("确实要删除吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        int profileId = (int)gridViewImportProfile.GetRowCellValue(rowhandle, "Id");
                        string message = "";
                        if (ImportProfileService.Instance.Delete(profileId))
                        {
                            gridViewImportProfile.DeleteSelectedRows();
                        }
                        else
                        {
                            ShowMessage(message);
                        }
                    }
                });
                e.Menu.Items.Add(menuItemDelete);
                DXMenuItem menuItemrefrash = new DXMenuItem("刷新", (s, en) =>
                {
                    _importProfiles = null;
                    if (this.CheckUpdatedStatus())
                        InitGrid();
                    Updated = true;
                });
                e.Menu.Items.Add(menuItemrefrash);

                rowhandle = e.HitInfo.RowHandle;
            }
        }

       

    }
}