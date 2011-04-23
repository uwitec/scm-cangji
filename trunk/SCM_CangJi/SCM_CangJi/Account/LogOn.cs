using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml.Serialization;

namespace SCM_CangJi.Account
{
    public partial class LogOn : FormBase
    {
        public LogOn()
        {
            InitializeComponent();
        }

        private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (SCM_CangJi.BLL.Services.AccountService.Instance.ValidateUser(txtUserName.EditValue.ToString(), txtPassword.EditValue.ToString()))
                {
                   //UpdateDB();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("登录失败！用户或者密码错误！");
                }
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;

            }
        }

        private void UpdateDB()
        {
            SqlScriptExcution s = new SqlScriptExcution();
            s.HasRunned = false;

            string path = System.Windows.Forms.Application.StartupPath + "\\PrintLayout";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            path += "\\SQL.xml";
            if (System.IO.File.Exists(path))
            {
                return;
            }
            string sql=GetSql();
            s.Script = sql;
            s.HasRunned = BLL.Services.CommonService.Instance.UpdateDB(sql);
           
            XmlSerializer ser = new XmlSerializer(s.GetType());
            ser.Serialize(new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite), s);
        }

        private string GetSql()
        {
            string sql = @"

EXECUTE sp_addextendedproperty N'MS_Description', '商品号', N'SCHEMA', N'dbo', N'TABLE', N'InputOrderDetails', N'COLUMN', N'ProductId'

EXECUTE sp_addextendedproperty N'MS_Description', N'入库数量', N'SCHEMA', N'dbo', N'TABLE', N'InputOrderDetails', N'COLUMN', N'InputCount'

EXECUTE sp_addextendedproperty N'MS_Description', N'生产日期', N'SCHEMA', N'dbo', N'TABLE', N'InputOrderDetails', N'COLUMN', N'ProductDate'

EXECUTE sp_addextendedproperty N'MS_Description', N'批号', N'SCHEMA', N'dbo', N'TABLE', N'InputOrderDetails', N'COLUMN', N'LotsNumber'

EXECUTE sp_addextendedproperty N'MS_Description', N'备注', N'SCHEMA', N'dbo', N'TABLE', N'InputOrderDetails', N'COLUMN', N'Remark'


EXEC sys.sp_addextendedproperty N'MS_Description', N'中文名' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'ProductChName'

EXEC sys.sp_addextendedproperty N'MS_Description', N'英文名' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'ProductEngName'

EXEC sys.sp_addextendedproperty N'MS_Description', N'品号1' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'ProductNumber1'

EXEC sys.sp_addextendedproperty N'MS_Description', N'品号2' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'ProductNumber2'

EXEC sys.sp_addextendedproperty N'MS_Description', N'规格' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'Spec'

EXEC sys.sp_addextendedproperty N'MS_Description', N'条形码' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'BarCode'


EXEC sys.sp_addextendedproperty N'MS_Description', N'商品类型' , N'SCHEMA',N'dbo', N'TABLE',N'Products', N'COLUMN',N'ProductTypeId'

";
            return sql;
        }
    }
    /// <summary>
    /// 最终用户对某个打印页的设置
    /// </summary>
    [Serializable()]
    public class SqlScriptExcution
    {
        public SqlScriptExcution()
        {
        }
        public bool HasRunned;
        public string Script = "";
    }
}
