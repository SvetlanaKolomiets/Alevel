using Homework9.Services.Abstractions;
using Homework9.Config;
using Microsoft.Extensions.Options;
using System.Globalization;
using Newtonsoft.Json;

namespace Homework9.Services
{
	public class FileService : IFileService
	{
        private readonly LoggerOption _loggerOptions;
        private readonly ILoggerService _loggerService;

        public FileService(IOptions<LoggerOption> loggerOptions, ILoggerService loggerService)
        {
            _loggerOptions = loggerOptions.Value;
            _loggerService = loggerService;
        }

        public string GetDirectory()
        {
			return _loggerOptions.Path;
        }

        public void CreateDirectory()
        {
            Directory.CreateDirectory(_loggerOptions.Path);
        }

        public void CheckIfDirectoryCouldBeCreated()
        {
            try
            {
                if (Directory.Exists(this.GetDirectory()))
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

        public string SetLogFileName()
        {
            string currentDate = DateTime.Now.ToString("MM-dd-yyyy hh:mm:ss.fff tt");
            return $"{currentDate}.txt";
        }

        public void WriteLogsToAFile()
        {
            try
            {
                this.CheckIfDirectoryCouldBeCreated();
                string logFile = this.SetLogFileName();
                string logFilePath = Path.Combine(GetDirectory(), logFile);
                this.GetFilesWithoutOldestOne();
                using (StreamWriter outputFile = new StreamWriter(logFilePath))
                {
                    outputFile.WriteLine(this.ConvertLogsToJson());
                }    
                Console.WriteLine($"File {logFile} with logs is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when trying to write logs to a file: {ex.Message}");
            }
        }

        public string[] GetAllFilesFromDirectory()
        {
            string[] allFiles = Directory.GetFiles(GetDirectory());
            
            return allFiles;
        }

        public string[] GetFilesWithoutOldestOne()
        {
            var allFiles = GetAllFilesFromDirectory();
            if (allFiles.Length >= 3)
            {
                var sortedFiles = SortFilesByDate(allFiles);
                DeleteOldestFile(sortedFiles);
            }
            return allFiles;
        }

        public string[] SortFilesByDate(string[] files)
        {
            var sortedFiles = files.OrderBy(fileName =>
            {
                if (DateTimeOffset.TryParseExact(Path.GetFileNameWithoutExtension(fileName),
                    "MM-dd-yyyy hh/mm/ss.fff tt", CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out DateTimeOffset result))
                {
                    return result;
                }
                else
                {
                    return default;
                }
            }).ToArray();

            return sortedFiles;
        }

        public void DeleteOldestFile(string[] sortedFiles)
        {
            if (sortedFiles.Length >= 3)
            {
                File.Delete(sortedFiles[2]);
                Console.WriteLine($"{sortedFiles[2]} was deleted");
            }
        }

        public string ConvertLogsToJson()
        {
            string[] logs = _loggerService.GetLogs();

            string jsonLogs = JsonConvert.SerializeObject(logs, Formatting.Indented);

            return jsonLogs;
        }
    }
}

