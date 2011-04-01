using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraPrinting;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml.Serialization;

namespace SCM_CangJi.Print
{
    
    public class PrintSettingController
    {
       public event Action OnPrinted;
        PrintingSystem ps = null;
        string formName = null;

        DevExpress.XtraPrinting.PrintableComponentLink link = null;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control">要打印的部件</param>
        /// <param name="FormName">此部件对应的布局信息</param>
        public PrintSettingController(IPrintable control, string FormName)
        {
            formName = FormName;
            ps = new DevExpress.XtraPrinting.PrintingSystem();
            link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            ps.Links.Add(link);
            link.Component = control;
            ps.PageSettingsChanged -= new EventHandler(ps_PageSettingsChanged);
            LoadPageSetting();
            ps.PageSettingsChanged += new EventHandler(ps_PageSettingsChanged);
            ps.AfterMarginsChange += new MarginsChangeEventHandler(ps_AfterMarginsChange);
            ps.EndPrint += new EventHandler(ps_EndPrint);
        }

        void ps_EndPrint(object sender, EventArgs e)
        {
            if (OnPrinted != null)
                OnPrinted();
        }
       
        public void Preview()
        {
            try
            {
                if (DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable)
                {
                    Cursor.Current = Cursors.AppStarting;
                    if (_PrintHeader != null)
                    {
                        PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                        phf.Header.Content.Clear();
                        phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
                        phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
                        phf.Header.LineAlignment = BrickAlignment.Center;
                    }
                    link.PaperKind = ps.PageSettings.PaperKind;
                    link.Margins = ps.PageSettings.Margins;
                    link.Landscape = ps.PageSettings.Landscape;
                    link.CreateDocument();
                    ps.PreviewFormEx.Show();

                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    XtraMessageBox.Show("打印机不可用...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        /// <summary>
        /// 打印控制器
        /// </summary>
        /// <param name="control">要打印的部件</param>
        public PrintSettingController(IPrintable control)
        {
            if (control == null) return;
            Control c = (Control)control;
            formName = c.FindForm().GetType().FullName + "." + c.Name;
            ps = new DevExpress.XtraPrinting.PrintingSystem();
            link = new DevExpress.XtraPrinting.PrintableComponentLink(ps);
            ps.Links.Add(link);
            link.Component = control;
            ps.PageSettingsChanged -= new EventHandler(ps_PageSettingsChanged);
            LoadPageSetting();
            ps.PageSettingsChanged += new EventHandler(ps_PageSettingsChanged);
            ps.AfterMarginsChange += new MarginsChangeEventHandler(ps_AfterMarginsChange);

        }
        public void ExportToHtml()
        {
            try
            {
                using (SaveFileDialog fd = new SaveFileDialog())
                {
                    fd.Title = "导出HTML文件";
                    fd.RestoreDirectory = true;
                    fd.Filter = "HTML文件|*.htm";
                    fd.FilterIndex = 1;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        //      if(obj is DevExpress.XtraGrid.GridControl)
                        //      {
                        //       ((DevExpress.XtraGrid.GridControl)obj).ExportToHtml(fd.FileName);
                        //       XtraMessageBox.Show("文件导出成功","导出",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //      }
                        //      else if(obj is DevExpress.XtraTreeList.TreeList)
                        //      {
                        link.CreateDocument();
                        ps.ExportToHtml(fd.FileName);
                        XtraMessageBox.Show("文件导出成功", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //      }

                    }
                }
            }
            finally
            {
            }
        }
        /// <summary>
        /// 网格分组时要导出，请使用这个，
        /// </summary>
        public void GridGroupToExcel()
        {
            DevExpress.XtraGrid.GridControl grid = this.link.Component as DevExpress.XtraGrid.GridControl;
            if (grid != null)
            {
                using (SaveFileDialog fd = new SaveFileDialog())
                {
                    fd.Title = "导出Excel文件";
                    fd.RestoreDirectory = true;
                    fd.Filter = "Excel文件|*.xls";
                    fd.FilterIndex = 1;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {

                        grid.ExportToXls(fd.FileName);
                        XtraMessageBox.Show("文件导出成功", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
            }
        }
        public void ExportToExcel()
        {
            try
            {
                using (SaveFileDialog fd = new SaveFileDialog())
                {
                    fd.Title = "导出Excel文件";
                    fd.RestoreDirectory = true;
                    fd.Filter = "Excel文件|*.xls";
                    fd.FilterIndex = 1;
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        //      if(obj is DevExpress.XtraGrid.GridControl)
                        //      {
                        //       ((DevExpress.XtraGrid.GridControl)obj).ExportToExcel(fd.FileName);
                        //       XtraMessageBox.Show("文件导出成功","导出",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        //      }
                        //      else if(obj is DevExpress.XtraTreeList.TreeList)
                        //      {
                        link.CreateDocument();
                        ps.ExportToXls(fd.FileName);
                       XtraMessageBox.Show("文件导出成功", "导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //      }


                    }
                }
            }
            finally
            {
            }
        }
        string _PrintHeader = null;
        /// <summary>
        /// 打印时的标题
        /// </summary>
        public string PrintHeader
        {
            set
            {
                _PrintHeader = value;
            }
        }
        /// <summary>
        /// 进行打印
        /// </summary>
        public void Print()
        {
            try
            {
                if (DevExpress.XtraPrinting.PrintHelper.IsPrintingAvailable)
                {
                    if (_PrintHeader != null)
                    {
                        PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                        phf.Header.Content.Clear();
                        phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
                        phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
                        phf.Header.LineAlignment = BrickAlignment.Center;
                    }
                    link.PaperKind = ps.PageSettings.PaperKind;
                    link.Margins = ps.PageSettings.Margins;
                    link.Landscape = ps.PageSettings.Landscape;
                    link.CreateDocument();
                    link.CreateDocument();
                    ps.Print();
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    XtraMessageBox.Show("打印机不可用...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            finally
            {
            }
        }


        private void ps_AfterMarginsChange(object sender, MarginsChangeEventArgs e)
        {
            SavePageSetting();
        }

        private void ps_PageSettingsChanged(object sender, EventArgs e)
        {
            SavePageSetting();
        }

        //获取页面设置信息
        void LoadPageSetting()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + "\\PrintLayout";
                if (!System.IO.Directory.Exists(path))
                {
                    return;
                }
                path += "\\" + formName + ".xml";
                if (!System.IO.File.Exists(path))
                {
                    return;
                }
                XmlSerializer ser = new XmlSerializer(typeof(UserPageSetting));
                UserPageSetting setting = (UserPageSetting)ser.Deserialize(new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));

                System.Drawing.Printing.Margins m = new System.Drawing.Printing.Margins(setting.Left, setting.Right, setting.Top, setting.Bottom);
                ps.PageSettings.Assign(m, (System.Drawing.Printing.PaperKind)setting.PaperKind, setting.Landscape);
            }
            catch { }
        }
        /// <summary>
        /// 保存当前网格的布局
        /// </summary>
        void SavePageSetting()
        {
            try
            {
                string path = System.Windows.Forms.Application.StartupPath + "\\PrintLayout";
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path += "\\" + formName + ".xml";
                DevExpress.XtraPrinting.XtraPageSettings setting = ps.PageSettings;
                UserPageSetting s = new UserPageSetting();
                s.Landscape = setting.Landscape;
                s.Left = setting.Margins.Left;
                s.Right = setting.Margins.Right;
                s.Top = setting.Margins.Top;
                s.Bottom = setting.Margins.Bottom;
                s.PaperKind = (int)setting.PaperKind;
                XmlSerializer ser = new XmlSerializer(s.GetType());
                ser.Serialize(new System.IO.FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite), s);
            }
            catch { }
        }


    }
    /// <summary>
    /// 最终用户对某个打印页的设置
    /// </summary>
    [Serializable()]
    public class UserPageSetting
    {
        public UserPageSetting()
        {
        }
        public bool Landscape;
        public int PaperKind;
        public int Top;
        public int Bottom;
        public int Left;
        public int Right;
    }

    //如何使用:

    //PrintSettingController pc=new PrintSettingController(this.treeList1); //这里可以是任何实现IPrintable 的控件
    //   pc.PrintHeader="我的报表";
    //   pc.Preview();


}