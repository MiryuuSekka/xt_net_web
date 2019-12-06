using System;

namespace EpamTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey Key;
            Clear();
            do
            {
                var Task1 = new Task1.Lost();
                Key = Console.ReadKey().Key;
            } while (Key != ConsoleKey.Escape);
            Clear();
            do
            {
                var Task2 = new Task2.WordFrequency();
                Key = Console.ReadKey().Key;
            } while (Key != ConsoleKey.Escape);
            Clear();

            do
            {
                var Task3 = new Task3.Menu();
                Key = Console.ReadKey().Key;
            } while (Key != ConsoleKey.Escape);
            Clear();
            Console.WriteLine("finale\n << Press ESC for exit >>");
            Console.ReadKey();
        }

        static void Clear()
        {
            Console.Clear();
            Console.WriteLine("<< Press ESC and go to next task >>");
        }
    }
}
