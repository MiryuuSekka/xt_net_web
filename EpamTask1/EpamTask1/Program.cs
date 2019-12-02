using System;

namespace EpamTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            Console.WriteLine("Task 1.1 - Rectangle");
            Basics.Rectangle.GetPerimeter();

            Console.WriteLine("Task 1.2 - Triangle");
            Basics.Triangle.GetTriangle();

            Console.WriteLine("Task 1.3 - Another triangle");
            Basics.Triangle.GetAnotherTriangle();

            Console.WriteLine("Task 1.4 - X-MAS tree");
            Basics.Triangle.GetXMasTree();

            Console.WriteLine("Task 1.5 - sum of numbers");
            Basics.SumOfNumbers.Get();

            Console.WriteLine("Task 1.6 - Font adjustment");
            Basics.FontAdjustment.Show();
            

            Console.WriteLine("\nTask 1.7 - array processing");
            Language.ArrayProcessing.GetNewArray();

            Console.WriteLine("\nTask 1.8 - No positive");
            Language.NoPositive.GetNewArray();

            Console.WriteLine("\nTask 1.9 - Non-negative sum");
            Language.NonNegativeSum.GetNewArray();

            Console.WriteLine("\nTask 1.10 - 2D array");
            Language.Array2d.GetNewArray();
            
            Console.WriteLine("\nTask 1.11 - Average string lenght");
            Strings.AverageStringLength.Get();

            Console.WriteLine("\nTask 1.12 - Char doubler");
            Strings.CharDouble.Get();

            Console.ReadKey();
        }
    }
}
