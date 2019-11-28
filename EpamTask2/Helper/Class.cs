using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class Class
    {
        public static Random Randomize = new Random();
        public static int GetNaturalNumber(string str)
        {
            int Number = 0;
            Console.WriteLine(str);
            int.TryParse(Console.ReadLine(), out Number);
            return Number;
        }

        public static bool IsNaturalNumber(int Number)
        {
            return Number > 0;
        }

        public static bool IsEscPressed(ConsoleKeyInfo Pressed)
        {
            return Pressed.Key == ConsoleKey.Escape;
        }

        public static string GetName(string str)
        {
            Console.WriteLine(str);
            str = Console.ReadLine();
            if (str.Length < 3)
            {
                throw new ArgumentException("Name must have more then 2 character");
            }
            return str;
        }

    }
}
