using System.Text.Json;
using Sortify.Models;

namespace Sortify.Services
{
    public class ConfigService : IConfigService
    {
        public SortConfig LoadConfig(string path)
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var config = JsonSerializer.Deserialize<SortConfig>(json);

                if (config == null || config.SortingRules == null || config.SortingRules.Count == 0)
                    throw new InvalidDataException("Config is invalid.");

                return config;
            }
            else
            {
                var defaultConfig = GetDefaultConfig();
                string json = JsonSerializer.Serialize(defaultConfig, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(path, json);
                return defaultConfig;
            }
        }

        public SortConfig GetDefaultConfig()
        {
            return new SortConfig
            {
                SortingRules = new Dictionary<string, string[]>
                {
                    { "Pictures", new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif" } },
                    { "Documents", new[] { ".pdf", ".docx", ".txt", ".xlsx" } },
                    { "Videos", new[] { ".mp4", ".avi", ".mov", ".mkv" } },
                    { "Archives", new[] { ".zip", ".rar", ".7z", ".tar" } },
                    { "Music", new[] { ".mp3", ".wav", ".flac" } }
                }
            };
        }
    }
}
