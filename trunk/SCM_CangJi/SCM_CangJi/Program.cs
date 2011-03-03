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
