using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEntity;

namespace WebBLL
{
    public class Autentification
    {
        private DAL.Folder<WebUsers> DALUser;

        public Autentification()
        {
            DALUser = new DAL.Folder<WebUsers>(Common.Path + @"\WebUsers.json");
            //check table
            //create table if havenot
        }

        public bool CheckPassword(string Username, string Password)
        {
            var User = GetUser(Username, Password);
            if (User != null)
            {
                return true;
            }
            return false;
        }

        public WebUsers GetUser(int Id)
        {
            var Users = DALUser.GetAll();
            Users = Users.Where(x => x.Id == Id);
            return Users.FirstOrDefault();
        }

        public WebUsers GetUser(string Username, string Password)
        {
            var Users = DALUser.GetAll();
            Users = Users.Where(x => x.Password == Password);
            Users = Users.Where(x => x.Username == Username);
            return Users.FirstOrDefault();
        }

        public WebUsers AddUser(string Username, string Password, WebUsers.Roles Role)
        {
            var User = WebUsers.Parse(DALUser.GetAll(), Username, Password, Role);
            if (User!=null)
            {
                DALUser.AddData(User);
            }
            return User;
        }

        public IEnumerable<WebUsers> GetAllUsers()
        {
            return DALUser.GetAll();
        }

        public void ChangeUserRole(int UserId, WebUsers.Roles NewRole)
        {
            var baseUser = GetUser(UserId);
            DALUser.DeleteById(UserId);
            baseUser.Role = NewRole;
            DALUser.AddData(baseUser);
        }
    }
}
