using Entities;
using System.Collections.Generic;
using System.Linq;
using Task6.BLL.Interface;

namespace Task6.BLL
{
    public class UserLogic : ILogic<User>
    {
        private DAL.Interface.IData<User> Data;
        private DAL.Interface.Serializer<User> Serializer;

        public UserLogic()
        {
            Data = new DAL.UserData();
            Serializer = new DAL.UserData();
            Serializer.OpenOrCreateFile(PathData.User);
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
    }
}