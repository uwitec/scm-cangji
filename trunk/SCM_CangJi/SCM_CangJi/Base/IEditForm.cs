using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCM_CangJi
{
    public interface IEditForm
    {
        void Save(Action saveAction);
        void Save();
        void SaveAndClose(Action saveAction);
    }

    public interface ISingleton<T>
    {
        T Instance { get; }
    }
}
