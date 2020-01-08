using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public int Age { get; set; }



        static public User Parse(string Name, string Date, IEnumerable<User> data)
        {
            User NewUser = new User();
            if (Name.Length < 2)
            {
                throw new ArgumentException("Wrong Name");
            }
            DateTime.TryParse(Date, out DateTime NewDate);
            int Age = CalculateAge(NewDate);
            if (Age > 150 || Age < 1)
            {
                throw new ArgumentException("Wrong date");
            }

            NewUser.Name = Name;
            NewUser.Age = Age;
            NewUser.BirthDay = NewDate;
            NewUser.Id = GetNewId( data.ToList() );
            return NewUser;
        }

        static internal int CalculateAge(DateTime Birth)
        {
            int Age = 0;
            var today = DateTime.Now;
            if (Birth < DateTime.Now)
            {
                Age = today.Date.Year - Birth.Date.Year;
                if (today.Date.Month < Birth.Date.Month)
                {
                    Age--;
                }
                if (today.Date.Month == Birth.Date.Month)
                {
                    if (today.Date.Day < Birth.Date.Day)
                    {
                        Age--;
                    }
                }
            }
            return Age;
        }

        static internal int GetNewId(List<User> data)
        {
            int NewId = 1;
            if (data == null || data.Count < 1)
            {
                return NewId;
            }
            NewId = data.Max(x => x.Id);
            NewId++;
            return NewId;
        }
    }
}
