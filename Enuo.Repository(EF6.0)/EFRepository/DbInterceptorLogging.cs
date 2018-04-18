using Enuo.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Enuo.Repository.EF6
{
    /// <summary>
    /// 标题：SQL拦截器
    /// 描述：可在EF执行SQL语句时，捕获信息
    /// 作者：孙继鹏 
    /// 日期：2015-12-03
    /// </summary>
    public class DbInterceptorLogging:DbCommandInterceptor
    {
        #region Variables

        private ILogger logger = new TraceLogger();
        private readonly Stopwatch stopwatch = new Stopwatch();

        #endregion

        #region DbCommandInterceptor
        public override void ScalarExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            stopwatch.Restart();
        }
        public override void ScalarExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                logger.Error<DbInterceptorLogging>(string.Format("Error excuting command:{0}", command.CommandText));
            }
            else
            {
                logger.Error<DbInterceptorLogging>(string.Format("SQL Database,DBsInterceptor.ScalarExecuted{1},Command:{0}:", command.CommandText,stopwatch.Elapsed));
            }
            base.ScalarExecuted(command, interceptionContext);
        }
        public override void NonQueryExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            stopwatch.Restart();
        }
        public override void NonQueryExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                logger.Error<DbInterceptorLogging>(string.Format("Error excuting command:{0}", command.CommandText));
            }
            else
            {
                logger.Error<DbInterceptorLogging>(string.Format("SQL Database,DBsInterceptor.ScalarExecuted{1},Command:{0}:", command.CommandText, stopwatch.Elapsed));
            }
            base.NonQueryExecuted(command, interceptionContext);
        }
        public override void ReaderExecuting(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            stopwatch.Restart();
        }
        public override void ReaderExecuted(System.Data.Common.DbCommand command, DbCommandInterceptionContext<System.Data.Common.DbDataReader> interceptionContext)
        {
            stopwatch.Stop();
            if (interceptionContext.Exception != null)
            {
                logger.Error<DbInterceptorLogging>(string.Format("Error executing command: {0},Except Message{1}", command.CommandText, interceptionContext.Exception.Message));
            }
            else
            {
                logger.Error<DbInterceptorLogging>(string.Format("SQL Database,DBsInterceptor.ScalarExecuted{1},Command:{0}:", command.CommandText, stopwatch.Elapsed));
            }
            base.ReaderExecuted(command, interceptionContext);
        }
        #endregion
    }
}