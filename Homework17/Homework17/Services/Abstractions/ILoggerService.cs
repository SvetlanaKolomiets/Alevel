namespace Homework17.Services.Abstractions
{
	public interface ILoggerService
	{
        event LoggerService.BackupEventHandler Started;
        Task<string> Log(string message);
    }
}

