using log4net;
using log4net.Appender;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExtendMethods.LogManage
{
    /// <summary>
    /// 日志服务类
    /// </summary>
    public class AppLogService:Singleton<AppLogService>,IAppLogService
    {
        /// <summary>
        /// 错误日志对象
        /// </summary>
        private static readonly ILog _errorLog = LogManager.GetLogger("errorLogger");
        /// <summary>
        /// 普通日志对象
        /// </summary>
        private static readonly ILog _infoLog = LogManager.GetLogger("infoLogger");
        /// <summary>
        /// 初始化系统日志
        /// </summary>
        /// <param name="logDir">日志存储目录</param>
        public void InitSysLog(string logDir)
        {
            try
            {
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                //设置日志文件的路径
                var rep = LogManager.GetRepository();
                var appenders = rep.GetAppenders();
                if (appenders != null && appenders.Length > 0)
                {
                    for (int i = 0, j = appenders.Length; i < j; i++)
                    {
                        var rfa = appenders[i] as FileAppender;
                        if (rfa != null)
                        {
                            if (rfa.Name == "errorAppender")
                            {
                                var logPath = Path.Combine(logDir, "log_error");
                                rfa.File = logPath;
                                rfa.ActivateOptions();
                            }
                            if (rfa.Name == "infoAppender")
                            {
                                var logPath = Path.Combine(logDir, "log_info");
                                rfa.File = logPath;
                                rfa.ActivateOptions();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Instance.Log(ex.Message, LogMessageType.ERROR);
                if (ex.InnerException != null)
                    Instance.Log(ex.InnerException.Message, LogMessageType.ERROR);
            }
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="type">消息类型</param>
        public void Log(string message, LogMessageType type = LogMessageType.INFO)
        {
            try
            {
                switch (type)
                {
                    case LogMessageType.ERROR:
                        _errorLog.Error(message);
                        break;
                    case LogMessageType.INFO:
                        _infoLog.Info(message);
                        break;
                }
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        /// <summary>
        /// 写异常到日志
        /// </summary>
        /// <param name="ex">异常消息</param>
        public void Log(Exception ex)
        {
            Instance.Log(ex.Message,LogMessageType.ERROR);
            Instance.Log(string.Format("异常信息：{0}\n 调用堆栈：{1}",ex.Message,ex.StackTrace),LogMessageType.ERROR);
        }

        /// <summary>
        /// 获取默认的日志服务类实例对象
        /// </summary>
        /// <param name="args">参数</param>
        /// <returns>日志服务实例对象</returns>
        public static AppLogService GetDefault(object args=null)
        {
            return Instance;
        }

    }
}
