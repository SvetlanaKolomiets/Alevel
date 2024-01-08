using System;

namespace Lesson_5
{
    public class Logger
    {
        private static Logger instance;
        private string[] Logs = new string[100];
        private int count = 0;
        private DateTime currentDate = DateTime.Now;

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }

        private enum LogType
        {
            Error,
            Info,
            Warning
        }

        public string AddErrorLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string log = $"{Environment.NewLine}{this.currentDate.ToString("dd/MM/yyyy HH:mm:ss")} {LogType.Error} {message}";
            Console.WriteLine(log);
            this.Logs[count] = log;
            this.count++;
            return log;
        }

        public string AddInfoLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string log = $"{Environment.NewLine}{this.currentDate.ToString("dd/MM/yyyy HH:mm:ss")} {LogType.Info} {message}";
            Console.WriteLine(log);
            this.Logs[count] = log;
            this.count++;
            return log;
        }

        public string AddWarningLog(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string log = $"{Environment.NewLine}{this.currentDate.ToString("dd/MM/yyyy HH:mm:ss")} {LogType.Warning} {message}";
            Console.WriteLine(log);
            this.Logs[count] = log;
            this.count++;
            return log;
        }

        public void AddLogsToAFile()
        {
            foreach (string element in this.Logs)
            {
                File.AppendAllText("log.txt", element);
            }
        }
    }
}