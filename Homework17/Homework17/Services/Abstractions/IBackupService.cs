namespace Homework17.Services.Abstractions
{
	public interface IBackupService
	{
        void CreateDirectory();
        void CheckIfDirectoryCouldBeCreated();
        string SetBackupFileName();
        void CreateBackupFile();
    }
}

