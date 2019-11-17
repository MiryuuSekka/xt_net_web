using System.Text;

namespace Task3
{
    public class Square
    {
        static int N;

        public static string GetSquare(string Number)
        {
            int.TryParse(Number, out N);
            if (!IsOddNumber(N))
            {
                return "Wrong number";
            }

            var ResultString = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                if(N/2 == i)
                {
                    ResultString.Append('*', N/2);
                    ResultString.Append(" ");
                    ResultString.Append('*', N / 2);
                }
                else
                {
                    ResultString.Append('*', N);
                }
                ResultString.Append("\n");
            }
            return ResultString.ToString();
        }

        static bool IsOddNumber(int Number)
        {
            return Number % 2 != 0;
        }
    }
}
