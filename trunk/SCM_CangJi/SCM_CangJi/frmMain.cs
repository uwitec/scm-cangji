using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Skins;
using DevExpress.XtraBars;
namespace SCM_CangJi
{
    public partial class frmMain : XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            InitSkin();
            InitMenu();
        }

        private void InitMenu()
        {

        }
        private void InitSkin()
        {
            foreach (SkinContainer cnt in SkinManager.Default.Skins)
            {
                BarButtonItem item = new BarButtonItem(barManager1, cnt.SkinName);
                barskin.AddItem(item);
                item.ItemClick += new ItemClickEventHandler(OnSkinClick);
            }
        }
        void OnSkinClick(object sender, ItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
            barManager1.GetController().PaintStyleName = "Skin";
            barskin.Caption = e.Item.Caption;
            barskin.Hint = barskin.Caption;
            barskin.ImageIndex = -1;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            MDIManage.SetFixedForm(new StartPage());
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            (new About()).ShowDialog(this);
        }

        private void showMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           MainMenus.Show();
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            SCM_CangJi.Lib.Utils.OpenMasterWebPage();
        }
    }
}
