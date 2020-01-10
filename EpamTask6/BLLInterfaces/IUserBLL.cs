using System.Collections.Generic;
using Entity;

namespace BLLInterfaces
{
    public interface IUserBLL
    {
        IEnumerable<User> GetAll();

        void AddData(User data);

        void DeleteById(int Id);
    }
}
