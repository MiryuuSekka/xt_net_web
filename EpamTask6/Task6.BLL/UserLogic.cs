using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Task6.BLL.Interface;

namespace Task6.BLL
{
    public class UserLogic : ILogic<User>
    {
        private DAL.UserData Data;

        public UserLogic()
        {
            Data = new DAL.UserData();
        }


        public void AddData(User data)
        {
            Data.AddData(data);
        }

        public void DeleteById(int Id)
        {
            Data.DeleteById(Id);
        }

        public IEnumerable<User> GetAll()
        {
            return Data.GetAll();
        }

        public User GetByID(int Id)
        {
            var data = Data.GetAll();
            return data.First(x => x.Id.Equals(Id));
        }


        public User TryParseToUser(string Name, string Date)
        {
            User NewUser = new User();
            if (Name.Length < 2)
            {
                throw new ArgumentException("Wrong Name");
            }
            DateTime.TryParse(Date, out DateTime NewDate);

            var b = DateTime.Now - NewDate;
            if (b.Days / 355.25 > 150 || b.Days / 355.25 < 1)
            {
                throw new ArgumentException("Wrong date");
            }
            NewUser.Name = Name;
            NewUser.BirthDay = NewDate;
            NewUser.Age = (int)(b.Days / 355.25);

            return NewUser;
        }

        internal int GetNewId()
        {
            var data = GetAll().ToList();
            int NewId = 0;
            bool Search = false;

            //
            return NewId;
        }
    }
}