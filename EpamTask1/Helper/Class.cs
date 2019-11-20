using System;

namespace Helper
{
    public static class Class
    {
        public static int ConvertedNumber;

        public static bool IsNaturalNumber(string Value)
        {
            int.TryParse(Value, out ConvertedNumber);
            return (ConvertedNumber > 0);
        }

        public static int GetNaturalNumber(string Text)
        {
            string str;
            bool result = false;
            do
            {
                Console.WriteLine("Write " + Text);
                str = Console.ReadLine();
                result = IsNaturalNumber(str);
                if (!result) Console.WriteLine("Wrong number. Try again!");
            }
            while (!result);
            return ConvertedNumber;
        }
        
    }
}
