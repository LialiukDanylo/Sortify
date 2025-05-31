using Sortify.Models;
using Sortify.Services;

namespace Sortify
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                ConfigService _configService = new();
                SortConfig config = _configService.LoadConfig("config.json");

                Console.WriteLine("Please, enter the folder path");
                while (true)
                {
                    Console.Write("Path: ");
                    string path = Console.ReadLine();
                    if (Directory.Exists(path))
                    {
                        Console.WriteLine($"Selected path: {path}");
                    }
                    else
                    {
                        Console.WriteLine("Folder does not exist. Try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadKey();
            }
        }
    }
}