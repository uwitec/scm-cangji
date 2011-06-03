/*
 *
 * 版本： V1.0
 * 作者： 尹华蓓
 * 日期： 6/3/2011 9:57:27 PM
 * CLR版本： 4.0.30319.225
 * 命名空间名称： SCM_CangJi.BLL.Services
 * 文件名： LogServices
 *
 * QQ ：  286575355
 * Email： kuchen1984@126.com
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SCM_CangJi.DAL;
using SCM_CangJi.Lib;

namespace SCM_CangJi.BLL.Services
{
    public class LogServices : BaseService<LogServices>
    {
        public object GetLogs(DateTime? from, DateTime? to, string userName, string message)
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(this.connectionString), context =>
            {
                var condition = ConditionBuilder.True<LogDetail>();
                if (from.HasValue)
                {
                    condition = condition.And(o => o.LogDate.Date >= from.Value.Date);
                }
                if (to.HasValue)
                {
                    condition = condition.And(o => o.LogDate.Date <= from.Value.Date);
                }
                if (!string.IsNullOrWhiteSpace(message))
                {
                    condition = condition.And(o => o.Message.Contains(message));
                }
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    condition = condition.And(o => o.UserName.Contains(userName));
                }
                result = (from log in context.LogDetails.Where(condition)
                          select new
                          {
                              客户端IP = log.ClientIP,
                              日志级别 = log.Level,
                              记录时间 = log.LogDate,
                              记录器 = log.Logger,
                              客户机名称 = log.MachineName,
                              日志信息 = log.Message,
                              用户名 = log.UserName,
                          }).ToList();

            });
            return result;
        }
    }
}
