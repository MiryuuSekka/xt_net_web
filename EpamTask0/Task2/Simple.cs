

namespace Task2
{
    public static class Simple
    {
        static int N;
        
        public static string IsSimple(string Number)
        {
            int.TryParse(Number, out N);
            var Root = System.Math.Sqrt(N);
            var RootValue = System.Math.Truncate(Root);


            if (N <= 0)
            {
                return "Wrong number";
            }

            if (N < 4)
            {
                return "SIMPLE";
            }
            else
            {
                for (int i = 2; i <= RootValue; i++)
                {
                    if (N % i == 0)
                    {
                        return "DON'T SIMPLE";
                    }
                }
                return "SIMPLE";
            }
        }
    }
}
