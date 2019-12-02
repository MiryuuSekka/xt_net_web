using System;

namespace Company
{
    public class Task5 : Helper.Task<Employee>
    {
        public override string TaskTitle()
        {
            return "Task 2.5 - EMPLOYEE";
        }

        internal DateTime GetBirthDate()
        {
            int y = Helper.Numbers.GetNatural("Write year of birth");
            if (y > DateTime.Now.Year - 13 || y < 1900)
            {
                throw new ArgumentException("Wrong year of birth. " +
                    "Age of User must be above 14 and year of birth after 1900");
            }
            int m = Helper.Numbers.GetNatural("Write month of birth");
            if (m > 12)
            {
                throw new ArgumentException("Wrong month of birth");
            }
            int d = Helper.Numbers.GetNatural("Write day of birth");
            if (d > DateTime.DaysInMonth(y, m))
            {
                throw new ArgumentException("Wrong day of birth");
            }
            return new DateTime(y, m, d);
        }

        internal User AddUser()
        {
            try
            {
                var FirstName = GetName("Write First Name");
                var SecondName = GetName("Write Second Name");
                Console.WriteLine("Write Father Name (can skip)");
                var FatherName = Console.ReadLine();
                if (FatherName.Length < 3)
                {
                    FatherName = "-";
                }

                var date = GetBirthDate();
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
            var user = AddUser();

            Console.WriteLine("Write position");
            var position = Console.ReadLine();
            
            var experience = Helper.Numbers.GetNatural("Write full years of expirience");

            Data.Add(new Employee(user, position, experience));
            Console.WriteLine("\nEmployee added");
        }

        string GetName(string str)
        {
            Console.WriteLine(str);
            str = Console.ReadLine();
            if (str.Length < 3)
            {
                throw new ArgumentException("Name must have more then 2 character");
            }
            return str;
        }
    }
}
