using System;
using System.Reflection;

namespace Lesson_5
{
    public class Action
    {
        public Result FirstMethod()
        {
            Logger logger = Logger.Instance;
            logger.AddInfoLog($"Start method: {MethodBase.GetCurrentMethod().Name}");

            Result result = new Result();
            result.Status = true;
            return result;
        }

        public Result SecondMethod()
        {
            Logger logger = Logger.Instance;
            logger.AddWarningLog($"Skipped logic in method: {MethodBase.GetCurrentMethod().Name}");

            Result result = new Result();
            result.Status = true;
            return result;
        }

        public Result ThirdMethod()
        {
            Result result = new Result();
            result.Status = false;
            result.Error = "I broke the logic";
            return result;
        }
    }
}