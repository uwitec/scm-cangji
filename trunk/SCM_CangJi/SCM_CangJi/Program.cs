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
            Application.Run(new MyContext()); 
            
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
        }

        static void Application_Idle(object sender, EventArgs e)
        {
         
        }

    }
}
