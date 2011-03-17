using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;
namespace SCM_CangJi
{
    public class DataHandler
    {
        public static object PromptAndImportEntities(out string[][] datas)
        {
            string[] sourceColumns = null;
            FileInfo file = null;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                file = new FileInfo(dlg.FileName);
            }
            else
            {
                datas = null;
                return null;
            }
            string[][] sourcedatas = null;
            if (file != null)
            {
                sourceColumns = PerformImport(file, out sourcedatas, 2);
            }
            datas = sourcedatas;
            return (from s in sourceColumns
                    select new
                    {
                        ColumnName = s
                    }).ToList();
        }
        private static string[] PerformImport(FileInfo file,out string[][] datas,int HeaderRows)
        {
            string[] sourceColumns = null;
            List<string> sourceRows = new List<string>();
            int headerLength = 1;
            using (StreamReader reader = file.OpenText())
            {
                while (reader.Peek() >= 0)
                {
                    string rowline = reader.ReadLine();
                    if (headerLength <= HeaderRows)
                    {

                        if (!string.Empty.Equals(rowline.Trim()))
                        {
                            sourceColumns = rowline.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        }
                    }
                    else
                    {
                        if (!string.Empty.Equals(rowline.Trim()))
                        {
                            sourceRows.Add(rowline);
                        }
                    }
                    headerLength++;
                }

            }
            string[][] sourceDatas = new string[sourceRows.Count][];
            for (int i = 0; i < sourceRows.Count; i++)
            {
                sourceDatas[i]=sourceRows[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            }
            datas = sourceDatas;
            return sourceColumns;
        }
    }


}
