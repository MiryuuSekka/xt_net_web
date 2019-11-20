using System;

namespace Part1_Basics
{
    public static class Rectangle
    {
        static int a, b;

        public static void GetPerimeter()
        {
            a = Helper.Class.GetNaturalNumber("value of side a");
            b = Helper.Class.GetNaturalNumber("value of side b");
            Console.WriteLine("Perimeter of this pectangle is ");
            Console.WriteLine(CalculatePerimeter() + "\n");
        }

        static int CalculatePerimeter()
        {
            return a * b;
        }
    }
}
