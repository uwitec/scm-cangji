using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DevExpress.XtraTabbedMdi;
using System.Windows.Forms;

namespace SCM_CangJi
{
    public partial class MyMDIManager : XtraTabbedMdiManager
    {
        public MyMDIManager()
        {
            BeginFloating += OnBeginFloating;
            InitializeComponent();
        }

        public MyMDIManager(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
         private XtraMdiTabPage _FixedPage;
        public XtraMdiTabPage FixedPage
        {
            get { return _FixedPage; }
            set
            {
                _FixedPage = value;
                InitFixedPage();
            }
        }




        public void SetFixedForm(Form form)
        {
            form.MdiParent = MdiParent;
            form.Show();
            FixedPage = PageByForm(form);
        }

        private XtraMdiTabPage PageByForm(Form form)
        {
            foreach (XtraMdiTabPage page in Pages)
            {
                if (page.MdiChild == form)
                {
                    return page;
                }
            }
            return null;
        }
        private void InitFixedPage()
        {
            if (_FixedPage != null)
            {
                _FixedPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
                CheckFixedPage();
            }
        }

        protected override void DoDragDrop()
        {
            if (SelectedPage == FixedPage)
                return;
            base.DoDragDrop();
            //CheckFixedPage();
        }

        private void CheckFixedPage()
        {
            if (_FixedPage == null)
                return;
            if (Pages.IndexOf(FixedPage) != 0)
            {
                Pages.Remove(FixedPage);
                Pages.Insert(0, FixedPage);
                LayoutChanged();
            }
        }


        void OnBeginFloating(object sender, FloatingCancelEventArgs e)
        {
            e.Cancel = PageByForm(e.ChildForm) == FixedPage;
        }

    }
}
