using BLLInterfaces;
using DependencyResolver;
using Entity;
using System;
using System.Collections.Generic;
using WebEntity;

namespace WebBLL
{
    public class Main
    {
        public IAwardBLL Application;

        public Main()
        {
            Application = Resolver.SelectAwardBLL();
        }

        public List<AwardData> GetAwards()
        {
            var result = new List<AwardData>();
            var Awards = Application.GetAllAwards();
            foreach (var item in Awards)
            {
                result.Add(new AwardData()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Users = Application.GetAllUsersWithAward(item.Id)
                });
            }
            return result;
        }
        public string AddAward(string title)
        {
            if (title != null)
            {
                var newAward = Entity.Award.Parse(Application.GetAllAwards(), title);
                Application.AddAward(newAward);
            }
            return title;
        }
        public AwardData GetAward(string Id)
        {
            int.TryParse(Id, out int num);
            var awards = GetAwards();
            return awards.Find(x => x.Id == num);
        }
        public void DeleteAward(string Id)
        {
            int.TryParse(Id, out int num);
            Application.DeleteAwardById(num);
        }
        private Award GetAwardById(int Id)
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
        public void EditAward(string Id, string Title)
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


        public List<UserData> GetUsers()
        {
            var result = new List<UserData>();
            var Users = Application.GetAllUsers();
            var a = new List<Award>();

            foreach (var item in Users)
            {
                result.Add(new UserData()
                {
                    Id = item.Id,
                    Age = item.Age,
                    Birthday = DateToString(item.BirthDay),
                    Name = item.Name,
                    Awards = Application.GetAllAwardAtUser(item.Id)
                });
            }
            return result;
        }
        public void AddUser(string name, string date)
        {
            var newDate = StringToDate(date);
            var newUser = User.Parse(Application.GetAllUsers(), name, newDate);
            Application.AddUser(newUser);
        }
        public UserData GetUser(string Id)
        {
            int.TryParse(Id, out int num);
            var users = GetUsers();
            return users.Find(x => x.Id == num);
        }
        public void DeleteUser(string Id)
        {
            int.TryParse(Id, out int num);
            Application.DeleteUserById(num);
        }
        private User GetUserById(int Id)
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
        public void EditUser(string Id, string Date, string Name)
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


        public void AddAwardWeilder(int AwardId, int UserId)
        {
            var Connection = ParseToAwardWeilder(AwardId, UserId);
            Application.AddAwardWeilder(Connection);
        }
        private AwardWeilder ParseToAwardWeilder(int AwardId, int UserId)
        {
            var a = new AwardWeilder
            {
                AwardId = AwardId,
                UserId = UserId
            };
            a.Id = a.GetNewId(Application.GetAllAwardWeilders());
            return a;
        }
        public void DeleteAwardWeilder(int AwardId, int UserId)
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

        

        public string DateToString(DateTime date)
        {
            var str = date.ToString();
            str = str.Remove(10);
            return str;
        }

        public DateTime StringToDate(string str)
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
