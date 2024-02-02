using Homework10.Enums;

namespace Homework10.Services.Abstractions
{
    public interface ILoggerService
    {
        void Log(LogType logType, string massage);
    }
}

