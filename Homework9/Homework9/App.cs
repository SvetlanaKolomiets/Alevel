using Homework9.Services.Abstractions;
using Homework9.Enums;
using Homework9.Exceptions;

namespace Homework9
{
	public class App
	{
		private readonly ILoggerService _loggerService;
		private readonly Actions _actions;

        public App(ILoggerService loggerService, Actions actions)
		{
            _loggerService = loggerService;
			_actions = actions;
		}

		public void Run()
		{
			int count = 0;
			while (count < 100)
			{
                Random random = new Random();
                int number = random.Next(1, 4);
                switch (number)
                {
                    case 1:
                        _actions.FirstMethod();
                        break;
                    case 2:
                        try
                        {
                            _actions.ThirdMethod();
                        }
                        catch (Exception ex)
                        {
                            _loggerService.Log(LogType.Error, $"Action failed by reason: {ex.Message}");
                        }
                        break;
                    case 3:
                        try
                        {
                            _actions.SecondMethod();
                        }
                        catch (BusinessException ex)
                        {
                            _loggerService.Log(LogType.Warning, $"Action got this custom Exception: {ex.Message}");
                        }
                        break;
                }

                count++;
            }
		}
	}
}

