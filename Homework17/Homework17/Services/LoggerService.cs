using Homework17.Config;
using Homework17.Services.Abstractions;
using Microsoft.Extensions.Options;

namespace Homework17.Services
{
	public class LoggerService : ILoggerService
    {
		private readonly LoggerOption _loggerOption;

        private readonly SemaphoreSlim _semaphoreSlim;

		private int _count = 0;

		public delegate void BackupEventHandler();

		public event BackupEventHandler Started;

		public LoggerService(IOptions<LoggerOption> loggerOptions)
		{
			_loggerOption = loggerOptions.Value;
            _semaphoreSlim = new SemaphoreSlim(1);
        }

		public async Task<string> Log(string message)
		{
			var log = $"{DateTime.UtcNow} {message} {Environment.NewLine}";

            await _semaphoreSlim.WaitAsync();

            try
            {
                await WriteLogstoAFile(log);

                Console.WriteLine(log);

                _count++;
                
                if (_count == _loggerOption.NumberOfLogsForBackup)
                {
                    Console.WriteLine($"count is {_count}");
                    OnStarted();
                    _count = 0;
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }

            return log;

        }

        public async Task WriteLogstoAFile(string message)
        {
            await File.AppendAllTextAsync(_loggerOption.Path, message);
        }

        protected virtual void OnStarted()
        {
            Started.Invoke();
        }

    }
}

