using System.Collections.Generic;
using BLLInterfaces;
using DALInterfaces;
using Entity;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        public IData<User> Manager;

        public UserBLL(IData<User> DALManager)
        {
            Manager = DALManager;
        }


        public IEnumerable<User> GetAll()
        {
            return Manager.GetAll();
        }

        public void AddData(User data)
        {
            Manager.AddData(data);
        }

        public void DeleteById(int Id)
        {
            Manager.Delete(Id);
        }
    }
}
