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
        public IData<Role> RoleManager;


        public WebBLL(IData<User> userDal, IData<Award> AwardDal, IData<AwardWeilder> WeilderDal, 
            IData<WebUser> WebDal, IData<Image> ImageDal, IData<Role> RoleDal)
        {
            UserManager = userDal;
            AwardManager = AwardDal;
            WeilderManager = WeilderDal;
            WebManager = WebDal;
            ImageManager = ImageDal;
            RoleManager = RoleDal;

            FullfillDB();
        }
        
        private void FullfillDB()
        {
            var Images = GetAllImages();
            var Roles = GetAllRoles();
            var Awards = GetAllAwards();
            var Users = GetAllUsers();
            var WebUsers = GetAllWebUsers();

            if (Images.Count() == 0)
            {
                AddImage(new Image() { Id = 1, IsDefault = true, Path = @"https://cdn1.iconfinder.com/data/icons/avatars-1-5/136/84-512.png" });
                AddImage(new Image() { Id = 2, IsDefault = true, Path = @"https://cdn1.iconfinder.com/data/icons/avatars-1-5/136/6-512.png" });
                AddImage(new Image() { Id = 3, IsDefault = true, Path = @"https://cdn1.iconfinder.com/data/icons/avatars-1-5/136/7-512.png" });
                AddImage(new Image() { Id = 4, IsDefault = true, Path = @"https://cdn4.iconfinder.com/data/icons/trophy-and-awards-1/64/Icon_Medal_Trophy_Awards_Red-512.png" });
                AddImage(new Image() { Id = 5, IsDefault = true, Path = @"https://cdn.iconscout.com/icon/free/png-256/avatar-370-456322.png" });
            }
            if (Roles.Count() == 0)
            {
                AddRole(new Role() { Id = 1, Id_Image = Images.ToList()[0].Id, Title = "Guest" });
                AddRole(new Role() { Id = 2, Id_Image = Images.ToList()[1].Id, Title = "User" });
                AddRole(new Role() { Id = 3, Id_Image = Images.ToList()[2].Id, Title = "Admin" });
            }
            if (Awards.Count() == 0)
            {
                AddAward(new Award() { Id = 1, Title = "Good award", Icon = Images.ToList()[3] });
            }
            if (Users.Count() == 0)
            {
                AddUser(new User() { Id = 1, Icon = Images.ToList()[4], Name = "Cat", Age = 0, BirthDay = DateTime.Now });
            }
            if (WebUsers.Count() == 0)
            {
                AddWebUser(new WebUser() { Id = 1, Role = Roles.ToList()[0], Password = "1234567890", Username = "Guest" });
                AddWebUser(new WebUser() { Id = 2, Role = Roles.ToList()[1], Password = "user", Username = "User" });
                AddWebUser(new WebUser() { Id = 3, Role = Roles.ToList()[2], Password = "admin", Username = "Admin" });
            }
        }

        #region get
        public IEnumerable<Image> GetAllImages()
        {
            return ImageManager.GetAll();
        }
        public Image GetImage(int Id)
        {
            return GetAllImages().Where(x => x.Id == Id).FirstOrDefault();
        }
        public Image GetImageForUser(User user)
        {
            var Image = new Image();
            if (user.Icon!=null)
            {
                Image = GetImage(user.Icon.Id);
            }
            if (Image == null)
            {
                var img = GetAllImages().ToList();
                Image = img[4];
            }
            return Image;
        }
        public Image GetImageForAward(Award award)
        {
            var Image = new Image();
            if (award.Icon != null)
            {
                Image = GetImage(award.Icon.Id);
            }
            if (Image == null)
            {
                var img = GetAllImages().ToList();
                Image = img[3];
            }
            return Image;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return RoleManager.GetAll();
        }
        public Role GetRole(int Id)
        {
            return GetAllRoles().Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<WebUser> GetAllWebUsers()
        {
            var Users = WebManager.GetAll();
            foreach (var item in Users)
            {
                item.Role = GetRole(item.Role.Id);
            }
            return Users;
        }
        public WebUser GetWebUser(int Id)
        {
            var User = GetAllWebUsers().Where(x => x.Id == Id).FirstOrDefault();
            if (User!=null)
            {
                User.Role = GetRole(User.Role.Id);
            }
            return User;
        }
        public WebUser GetWebUser(string Username, string Password)
        {
            var Users = GetAllWebUsers();
            Users = Users.Where(x => x.Password == Password);
            Users = Users.Where(x => x.Username == Username);
            var User = Users.FirstOrDefault();
            if (User != null)
            {
                User.Role = GetRole(User.Role.Id);
            }
            return User;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var Users = UserManager.GetAll();
            foreach (var item in Users)
            {
                item.Icon = GetImageForUser(item);
            }
            return Users;
        }
        public User GetUser(int Id)
        {
            return GetAllUsers().Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Award> GetAllAwards()
        {
            var Awards = AwardManager.GetAll();
            foreach (var item in Awards)
            {
                item.Icon = GetImageForAward(item);
            }
            return Awards;
        }
        public Award GetAward(int Id)
        {
            return GetAllAwards().Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<AwardWeilder> GetAllAwardWeilders()
        {
            return WeilderManager.GetAll();
        }
        public IEnumerable<UserAward> GetAllWeilders()
        {
            var result = new List<UserAward>();
            var Weilders = GetAllAwardWeilders();
            var Awards = GetAllAwards();
            var Users = GetAllUsers();

            foreach (var item in Weilders)
            {
                result.Add(new UserAward()
                {
                    WeilderId = item.Id,
                    Award = Awards.Where(x => x.Id == item.AwardId).FirstOrDefault(),
                    User = Users.Where(x => x.Id == item.UserId).FirstOrDefault()
                });
            }
            return result;
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
        #endregion

        #region add
        public void AddRole(Role data)
        {
            RoleManager.AddData(data);
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

        public void AddAwardWeilder(AwardWeilder data)
        {
            WeilderManager.AddData(data);
        }

        public void AddImage(Image data)
        {
            ImageManager.AddData(data);
        }
        public string AddImage(string Path, int? UserId, int? AwardId)
        {
            Image NewImage;
            try
            {
                NewImage = Image.Parse(GetAllImages(), Path);
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
            NewImage = GetAllImages().Last();//ImageManager.AddData(NewImage);
            
            if (UserId.HasValue)
            {
                var User = GetUser(UserId.Value);
                User.Icon = NewImage;
                EditUser(User);
            }
            if (AwardId.HasValue)
            {
                var Award = GetAward(AwardId.Value);
                Award.Icon = NewImage;
                EditAward(Award);
            }
            return "";
        }

        public WebUser AddWebUser(string Username, string Password, Role Role)
        {
            var User = WebUser.Parse(GetAllWebUsers() , Username, Password, Role);
            if (User != null)
            {
                WebManager.AddData(User);
            }
            return User;
        }
        public void AddWebUser(WebUser data)
        {
            WebManager.AddData(data);
        }
        #endregion

        #region delete
        public void DeleteUser(int Id)
        {
            var Weilders = WeilderManager.GetAll().ToList();
            Weilders = Weilders.FindAll(x => x.UserId.Equals(Id));

            foreach (var item in Weilders)
            {
                WeilderManager.Delete(item.Id);
            }
            UserManager.Delete(Id);
        }
        public void DeleteAward(int Id)
        {
            var Weilders = WeilderManager.GetAll().ToList();
            Weilders = Weilders.FindAll(x => x.AwardId.Equals(Id));

            foreach (var item in Weilders)
            {
                WeilderManager.Delete(item.Id);
            }
            AwardManager.Delete(Id);
        }
        public void DeleteWeilder(int Id)
        {
            WeilderManager.Delete(Id);
        }
        public void DeleteImage(int Id)
        {
            ImageManager.Delete(Id);
            foreach (var item in GetAllAwards().Where(x => x.Icon.Id == Id))
            {
                item.Icon = null;
                EditAward(item);
            }
            foreach (var item in GetAllUsers().Where(x => x.Icon.Id == Id))
            {

            }
        }
        public void DeleteWebUser(int Id)
        {
            WebManager.Delete(Id);
        }
        public void DeleteRole(int Id)
        {
            RoleManager.Delete(Id);
        }
        #endregion

        #region Edit
        public void EditUser(User EditedVer)
        {
            UserManager.Edit(EditedVer);
        }
        public void EditAward(Award EditedVer)
        {
            AwardManager.Edit(EditedVer);
        }
        public void EditWebUser(WebUser EditedVer)
        {
            WebManager.Edit(EditedVer);
        }
        public void EditRole(Role EditedVer)
        {
            RoleManager.Edit(EditedVer);
        }
        public void EditImage(Image EditedVer, int? UserId, int? AwardId)
        {
            if (UserId.HasValue)
            {
                var user = GetUser(UserId.Value);
                user.Icon = EditedVer;
                EditUser(user);
            }
            if (AwardId.HasValue)
            {
                var award = GetAward(AwardId.Value);
                award.Icon = EditedVer;
                EditAward(award);
            }
            ImageManager.Edit(EditedVer);
        }
        public void EditWeilder(AwardWeilder EditedVer)
        {
            WeilderManager.Edit(EditedVer);
        }
        #endregion

        public bool LogInCheck(string Username, string Password)
        {
            if (GetWebUser(Username, Password) != null)
            {
                return true;
            }
            return false;
        }
    }
}
