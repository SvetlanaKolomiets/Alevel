using Homework10.Config;
using Homework10.Enums;
using Homework10.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Homework10.Services
{
	public class LoggerService : ILoggerService
    {
        private readonly LoggerOption _loggerOptions;

        public LoggerService(IOptions<LoggerOption> loggerOptions)
		{
            _loggerOptions = loggerOptions.Value;
        }

        public void Log(LogType logType, string message)
        {
            var log = $"{DateTime.UtcNow} {logType} {message} {Environment.NewLine}";
            File.AppendAllText(_loggerOptions.Path, log);
        }
    }
}

