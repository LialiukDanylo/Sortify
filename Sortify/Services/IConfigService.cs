using Sortify.Models;

namespace Sortify.Services
{
    public interface IConfigService
    {
        public SortConfig LoadConfig(string path);
        public SortConfig GetDefaultConfig();
    }
}