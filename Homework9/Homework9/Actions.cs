using System.Reflection;
using Homework9.Enums;
using Homework9.Services.Abstractions;
using Homework9.Exceptions;

namespace Homework9
{
	public class Actions
	{
        private readonly ILoggerService _loggerService;

        public Actions(ILoggerService loggerService)
		{
			_loggerService = loggerService;
		}

        public void FirstMethod()
        {
            _loggerService.Log(LogType.Info, $"Start method: {MethodBase.GetCurrentMethod().Name}");
        }

        public void SecondMethod()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public void ThirdMethod()
        {
            throw new Exception("I broke a logic");
        }
    }
}

