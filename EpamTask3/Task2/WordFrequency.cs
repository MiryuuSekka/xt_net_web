using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// задан англ текст. выделить отдельные слова
    /// для каждого посчитать частоту встречаемости
    /// слова отличающиеся регистром, считать одиннаковыми. 
    /// в качестве разделитетей считать пробел и точку
    /// </summary>
    public class WordFrequency
    {
        HashSet<string> Words;
        Dictionary<string, int> Result;
        StringBuilder Info;

        public WordFrequency()
        {
            Info = new StringBuilder();
            Console.WriteLine("Task 3.1");
            Console.WriteLine("Write Text. For word separete use symbols SPACE and DOT");
            var text = Console.ReadLine();
            if (text.Length < 1)
            {
                throw new ArgumentException("Too short text");
            }

            var Splited = SplitText(text);
            SearchCopiesNumber(Splited);
            ResultTable();

            Console.WriteLine(Info.ToString());
        }

        string[] SplitText(string text)
        {
            text = text.ToLower();
            var SplittedText = text.Split('.', ' ');
            Words = new HashSet<string>();

            foreach (var item in SplittedText)
            {
                Words.Add(item);
            }

            Info.AppendLine();
            Info.Append("Splited text: ");
            foreach (var item in Words)
            {
                Info.Append(item + " ");
            }

            return SplittedText;
        }

        void SearchCopiesNumber(string[] Splited)
        {
            int count;

            Result = new Dictionary<string, int>();
            foreach (var word in Words)
            {
                count = 0;
                foreach (var text in Splited)
                {
                    if (text.Equals(word))
                    {
                        count++;
                    }
                }
                Result.Add(word, count);
            }
        }

        void ResultTable()
        {
            Info.AppendLine();
            Info.AppendLine();
            Info.AppendLine("Result: ");
            foreach (var item in Result)
            {
                Info.AppendLine(item.Key + " - " + item.Value);
            }
        }
    }
}
