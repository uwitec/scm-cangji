/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/30/2011 11:00:57 AM
 * CLR版本： 4.0.30319.225
 * 命名空间名称：SCM_CangJi.BLL
 * 文件名： MyLogManager
 *
 * QQ ：  286575355
 * Email： kuchen1984@126.com
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Core;
using System.Reflection;

namespace SCM_CangJi.BLL
{
   public  class MyLogManager
    { 
        private static readonly WrapperMap s_wrapperMap = new WrapperMap(new WrapperCreationHandler(WrapperCreationHandler));

        private MyLogManager() { }

        public static IMyLog Exists(string name)
        {
            return Exists(Assembly.GetCallingAssembly(), name);
        }

        public static IMyLog Exists(string domain, string name)
        {
            return WrapLogger(LoggerManager.Exists(domain, name));
        }

        public static IMyLog Exists(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.Exists(assembly, name));
        }

        public static IMyLog[] GetCurrentLoggers()
        {
            return GetCurrentLoggers(Assembly.GetCallingAssembly());
        }

        public static IMyLog[] GetCurrentLoggers(string domain)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(domain));
        }

        public static IMyLog[] GetCurrentLoggers(Assembly assembly)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(assembly));
        }

        public static IMyLog GetLogger(string name)
        {
            return GetLogger(Assembly.GetCallingAssembly(), name);
        }

        public static IMyLog GetLogger(string domain, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, name));
        }

        public static IMyLog GetLogger(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, name));
        }

        public static IMyLog GetLogger(Type type)
        {
            return GetLogger(Assembly.GetCallingAssembly(), type.FullName);
        }

        public static IMyLog GetLogger(string domain, Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, type));
        }

        public static IMyLog GetLogger(Assembly assembly, Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, type));
        }

        private static IMyLog WrapLogger(ILogger logger)
        {
            return (IMyLog)s_wrapperMap.GetWrapper(logger);
        }

        private static IMyLog[] WrapLoggers(ILogger[] loggers)
        {
            IMyLog[] results = new IMyLog[loggers.Length];
            for (int i = 0; i < loggers.Length; i++)
            {
                results[i] = WrapLogger(loggers[i]);
            }
            return results;
        }

        private static ILoggerWrapper WrapperCreationHandler(ILogger logger)
        {
            return new MyLog(logger);
        }
    }
}
