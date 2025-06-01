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
                SortingRules = new Dictionary<string, HashSet<string>>
                {
                    { "Pictures", [ ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".webp" ] },
                    { "Documents", [ ".pdf", ".docx", ".txt", ".xlsx", ".xml", ".json" ] },
                    { "Videos", [ ".mp4", ".avi", ".mov", ".mkv" ] },
                    { "Archives", [ ".zip", ".rar", ".7z", ".tar" ] },
                    { "Music", [ ".mp3", ".wav", ".flac" ] }
                }
            };
        }
    }
}