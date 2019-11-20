using System;
using System.Text;

namespace Part2_Language
{
    public static class Array2d
    {
        static int Size;
        static int[,] IntArray;

        public static void GetNewArray()
        {
            Size = Helper.Class.GetNaturalNumber("");
            IntArray = new int[Size,Size];
            FullfillArray();
            Console.WriteLine("\nArray is\n" + GetValuesOfArray());
            Console.WriteLine("\nsum of EVEN positions in 2d-array is " + GetSumOfEvenPositions());
        }

        static void FullfillArray()
        {
            var Randomize = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    IntArray[i, j] = Randomize.Next(-100, 100);
                }
            }
        }

        static string GetValuesOfArray()
        {
            var str = new StringBuilder();
            str.Append('{');
            for (int i = 0; i < Size; i++)
            {
                str.Append("\n {");
                for (int j = 0; j < Size; j++)
                {
                    str.Append(IntArray[i, j]);
                    if (j != Size - 1)
                    {
                        str.Append(", ");
                    }
                }
                str.Append("}");
            }
            str.Append("\n}");
            return str.ToString();
        }

        static int GetSumOfEvenPositions()
        {
            int result = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(IsEven(i, j))
                    {
                        result += IntArray[i, j];
                    }
                }
            }
            return result;
        }

        static bool IsEven(int x, int y)
        {
            return (x + y) % 2 == 0;
        }
    }
}
