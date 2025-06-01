namespace Sortify.Models
{
    public class SortConfig
    {
        public Dictionary<string, HashSet<string>> SortingRules { get; set; } = new();
    }
}