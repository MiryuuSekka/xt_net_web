using System;

namespace Company
{
    public class User : Helper.IInfo
    {
        public User(string firstName, string lastName, string fatherName, DateTime birthDate)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            if (firstName.Length < 3 || lastName.Length < 3)
            {
                throw new ArgumentException("Name lenght must be more then 2 symbols");
            }
            if (fatherName != null && fatherName.Length > 3)
            {
                this.FatherName = fatherName;
            }
            this.BirthDate = birthDate;
        }

        string FirstName { get; set; }
        string LastName { get; set; }
        string FatherName { get; set; }
        DateTime BirthDate { get; set; }
        string Age
        {
            get
            {
                var years = ((DateTime.Now - BirthDate).Days) / 365.25m;
                return Math.Truncate(years).ToString();
            }
        }

        public string GetInfo()
        {
            var Data = "\nUser: ";
            Data += "\n     Ф.И.О - " + LastName + " " + FirstName + " " + FatherName;
            Data += "\n     Дата рождения - " + BirthDate.ToLongDateString();
            Data += "\n     Возраст - " + Age;
            return Data;
        }
    }
}
