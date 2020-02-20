using BLLInterfaces;
using DependencyResolver;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamTask10.Models
{
    public class WebData
    {
        public static WebUser CurrentUser = GetUserByID(1);
        public static string CurrentUserAvatar = GetImageForWebUser(CurrentUser.Role, CurrentUser.Id).Path;

        private static IWebBLL Connect()
        {
            return Resolver.SelectWebBLLjson();
        }


        public static bool CheckPassword(string username, string password)
        {
            return Connect().CheckPassword(username, password);
        }
        public static void SelectUser(string Username, string Password)
        {
            var User = Connect().GetUser(Username, Password);
            CurrentUser = User;
            CurrentUserAvatar = GetImageForWebUser(CurrentUser.Role, User.Id).Path;
        }
        private static AwardWeilder ParseToAwardWeilder(int AwardId, int UserId)
        {
            var Weilder = new AwardWeilder
            {
                AwardId = AwardId,
                UserId = UserId
            };
            Weilder.Id = Weilder.GetNewId(Connect().GetAllAwardWeilders());
            return Weilder;
        }

        #region add
        public static void AddUser(string Username, string Password, WebUser.Roles Role)
        {
            Connect().AddUser(Username, Password, Role);
        }
        public static void AddAward(string Title)
        {
            var all = Connect().GetAllAwards();
            Connect().AddAward(Award.Parse(all, Title));
        }
        public static void AddAwardWeilder(int AwardId, int UserId)
        {
            var weilder = ParseToAwardWeilder(AwardId, UserId);
            Connect().AddAwardWeilder(weilder);
        }
        public static string AddUser(string Name, string Date)
        {
            User NewUser;
            try
            {
                NewUser = User.Parse(GetAllUsers(), Name, StringToDate(Date));
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
            Connect().AddUser(NewUser);
            return "";
        }
        #endregion

        #region get
        public static IEnumerable<Award> GetAllAwards()
        {
            return Connect().GetAllAwards();
        }
        public static IEnumerable<User> GetAllUsers()
        {
            return Connect().GetAllUsers();
        }
        public static IEnumerable<WebUser> GetAllWebUsers()
        {
            return Connect().GetAllWebUsers();
        }
        public static IEnumerable<Award> GetAllGetAllAwardAtUser(int UserId)
        {
            return Connect().GetAllAwardAtUser(UserId);
        }
        public static IEnumerable<User> GetAllUsersWithAward(int AwardId)
        {
            return Connect().GetAllUsersWithAward(AwardId);
        }
        public static IEnumerable<UserAward> GetAllWeilders()
        {
            return Connect().GetAllWeilders();
        }

        public static User GetUser(int id)
        {
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }
        public static User GetUser(string id)
        {
            int.TryParse(id, out int ID);
            return GetUser(ID);
        }

        public static Award GetAward(string id)
        {
            int.TryParse(id, out int ID);
            return GetAward(ID);
        }
        public static Award GetAward(int id)
        {
            return GetAllAwards().Where(x => x.Id == id).FirstOrDefault();
        }

        public static WebUser.Roles GetRole(string result)
        {
            if (result == "on")
            {
                return WebUser.Roles.Admin;
            }
            return WebUser.Roles.User;
        }
        public static WebUser GetUserByID(int Id)
        {
            return Connect().GetUser(Id);
        }
        public static WebUser GetUserByID(string Id)
        {
            int.TryParse(Id, out int ID);
            return GetUserByID(ID);
        }

        public static Image GetImageForWebUser(WebUser.Roles Role, int WebUserId)
        {
            var result = Connect().GetImageByWebUserId(WebUserId);
            if (result == null)
            {
                return Connect().GetDefaultImageForWebUser(Role);
            }
            return result;
        }
        public static Image GetImageForUser(int UserId)
        {
            var result = Connect().GetImageByUserId(UserId);
            if (result == null)
            {
                return Connect().GetDefaultImageForUser();
            }
            return result;
        }
        public static Image GetImageForAward(int AwardId)
        {
            var result = Connect().GetImageByAwardId(AwardId);
            if (result == null)
            {
                return Connect().GetDefaultImageForAward();
            }
            return result;
        }
        #endregion

        #region edit
        public static void EditUserRole(string UserId, string NewRole)
        {
            int.TryParse(UserId, out int Id);
            EditUserRole(Id, NewRole);
        }
        public static void EditUserRole(int UserId, string NewRole)
        {
            var Role = WebUser.Roles.Guest;
            switch (NewRole)
            {
                case "up":
                    Role = WebUser.Roles.Admin;
                    break;
                case "down":
                    Role = WebUser.Roles.User;
                    break;
                default:
                    Role = WebUser.Roles.Guest;
                    break;
            }
            Connect().ChangeUserRole(UserId, Role);
        }
        public static void EditImage(string Path, int? WebUserId, int? UserId, int? AwardId)
        {
            Image image;
            if (!UserId.HasValue && !AwardId.HasValue)
            {
                return;
            }
            if (UserId.HasValue)
            {
                image = Connect().GetImageByUserId(UserId.Value);
                if (image != null)
                {
                    Connect().DeleteImage(image.Id);
                }
            }
            if (AwardId.HasValue)
            {
                image = Connect().GetImageByAwardId(AwardId.Value);
                if (image != null)
                {
                    Connect().DeleteImage(image.Id);
                }
            }
            Connect().AddImage(Path, WebUserId, UserId, AwardId);
        }

        public static void EditAward(string id, string Title)
        {
            int.TryParse(id, out int ID);
            EditAward(ID, Title);
        }
        public static void EditAward(int id, string Title)
        {
            var BaseAward = GetAward(id);
            var ConnectionUser = Connect().GetAllAwardWeilders();

            if (Title != BaseAward.Title && Title.Length > 3)
            {
                BaseAward.Title = Title;
                DeleteAward(id);

                Connect().AddAward(BaseAward);
                foreach (var item in ConnectionUser)
                {
                    if (item.AwardId == id)
                    {
                        Connect().AddAwardWeilder(item);
                    }
                }
            }
        }

        public static void EditUser(string Id, string Date, string Name)
        {
            int.TryParse(Id, out int ID);
            EditUser(ID, Date, Name);
        }
        public static void EditUser(int Id, string Date, string Name)
        {
            var BaseUser = GetAllUsers().Where(x => x.Id == Id).FirstOrDefault();
            if (BaseUser != null)
            {
                if (Name.Length > 3)
                {
                    BaseUser.Name = Name;
                }
                if (Date.Length == 10)
                {
                    BaseUser.BirthDay = StringToDate(Date);
                    //Date = DateToString(BaseUser.BirthDay);
                }

                //var EditedUser = User.Parse(Connect().GetAllUsers(), Name, StringToDate(Date));
                //EditedUser.Id = Id;
                DeleteUser(Id);

                var ConnectionAward = Connect().GetAllAwardWeilders();
                Connect().AddUser(BaseUser);
                foreach (var item in ConnectionAward)
                {
                    if (item.UserId == Id)
                    {
                        Connect().AddAwardWeilder(item);
                    }
                }
            }
        }
        #endregion

        #region delete
        public static void DeleteUser(string id)
        {
            int.TryParse(id, out int ID);
            Connect().DeleteUserById(ID);
        }
        public static void DeleteUser(int id)
        {
            Connect().DeleteUserById(id);
        }

        public static void DeleteAward(string id)
        {
            int.TryParse(id, out int ID);
            DeleteAward(ID);
        }
        public static void DeleteAward(int id)
        {
            Connect().DeleteAwardById(id);
        }

        public static void DeleteAwardWeilder(int AwardId, int UserId)
        {
            var targets = Connect().GetAllAwardWeilders().Where(x => x.UserId==UserId);
            var target = targets.Where(x => x.AwardId == AwardId).FirstOrDefault();
            if (target != null)
            {
                Connect().DeleteWeilderById(target.Id);
            }
        }
        #endregion

        private static DateTime StringToDate(string str)
        {
            var Date = str.Split('-');
            var DateInt = new int[3];
            for (int i = 0; i < Date.Length; i++)
            {
                int.TryParse(Date[i], out DateInt[i]);
            }
            var newDate = new DateTime(DateInt[0], DateInt[1], DateInt[2]);
            return newDate;
        }
        public static string DateToString(DateTime date)
        {
            return date.ToString().Remove(10);
        }
    }
}