namespace Sortify.Services
{
    public interface ISortService
    {
        public void Sort(string directory, string folder, HashSet<string> extensions);
    }
}
