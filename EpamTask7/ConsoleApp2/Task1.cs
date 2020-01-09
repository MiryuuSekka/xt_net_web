using BLL;

namespace ConsoleApp2
{
    /// <summary>
    /// Date existance
    /// dd-mm-yyyy
    /// </summary>
    public class Task1 : AbstractTask
    {
        public override void SelectMessages()
        {
            GreatingsMessage = "Its Task 7.1 - DATE EXISTANCE";
            QuestionText = "Write Text with date at format dd-mm-yyyy";
            SuccsessText = "In text finded date";
            ErrorText = "In text didnt find date";
        }

        public override bool CheckText(string Text)
        {
            return Logic.IsMatch(Text, Entity.Patterns.Date);
        }
    }
}
