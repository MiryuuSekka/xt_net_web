using System;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey Key;
            do
            {
                Key = Menu();

                switch (Key)
                {
                    case ConsoleKey.D1:
                        StartApp1();
                        break;

                    case ConsoleKey.D2:
                        StartApp2();
                        break;

                    default:
                        break;
                }
            } while (Key != ConsoleKey.Escape);
        }

        static ConsoleKey Menu()
        {
            Console.Clear();
            Console.WriteLine("Choose part of task 6:");
            Console.WriteLine("     <<1>> User ");
            Console.WriteLine("     <<2>> User with awards ");
            Console.WriteLine("Press number for select");

            return Console.ReadKey().Key;
        }

        static void StartApp1()
        {
            var App = new UserConsole();
            App.Start();
        }

        static void StartApp2()
        {
            var App = new AwardConsole();
            App.Start();
        }

    }
}
