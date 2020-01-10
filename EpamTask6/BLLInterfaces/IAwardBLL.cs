using System.Collections.Generic;
using Entity;

namespace BLLInterfaces
{
    public interface IAwardBLL
    {
        IEnumerable<User> GetAllUsers();

        IEnumerable<Award> GetAllAwards();

        IEnumerable<AwardWeilder> GetAllAwardWeilders();


        void AddUser(User data);

        void AddAward(Award data);

        void AddAwardWeilder(AwardWeilder data);


        void DeleteUserById(int Id);

        void DeleteAwardById(int Id);

        void DeleteWeilderById(int Id);


        List<User> GetAllUsersWithAward(int AwardId);

        List<Award> GetAllAwardAtUser(int UserId);

        void AddUser(User user, params Award[] Awards);

        void AddAward(Award award, params User[] Users);
    }
}
