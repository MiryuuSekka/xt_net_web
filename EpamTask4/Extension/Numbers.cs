using System;
using System.Text.RegularExpressions;

namespace Extension
{
    public static class Numbers
    {
        /// <summary>
        /// /// 4.4.
        ///     Расширить массивы чисел методом, позволяющим найти их сумму.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double GetSum(this Array value)
        {
            double m = 0;
            foreach (var item in value)
            {
                double.TryParse(item.ToString(), out double itemValue);
                m += itemValue;
            }
            return m;
        }

        /// <summary>
        /// /// 4.5.
        ///     Расширить строку методом, определяющим, является ли она 
        ///     положительным целым числом. Стандартные методы преобразования 
        ///     строки в число (Parse и т.п.) не использовать.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNaturalNumber(this string value)
        {
            if(!string.IsNullOrEmpty(value))
            {
                var pattern = new Regex(@"^(?!0)([\d]+)$");
                return pattern.IsMatch(value);
            }
            return false;
        }
    }
}
