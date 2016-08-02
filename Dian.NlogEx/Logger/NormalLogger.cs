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

        /// <summary>
        /// 输出带有客户端请求信息的日志
        /// </summary>
        /// <param name="clientIp">客户端 IP</param>
        /// <param name="requestUrl">客户端请求的 URL</param>
        /// <param name="requestParameter">客户端请求的参数</param>
        /// <param name="requestBody">客户端请求的 Body</param>
        /// <param name="logLevel">自定义日志级别 <see cref="LogLevel"/></param>
        /// <param name="message">自定义日志内容,支持格式化</param>
        /// <param name="args">与 message 结合使用，格式化的参数</param>
        public static void WriteEx(string clientIp, string requestUrl, string requestParameter,
            string requestBody, LogLevelEx logLevel, string message, params object[] args)
        {
            var logInfo = CreateLogEventInfo(clientIp, requestUrl, requestParameter, requestBody, logLevel);
            logInfo.Message = string.Format(message, args);

            _logger.Log(logInfo);
        }

        /// <summary>
        /// 输出带有客户端请求信息的日志
        /// </summary>
        /// <param name="clientIp">客户端 IP</param>
        /// <param name="requestUrl">客户端请求的 URL</param>
        /// <param name="requestParameter">客户端请求的参数</param>
        /// <param name="requestBody">客户端请求的 Body</param>
        /// <param name="logLevel">自定义日志级别 <see cref="LogLevel"/></param>
        /// <param name="message">自定义日志内容,支持格式化</param>
        /// <param name="args">与 message 结合使用，格式化的参数</param>
        /// <param name="ex">异常</param>
        public static void WriteEx(string clientIp, string requestUrl, string requestParameter,
                            string requestBody, LogLevelEx logLevel, Exception ex, string message, params object[] args)
        {
            LogEventInfo logInfo = CreateLogEventInfo(clientIp, requestUrl, requestParameter, requestBody, logLevel);
            logInfo.Message = string.Format(message, args);
            logInfo.Exception = ex;

            _logger.Log(logInfo);
        }

        /// <summary>
        /// 输出带有客户端请求信息的日志
        /// </summary>
        /// <param name="clientIp">客户端 IP</param>
        /// <param name="requestUrl">客户端请求的 URL</param>
        /// <param name="requestParameter">客户端请求的参数</param>
        /// <param name="requestBody">客户端请求的 Body</param>
        /// <param name="logLevel">自定义日志级别 <see cref="LogLevel"/></param>
        /// <param name="ex">异常</param>
        public static void WriteEx(string clientIp, string requestUrl, string requestParameter,
                            string requestBody, LogLevelEx logLevel, Exception ex)
        {
            LogEventInfo logInfo = CreateLogEventInfo(clientIp, requestUrl, requestParameter, requestBody, logLevel);
            logInfo.Exception = ex;

            _logger.Log(logInfo);
        }

        /// <summary>
        /// Debug模式才生效，Relase时会不输出日志
        /// </summary>
        public static void Trace(string message, params object[] args)
        {
            _logger.ConditionalTrace(message, args);
        }

        /// <summary>
        /// Debug模式才生效，Relase时会不输出日志
        /// </summary>
        public static void Trace(string message)
        {
            _logger.ConditionalTrace(message);
        }

        public static void Warn(string message, params object[] args)
        {
            _logger.Warn(message, args);
        }

        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Debug(string message, params object[] args)
        {
            _logger.Debug(message, args);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Debug(Exception ex)
        {
            _logger.Debug(ex);
        }

        public static void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Error(string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Error(Exception ex)
        {
            _logger.Error(ex);
        }

        public static void Fatal(string message, params object[] args)
        {
            _logger.Fatal(message, args);
        }

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public static void Fatal(Exception ex)
        {
            _logger.Fatal(ex);
        }

        private static LogEventInfo CreateLogEventInfo(string clientIp, string requestUrl, string requestParameter, string requestBody, LogLevelEx logLevel)
        {
            var logInfo = new LogEventInfo
            {
                Level = LogLevelMap.Value[logLevel],
                LoggerName = CsLoggerName
            };

            logInfo.Properties["clientIp"] = clientIp;
            logInfo.Properties["requestUrl"] = requestUrl;
            logInfo.Properties["requestParameter"] = requestParameter;
            logInfo.Properties["requestBody"] = requestBody;

            return logInfo;
        }


    }
}
