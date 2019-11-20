using System;

namespace Part1_Basics
{
    public static class FontAdjustment
    {
        [Flags]
        enum ParametersPull
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        static ParametersPull Parameters;

        public static void Show()
        {
            bool status = false;
            Console.WriteLine("Для перехода к следующему заданию нажмите Esc");
            do
            {
                Console.WriteLine("\nПараметры надписи:" + GetResult());
                Console.WriteLine("Введите:\n1: bold\n2: italic\n3: underline");
                status = setResult(Console.ReadKey());
                Console.WriteLine();
            }
            while (!status);
        }

        static bool setResult(ConsoleKeyInfo Key)
        {
            switch(Key.Key)
            {
                default:
                    Console.WriteLine("\nWrong number");
                    return false;

                case ConsoleKey.D1:
                    ChangeParameters(1);
                    return false;

                case ConsoleKey.D2:
                    ChangeParameters(2);
                    return false;

                case ConsoleKey.D3:
                    ChangeParameters(3);
                    return false;

                case ConsoleKey.Escape:
                    Console.WriteLine("\nGo to next task");
                    return true;
            }
        }

        static void ChangeParameters(int Number)
        {
            ParametersPull param;
            switch (Number)
            {
                default:
                    param = ParametersPull.None;
                    break;

                case 1:
                    param = ParametersPull.Bold;
                    break;

                case 2:
                    param = ParametersPull.Italic;
                    break;

                case 3:
                    param = ParametersPull.Underline;
                    break;
            }
            Parameters = (Parameters.HasFlag(param))? Parameters & ~param : Parameters | param;
        }

        static string GetResult()
        {
            string result = "";
            if (Parameters.HasFlag(ParametersPull.Bold))
            {
                if (result.Length > 1) result += ", ";
                result += ParametersPull.Bold.ToString();
            }

            if (Parameters.HasFlag(ParametersPull.Italic))
            {
                if (result.Length > 1) result += ", ";
                result += ParametersPull.Italic.ToString();
            }

            if (Parameters.HasFlag(ParametersPull.Underline))
            {
                if (result.Length > 1) result += ", ";
                result += ParametersPull.Underline.ToString();
            }

            if (result.Length < 1)
            {
                result += ParametersPull.None.ToString();
            }
            return result;
        }
    }
}
