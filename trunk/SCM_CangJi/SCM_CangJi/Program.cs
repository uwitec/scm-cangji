using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace SCM_CangJi
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // The following line provides localization for data formats. 
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");

            // The following line provides localization for the application's user interface. 
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CHS");

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2007 Blue");
            DialogResult logResult =(new Account.LogOn()).ShowDialog();
            switch (logResult)
            {
                case DialogResult.Abort:
                case DialogResult.Cancel:
                case DialogResult.Ignore:
                case DialogResult.No:
                case DialogResult.None:
                    Application.Exit();
                    return;
                case DialogResult.OK:
                    Application.Run(new MyContext()); 
                    break;

            }
             
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
        }

       

    }
}
