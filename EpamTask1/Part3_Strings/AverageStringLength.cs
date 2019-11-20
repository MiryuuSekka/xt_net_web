using System;
using System.Linq;


namespace Part3_Strings
{
    public static class AverageStringLength
    {
        public static void Get()
        {
            Console.WriteLine();
            var FullText = Console.ReadLine();
            DeletePunctiation(ref FullText);
            var text = FullText.Split(' ');
            Console.WriteLine("result is " + GetAverage(text));
        }

        static void DeletePunctiation( ref string FullText)
        {
            FullText = FullText.Replace(',', ' ');
            FullText = FullText.Replace('.', ' ');
            FullText = FullText.Replace(';', ' ');
            FullText = FullText.Replace(':', ' ');
            FullText = FullText.Replace('-', ' ');
            FullText = FullText.Replace('\"', ' ');
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
