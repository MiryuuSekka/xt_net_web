using System;
using System.Linq;


namespace Strings
{
    public static class AverageStringLength
    {
        public static void Get()
        {
            Console.WriteLine();
            var FullText = Console.ReadLine();
            FullText = DeletePunctiation(FullText);
            var text = FullText.Split(' ');
            Console.WriteLine("result is " + GetAverage(text));
        }

        static string DeletePunctiation( string FullText)
        {
            string FormattedText = "";
            foreach (var item in FullText)
            {
                if(Char.IsPunctuation(item))
                {
                    FormattedText += ' ';
                }
                else
                {
                    FormattedText += item;
                }
            }
            return FormattedText;
        }

        static int GetAverage(string[] text)
        {
            int result = 0;
            for (int i = 0; i < text.Count(); i++)
            {
                result += text[i].Length;
            }
            result /= text.Count();
            return result;
        }
    }
}
