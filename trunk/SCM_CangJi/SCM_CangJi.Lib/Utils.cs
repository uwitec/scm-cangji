using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCM_CangJi.Lib
{
    public class Utils
    {
        public static void OpenMasterWebPage()
        {
            System.Diagnostics.Process precess = new System.Diagnostics.Process();
            precess.StartInfo.FileName = "http://www.shcjwl.com/";
            precess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            precess.Start();
        }
       
    }
   
}
