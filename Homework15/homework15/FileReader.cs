namespace homework15
{
    public class FileReader
    {

        private async Task<string[]> ReadFirstFileContent()
        {
            var lines = await File.ReadAllLinesAsync("/Users/Svitlana/Documents/Hello.txt");

            return lines;
        }

        private async Task<string[]> ReadSecondFileContent()
        {
            var lines = await File.ReadAllLinesAsync("/Users/Svitlana/Documents/World.txt");

            return lines;
        }

        public async Task<IEnumerable<string>> ShowFilesContent()
        {
            var firstFile = ReadFirstFileContent();

            var secondFile = ReadSecondFileContent();

            await Task.WhenAll(firstFile, secondFile);

            var file = firstFile.Result.Concat(secondFile.Result);

            foreach (var line in file)
            {
                Console.Write($"{line} ");
            }

            return file;

        }
    }
}

