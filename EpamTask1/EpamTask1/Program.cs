using System;

namespace EpamTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Task 1.1 - Rectangle");
            Part1_Basics.Rectangle.GetPerimeter();

            Console.WriteLine("Task 1.2 - Triangle");
            Part1_Basics.Triangle.GetTriangle();

            Console.WriteLine("Task 1.3 - Another triangle");
            Part1_Basics.Triangle.GetAnotherTriangle();

            Console.WriteLine("Task 1.4 - X-MAS tree");
            Part1_Basics.Triangle.GetXMasTree();

            Console.WriteLine("Task 1.5 - sum of numbers");
            Part1_Basics.SumOfNumbers.Get();

            Console.WriteLine("Task 1.6 - Font adjustment");
            Part1_Basics.FontAdjustment.Show();
            

            Console.WriteLine("\nTask 1.7 - array processing");
            Part2_Language.ArrayProcessing.GetNewArray();

            Console.WriteLine("\nTask 1.8 - No positive");
            Part2_Language.NoPositive.GetNewArray();

            Console.WriteLine("\nTask 1.9 - Non-negative sum");
            Part2_Language.NonNegativeSum.GetNewArray();

            Console.WriteLine("\nTask 1.10 - 2D array");
            Part2_Language.Array2d.GetNewArray();


            Console.WriteLine("\nTask 1.11 - Average string lenght");
            Part3_Strings.AverageStringLength.Get();

            Console.WriteLine("\nTask 1.12 - Char doubler");
            Part3_Strings.CharDouble.Get();

            Console.ReadKey();
        }
    }
}
