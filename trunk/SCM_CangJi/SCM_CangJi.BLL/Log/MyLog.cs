/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 5/30/2011 10:55:01 AM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.BLL
 * 文件名： MyLog
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
using log4net;
using System.Net;

namespace SCM_CangJi.BLL
{
   public interface IMyLog:ILog
    {
    }
    public class MyLog : LogImpl, IMyLog
    {
        private readonly static Type ThisDeclaringType = typeof(MyLog);

        public MyLog(ILogger logger)
            : base(logger)
        {
        }
        public override void Error(object message)
        {
            Error(message,null);
        }
        public override void Error(object message, Exception exception)
        {
            if (this.IsErrorEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(
                    ThisDeclaringType, Logger.Repository,
                    Logger.Name, Level.Info, message, exception);
                loggingEvent.Properties["UserName"] = Security.SecurityContext.Current.CurrentyUser.UserName;
                string strHostName = Dns.GetHostName(); //得到本机的主机名
                loggingEvent.Properties["MachineName"] = strHostName;
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                if (ipEntry.AddressList.Length > 0)
                {
                    string ip = ipEntry.AddressList[0].ToString();
                    loggingEvent.Properties["ClientIP"] = ip;
                }

                Logger.Log(loggingEvent);
            }

        }
        public override void Info(object message, Exception exception)
        {
            if (this.IsDebugEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(
                    ThisDeclaringType, Logger.Repository,
                    Logger.Name, Level.Info, message, exception);
                loggingEvent.Properties["UserName"] = Security.SecurityContext.Current.CurrentyUser.UserName;
                string strHostName = Dns.GetHostName(); //得到本机的主机名
                loggingEvent.Properties["MachineName"] = strHostName;
                IPHostEntry ipEntry = Dns.GetHostByName(strHostName); //取得本机IP
                if (ipEntry.AddressList.Length > 0)
                {
                    string ip = ipEntry.AddressList[0].ToString();
                    loggingEvent.Properties["ClientIP"] = ip;
                }

                Logger.Log(loggingEvent);
            }
        }
        public override void Info(object message)
        {
            Info(message,null);
        }
    }
}
