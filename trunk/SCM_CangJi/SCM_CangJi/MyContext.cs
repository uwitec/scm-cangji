using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCM_CangJi
{
    public class MyContext : SplashScreenApplicationContext
    {

            protected override void OnCreateSplashScreenForm()
            {
                this.SplashScreenForm = new SplashForm();//启动窗体 
            }

            protected override void OnCreateMainForm()
            {

                this.PrimaryForm = new frmMain();//主窗体 

            }

            protected override void SetSeconds()
            {

                this.SecondsShow = 10;//启动窗体显示的时间(秒) 

            }
    }
}
