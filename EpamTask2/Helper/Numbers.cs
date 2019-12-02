using System;

namespace Helper
{
    public static class Numbers
    {
        public static Random Randomize = new Random();

        public static int GetNatural(string str)
        {
            Console.WriteLine(str);
            int.TryParse(Console.ReadLine(), out int Number);
            return Number;
        }

        public static bool IsNatural(int Number)
        {
            return Number > 0;
        }
    }
}
