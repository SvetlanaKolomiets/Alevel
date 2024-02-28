using Microsoft.Extensions.Options;
using Homework17.Config;
using Homework17.Services.Abstractions;

namespace Homework17.Services
{
	public class BackupService : IBackupService
    {
        private readonly BackupOption _backupOptions;
        private readonly LoggerOption _loggerOption;

        public BackupService(IOptions<BackupOption> backupOptions, IOptions<LoggerOption> loggerOptions)
		{
            _backupOptions = backupOptions.Value;
            _loggerOption = loggerOptions.Value;
		}

        public void CreateDirectory()
        {
            Directory.CreateDirectory(_backupOptions.Path);
        }

        public void CheckIfDirectoryCouldBeCreated()
        {
            try
            {
                if (Directory.Exists(_backupOptions.Path))
                {
                    Console.WriteLine("A directory by this name already exists");
                    return;
                }

                this.CreateDirectory();
                Console.WriteLine("New directory is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Directory cannot be created {0}", ex.ToString());
            }
        }

        public string SetBackupFileName()
        {
            string currentDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss.fff tt");
            return $"{currentDate}.txt";
        }

        public void CreateBackupFile()
        {
            try
            {
                this.CheckIfDirectoryCouldBeCreated();
                var backupFile = this.SetBackupFileName();
                var backupPath = Path.Combine(_backupOptions.Path, backupFile);

                using (StreamWriter outputFile = new StreamWriter(backupPath))
                {
                    var lines = File.ReadAllLines(_loggerOption.Path);

                    foreach (var line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }

                Console.WriteLine($"Backup file {backupFile} is created");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to create a backup file: {ex.Message}");
            }
        }
    }
}

