using System.Collections.Generic;
using BLLInterfaces;
using DALInterfaces;
using Entity;
using System.Linq;

namespace BLL
{
    public class AwardBLL : IAwardBLL
    {
        public IData<User> UserManager;
        public IData<Award> AwardManager;
        public IData<AwardWeilder> WeilderManager;


        public AwardBLL(IData<User> UserDAL, IData<Award> AwardDAL, IData<AwardWeilder> WeilderDAL)
        {
            UserManager = UserDAL;
            AwardManager = AwardDAL;
            WeilderManager = WeilderDAL;
        }


        #region get
        public IEnumerable<User> GetAllUsers()
        {
            return UserManager.GetAll();
        }

        public IEnumerable<Award> GetAllAwards()
        {
            return AwardManager.GetAll();
        }

        public IEnumerable<AwardWeilder> GetAllAwardWeilders()
        {
            return WeilderManager.GetAll();
        }

        public IEnumerable<User> GetAllUsersWithAward(int AwardId)
        {
            var HaveAward = new List<User>();
            User SomeUser;
            var Users = UserManager.GetAll();
            var Weilders = WeilderManager.GetAll();

            foreach (var item in Weilders)
            {
                if (item.AwardId.Equals(AwardId))
                {
                    SomeUser = Users.First(x => x.Id.Equals(item.UserId));
                    HaveAward.Add(SomeUser);
                }
            }
            return HaveAward;
        }

        public IEnumerable<Award> GetAllAwardAtUser(int UserId)
        {
            var HaveAward = new List<Award>();
            Award SomeAward;
            var Awards = AwardManager.GetAll();
            var Weilders = WeilderManager.GetAll();

            foreach (var item in Weilders)
            {
                if (item.UserId.Equals(UserId))
                {
                    SomeAward = Awards.First(x => x.Id.Equals(item.AwardId));
                    HaveAward.Add(SomeAward);
                }
            }
            return HaveAward;
        }
        #endregion

        #region add
        public void AddUser(User data)
        {
            UserManager.AddData(data);
        }

        public void AddUser(User user, params Award[] Awards)
        {
            var WeilderInfo = new AwardWeilder();
            WeilderInfo.UserId = user.Id;

            AddUser(user);
            foreach (var item in Awards)
            {
                WeilderInfo.AwardId = item.Id;
                WeilderInfo.Id = WeilderInfo.GetNewId(WeilderManager.GetAll());

                AddAwardWeilder(WeilderInfo);
            }
        }

        public void AddAward(Award data)
        {
            AwardManager.AddData(data);
        }

        public void AddAward(Award award, params User[] Users)
        {
            var WeilderInfo = new AwardWeilder();
            WeilderInfo.AwardId = award.Id;

            AddAward(award);
            foreach (var item in Users)
            {
                WeilderInfo.UserId = item.Id;
                WeilderInfo.Id = WeilderInfo.GetNewId(WeilderManager.GetAll());

                AddAwardWeilder(WeilderInfo);
            }
        }

        public void AddAwardWeilder(AwardWeilder data)
        {
            WeilderManager.AddData(data);
        }
        #endregion

        #region delete
        public void DeleteUserById(int Id)
        {
            var Weilders = WeilderManager.GetAll().ToList();
            Weilders = Weilders.FindAll(x => x.UserId.Equals(Id));

            foreach (var item in Weilders)
            {
                WeilderManager.DeleteById(item.Id);
            }
            UserManager.DeleteById(Id);
        }

        public void DeleteAwardById(int Id)
        {
            var Weilders = WeilderManager.GetAll().ToList();
            Weilders = Weilders.FindAll(x => x.AwardId.Equals(Id));

            foreach (var item in Weilders)
            {
                WeilderManager.DeleteById(item.Id);
            }
            AwardManager.DeleteById(Id);
        }

        public void DeleteWeilderById(int Id)
        {
            WeilderManager.DeleteById(Id);
        }
        #endregion
    }
}
