using System.Collections.Generic;

namespace Entities
{
    public class Award : HaveKey
    {
        public string Title { get; set; }

        static public Award Parse(string Title, List<Award> Awards)
        {
            if(Title.Length < 5)
            {
                throw new System.ArgumentException("Too short Title. Needed more then 5 characters");
            }
            if(Awards.FindAll(x => x.Title.Equals(Title)).Count > 0)
            {
                throw new System.ArgumentException("Already have same award");
            }
            var NewAward = new Award();
            NewAward.Id = GetNewId(Awards);
            NewAward.Title = Title;
            return NewAward;
        }
    }
}
