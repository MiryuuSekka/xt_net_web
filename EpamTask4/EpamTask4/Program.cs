using System;
using System.Collections.Generic;
using System.Text;
using Extension;

namespace EpamTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomSortDemo();
            Console.ReadKey();

            SortingUnit();
            Console.ReadKey();

            NumberArraySum();
            Console.ReadKey();

            ToIntOrNotToInt();
            Console.ReadKey();
        }


        static SortTask1 Task1 = new SortTask1();
        static void CustomSortDemo()
        {
            Task1 = new SortTask1();
            Console.Clear();
            Console.WriteLine("Task 4.1 & Task 4.2");

            var array1 = new List<string>() { "b", "dec", "a", "december", "dece", "december31", "decem", "decembe", "december3", "decemb" };
            Task2Console(array1);

            var array2 = new List<int>() { 1, 3, 53, 5, 6, 8, 2, 4, 5, 33, 5 };
            Task2Console(array2);

            var array3 = new List<char>() { '4', '5', 'f', 'F', '1' };
            Task2Console(array3);

            var array4 = new List<char>();

            try
            {
                Task2Console(array4);

                Task2Console<char>(null);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        /// <summary>
        /// demonstration of work task 4.1 and 4.2
        /// </summary>
        /// <typeparam name="T">type of array</typeparam>
        /// <param name="array"></param>
        static void Task2Console<T>(List<T> array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            Console.WriteLine("\nSort:");
            foreach (var item in array)
                Console.Write(item.ToString() + " ");
            Console.WriteLine();

            var SortType = new Function<T>(Task1.CustomIncreaseSort<T>);
            array = Task1.DoSort<T>(array, SortType);
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine("\ntime: " + Task1.GetTime().ToString());
        }

    
        static void SortingUnit()
        {
            Console.Clear();
            Console.WriteLine("Task 4.3");

            var Task2 = new Sort<int>();
            var arr = new int[] { 3, 1, 455, 23, 12, 4 };
            Console.Write("Started array 1: ");
            WriteArray(arr);
            Task2.CreateThread(arr, Task2.PrimarySortMethod, Task2.SecondarySortMethod);

            var Task3 = new Sort<string>();
            var arr2 = new string[] { "aaa", "d", "s", "1123", "a", "rr", "ra", "rf", "AAAAAAAAAAAAAAAAAAAAAAb", "AAAAAAAAAAAAAAAAAAAAAAa" };
            Console.Write("Started array 2: ");
            WriteArray(arr2);
            Task3.CreateThread(arr2, Task3.PrimarySortMethod, Task3.SecondarySortMethod);

            var arr3 = new string[] { "a", "a", "a", "a", "a", "b", "a", "a", "a", "a" };
            Console.Write("Started array 3: ");
            WriteArray(arr3);
            Task3.CreateThread(arr3, Task3.PrimarySortMethod, Task3.SecondarySortMethod);

            Console.Write("Sorted array 1: ");
            WriteArray(arr);
            Console.Write("Sorted array 2: ");
            WriteArray(arr2);
            Console.Write("Sorted array 3: ");
            WriteArray(arr3);
        }

        static void WriteArray(Array array)
        {
            var str = new StringBuilder();

            str.Append("[ ");
            foreach (var item in array)
            {
                str.Append(item.ToString());
                str.Append(" ");
            }
            str.Append("]");
            Console.WriteLine(str.ToString());
        }


        static void NumberArraySum()
        {
            Console.Clear();
            Console.WriteLine("Task 4.4");

            var array1 = new int[] { 1, 3, 4, 5, 67, 7, 5, 3, 3 };
            var result1 = array1.GetSum();

            var array2 = new double[] { 1, 3, 4, 5, 67, 7, 5, 3, 3 };
            var result2 = array2.GetSum();

            var array3 = new float[] { 1, 3, 4, 5, 67, 7, 5, 3, 3 };
            var result3 = array3.GetSum();
            
            var array4 = new decimal[] { 1, 3, 4, 5, 67, 7, 5, 3, 3 };
            var result4 = array4.GetSum();
        }

        static void ToIntOrNotToInt()
        {
            Console.Clear();
            Console.WriteLine("Task 4.5");

            var str1 = "ouefheosuw55e";
            var result1 = str1.IsNaturalNumber();

            var str2 = "54647";
            var result2 = str2.IsNaturalNumber();

            var str3 = "34.24";
            var result3 = str3.IsNaturalNumber();

            var str4 = "-143";
            var result4 = str4.IsNaturalNumber();

            var str5 = "0143";
            var result5 = str5.IsNaturalNumber();
        }

        static void SeekU()
        {
            Console.Clear();
            Console.WriteLine("Task 4.6");
        }
    }
}

