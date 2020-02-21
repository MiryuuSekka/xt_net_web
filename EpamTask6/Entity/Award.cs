using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class Award : HaveId
    {
        public string Title { get; set; }
        public Image Icon { get; set; }

        public static Award Parse(IEnumerable<Award> Awards, string Answer)
        {
            if (Answer.Length < 5)
            {
                throw new ArgumentException("Too short Title of Award. Min lenght is 5 characters");
            }

            var Result = Awards.ToList().FindAll(x => x.Title.Equals(Answer));
            if (Result.Count > 0)
            {
                throw new ArgumentException("Award with same title already exist");
            }

            var NewAward = new Award
            {
                Title = Answer
            };
            NewAward.Id = NewAward.GetNewId(Awards);
            return NewAward;
        }
    }
}
