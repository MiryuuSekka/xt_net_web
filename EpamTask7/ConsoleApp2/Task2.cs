using BLL;

namespace ConsoleApp2
{
    /// <summary>
    /// html replacer 
    /// <b></b>
    /// <i></i>
    /// <font color="red"></font>
    /// </summary>
    public class Task2 : AbstractTask
    {
        string clearSuccsessText;

        public override void SelectMessages()
        {
            GreatingsMessage = "Its Task 7.2 - HTML REPLACER";
            QuestionText = "Write Text with html tags";
            clearSuccsessText = "In text finded tags and removed. result is ->    ";
            SuccsessText = clearSuccsessText;
            ErrorText = "In text didnt find html tags";
        }

        public override bool CheckText(string Text)
        {
            if (Logic.IsMatch(Text, Entity.Patterns.HtmlTags))
            {
                SuccsessText += Logic.ReplaceAll(Text, Entity.Patterns.HtmlTags);
                return true;
            }
            return false;
        }
    }
}
