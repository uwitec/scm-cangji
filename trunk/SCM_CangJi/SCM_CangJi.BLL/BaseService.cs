using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using log4net;
namespace SCM_CangJi.BLL
{
    public abstract class BaseService<TDAL>
         where TDAL : class, new()
    {
        private ILog log = LogManager.GetLogger(typeof(TDAL));
        private static readonly Lazy<TDAL> _instance = new Lazy<TDAL>(() => new TDAL());
        public static TDAL Instance
        {
            get
            {
                return _instance.Value;
            }
        }
       public  string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SCM_CangJiConnectionString"].ConnectionString;
        public void Using<T>(T context, Action<T> action)
       where T : DataContext
        {
            try
            {
                action(context);
            }
            catch(Exception e)
            {
                log.Error("程序发生了异常", e);
                throw e;
            }
            finally
            {
                if (context is IDisposable)
                {
                    (context as IDisposable).Dispose();
                    context = default(T);
                }
            }
        }

        public TResult Using<T, TResult>(T context, Func<T, TResult> action)
        where T : DataContext
        {
            try
            {
                TResult result = action(context);
                return result;
            }
            catch(Exception e)
            {
                log.Error("程序发生了异常", e);
                throw e;
            }
            finally
            {
                if (context is IDisposable)
                {
                    (context as IDisposable).Dispose();
                    context = default(T);
                }
            }
        }
    }
}
