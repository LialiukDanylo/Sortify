namespace Sortify.Services
{
    public class SortService : ISortService
    {
        public void Sort(string directory, string folder, HashSet<string> extensions)
        {
            string pathToFolder = Path.Combine(directory, folder);

            if (!Directory.Exists(pathToFolder))
                Directory.CreateDirectory(pathToFolder);

            string[] files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                string fileExtension = Path.GetExtension(file);
                if (extensions.Contains(fileExtension))
                {
                    string newPath = Path.Combine(pathToFolder, Path.GetFileName(file));
                    Directory.Move(file, newPath);
                }
            }
        }
    }
}