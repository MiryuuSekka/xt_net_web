using System;
using System.Text;

namespace Part2_Language
{
    static public class NoPositive
    {
        static int Size;
        static int[,,] IntArray;

        public static void GetNewArray()
        {
            Size = Helper.Class.GetNaturalNumber("");
            IntArray = new int[Size, Size, Size];
            FullfillArray();
            Console.WriteLine("Array is\n" + GetValuesOfArray());
            ReplacePositive();
            Console.WriteLine("No positive numbers array is\n" + GetValuesOfArray());
        }

        static void FullfillArray()
        {
            var Randomize = new Random();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        IntArray[i, j, k] = Randomize.Next(-100, 100);
                    }
                }
            }
        }

        static string GetValuesOfArray()
        {
            var str = new StringBuilder();
            str.Append('{');
            for (int i = 0; i < Size; i++)
            {
                str.Append("\n   {");
                for (int j = 0; j < Size; j++)
                {
                    str.Append("\n       {");
                    for (int k = 0; k < Size; k++)
                    {
                        str.Append(IntArray[i, j, k]);
                        if (k != Size - 1)
                        {
                            str.Append(", ");
                        }
                        else
                        {
                            str.Append("}");
                        }
                    }
                }
                str.Append("\n   }");
            }
            str.Append("\n}");
            return str.ToString();
        }

        static void ReplacePositive()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    for (int k = 0; k < Size; k++)
                    {
                        if(IntArray[i,j,k] > 0)
                        {
                            IntArray[i, j, k] = 0;
                        }
                    }
                }
            }
        }
    }
}
