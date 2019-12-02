using System;

namespace Helper
{
    public static class Number
    {
        public static int Converted;

        public static bool IsNatural(string Value)
        {
            int.TryParse(Value, out Converted);
            return (Converted > 0);
        }

        public static int GetNatural(string Text)
        {
            string str;
            bool result = false;
            do
            {
                Console.WriteLine("Write " + Text);
                str = Console.ReadLine();
                result = IsNatural(str);
                if (!result) Console.WriteLine("Wrong number. Try again!");
            }
            while (!result);
            return Converted;
        }
        
    }
}
