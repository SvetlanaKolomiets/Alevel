namespace Homework9.Services.Abstractions
{
	public interface IFileService
	{
        string GetDirectory();
        void CreateDirectory();
        void CheckIfDirectoryCouldBeCreated();
        string SetLogFileName();
        void WriteLogsToAFile();
        string[] GetAllFilesFromDirectory();
        string[] GetFilesWithoutOldestOne();
        string[] SortFilesByDate(string[] files);
        void DeleteOldestFile(string[] sortedFiles);
        string ConvertLogsToJson();
    }
}

