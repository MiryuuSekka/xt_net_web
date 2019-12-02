using System;

namespace Company
{
    public class Employee : Helper.IInfo
    {
        User User { get; set; }
        string Position { get; set; }
        int Experience { get; set; }

        public Employee(User user, string position, int experience)
        {
            this.User = user ?? throw new ArgumentNullException(nameof(user));
            this.Position = position ?? throw new ArgumentNullException(nameof(position));
            this.Experience = experience;
        }

        public string GetInfo()
        {
            var info = User.GetInfo();
            info += "\n     Position - " + Position;
            info += ", experience - " + Experience;
            return info;
        }
    }
}
