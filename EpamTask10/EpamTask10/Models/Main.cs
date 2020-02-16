using BLLInterfaces;
using DependencyResolver;
using Entity;
using EpamTask10.Models.classes;
using System;
using System.Collections.Generic;

namespace EpamTask10.Models
{
    public class Main
    {
        public static IAwardBLL Application = Resolver.SelectAwardBLL();

        private static string DefaultImage = "https://cdn4.iconfinder.com/data/icons/trophy-and-awards-1/64/Icon_Medal_Trophy_Awards_Red-512.png";
        private static string DefaultAvatar = "https://cdn.iconscout.com/icon/free/png-256/avatar-370-456322.png";

        public static List<DataAward> GetAwards()
        {
            var result = new List<DataAward>();
            var Awards = Application.GetAllAwards();
            foreach (var item in Awards)
            {
                result.Add(new DataAward()
                {
                    Id = item.Id,
                    Image = DefaultImage,
                    Title = item.Title,
                    Users = Application.GetAllUsersWithAward(item.Id)
                });
            }
            return result;
        }

        public static List<DataUser> GetUsers()
        {
            var result = new List<DataUser>();
            var Users = Application.GetAllUsers();
            var a = new List<Award>();

            foreach (var item in Users)
            {
                result.Add(new DataUser()
                {
                    Id = item.Id,
                    Image = DefaultAvatar,
                    Age = item.Age,
                    Birthday = DateToString(item.BirthDay),
                    Name = item.Name,
                    Awards = Application.GetAllAwardAtUser(item.Id)
            });
            }
            return result;
        }


        public static string AddAward(string title)
        {
            if (title != null)
            {
                var newAward = Entity.Award.Parse(Application.GetAllAwards(), title);
                Application.AddAward(newAward);
            }
            return title;
        }

        public static void AddUser(string name, string date)
        {
            var newDate = StringToDate(date);
            var newUser = User.Parse(Application.GetAllUsers(), name, newDate);
            Application.AddUser(newUser);
        }

        public static void AddAwardWeilder(int AwardId, int UserId)
        {
            var Connection = ParseToAwardWeilder(AwardId, UserId);
            Application.AddAwardWeilder(Connection);
        }


        public static DataAward GetAward(string Id)
        {
            int.TryParse(Id, out int num);
            var awards = GetAwards();
            return awards.Find(x => x.Id == num);
        }

        public static DataUser GetUser(string Id)
        {
            int.TryParse(Id, out int num);
            var users = GetUsers();
            return users.Find(x => x.Id == num);
        }


        public static void DeleteUser(string Id)
        {
            int.TryParse(Id, out int num);
            Application.DeleteUserById(num);
        }

        public static void DeleteAward(string Id)
        {
            int.TryParse(Id, out int num);
            Application.DeleteAwardById(num);
        }

        public static void DeleteAwardWeilder(int AwardId, int UserId)
        {
            var Connections = Application.GetAllAwardWeilders();
            foreach (var item in Connections)
            {
                if (item.AwardId == AwardId && item.UserId == UserId)
                {
                    Application.DeleteWeilderById(item.Id);
                }
            }
        }

        private static Award GetAwardById(int Id)
        {
            var awards = Application.GetAllAwards();
            foreach (var item in awards)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }
            return null;
        }

        private static User GetUserById(int Id)
        {
            var users = Application.GetAllUsers();
            foreach (var item in users)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }
            return null;
        }

        public static void EditUser(string Id, string Date, string Name)
        {
            int.TryParse(Id, out int UserId);
            var ConnectionAward = Application.GetAllAwardWeilders();

            var BaseUser = GetUserById(UserId);
            if (Name.Length < 4)
            {
                Name = BaseUser.Name;
            }
            if (Date.Length < 10)
            {
                Date = DateToString(BaseUser.BirthDay);
            }

            var EditedUser = User.Parse(Application.GetAllUsers(), Name, StringToDate(Date));
            EditedUser.Id = UserId;
            DeleteUser(Id.ToString());

            Application.AddUser(EditedUser);
            foreach (var item in ConnectionAward)
            {
                if (item.UserId == UserId)
                {
                    Application.AddAwardWeilder(item);
                }
            }
        }

        public static void EditAward(string Id, string Title)
        {
            int.TryParse(Id, out int AwardId);
            var ConnectionUser = Application.GetAllAwardWeilders();
            var BaseAward = GetAwardById(AwardId);

            if (Title != BaseAward.Title && Title.Length > 3)
            {
                BaseAward.Title = Title;
                DeleteAward(Id.ToString());

                Application.AddAward(BaseAward);
                foreach (var item in ConnectionUser)
                {
                    if (item.AwardId == AwardId)
                    {
                        Application.AddAwardWeilder(item);
                    }
                }
            }
        }


        private static AwardWeilder ParseToAwardWeilder(int AwardId, int UserId)
        {
            var a = new AwardWeilder
            {
                AwardId = AwardId,
                UserId = UserId
            };
            a.Id = a.GetNewId(Application.GetAllAwardWeilders());
            return a;
        }

        public static string DateToString(DateTime date)
        {
            var str = date.ToString();
            str = str.Remove(10);
            return str;
        }

        public static DateTime StringToDate(string str)
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