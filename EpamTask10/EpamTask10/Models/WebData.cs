using System.Collections.Generic;
using WebBLL;
using WebEntity;

namespace EpamTask10.Models
{
    public class WebData
    {
        public static WebUsers CurrentUser = GetUserByID(1);
        public static string CurrentUserAvatar = GetImageForWebUser(CurrentUser.Role, "");


        public static WebUsers GetUserByID(int Id)
        {
            var BLL = new Autentification();
            var User = BLL.GetUser(Id);
            return User;
        }

        public static IEnumerable<WebUsers> GetAllWebUsers()
        {
            var BLL = new Autentification();
            return BLL.GetAllUsers();
        }
        public static IEnumerable<AwardData> GetAllAwards()
        {
            var webBLL = new Main();
            var Awards = webBLL.GetAwards();
            foreach (var item in Awards)
            {
                item.Image = GetImageForAward(item.Id.ToString());
            }
            return Awards;
        }
        public static IEnumerable<UserData> GetAllUsers()
        {
            var webBLL = new Main();
            var Users = webBLL.GetUsers();
            foreach (var item in Users)
            {
                item.Image = GetImageForUser(item.Id.ToString());
            }
            return Users;
        }

        public static void SelectUser(string Username, string Password)
        {
            var BLL = new Autentification();
            var User = BLL.GetUser(Username, Password);
            CurrentUser = User;
            CurrentUserAvatar = GetImageForWebUser(CurrentUser.Role, User.Id.ToString());
        }

        public static string GetImageForUser(string UserId)
        {
            var BLL = new Gallery();
            int.TryParse(UserId, out int Id);
            var result = BLL.GetImageByUserId(Id);
            if (result == null)
            {
                return BLL.GetImageByImageId(5).Image;
            }
            else
            {
                return result.Image;
            }
        }
        public static string GetImageForAward(string AwardId)
        {
            var BLL = new Gallery();
            int.TryParse(AwardId, out int Id);
            var result = BLL.GetImageByAwardId(Id);
            if (result == null)
            {
                return BLL.GetImageByImageId(4).Image;
            }
            else
            {
                return result.Image;
            }
        }
        public static string GetImageForWebUser(WebUsers.Roles Role, string WebUserId)
        {
            var BLL = new Gallery();
            int.TryParse(WebUserId, out int Id);
            var result = BLL.GetImageByWebUserId(Id);
            if (result == null)
            {
                return GetDefaultImageForWebUser(Role);
            }
            else
            {
                return result.Image;
            }
        }
        public static string GetDefaultImageForWebUser(WebUsers.Roles Role)
        {
            var BLL = new Gallery();
            switch (Role)
            {
                case WebUsers.Roles.User:
                    return BLL.GetImageByImageId(2).Image;
                case WebUsers.Roles.Admin:
                    return BLL.GetImageByImageId(3).Image;
                default:
                    return BLL.GetImageByImageId(1).Image;
            }
        }
        
        public static void ChangeImage(string Path, int? WebUserId, int? UserId, int? AwardId)
        {
            var BLL = new Gallery();
            Images image;
            if (!UserId.HasValue && !AwardId.HasValue)
            {
                return;
            }
            if (UserId.HasValue)
            {
                image = BLL.GetImageByUserId(UserId.Value);
                if (image!=null)
                {
                    BLL.DeleteImage(image.Id);
                }
            }
            if (AwardId.HasValue)
            {
                image = BLL.GetImageByAwardId(AwardId.Value);
                if (image != null)
                {
                    BLL.DeleteImage(image.Id);
                }
            }
            BLL.AddImage(Path, WebUserId, UserId, AwardId);
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
            var BLL = new Autentification();
            BLL.ChangeUserRole(id, Role);
        }


        public static void AddUser(string Name, string Date)
        {
            var webBLL = new Main();
            webBLL.AddUser(Name, Date);
        }
        public static void DeleteUser(string id)
        {
            var webBLL = new Main();
            webBLL.DeleteUser(id);
        }
        public static UserData GetUser(string id)
        {
            var webBLL = new Main();
            var user = webBLL.GetUser(id);
            user.Image = GetImageForUser(user.Id.ToString());
            return user;
        }
        public static void EditUser(string id, string Date, string Name)
        {
            var webBLL = new Main();
            webBLL.EditUser(id, Date, Name);
        }

        public static void AddAward(string Title)
        {
            var webBLL = new Main();
            webBLL.AddAward(Title);
        }
        public static void DeleteAward(string id)
        {
            var webBLL = new Main();
            webBLL.DeleteAward(id);
        }
        public static AwardData GetAward(string id)
        {
            var webBLL = new Main();
            var award = webBLL.GetAward(id);
            award.Image = GetImageForAward(award.Id.ToString());
            return award;
        }
        public static void EditAward(string id, string Title)
        {
            var webBLL = new Main();
            webBLL.EditAward(id, Title);
        }


        public static void DeleteAwardWeilder(int AwardId, int UserId)
        {
            var webBLL = new Main();
            webBLL.DeleteAwardWeilder(AwardId, UserId);
        }
        public static void AddAwardWeilder(int AwardId, int UserId)
        {
            var webBLL = new Main();
            webBLL.AddAwardWeilder(AwardId, UserId);
        }
    }
}