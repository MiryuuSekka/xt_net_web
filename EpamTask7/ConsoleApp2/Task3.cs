using BLL;

namespace ConsoleApp2
{
    /// <summary>
    /// email finder
    /// 
    /// </summary>
    public class Task3 : AbstractTask
    {
        string clearSuccsessText;

        public override void SelectMessages()
        {
            GreatingsMessage = "Its Task 7.3 - E-MAIL FINDER";
            QuestionText = "Write Text with email";
            clearSuccsessText = "In text finded email and selected. result is ->    ";
            SuccsessText = clearSuccsessText;
            ErrorText = "In text didnt find email";
        }

        public override bool CheckText(string Text)
        {
            if (Logic.IsMatch(Text, Entity.Patterns.Email))
            {
                Text = Logic.GetSearchResult(Text, Entity.Patterns.Email);
                SuccsessText += Text;
                return true;
            }
            return false;

        }
    }
}
