using System;

namespace EpamTask0
{
    class Program
    {
        static string Str;
        static void Main(string[] args)
        {
            DoTask1();
            DoTask2();
            DoTask3();
            DoTask4();

            Console.ReadKey();
        }

        static void DoTask1()
        {
            Console.WriteLine("Task 1 Sequence:\nWrite number");
            Str = Console.ReadLine();
            Str = Task1.Sequence.GetSequence(Str);
            Console.WriteLine("Result of Task 1 Simple:\n" + Str + "\n");
        }
        static void DoTask2()
        {
            Console.WriteLine("Task 2 Simple:\nWrite number. ");
            Str = Console.ReadLine();
            Str = Task2.Simple.IsSimple(Str);
            Console.WriteLine("Result of Task 2 :\nThis number is SIMPLE?\n" + Str + "\n");
        }
        static void DoTask3()
        {
            Console.WriteLine("Task 3 Square:\nWrite number. It's size of square");
            Str = Console.ReadLine();
            Str = Task3.Square.GetSquare(Str);
            Console.WriteLine("Result of Task 3 :\n" + Str + "\n");
        }
        static void DoTask4()
        {
            Console.WriteLine("Task 4 :\nWrite number. Size of array");
            Str = Task4.ArrayTask.GetSortedArray();
            Console.WriteLine(Str + "\n");
        }
    }
}
