using System;
using System.Text;

namespace Task4
{
    public class ArrayTask
    {
        static int ArraySize;

        static int[] ArrayLenght;

        static int[] Values;


        static bool GetArrayLenght(string Number) {
            int.TryParse(Number, out ArraySize);
            return ArraySize > 0;
        }

        static bool GetArraySizes()
        {
            int N;
            ArrayLenght = new int[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                Console.WriteLine("Size of next array. " + (i+1).ToString() + "/"+ ArraySize);
                int.TryParse(Console.ReadLine(), out N);

                ArrayLenght[i] = N;
                if (N < 1) return false;
            }
            return true;
        }

        static string FullfillArray(int[] values)
        {
            var Str = new StringBuilder();
            int count = 0;

            Str.Append('{');
            for (int i = 0; i < ArraySize; i++)
            {
                Str.Append('{');
                for (int j = 0; j < ArrayLenght[i]; j++)
                {
                    Str.Append(values[count]);
                    if(j < ArrayLenght[i]-1) Str.Append(", ");
                    count++;
                }
                Str.Append('}');
                if (i < ArraySize - 1) Str.Append(", ");
            }
            Str.Append('}');
            return Str.ToString();
        }

        static int[] SortArray(int[] values)
        {
            Array.Sort(values);
            return values;
        }


        public static string GetSortedArray()
        {
            string Str;
            Str = Console.ReadLine();
            if (!GetArrayLenght(Str))
            {
                return "Wrong size of array";
            }
            if (!GetArraySizes())
            {
                return "Wrong size of array";
            }
            int Lenght = 0;
            foreach (var item in ArrayLenght)
            {
                Lenght += item;
            }
            Values = GetRandom(Lenght);
            Str = FullfillArray(Values);
            Console.WriteLine("\nNew Array:\n" + Str);
            SortArray(Values);
            Str = FullfillArray(Values);
            Console.WriteLine("\nSorted Array:\n" + Str);
            return "";
        }

        static int[] GetRandom(int Lenght)
        {
            var values = new int[Lenght];
            var Randomise = new Random();
            for (int i = 0; i < Lenght; i++)
            {
                values[i] = Randomise.Next(100);
            }
            return values;
        }
    }
}
