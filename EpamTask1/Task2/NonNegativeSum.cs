using System;
using System.Text;

namespace Part2_Language
{
    public static class NonNegativeSum
    {
        static int Size;
        static int[] IntArray;

        public static void GetNewArray()
        {
            Size = Helper.Class.GetNaturalNumber("");
            IntArray = new int[Size];
            FullfillArray();
            Console.WriteLine("\nArray is\n" + GetValuesOfArray());
            ReplacePositive();
            Console.WriteLine("Non-negative numbers array\n" + GetValuesOfArray());
            Console.WriteLine("\nsum of non-negative numbers in array is " + GetSumOfArray());
        }

        static void FullfillArray()
        {
            var Randomize = new Random();
            for (int i = 0; i < Size; i++)
            {
                IntArray[i] = Randomize.Next(-100, 100);
            }
        }

        static string GetValuesOfArray()
        {
            var str = new StringBuilder();
            str.Append('{');
            for (int i = 0; i < Size; i++)
            {
                str.Append(IntArray[i]);
                if (i != Size - 1)
                {
                    str.Append(", ");
                }
            }
            str.Append("}");
            return str.ToString();
        }

        static void ReplacePositive()
        {
            for (int i = 0; i < Size; i++)
            {
                if (IntArray[i] < 0)
                {
                    IntArray[i] = 0;
                }
            }
        }

        static int GetSumOfArray()
        {
            int result = 0;
            foreach (var item in IntArray)
            {
                result += item;
            }
            return result;
        }
    }
}
