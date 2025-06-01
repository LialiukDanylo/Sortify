using Sortify.Models;
using Sortify.Services;

namespace Sortify
{
    public class Program
    {
        public static void Main()
        {
            ConfigService configService = new();
            SortService sortService = new();
            SortConfig config;

            try
            {
                config = configService.LoadConfig("config.json");
            }
            catch (InvalidDataException ex)
            {
                Console.WriteLine($"[!] Warning: {ex.Message}");
                Console.WriteLine("Using default configuration...\n");

                config = configService.GetDefaultConfig();
            }

            Console.WriteLine("Please enter the folder path");
            while (true)
            {
                Console.Write("> Path: ");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    sortService.SortFiles(config, path);
                    Console.WriteLine("[OK] Sorting complete.\n");
                }
                else
                {
                    Console.WriteLine("[!] Folder does not exist. Try again.\n");
                }
            }
        }
    }
}