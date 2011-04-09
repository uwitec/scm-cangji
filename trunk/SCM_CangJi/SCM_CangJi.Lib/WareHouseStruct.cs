using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace SCM_CangJi.Lib
{
    #region 数据库操作动作
    public enum ACTION { INSERT, UPDATE, DELETE }
    #endregion

    #region 仓库信息
    public struct STORAGEINFO
    {
        public int id;
        public string storageID;
        public string storageName;
        public string storageAddress;
        public string storageRemark;
        public Rectangle rect;
        public bool isShow;	//是否显示
        public uint nClick;	//选中状态
        public uint nFlags;
    }
    #endregion

    #region 货架信息
    public struct StorageRack
    {
        public int id;
        public string RackName;
        public string RackSaveAreaName;
        public string RackSaveAreaID;
        public string RackStyleName;
        public string RackStyleID;
        public int Rows;
        public string Remark;
        public int StorageID;
        public string StorageName;
    }
    #endregion
            
    #region 物品信息
    public struct WPXX
    {
        public String CWID;
        public String CWName;
        public String sWPName;
        public int iCs;	//摆放层数	
        public int iPs;	//摆放排数
        public int iSl;	//商品数量
        public Rectangle cWPRect;
        public uint nFlags;
        public uint nCheck;
    }
    #endregion

    #region 货架信息
    public struct CWXX
    {
        public String CWID;
        public String CWName;
        public int maxrow;
    }
    #endregion

    #region 层按纽信息
    public struct RowInfo
    {
        public int RowID;
        public Rectangle rect;
        public uint nFlags;
    }
    #endregion

    #region 货架层信息
    public struct CCXX
    {
        public String CWID;
        public int CID;
        public int PID;
        public int maxcol;
        public String sWPName;
        public int sl;
        public String PName;
        public Rectangle CCRect;	//每排的矩形
        public uint nFlags;
        public uint nCheck;
    }
    #endregion

    #region 导入的数据结构
    public struct ImportDataInfo
    {
        public string TableName;    //表名称
        public string DestField;    //目标字段
        public string SrcField;     //源字段
    }
    #endregion

    
}
