using System;

namespace Helper
{
    public static class Number
    {
        public static int GetNatural(string Line)
        {
            int.TryParse(Line, out int N);
            if (N <= 0)
            {
                throw new ArgumentException("Value not natural number");
            }
            return N;
        }

        public static bool IsEven(int N)
        {
            return N % 2 == 0;
        }
    }
}
