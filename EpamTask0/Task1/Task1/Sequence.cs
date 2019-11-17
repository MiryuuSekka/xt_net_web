

namespace Task1
{
    public class Sequence
    {
        static int N;

        public static string GetSequence(string Number)
        {
            string Result = "";
            int.TryParse(Number, out N);

            for (int i = 1; i <= N; i++)
            {
                Result += i;
                if (i < N)
                {
                    Result += ", ";
                }
            }
            return Result;
        }
    }
}
