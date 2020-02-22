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
        public static WebUser CurrentUser = SelectUser("Guest", "1234567890");
        public static string CurrentUserAvatar = GetImageForWebUser(CurrentUser);

        private static IWebBLL Connect()
        {
            return Resolver.SelectWebBLL();
        }


        public static bool CheckPassword(string username, string password)
        {
            return Connect().LogInCheck(username, password);
        }
        public static WebUser SelectUser(string Username, string Password)
        {
            var User = Connect().GetWebUser(Username, Password);
            CurrentUser = User;
            CurrentUserAvatar = Connect().GetImage(CurrentUser.Role.Id_Image).Path;
            return User;
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

        #region get
        public static string GetImageForWebUser(WebUser user)
        {
            return Connect().GetImage(user.Role.Id_Image).Path;
        }

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

        public static Role GetRole(string result)
        {
            if (result == "on")
            {
                return Connect().GetAllRoles().ToList()[2];
            }
            return Connect().GetAllRoles().ToList()[1];
        }
        public static WebUser GetUserByID(int Id)
        {
            return Connect().GetWebUser(Id);
        }
        public static WebUser GetUserByID(string Id)
        {
            int.TryParse(Id, out int ID);
            return GetUserByID(ID);
        }

        public static Image GetImageForUser(User user)
        {
            return Connect().GetImageForUser(user);
        }
        public static Image GetImageForAward(Award award)
        {
            return Connect().GetImageForAward(award);
        }
        #endregion

        #region add        
        public static string AddUser(string Username, string Password, Role Role)
        {
            try
            {
                Connect().AddWebUser(Username, Password, Role);
            }
            catch (ArgumentException e)
            {

                return e.Message;
            }
            return "";
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
                NewUser.Icon = new Image();
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
            Connect().AddUser(NewUser);
            return "";
        }
        #endregion

        #region edit
        public static void EditAward(string id, string Title)
        {
            int.TryParse(id, out int ID);
            EditAward(ID, Title);
        }
        public static void EditUserRole(string UserId, string NewRole)
        {
            int.TryParse(UserId, out int Id);
            EditUserRole(Id, NewRole);
        }
        public static void EditUser(string Id, string Date, string Name)
        {
            int.TryParse(Id, out int ID);
            EditUser(ID, Date, Name);
        }

        public static void EditUserRole(int UserId, string NewRole)
        {
            var User = Connect().GetWebUser(UserId);
            User.Role = (NewRole == "up") ? Connect().GetAllRoles().ToList()[2] : Connect().GetAllRoles().ToList()[1];
            Connect().EditWebUser(User);
        }
        public static void EditImage(string Path, int? UserId, int? AwardId)
        {
            var newImage = Image.Parse(Connect().GetAllImages(), Path);
            Connect().AddImage(newImage);
            newImage = Connect().GetAllImages().Last();

            Connect().EditImage(newImage, UserId, AwardId);
        }

        public static void EditAward(int id, string Title)
        {
            var BaseAward = Connect().GetAward(id);
            if (BaseAward.Title != Title)
            {
                BaseAward.Title = Title;
            }
            Connect().EditAward(BaseAward);
        }
        public static void EditUser(int Id, string Date, string Name)
        {
            var BaseUser = Connect().GetUser(Id);
            if (Date.Length > 0)
            {
                BaseUser.BirthDay = StringToDate(Date);
            }
            if (BaseUser.Name != Name)
            {
                BaseUser.Name = Name;
            }
            Connect().EditUser(BaseUser);
        }
        #endregion

        #region delete
        public static void DeleteUser(string id)
        {
            int.TryParse(id, out int ID);
            Connect().DeleteUser(ID);
        }
        public static void DeleteUser(int id)
        {
            Connect().DeleteUser(id);
        }

        public static void DeleteAward(string id)
        {
            int.TryParse(id, out int ID);
            DeleteAward(ID);
        }
        public static void DeleteAward(int id)
        {
            Connect().DeleteAward(id);
        }

        public static void DeleteAwardWeilder(int AwardId, int UserId)
        {
            var targets = Connect().GetAllAwardWeilders().Where(x => x.UserId == UserId);
            var target = targets.Where(x => x.AwardId == AwardId).FirstOrDefault();
            if (target != null)
            {
                Connect().DeleteWeilder(target.Id);
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
    }
}