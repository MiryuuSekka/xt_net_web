using System;

namespace Company
{
    public class Employee : Helper.iInfo
    {
        User user { get; set; }
        string position { get; set; }
        int experience { get; set; }

        public Employee(User user, string position, int experience)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            this.position = position ?? throw new ArgumentNullException(nameof(position));
            this.experience = experience;
        }

        public string GetInfo()
        {
            var info = user.GetInfo();
            info += "\n     Position - " + position;
            info += ", experience - " + experience;
            return info;
        }
    }
}
