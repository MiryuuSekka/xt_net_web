using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Part1_Basics.Triangle.Get();
            Console.WriteLine("Task 1.3 - Another triangle");
            Part1_Basics.AnotherTriangle.Get();
            Console.WriteLine("Task 1.4 - X-MAS tree");
            Part1_Basics.XMasTree.Get();
            Console.WriteLine("Task 1.5 - sum of numbers");
            Part1_Basics.SumOfNumbers.Get();
            //Console.WriteLine("Task 1.6 - Font adjustment");

            //Console.WriteLine("Task 1.7 - array processing");
            //Console.WriteLine("Task 1.8 - No positive");
            //Console.WriteLine("Task 1.9 - Non-negative sum");
            //Console.WriteLine("Task 1.10 - 2D array");

            //Console.WriteLine("Task 1.11 - Average string lenght");
            //Console.WriteLine("Task 1.12 - Char doubler");
            Console.ReadKey();
        }
    }
}
