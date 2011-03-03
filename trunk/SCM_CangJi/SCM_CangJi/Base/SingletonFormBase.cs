using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCM_CangJi.Base
{
    /// <summary>
    /// 单例模式form 基类 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class SingletonFormBase<T> : FormBase
        where T : class,new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());
        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public SingletonFormBase()
        {
            InitializeComponent();
        }
    }
}
