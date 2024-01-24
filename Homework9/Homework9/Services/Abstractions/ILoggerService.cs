using Homework9.Enums;

namespace Homework9.Services.Abstractions
{
    public interface ILoggerService
    {
        void Log(LogType logType, string massage);
        string[] GetLogs();
    }
}

