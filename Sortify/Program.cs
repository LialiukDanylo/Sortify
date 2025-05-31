using Sortify.Models;
using Sortify.Services;

namespace Sortify
{
    public class Program
    {
        public static void Main()
        {
            ConfigService configService = new();
            SortConfig config;

            try
            {
                config = configService.LoadConfig("config.json");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"Warning: {ex.Message}");
                Console.WriteLine("Using default configuration...\n");

                config = configService.GetDefaultConfig();
            }

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
    }
}