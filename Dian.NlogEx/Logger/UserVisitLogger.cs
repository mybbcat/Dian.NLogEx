using System;
using System.Collections.Generic;
using NLog;

namespace Dian.NLogEx
{
    /// <summary>
    /// 用户访问API日志的记录器
    /// </summary>
    /// <remarks>
    /// Nlog.logger扩展类
    /// </remarks>
    public sealed class UserVisitLogger
    {
        private const string CsLoggerName = "WebUserVisitLogger";
        private static readonly NLog.Logger _logger = LogManager.GetLogger(CsLoggerName);

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
