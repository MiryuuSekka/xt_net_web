using System;
using System.Text;

namespace EpamTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey Pressed;
            do
            {
                menu();
                Pressed = Console.ReadKey().Key;
                action(Pressed);
            }
            while (!Pressed.Equals(ConsoleKey.Escape));
        }

        static void menu()
        {
            Console.Clear();
            var str = new StringBuilder();
            str.Append("TASK 2\nMENU\n");
            str.Append("    1 - Round\n");
            str.Append("    2 - Triangle\n");
            str.Append("    3 - User\n");
            str.Append("    4 - MyString\n");
            str.Append("    5 - Employee\n");
            str.Append("    6 - Ring\n");
            str.Append("    7 - Vector graphics editor\n");
            str.Append("    8 - GAME (only map generator)\n");
            str.Append("Press number of task for start. OR esc for exit\n");
            Console.WriteLine(str.ToString());
        }

        static void action(ConsoleKey Pressed)
        {
            switch(Pressed)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    var task1 = new Graphics.Task1();
                    break;

                case ConsoleKey.D2:
                    var task2 = new Graphics.Task2();
                    break;

                case ConsoleKey.D6:
                    var task6 = new Graphics.Task6();
                    break;

                case ConsoleKey.D7:
                    var task7 = new Graphics.Task7();
                    break;

                case ConsoleKey.D3:
                    var task3 = new Company.Task3();
                    break;

                case ConsoleKey.D4:
                    var task4 = new CustomString.Task4();
                    break;

                case ConsoleKey.D5:
                    var task5 = new Company.Task5();
                    break;

                case ConsoleKey.D8:
                    var task8 = new GameConsole.Class();
                    break;
            }
        }
    }
}
