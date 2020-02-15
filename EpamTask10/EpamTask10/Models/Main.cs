using BLLInterfaces;
using DependencyResolver;
using EpamTask10.Models.classes;
using System;
using System.Collections.Generic;

namespace EpamTask10.Models
{
    public class Main
    {
        private static string DefaultImage = "https://cdn4.iconfinder.com/data/icons/trophy-and-awards-1/64/Icon_Medal_Trophy_Awards_Red-512.png";
        private static string DefaultAvatar = "https://cdn.iconscout.com/icon/free/png-256/avatar-370-456322.png";

        public static IAwardBLL Application = Resolver.SelectAwardBLL();


        public static List<DataAward> GetAwards()
        {
            var result = new List<DataAward>();
            var Awards = Application.GetAllAwards();
            var Users = Application.GetAllAwardWeilders();

            foreach (var item in Awards)
            {
                result.Add(new DataAward()
                {
                    Id = item.Id,
                    Image = DefaultImage,
                    Title = item.Title
                });
            }
            return result;
        }

        public static List<DataUser> GetUsers()
        {
            var result = new List<DataUser>();
            var Users = Application.GetAllUsers();
            // awards = Application.GetAllAwardAtUser(item.Id)
            foreach (var item in Users)
            {
                result.Add(new DataUser()
                {
                    Id = item.Id,
                    Image = DefaultAvatar,
                    Age = item.Age,
                    Birthday = DateToString(item.BirthDay),
                    Name = item.Name
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
            var newUser = Entity.User.Parse(Application.GetAllUsers(), name, newDate);
            Application.AddUser(newUser);
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