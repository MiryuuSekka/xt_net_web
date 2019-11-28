using System;

namespace Company
{
    public class User : Helper.iInfo
    {
        public User(string firstName, string lastName, string fatherName, DateTime birthDate)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            _lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            if (firstName.Length < 3 || lastName.Length < 3)
            {
                throw new ArgumentException("Name lenght must be more then 2 symbols");
            }
            if (fatherName != null && fatherName.Length > 3)
            {
                _fatherName = fatherName;
            }
            _birthDate = birthDate;
        }

        string FirstName { get; set; }
        string _lastName { get; set; }
        string _fatherName { get; set; }
        DateTime _birthDate { get; set; }
        string _age
        {
            get
            {
                var years = ((DateTime.Now - _birthDate).Days) / 365.25m;
                return Math.Truncate(years).ToString();
            }
        }

        public string GetInfo()
        {
            var Data = "\nUser: ";
            Data += "\n     Ф.И.О - " + _lastName + " " + FirstName + " " + _fatherName;
            Data += "\n     Дата рождения - " + _birthDate.ToLongDateString();
            Data += "\n     Возраст - " + _age;
            return Data;
        }
    }
}
