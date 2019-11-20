using System;
using System.Text;

namespace Part1_Basics
{
    public static class AnotherTriangle
    {
        public static void Get()
        {
            var N = Helper.Class.GetNaturalNumber("size of triangle");
            Console.WriteLine(ConstructTriangle(N) + "\n");
        }

        static string ConstructTriangle(int Size)
        {
            var Triangle = new StringBuilder();
            for (int i = 0, count = Size; i <= Size; i++, count--)
            {
                Triangle.Append(' ', count);
                Triangle.Append('*', (i * 2 + 1));
                Triangle.Append("\n");
            }
            return Triangle.ToString();
        }
    }
}
