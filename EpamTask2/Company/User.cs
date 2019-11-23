using System;

namespace Company
{
    public class User
    {
        string FirstName;
        string LastName;
        string FatherName;
        DateTime BirthDate;
        int Age;

        public User(string FirstName, string LastName, string FatherName,
                        int Age, DateTime BirthDate)
        {
            CreateNewUser(FirstName, LastName, FatherName, Age, BirthDate);
        }
        
        public User()
        {
            CreateNewUser("Unknown", "Unknown", "-", 0, DateTime.MinValue.Date);
        }

        void CreateNewUser(string FirstName, string LastName, string FatherName,
                        int Age, DateTime BirthDate)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FatherName = FatherName;
            this.BirthDate = BirthDate;
            this.Age = Age;
        }

        public string GetInformation()
        {
            var Data = "User: ";
            Data += "\n     Ф.И.О - " + LastName + " " + FirstName + " " + FatherName;
            Data += "\n     Дата рождения - " + BirthDate;
            Data += "\n     Возраст - " + Age;
            return Data;
        }
    }
}
