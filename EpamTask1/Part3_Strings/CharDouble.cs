using System;
using System.Linq;
using System.Text;

namespace Strings
{
    public static class CharDouble
    {
        static string FirstString;
        static string SecondString;

        public static void Get()
        {
            Console.WriteLine("Введите первую строку:");
            FirstString = Console.ReadLine();
            
            Console.WriteLine("Введите вторую строку:");
            SecondString = Console.ReadLine();

            Console.WriteLine("Результат:\n" + DoubleCharsInString());
        }

        static string DoubleCharsInString()
        {
            var result = new StringBuilder();
            var CharsForDouble= GetChars();
            foreach (var item in FirstString)
            {
                result.Append(item);
                if(IsSelected(CharsForDouble, item))
                {
                    result.Append(item);
                }
            }
            return result.ToString();
        }

        static bool IsSelected(string SelectedChars, char Selected)
        {
            foreach (var item in SelectedChars)
            {
                if (item.Equals(Selected))
                {
                    return true;
                }
            }
            return false;
        }

        static string GetChars()
        {
            string CharsForDouble = "";
            foreach (var SelectedChar in SecondString)
            {
                if (!CharsForDouble.Contains(SelectedChar))
                {
                    CharsForDouble += SelectedChar;
                }
            }
            return CharsForDouble;
        }
    }
}
