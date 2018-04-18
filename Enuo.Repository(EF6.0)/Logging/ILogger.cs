using Enuo.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enuo.Infrastructure.Logging
{

    /// <summary>
    /// 标题：文本日志实体类
    /// 描述：用来定义文本中记录日志的信息属性集合
    /// 作者：孙继鹏
    /// 日期：2013-12-24
    /// </summary>
    internal class TextLogEntry
    {
        /// <summary>
        /// 发生时间戳
        /// </summary>
        public DateTime TimeStamp { get; set; }
        /// <summary>
        /// 记录日志的序号
        /// </summary>
        public int EventId { get; set; }
        /// <summary>
        /// 发生异常的目标文件命名空间
        /// </summary>
        public string AppNameSpace { get; set; }
        /// <summary>
        /// 日志类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 日志信息
        /// </summary>
        public string Message { get; set; }


    }
    /// <summary>
    /// 标题：日志接口
    /// 描述：日志类型分为Information(消息)、Waring()、Error(错误或严重程序类)、Debug(调试)级别，分别生成积累别
    /// 日期：2014-8-27
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// 消息日志
        /// </summary>
        /// <param name="message">日志信息</param>
        void Information<T>(string message) where T :class;
        void Information<T>(Exception exception)where T :class;
        void Warning<T>(string message)where T :class;
        void Warning<T>(Exception exception) where T:class;
        void Critical<T>(string message)where T :class;
        void Error<T>(string message) where T :class;
        void Error<T>(Exception exception) where T :class;
        /// <summary>
        /// 调试跟踪日志
        /// </summary>
        /// <param name="message">日志信息</param>
        void Debug<T>(string message)where T :class;
        /// <summary>
        /// 自定义类别日志
        /// </summary>
        /// <param name="message">日志信息</param>
        /// <param name="category">自定义类别</param>
        void Defined<T>(string message, string category)where T :class;
    }


}
