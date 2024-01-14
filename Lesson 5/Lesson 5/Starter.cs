using System;
using System.Xml.Linq;

namespace Lesson_5
{
    public class Starter
    {
        public void Run()
        {
            int count = 0;

            Action action = new Action();
            Logger logger = Logger.Instance;

            while (count < 100)
            {
                Random random = new Random();
                int number = random.Next(1, 4);
                switch (number)
                {
                    case 1:
                        action.FirstMethod();
                        break;
                    case 2:
                        action.SecondMethod();
                        break;
                    case 3:
                        if (action.ThirdMethod().Status == false)
                        {
                            logger.AddErrorLog($"Action failed by the reason: {action.ThirdMethod().Error}");
                        }
                        break;
                }

                count++;
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Do you want to write logs to a file? Write Y/N and press Enter: ");
            var input = Console.ReadLine();
            switch (input)
            {
                case "Y":
                    logger.AddLogsToAFile();
                    Console.WriteLine($"{Environment.NewLine}Logs are written to a file log.txt");
                    break;
                case "N":
                    break;
                default:
                    Console.WriteLine($"{Environment.NewLine}Logs cannot be written to a file. Try again");
                    break;
            }
        }
    }
}