using Homework17.Services.Abstractions;

namespace Homework17
{
	public class App
	{
		private readonly ILoggerService _logger;

        private readonly IBackupService _backup;

        public App(ILoggerService logger, IBackupService backup)
		{
			_logger = logger;
            _backup = backup;
            _logger.Started += BackupLogFile;
        }

        public async Task Run()
        {
            var task1 = Task.Run(() => FirstMethod());
            var task2 = Task.Run(() => SecondMethod());
            await Task.WhenAll(task1, task2);
        }

        public async Task FirstMethod()
		{
			var numberOfLogs = 50;

			for (int i = 0; i < numberOfLogs; i++)
			{
				var message = $"{i} message from the first method";
                await _logger.Log(message);
            }
        }

        public async Task SecondMethod()
        {
            var numberOfLogs = 50;

            for (int i = 0; i < numberOfLogs; i++)
            {
                var message = $"{i} message from the second method";
                await _logger.Log(message);
            }

        }

        private void BackupLogFile()
        {
            _backup.CreateBackupFile();
        }
    }
}

