using System;
using System.Text;

namespace Basics
{
    public static class Triangle
    {
        public static void GetTriangle()
        {
            var N = Helper.Number.GetNatural("size of triangle");
            Console.WriteLine(ConstructTriangle(N) + "\n");
        }

        public static void GetAnotherTriangle()
        {
            var N = Helper.Number.GetNatural("size of triangle");
            Console.WriteLine(ConstructAnotherTriangle(N) + "\n");
        }

        public static void GetXMasTree()
        {
            var N = Helper.Number.GetNatural("size of tree");
            Console.WriteLine(ConstructXMASTree(N) + "\n");
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

        static string ConstructAnotherTriangle(int Size)
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

        static string ConstructXMASTree(int Size)
        {
            var Triangle = new StringBuilder();
            for (int triangle = 0; triangle < Size; triangle++)
            {
                for (int i = 0, count = triangle; i <= triangle; i++, count--)
                {
                    Triangle.Append(' ', Size - triangle);
                    Triangle.Append(' ', count);
                    Triangle.Append('*', (i * 2 + 1));
                    Triangle.Append("\n");
                }
            }
            return Triangle.ToString();
        }
    }
}
