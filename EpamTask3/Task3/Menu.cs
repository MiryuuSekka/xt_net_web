using System;

namespace Task3
{
    public class Menu
    {
        DynamicArray<string> myArray;
        HardcoreDynamicArray<string> myHardcoreArray;
        CycledDynamicArray<string> myCycledArray;

        public Menu()
        {
            Console.WriteLine("TASK 3.3 and 3.4\n Set breakpoint in code");
            Part1();
            Part2();
            Part3();
            Part4();
            Part5();
            Part6();
            Part7();
            Part8();
            Part9();
            Part10();
            Part11();
            myHardcoreArray = new HardcoreDynamicArray<string>();
            myHardcoreArray.AddRange(myArray);
            Part12();
            Part13();
            Part14();
            Part15();
            myCycledArray = new CycledDynamicArray<string>();
            myCycledArray.AddRange(myHardcoreArray);
            Part16();
            Console.WriteLine("finished");
        }

        #region Task 3.3
        void Part1()
        {
            myArray = new DynamicArray<string>();
            var capacity = myArray.Capacity;
        }

        void Part2()
        {
            var capacity = 66;
            myArray = new DynamicArray<string>(capacity);
            capacity = myArray.Capacity;
        }

        void Part3()
        {
            var array = new string[] { "1", "4", "5", "6", "7", "8", "9", "0", "10", "4", "2", "555" };
            myArray = new DynamicArray<string>(array);
            var capacity = myArray.Capacity;
        }

        void Part4()
        {
            myArray.Add("10");
        }

        void Part5()
        {
            var capacity = myArray.Capacity;
            myArray.AddRange(new string[] { "3", "4", "6", "1", "3" });
            capacity = myArray.Capacity;
        }

        void Part6()
        {
            var capacity = myArray.Capacity;
            myArray.Remove("555");
            myArray.Remove(myArray.Current);
            capacity = myArray.Capacity;
        }

        void Part7()
        {
            var capacity = myArray.Capacity;
            myArray.Insert(7, "999");
            capacity = myArray.Capacity;
        }

        void Part8()
        {
            var count = myArray.Length;
        }

        void Part9()
        {
            var capacity = myArray.Capacity;
        }

        void Part10()
        {
            var result1 = myArray.GetEnumerator();
            var result2 = myArray.Current;
            var result3 = myArray.MoveNext();
            myArray.Reset();
            result2 = myArray.Current;
        }

        void Part11()
        {
            var result = myArray[6];
        }

        #endregion

        #region Task 3.4
        void Part12()
        {
            var result1 = myHardcoreArray[-4];
        }

        void Part13()
        {
            var array1 = myHardcoreArray;
            myHardcoreArray.Capacity -= 5;
            var array2 = myHardcoreArray;
        }

        void Part14()
        {
            var array = myHardcoreArray.Clone();
        }

        void Part15()
        {
            var array = myHardcoreArray.ToArray();
        }

        void Part16()
        {
            int count = 0;
            do
            {
                foreach (var item in myCycledArray)
                {
                    count++;
                }
            } while (count < 500);
        }
        #endregion
    }
}

