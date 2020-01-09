using BLL;

namespace ConsoleApp2
{
    /// <summary>
    /// number validator
    /// </summary>
    public class Task4 : AbstractTask
    {
        string clearSuccsessText;
        public override void SelectMessages()
        {
            GreatingsMessage = "Its Task 7.4 - NUMBERS VERIFICATION";
            QuestionText = "Write Text with numbers";
            clearSuccsessText = "In text finded numbers  -> ";
            SuccsessText = clearSuccsessText;
            ErrorText = "In text didnt find numbers";
        }


        public override bool CheckText(string Text)
        {
            string SNum = "";
            string NormalNum = "";
            SuccsessText = clearSuccsessText;
            if (Logic.IsMatch(Text, Entity.Patterns.NumberScience))
            {
                SNum = Logic.GetSearchResult(Text, Entity.Patterns.NumberScience);
                Text = Logic.ReplaceAll(Text, Entity.Patterns.NumberScience);
                SuccsessText += "Science notation: " + SNum;
            }
            if (Logic.IsMatch(Text, Entity.Patterns.NumberUsual))
            {
                NormalNum = Logic.GetSearchResult(Text, Entity.Patterns.NumberUsual);
                SuccsessText += "Normal notation: " + NormalNum;
                return true;
            }
            return false;
        }

    }
}
