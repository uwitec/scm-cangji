using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;

namespace SCM_CangJi.BLL
{
    public class DataBaseConnection
    {
        private SqlConnection conn = null;  //连接数据库的对象
        private string connectionString;
        
        #region 连接数据库构造函数
        public DataBaseConnection()
        {
            if (conn == null)
            {
                connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SCM_CangJiConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);

                if (conn == null)
                {
                    System.Windows.Forms.MessageBox.Show("连接数据库错误，请确定数据库和网络连接是否正常！");
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();//打开数据库连接
                }
            }
        }
        #endregion

        public int GetCount(string sql)
        {
            DataSet custDs = Query(sql);

            int count = -1;
            count = custDs.Tables[0].Rows.Count;
            return count;
        }

        #region 数据库查询
        public DataSet Query(string sql)
        {
            if (conn == null)
            {
                System.Windows.Forms.MessageBox.Show("连接数据库错误，请确定数据库和网络连接是否正常！");
                return null;
            }

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);

            return ds;
        }
        #endregion

        #region 更新数据库
        public int Update(string sql)
        {
            if (conn == null)
            {
                System.Windows.Forms.MessageBox.Show("连接数据库错误，请确定数据库和网络连接是否正常！");
                return -1;
            }

            SqlCommand oc = new SqlCommand();
            oc.CommandText = sql;
            oc.CommandType = CommandType.Text;
            oc.Connection = conn;
            int count = -1;

            try
            {
                count = oc.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                if (ex.Number == 547)
                {
                    System.Windows.Forms.MessageBox.Show("数据已被使用不能删除！");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("数据更新异常！");
                }
            }

            return count;
        }
        #endregion

        #region 关闭数据库连接
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
