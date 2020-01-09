using System.Text.RegularExpressions;

namespace BLL
{
    public class Logic
    {
        public static bool IsMatch(string Text, string Pattern)
        {
            var TextMask = new Regex(Pattern);
            return TextMask.IsMatch(Text);
        }

        public static string ReplaceAll(string Text, string Pattern)
        {
            var TextMask = new Regex(Pattern);
            if (TextMask.IsMatch(Text))
            {
                Text = TextMask.Replace(Text, "");
            }
            return Text;
        }

        public static string GetSearchResult(string Text, string Pattern)
        {
            var TextMask = new Regex(Pattern);
            if (TextMask.IsMatch(Text))
            {
                var result = TextMask.Matches(Text);
                Text = "";
                foreach (var item in result)
                {
                    Text += item.ToString();
                    Text += "\n";
                }
            }
            return Text;

        }

        public static int CountMatches(string Text, string Pattern)
        {
            var TextMask = new Regex(Pattern);
            return TextMask.Matches(Text).Count;
        }
    }
}
