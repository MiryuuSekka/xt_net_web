using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    /// <summary>
    ///В кругу стоят Н человек пронумерованных от 1 до Н.
    ///при ведении счёта по кругу вычёркивается каждый второй человек,
    ///пока не останется один
    /// </summary>
    public class Lost
    {
        List<int> Numbers;

        public Lost()
        {
            int N = 0;
            Greeting();
            try
            {
                N = Helper.Number.GetNatural(Console.ReadLine());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            FullfillArray(N);
            Logic();

        }

        void Greeting()
        {
            var str = new StringBuilder();
            str.AppendLine("TASK 3.1");
            str.AppendLine("In circle standing N people.");
            str.AppendLine("They counted from 1 to N");
            str.AppendLine("When counting by circle - kickout all even number person");
            str.AppendLine("while dont stay only one");
            str.AppendLine();
            str.AppendLine("<< Write they number >>");

            Console.WriteLine(str.ToString());
        }

        void Logic()
        {
            var str = new StringBuilder();
            int circleNumber = 0;
            do
            {
                foreach (var item in Numbers)
                {
                    str.Append(item + " ");
                }
                str.AppendLine();

                Numbers.RemoveAll(x => !Helper.Number.IsEven(Numbers.IndexOf(x) + circleNumber));

                circleNumber++;
            } while (Numbers.Count > 1);

            str.Append(Numbers[0]);
            Console.WriteLine(str.ToString());
        }

        void FullfillArray(int Capacity)
        {
            Numbers = new List<int>(Capacity);
            for (int i = 0; i < Capacity; i++)
            {
                Numbers.Add(i + 1);
            }
        }
    }
}
