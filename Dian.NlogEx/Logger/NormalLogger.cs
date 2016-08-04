using System;
using System.Collections.Generic;
using System.Diagnostics;
using NLog;
using NLog.Config;

namespace Dian.NLogEx
{
    /// <summary>
    /// 普通通用的日志记录器
    /// </summary>
    /// <remarks>
    /// Nlog.logger扩展类
    /// Trace 与 Debug 的输出，只在 DEBUG 模式生效
    /// </remarks>
    public class NormalLogger
    {
        private const string CsLoggerName = "NormalLogger";
        private static readonly Logger _logger = LogManager.GetLogger(CsLoggerName);

        /// <summary>
        /// 按照日志的严重性倒序排列
        /// </summary>
        private static readonly Lazy<Dictionary<LogLevelEx, LogLevel>> LogLevelMap = new Lazy<Dictionary<LogLevelEx, LogLevel>>
            (() => new Dictionary<LogLevelEx, LogLevel>
            {
                { LogLevelEx.Trace, NLog.LogLevel.Trace },
                { LogLevelEx.Debug, NLog.LogLevel.Debug },
                { LogLevelEx.Info, NLog.LogLevel.Info },
                { LogLevelEx.Warnning, NLog.LogLevel.Warn },
                { LogLevelEx.Error, NLog.LogLevel.Error },
                { LogLevelEx.Fatal, NLog.LogLevel.Fatal }
            });

        public static void Trace(Type module, string message, params object[] args)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Trace);
            logInfo.Message = string.Format(message, args);
            _logger.Log(logInfo);
        }

        public static void Trace(Type module, string message)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Trace);
            logInfo.Message = message;
            _logger.Log(logInfo);
        }

        public static void Debug(Type module, string message, Exception ex = null)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Debug);
            logInfo.Message = message;
            logInfo.Exception = ex;
            _logger.Log(logInfo);
        }

        public static void Debug(Type module, string message, Exception ex = null, params object[] args)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Debug);
            logInfo.Message = string.Format(message, args);
            logInfo.Exception = ex;
            _logger.Log(logInfo);
        }

        public static void Info(Type module, string message, params object[] args)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Info);
            logInfo.Message = string.Format(message, args);
            _logger.Log(logInfo);
        }

        public static void Info(Type module, string message)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Info);
            logInfo.Message = message;
            _logger.Log(logInfo);
        }
        public static void Warn(Type module, string message, params object[] args)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Debug);
            logInfo.Message = string.Format(message, args);
            _logger.Log(logInfo);
        }

        public static void Warn(Type module, string message)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Debug);
            logInfo.Message = message;
            _logger.Log(logInfo);
        }

        public static void Error(Type module, string message, Exception ex = null)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Error);
            logInfo.Message = message;
            logInfo.Exception = ex;
            _logger.Log(logInfo);
        }

        public static void Error(Type module, string message, Exception ex = null, params object[] args)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Error);
            logInfo.Message = string.Format(message, args);
            logInfo.Exception = ex;
            _logger.Log(logInfo);
        }

        public static void Fatal(Type module, string message, Exception ex = null)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Fatal);
            logInfo.Message = message;
            logInfo.Exception = ex;
            _logger.Log(logInfo);
        }

        public static void Fatal(Type module, string message, Exception ex = null, params object[] args)
        {
            var logInfo = CreateLogEventInfo(module.FullName, NLogEx.LogLevelEx.Fatal);
            logInfo.Message = string.Format(message, args);
            logInfo.Exception = ex;
            _logger.Log(logInfo);
        }

        private static LogEventInfo CreateLogEventInfo(string module, LogLevelEx logLevel)
        {
            var logInfo = new LogEventInfo
            {
                Level = LogLevelMap.Value[logLevel],
                LoggerName = CsLoggerName
            };

            logInfo.Properties["module"] = module;

            return logInfo;
        }
    }
}
