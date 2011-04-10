using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;

namespace SCM_CangJi.Commom
{
    public class CommonUtil
    {
        public static void SetProperValue<T>(DataRow row, ImportDataInfo importDataInfo, ref T p)
        {
            Type t = p.GetType();
            var property = t.GetProperty(importDataInfo.DestField);

            if (property.PropertyType == typeof(Int32))
            {
                property.SetValue(p, Convert.ToInt32(row[importDataInfo.SrcField]), null);
            }
            else if (property.PropertyType == typeof(Nullable<Int32>))
            {
                if (row[importDataInfo.SrcField] != null && !string.IsNullOrWhiteSpace(row[importDataInfo.SrcField].ToString()))
                {
                    property.SetValue(p, Convert.ToInt32(row[importDataInfo.SrcField]), null);
                }
            }
            else if (property.PropertyType == typeof(String))
            {
                property.SetValue(p, row[importDataInfo.SrcField], null);
            }
            else if (property.PropertyType == typeof(DateTime))
            {
                property.SetValue(p, Convert.ToDateTime(row[importDataInfo.SrcField]), null);
            }
            else if (property.PropertyType == typeof(Nullable<DateTime>))
            {
                if (row[importDataInfo.SrcField] != null && !string.IsNullOrWhiteSpace(row[importDataInfo.SrcField].ToString()))
                {
                    property.SetValue(p, Convert.ToDateTime(row[importDataInfo.SrcField]), null);
                }
            }
        }
    }
}
