

namespace Task2
{
    public static class Simple
    {
        static int N;
        
        public static string IsSimple(string Number)
        {
            string Result = "";
            int.TryParse(Number, out N);
            for (int i = 2; i < N; i++)
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
