using BLLInterfaces;
using DALInterfaces;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class WebBLL: IWebBLL
    {
        public IData<User> UserManager;
        public IData<Award> AwardManager;
        public IData<AwardWeilder> WeilderManager;
        public IData<WebUser> WebManager;
        public IData<Image> ImageManager;


        public WebBLL(IData<User> userDal, IData<Award> AwardDal, IData<AwardWeilder> WeilderDal, 
            IData<WebUser> WebDal, IData<Image> ImageDal)
        {
            UserManager = userDal;
            AwardManager = AwardDal;
            WeilderManager = WeilderDal;
            WebManager = WebDal;
            ImageManager = ImageDal;
        }

        #region get all
        public IEnumerable<Award> GetAllAwards()
        {
            return AwardManager.GetAll();
        }

        public IEnumerable<AwardWeilder> GetAllAwardWeilders()
        {
            return WeilderManager.GetAll();
        }

        public IEnumerable<Image> GetAllImages()
        {
            return ImageManager.GetAll();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return UserManager.GetAll();
        }

        public IEnumerable<WebUser> GetAllWebUsers()
        {
            return WebManager.GetAll();
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

        public IEnumerable<UserAward> GetAllWeilders()
        {
            var result = new List<UserAward>();
            var Weilders = GetAllAwardWeilders();
            var Awards = GetAllAwards();
            var Users = GetAllUsers();

            foreach (var item in Weilders)
            {
                result.Add(new UserAward() {
                    WeilderId = item.Id ,
                    Award = Awards.Where(x => x.Id==item.AwardId).FirstOrDefault(),
                    User = Users.Where(x => x.Id == item.UserId).FirstOrDefault()
                });
            }
            return result;
        }
        #endregion

        #region get

        public Image GetImageByAwardId(int Id)
        {
            return GetAllImages().Where(x => x.AwardId == Id).FirstOrDefault();
        }

        public Image GetImageByImageId(int Id)
        {
            return GetAllImages().Where(x => x.Id == Id).FirstOrDefault();
        }

        public Image GetImageByUserId(int Id)
        {
            return GetAllImages().Where(x => x.UserId == Id).FirstOrDefault();
        }

        public Image GetImageByWebUserId(int Id)
        {
            return GetAllImages().Where(x => x.WebUserId == Id).FirstOrDefault();
        }

        public Image GetDefaultImageForWebUser(WebUser.Roles Role)
        {
            switch (Role)
            {
                case WebUser.Roles.User:
                    return GetImageByImageId(2);
                case WebUser.Roles.Admin:
                    return GetImageByImageId(3);
                default:
                    return GetImageByImageId(1);
            }
        }
        public Image GetDefaultImageForAward()
        {
            return GetImageByImageId(4);
        }
        public Image GetDefaultImageForUser()
        {
            return GetImageByImageId(5);
        }

        public WebUser GetUser(int Id)
        {
            return GetAllWebUsers().Where(x => x.Id == Id).FirstOrDefault();
        }

        public WebUser GetUser(string Username, string Password)
        {
            var Users = GetAllWebUsers().Where(x => x.Password == Password);
            Users = Users.Where(x => x.Username == Username);
            return Users.FirstOrDefault();
        }
        #endregion

        #region add
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

        public string AddImage(string Path, int? WebUserId, int? UserId, int? AwardId)
        {
            Image NewImage;
            try
            {
                NewImage = Image.Parse(GetAllImages(), Path, WebUserId, UserId, AwardId);
                ImageManager.AddData(NewImage);
                return "";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        public WebUser AddUser(string Username, string Password, WebUser.Roles Role)
        {
            var User = WebUser.Parse(GetAllWebUsers() , Username, Password, Role);
            if (User != null)
            {
                WebManager.AddData(User);
            }
            return User;
        }

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
        #endregion

        #region delete
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

        public void DeleteImage(int Id)
        {
            var Images = GetAllImages().Where(x => x.Id == Id);
            foreach (var item in Images)
            {
                if (!item.IsDefault)
                {
                    ImageManager.DeleteById(Id);
                }
            }
        }

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

        public void DeleteWeilderById(int Id)
        {
            WeilderManager.DeleteById(Id);
        }
        #endregion

        public void ChangeUserRole(int UserId, WebUser.Roles NewRole)
        {
            var baseUser = GetUser(UserId);
            WebManager.DeleteById(UserId);
            baseUser.Role = NewRole;
            WebManager.AddData(baseUser);
        }

        public bool CheckPassword(string Username, string Password)
        {
            if (GetUser(Username, Password) != null)
            {
                return true;
            }
            return false;
        }
    }
}
