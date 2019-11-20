using System;
using System.Text;

namespace Part2_Language
{
    public class ArrayProcessing
    {
        static int Size;
        static int[] IntArray;

        public static void GetNewArray()
        {
            Size = Helper.Class.GetNaturalNumber("");
            IntArray = new int[Size];
            FullfillArray();
            Console.WriteLine("Array is\n" + GetValuesOfArray());
            Console.WriteLine("Max value in array is " + GetMax());
            Console.WriteLine("Min value in array is " + GetMin());
            SortArray();
            Console.WriteLine("Sorted array is\n" + GetValuesOfArray());
        }

        static void FullfillArray()
        {
            var Randomize = new Random();
            for (int i = 0; i < Size; i++)
            {
                IntArray[i] = Randomize.Next(100);
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
                else
                {
                    str.Append(" }");
                }
            }
            return str.ToString();
        }

        static int GetMax()
        {
            var Max = IntArray[0];
            foreach (var value in IntArray)
            {
                if (Max < value) Max = value;
            }
            return Max;
        }

        static int GetMin()
        {
            var Min = IntArray[0];
            foreach (var value in IntArray)
            {
                if (Min > value) Min = value;
            }
            return Min;
        }

        static void SortArray()
        {
            int N;
            do
            {
                for (int i = 0; i < Size - 1; i++)
                {
                    if (IntArray[i] >= IntArray[i + 1])
                    {
                        N = IntArray[i];
                        IntArray[i] = IntArray[i + 1];
                        IntArray[i + 1] = N;
                    }
                }
            }
            while (!IsSorted());
        }

        static bool IsSorted()
        {
            for (int i = 0; i < Size - 1; i++)
            {
                if (IntArray[i] >= IntArray[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
