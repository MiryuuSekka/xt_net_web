using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask2
{
    class Program
    {
        static bool IsProgress;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Menu();
                IsProgress = Action(Console.ReadKey());
            }
            while (IsProgress);
        }

        static void Menu()
        {
            var str = new StringBuilder();
            str.Append("TASK 2\nMENU\n");
            str.Append("    1 - Round\n");
            str.Append("    2 - Triangle\n");
            str.Append("    3 - User\n");
            str.Append("    4 - MyString\n");
            str.Append("    5 - Employee\n");
            str.Append("    6 - Ring\n");
            str.Append("    7 - Vector graphics editor\n");
            str.Append("    8 - GAME\n");
            str.Append("Press number of task for start. OR esc for exit\n");
            Console.WriteLine(str.ToString());
        }

        static bool Action(ConsoleKeyInfo Pressed)
        {
            switch(Pressed.Key)
            {
                default:
                    break;
                case ConsoleKey.Escape:
                    return false;
                case ConsoleKey.D1:
                    var task1 = new Graphics.Task1();
                    break;
            }
            return true;
        }

        /*
            //var task2 = new Graphics.Task2();
            //var task3 = new Graphics.Task3();
            //var task4 = new Graphics.Task4();
            //var task5 = new Graphics.Task5();
            //var task6 = new Graphics.Task6();
            //var task7 = new Graphics.Task7();
            //var task8 = new Graphics.Task8();

         */
    }
}
