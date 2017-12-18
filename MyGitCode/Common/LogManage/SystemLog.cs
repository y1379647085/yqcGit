using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendMethods.LogManage
{
    /// <summary>
    /// 系统日志类
    /// </summary>
    public class SystemLog
    {
        /// <summary>
        /// 初始化日志
        /// </summary>
        /// <param name="logDir">日志存储目录</param>
        public static void InitSysLog(string logDir)
        {
            AppLogService.Instance.InitSysLog(logDir);
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息类型</param>
        /// <param name="type">消息类型</param>
        public static void Log(string message, LogMessageType type = LogMessageType.INFO)
        {
            AppLogService.Instance.Log(message,type);
        }

        /// <summary>
        /// 写异常到日志
        /// </summary>
        /// <param name="message">异常信息</param>
        public static void Log(Exception message)
        {
            AppLogService.Instance.Log(message);
        }
    }
}
