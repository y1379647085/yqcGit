using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendMethods.LogManage
{
    /// <summary>
    /// 日志服务接口
    /// </summary>
    public interface IAppLogService
    {
        /// <summary>
        /// 初始化日志
        /// </summary>
        /// <param name="logDir">日志存储目录</param>
        void InitSysLog(string logDir);
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="type">消息类型</param>
        void Log(string message, LogMessageType type = LogMessageType.INFO);
        /// <summary>
        /// 写异常到日志
        /// </summary>
        /// <param name="message">异常消息</param>
        void Log(Exception message);
    }

    /// <summary>
    /// 日志消息的类型
    /// </summary>
    public enum LogMessageType
    {
        /// <summary>
        /// 普通消息类型
        /// </summary>
        INFO,
        /// <summary>
        /// 错误类型
        /// </summary>
        ERROR
    }
}
