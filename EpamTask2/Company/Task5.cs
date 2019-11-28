using System;

namespace Company
{
    public class Task5 : Helper.Task<Employee>
    {
        internal DateTime GetBirthDate()
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

        internal User _addUser()
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

                var date = GetBirthDate();
                return new User(FirstName, SecondName, FatherName, date);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public override void _add()
        {
            var user = _addUser();

            Console.WriteLine("Write position");
            var position = Console.ReadLine();
            
            var experience = Helper.Class.GetNaturalNumber("Write full years of expirience");

            _data.Add(new Employee(user, position, experience));
            Console.WriteLine("\nEmployee added");
        }

        public override string _menu()
        {
            Console.Clear();
            return "Task 2.5. Employee\n" +
               "\nPress key 1 - Create new Employee" +
               "\n          2 - View created Employees" +
               "\n          3 - Clear created Employees" +
               "\n          ESC - Back to menu" +
               "\n---------------------------------\n";
        }
    }
}
