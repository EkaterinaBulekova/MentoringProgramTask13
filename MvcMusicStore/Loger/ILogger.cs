using System;

namespace MvcMusicStore.Loger
{
    public interface ILogger
    {
        void Info(string message);

        void Debug(string message);

        void Debug(string message, Exception exception);

        void Debug(Exception exception);

        void Error(string message);

        void Error(string message, Exception exception);

        void Error(Exception exception);

    }
}
