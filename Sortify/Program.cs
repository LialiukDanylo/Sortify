namespace Sortify
{
    public class Program
    {
        public static void Main()
        {
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