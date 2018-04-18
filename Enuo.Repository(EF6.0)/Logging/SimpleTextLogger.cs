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
    /// 标题：文本日志类
    /// 描述：自定义的文本日志记录类，默认实现
    ///       1.调试类别日志的写入
    ///       2.消息类别日志的写入
    ///       3.可恢复错误类别日志的写入
    ///       4.错误或严重程序类别日志的写入
    ///       5.自定义类别日志的写入
    /// 作者：孙继鹏
    /// 日期：2013-11-18，2013-12-24,2015-12-13
    /// </summary>
    public class SimpleTextLogger:ILogger
    {
        #region Variables
        private readonly Lazy<SimpleTextLogger> instance = new Lazy<SimpleTextLogger>(()=> new SimpleTextLogger());
        /// <summary>
        /// 分类目录
        /// </summary>
        private static string category;
        /// <summary>
        /// 默认的文本头部样式
        /// </summary>
        private const string DefaultHeader = "------------------Log---------------";
        /// <summary>
        /// 用于存储类别对应的事件ID
        /// key：类别名称  Value：当前事件可用的事件ID
        /// </summary>
        private static Dictionary<string, int> CategoryEventIdCache = new Dictionary<string, int>();
        #endregion

        #region Ctors
        static SimpleTextLogger()
        {
            CategoryEventIdCache.Add(TraceEventType.Error.ToString(), 0);
            CategoryEventIdCache.Add(TraceEventType.Information.ToString(), 0);
            CategoryEventIdCache.Add(TraceEventType.Critical.ToString(), 0);
            CategoryEventIdCache.Add(TraceEventType.Verbose.ToString(), 0);
        }
        public SimpleTextLogger() { }
        #endregion

        #region Property
        /// <summary>
        /// 默认的日志路径
        /// </summary>
        public static string DefaultDirectory
        {
            get
            {
                string dirname = "AppLog";
                string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dirname);
                if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                return dir;
            }
        }
        /// <summary>
        /// 获取当前日志类型路径
        /// </summary>
        internal static string CurrentLogPath
        {
            get
            {
                string path = Path.Combine(DefaultDirectory, category);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
            set
            {
                category = value;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 自维护生成事件ID
        /// </summary>
        /// <param name="category">日志类别</param>
        /// <returns>返回ID</returns>
        private int GetEventId(string category)
        {
            int EventId = 0;
            if (CategoryEventIdCache.ContainsKey(category))
            {
                int temp = CategoryEventIdCache[category];
                EventId = temp;
                CategoryEventIdCache[category] = ++temp;
            }
            else
            {
                CategoryEventIdCache.Add(category, EventId);
            }
            return EventId;
        }
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="entry">日志实体类</param>
        private void WriteLog(TextLogEntry entry)
        {
            CurrentLogPath = entry.Category;
            string filename = DateTime.Now.ToString("yyyyMMddHH") + ".log";
            string FilePath = Path.Combine(CurrentLogPath, filename);
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                fs.Seek(0, SeekOrigin.End);
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    StringBuilder ContentText = new StringBuilder();
                    ContentText.AppendLine(string.Format("{0}:{1}", "TimeStamp", entry.TimeStamp));
                    ContentText.AppendLine(string.Format("{0}:{1}", "EventId", entry.EventId));
                    ContentText.AppendLine(string.Format("{0}:{1}", "Category", entry.Category));
                    ContentText.AppendLine(string.Format("{0}:{1}", "NameSpaceInfo", entry.AppNameSpace));
                    ContentText.AppendLine(string.Format("{0}:{1}", "Message", entry.Message));
                    sw.WriteLine(DefaultHeader);
                    sw.WriteLine(ContentText);
                    //sw.WriteLine(DefaultFooter);
                    sw.Close();
                }
                fs.Close();
            }
        }
        #endregion

        public void Critical<T>(string message) where T :class
        {
            TextLogEntry entry = new TextLogEntry();
            entry.TimeStamp = DateTime.Now;
            entry.AppNameSpace = typeof(T).Namespace;
            entry.Message = message;
            entry.EventId = GetEventId(TraceEventType.Critical.ToString());
            entry.Category = TraceEventType.Critical.ToString();
            WriteLog(entry);
        }

        public void Debug<T>(string message)where T :class
        {
            TextLogEntry entry = new TextLogEntry();
            entry.TimeStamp = DateTime.Now;
            entry.Message = message;
            entry.AppNameSpace = typeof(T).Namespace;
            entry.EventId = GetEventId(TraceEventType.Verbose.ToString());
            entry.Category = TraceEventType.Verbose.ToString();
            WriteLog(entry);
        }

        public void Error<T>(string message)where T :class
        {
            TextLogEntry entry = new TextLogEntry();
            entry.TimeStamp = DateTime.Now;
            entry.AppNameSpace = typeof(T).Namespace;
            entry.Message = message;
            entry.EventId = GetEventId(TraceEventType.Error.ToString());
            entry.Category = TraceEventType.Error.ToString();
            WriteLog(entry);
        }

        public void Information<T>(string message) where T :class
        {
            TextLogEntry entry = new TextLogEntry();
            entry.TimeStamp = DateTime.Now;
            entry.AppNameSpace = typeof(T).Namespace;
            entry.Message = message;
            entry.EventId = GetEventId(TraceEventType.Information.ToString());
            entry.Category = TraceEventType.Information.ToString();
            WriteLog(entry);
        }

        public void Warning<T>(string message)where T :class
        {
            TextLogEntry entry = new TextLogEntry();
            entry.TimeStamp = DateTime.Now;
            entry.AppNameSpace = typeof(T).Namespace;
            entry.Message = message;
            entry.EventId = GetEventId(TraceEventType.Warning.ToString());
            entry.Category = TraceEventType.Warning.ToString();
            WriteLog(entry);
        }

        public void Defined<T>(string message, string category)where T :class
        {
            TextLogEntry entry = new TextLogEntry();
            entry.TimeStamp = DateTime.Now;
            entry.Message = message;
            entry.EventId = GetEventId(category);
            entry.Category = category;
            entry.AppNameSpace = typeof(T).Namespace;
            WriteLog(entry);
        }

        public void Information<T>(Exception exception)where T :class
        {
            throw new NotImplementedException();
        }

        public void Warning<T>(Exception exception)where T :class
        {
            throw new NotImplementedException();
        }

        public void Error<T>(Exception exception)where T :class
        {
            throw new NotImplementedException();
        }
    }
}
