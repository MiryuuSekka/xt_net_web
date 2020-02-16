using System.Collections.Generic;
using WebEntity;

namespace EpamTask10.Models
{
    public class WebData
    {
        private static readonly string DefaultImage = "https://cdn4.iconfinder.com/data/icons/trophy-and-awards-1/64/Icon_Medal_Trophy_Awards_Red-512.png";
        public static WebUsers CurrentUser = GetUserByID(1);
        public static string CurrentUserAvatar = GetImageForUser(CurrentUser.Role);


        public static WebUsers GetUserByID(int Id)
        {
            var BLL = new WebBLL.Autentification();
            var User = BLL.GetUser(Id);
            return User;
        }

        public static IEnumerable<WebUsers> GetAllUsers()
        {
            var BLL = new WebBLL.Autentification();
            return BLL.GetAllUsers();
        }

        public static void SelectUser(string Username, string Password)
        {
            var BLL = new WebBLL.Autentification();
            var User = BLL.GetUser(Username, Password);
            CurrentUser = User;
            CurrentUserAvatar = GetImageForUser(CurrentUser.Role);
        }

        public static string GetImageForUser(WebUsers.Roles Role)
        {
            switch (Role)
            {
                case WebUsers.Roles.User:
                    return "https://cdn1.iconfinder.com/data/icons/avatars-1-5/136/6-512.png";
                case WebUsers.Roles.Admin:
                    return "https://cdn1.iconfinder.com/data/icons/avatars-1-5/136/7-512.png";
                default:
                    return "https://cdn1.iconfinder.com/data/icons/avatars-1-5/136/84-512.png";
            }
        }


        public static void ChangeUserRole(string UserId, string NewRole)
        {
            int.TryParse(UserId, out int id);
            var Role = WebUsers.Roles.Guest;
            switch (NewRole)
            {
                case "up":
                    Role = WebUsers.Roles.Admin;
                    break;
                case "down":
                    Role = WebUsers.Roles.User;
                    break;
                default:
                    Role = WebUsers.Roles.Guest;
                    break;
            }
            var BLL = new WebBLL.Autentification();
            BLL.ChangeUserRole(id, Role);
        }
    }
}