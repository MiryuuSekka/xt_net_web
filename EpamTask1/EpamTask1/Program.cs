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
            

            Console.WriteLine("Task 1.7 - array processing");
            Part2_Language.ArrayProcessing.GetNewArray();

            Console.WriteLine("Task 1.8 - No positive");
            Part2_Language.NoPositive.GetNewArray();

            //Console.WriteLine("Task 1.9 - Non-negative sum");
            //Console.WriteLine("Task 1.10 - 2D array");

            //Console.WriteLine("Task 1.11 - Average string lenght");
            //Console.WriteLine("Task 1.12 - Char doubler");
            Console.ReadKey();
        }
    }
}
