using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class WebUser : HaveId
    {
        public enum Roles
        {
            Guest,
            User,
            Admin
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public static WebUser Parse(IEnumerable<WebUser> AllWebUsers, string Username, string Password, WebUser.Roles Role)
        {
            if (AllWebUsers == null)
            {
                throw new ArgumentException("Cant create User. Cant find Table");
            }
            if (Username.Length < 4)
            {
                throw new ArgumentException("Too short username. Need more then 3 characters");
            }
            if (Password.Length < 6)
            {
                throw new ArgumentException("Too short password.  Need more then 5 characters");
            }
            if (AllWebUsers.Where(x => x.Username == Username).Count() > 0)
            {
                throw new ArgumentException("Username already exist");
            }

            var NewUser = new WebUser
            {
                Role = Role,
                Username = Username,
                Password = Password
            };
            NewUser.Id = NewUser.GetNewId(AllWebUsers);
            return NewUser;
        }
    }
}
