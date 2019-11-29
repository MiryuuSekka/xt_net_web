using System;

namespace Company
{
    public class Task3 : Helper.Task<User>
    {
        public override string TaskTitle()
        {
            return "Task 2.3 - USER";
        }

        internal DateTime getBirthDate()
        {
            int y = Helper.Class.GetNaturalNumber("Write year of birth");
            if (y > DateTime.Now.Year - 13 || y < 1900)
            {
                throw new ArgumentException("Wrong year of birth. " +
                    "Age of User must be above 14 and year of birth after 1900");
            }
            int m = Helper.Class.GetNaturalNumber("Write month of birth");
            if (m > 12)
            {
                throw new ArgumentException("Wrong month of birth");
            }
            int d = Helper.Class.GetNaturalNumber("Write day of birth");
            if (d > DateTime.DaysInMonth(y, m))
            {
                throw new ArgumentException("Wrong day of birth");
            }
            return new DateTime(y, m, d);
        }

        internal User addUser()
        {
            try
            {
                var FirstName = Helper.Class.GetName("Write First Name");
                var SecondName = Helper.Class.GetName("Write Second Name");
                Console.WriteLine("Write Father Name (can skip)");
                var FatherName = Console.ReadLine();
                if (FatherName.Length < 3)
                {
                    FatherName = "-";
                }

                var date = getBirthDate();
                return new User(FirstName, SecondName, FatherName, date);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public override void AddToList()
        {
            var result = addUser();
            if (result!=null)
            {
                Data.Add(result);
                Console.WriteLine("User Added");
            }
        }
    }
}
