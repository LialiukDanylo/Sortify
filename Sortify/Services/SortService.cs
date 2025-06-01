using Sortify.Models;

namespace Sortify.Services
{
    public class SortService : ISortService
    {
        public void SortFiles(SortConfig config, string directory)
        {
            foreach (var type in config.SortingRules)
            {
                MoveFilesByExtension(directory, type.Key, type.Value);
            }
        }

        private void MoveFilesByExtension(string directory, string folder, HashSet<string> extensions)
        {
            var normalizedExtensions = new HashSet<string>(extensions, StringComparer.OrdinalIgnoreCase);

            string[] files = Directory.GetFiles(directory);

            var filesToMove = files
                .Where(file => normalizedExtensions.Contains(Path.GetExtension(file)))
                .ToList();

            if(filesToMove.Count == 0)
                return;

            string pathToFolder = Path.Combine(directory, folder);

            if (!Directory.Exists(pathToFolder))
                Directory.CreateDirectory(pathToFolder);
            
            foreach (var file in filesToMove)
            {
                string newPath = Path.Combine(pathToFolder, Path.GetFileName(file));
                Directory.Move(file, newPath);
            }
        }
    }
}