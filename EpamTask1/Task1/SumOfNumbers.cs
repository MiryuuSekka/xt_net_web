using System;

namespace Part1_Basics
{
    public static class SumOfNumbers
    {
        public static void Get()
        {
            int sum;
            sum = AddToSum(3);
            sum += AddToSum(5);
            Console.WriteLine(sum + "\n");
        }

        static int AddToSum(int N)
        {
            int result = N;
            int Max = 999/N;
            for (int i = 2; i <= Max; i++)
            {
                result += i * N;
            }
            return result;
        }
    }
}
