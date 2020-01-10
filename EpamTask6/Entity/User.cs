using System;
using System.Collections.Generic;

namespace Entity
{
    public class User : HaveId
    {
        public string Name { get; set; }

        public DateTime BirthDay { get; set; }

        public int Age { get; set; }


        public void CalculateAge()
        {
            var today = DateTime.Now;
            if (BirthDay < DateTime.Now)
            {
                this.Age = today.Date.Year - BirthDay.Date.Year;
                if (today.Date.Month < BirthDay.Date.Month)
                {
                    this.Age--;
                }
                if (today.Date.Month == BirthDay.Date.Month)
                {
                    if (today.Date.Day < BirthDay.Date.Day)
                    {
                        this.Age--;
                    }
                }
            }
        }



        static public User Parse(IEnumerable<User> data, params string[] Answers)
        {
            User NewUser = new User();
            try
            {
                NewUser.Name = User.ParseName(Answers[0]);
                NewUser.BirthDay = User.ParseBirthDate(Answers[1]);
                NewUser.CalculateAge();
                NewUser.Age = User.ParseAge(NewUser.Age, Answers[2]);
            }
            catch (ArgumentException e)
            {
                throw e;
            }

            NewUser.Id = NewUser.GetNewId(data);
            return NewUser;
        }


        static private string ParseName(string text)
        {
            if (text.Length < 2)
            {
                throw new ArgumentException("Wrong Name. Too smol");
            }
            return text;
        }

        static private DateTime ParseBirthDate(string text)
        {
            var NewDate = new DateTime();
            if (!text.Length.Equals(10))
            {
                throw new ArgumentException("Wrong Date. Must be 10 digits");
            }
            DateTime.TryParse(text, out NewDate);

            return NewDate;
        }

        static private int ParseAge(int userAge, string text)
        {
            if (text.Length > 0)
            {
                var Age = 0;
                int.TryParse(text, out Age);
                if (!userAge.Equals(Age))
                {
                    throw new ArgumentException("Wrong age");
                }
            }
            if (userAge > 150 || userAge < 1)
            {
                throw new ArgumentException("Wrong age");
            }
            return userAge;
        }

    }
}
