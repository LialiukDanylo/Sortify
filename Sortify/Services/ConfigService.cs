using System.Text.Json;
using Sortify.Models;

namespace Sortify.Services
{
    public class ConfigService : IConfigService
    {
        public SortConfig LoadConfig(string path)
        {
            var json = File.ReadAllText(path);

            try
            {
                var config = JsonSerializer.Deserialize<SortConfig>(json);

                if (config.SortingRules.Count == 0)
                    throw new Exception("Config invalid: missing or empty SortingRules");

                return config;
            }
            catch (JsonException ex)
            {
                throw new Exception("Config invalid: JSON parsing error", ex);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
