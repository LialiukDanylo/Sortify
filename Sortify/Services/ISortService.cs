using Sortify.Models;

namespace Sortify.Services
{
    public interface ISortService
    {
        public void SortFiles(SortConfig config, string directory);
    }
}