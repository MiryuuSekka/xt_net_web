
namespace Entity
{
    public static class Patterns
    {
        public static string Date = @"(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-](19|20)\d\d";
        public static string HtmlTags = @"<[^>]*>";
        public static string Email = @"[\w][\w._]*[\w][@][\w]*[.][\w]{2,6}";
        public static string Time = @"^([012]?[0-9])[:]([0-5][0-9])[:]([0-5][0-9])\d\d$";

        public static string NumberUsual = @"[-]?[\d]*([.][\d]*)?";
        public static string NumberScience = @"[-]?[\d]*[.][\d]*(([Ee])|([Xx\*]10(\^)))[-]?[\d]*";
    }
}
