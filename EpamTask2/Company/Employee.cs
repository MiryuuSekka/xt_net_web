using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Employee : User
    {
        string position;
        int experience;

        public Employee()
        {
            position = "-";
            experience = 0;
        }
        /*
        public Employee(string FirstName, string LastName, int Age, DateTime BirthDate, string Position, int Experience) 
            : base(FirstName, LastName, Age, BirthDate)
        {
            position = Position;
            experience = Experience;
        }
        */
    }
}
