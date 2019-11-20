using System;
using System.Text;

namespace Part1_Basics
{
    public static class Triangle
    {
        public static void Get()
        {
            var N = Helper.Class.GetNaturalNumber("size of triangle");
            Console.WriteLine(ConstructTriangle(N) + "\n");
        }

        static string ConstructTriangle(int Size)
        {
            var Triangle = new StringBuilder();
            for (int i = 1; i <= Size; i++)
            {
                Triangle.Append('*', i);
                Triangle.Append("\n");
            }
            return Triangle.ToString();
        }
    }
}
