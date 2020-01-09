using BLL;

namespace ConsoleApp2
{
    /// <summary>
    /// time counter
    /// </summary>
    public class Task5 : AbstractTask
    {
        string clearSuccsessText;
        public override void SelectMessages()
        {
            GreatingsMessage = "Its Task 7.5 - TIME COUNTER";
            QuestionText = "Write Text with time";
            clearSuccsessText = "In text finded time  -> ";
            SuccsessText = clearSuccsessText;
            ErrorText = "In text didnt find time";
        }

        public override bool CheckText(string Text)
        {
            var Count = Logic.CountMatches(Text, Entity.Patterns.Time);
            if (Count > 0)
            {
                SuccsessText = clearSuccsessText + Count.ToString() + "results";
                SuccsessText += Logic.GetSearchResult(Text, Entity.Patterns.Time);
                return true;
            }
            return false;
        }
    }
}
