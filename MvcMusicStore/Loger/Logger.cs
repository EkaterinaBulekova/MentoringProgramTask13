using System;
using log4net;
using log4net.Config;

namespace MvcMusicStore.Loger
{
    public class Logger : ILogger
    {
        private readonly ILog _log;

        public Logger(ILog logger)
        {
            _log = logger;
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public void Debug(Exception exception)
        {
            if (_log.IsDebugEnabled)
                _log.Debug(exception);
        }

        public void Debug(string message)
        {
            if (_log.IsDebugEnabled)
                _log.Debug(message);
        }

        public void Debug(string message, Exception exception)
        {
            if (_log.IsDebugEnabled)
                _log.Debug(message, exception);
        }

        public void Error(string message)
        {
            if (_log.IsErrorEnabled)
                _log.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            if (_log.IsErrorEnabled)
                _log.Error(message, exception);
        }

        public void Error(Exception exception)
        {
            if (_log.IsErrorEnabled)
                _log.Error(exception);
        }

        public void Info(string message)
        {
            if (_log.IsInfoEnabled)
                _log.Info(message);
        }
    }
}