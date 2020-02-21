using System.Collections.Generic;
using Entity;

namespace BLLInterfaces
{
    public interface IAwardBLL
    {
        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();

        IEnumerable<AwardWeilder> GetAllAwardWeilders();

        IEnumerable<User> GetAllUsersWithAward(int AwardId);

        IEnumerable<Award> GetAllAwardAtUser(int UserId);


        void AddUser(User data);
        void AddUser(User user, params Award[] Awards);

        void AddAward(Award data);
        void AddAward(Award award, params User[] Users);

        void AddAwardWeilder(AwardWeilder data);


        void DeleteUser(int Id);

        void DeleteAward(int Id);

        void DeleteWeilder(int Id);

    }
}
