using System.Diagnostics;
using Homework9.Config;
using Homework9.Enums;
using Homework9.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Homework9.Services
{
	public class LoggerService : ILoggerService
	{
        private string[] _logs = new string[100];
        private int _count = 0;
        private readonly LoggerOption _loggerOptions;

		public LoggerService(IOptions<LoggerOption> loggerOptions)
		{
			_loggerOptions = loggerOptions.Value;
		}

		public void Log(LogType logType, string message)
		{
			var log = $"{DateTime.UtcNow} {logType} {message}";
            _logs[_count] = log;
            _count++;
            Console.WriteLine(log);
			Debug.WriteLine($"write log to {_loggerOptions.Path}");
			
        }

		public string[] GetLogs()
		{
			return _logs;
		}
	}
}

