using DAL;
using DALInterfaces;
using BLLInterfaces;
using BLL;
using Entity;
using DAL.sqlClasses;

namespace DependencyResolver
{
    public class Resolver
    {
        public static readonly string Path = @"D:\\epam\\EpamTask10\\EpamTask10";

        public static IUserBLL SelectUserBLL()
        {
            return new UserBLL(SelectDAL<User>(@"\\DataUser.json"));
        }

        public static IAwardBLL SelectAwardBLL()
        {
            var UserDAL = SelectDAL<User>( @"\\DataUser.json");
            var AwardDAL = SelectDAL<Award>(@"\\DataAward.json");
            var WeilderDAL = SelectDAL<AwardWeilder>(@"\\DataAwardWeilder.json");

            return new AwardBLL(UserDAL, AwardDAL, WeilderDAL);
        }
        
        public static IWebBLL SelectWebBLL()
        {
            var UserDAL = SelectWebDAL<User>(@"\\DataUser.json", "User");
            var AwardDAL = SelectWebDAL<Award>(@"\\DataAward.json", "Award");
            var WeilderDAL = SelectWebDAL<AwardWeilder>(@"\\DataAwardWeilder.json", "AwardWeilder");
            var WebUserDAL = SelectWebDAL<WebUser>(@"\\WebUsers.json", "WebUser");
            var ImageDAL = SelectWebDAL<Image>(@"\\Images.json", "Image");
            var RoleDAL = SelectWebDAL<Role>(@"\\Roles.json", "Role");

            return new WebBLL(UserDAL, AwardDAL, WeilderDAL, WebUserDAL, ImageDAL, RoleDAL);
        }

        private static IData<T> SelectDAL<T>(string File) where T : HaveId
        {
            switch (CheckSettings())
            {
                default:
                    return new Local<T>();

                case 1:
                    return new Folder<T>(Path + File);
            }
        }

        private static IData<T> SelectWebDAL<T>(string File, string type) where T : HaveId
        {
            switch (CheckSettings())
            {
                default:
                    return new Folder<T>(Path + File);

                case 1:
                    return ChooseGetDal<T>(type);
            }
        }

        private static IData<T> ChooseGetDal<T>(string type) where T : HaveId
        {
            IData<T> result;
            switch (type)
            {
                case "User":
                    result = (IData<T>)(new SqlUser<User>("User_Table"));
                    return result;

                case "Award":
                    result = (IData<T>)(new SqlAward<Award>("Award_Table"));
                    return result;

                case "Image":
                    result = (IData<T>)(new SqlImage<Image>("Image_Table"));
                    return result;

                case "Role":
                    result = (IData<T>)(new SqlRole<Role>("Role_Table"));
                    return result;

                case "WebUser":
                    result = (IData<T>)(new SqlWebUser<WebUser>("WebUser_Table"));
                    return result;

                case "AwardWeilder":
                    result = (IData<T>)(new SqlWeilder<AwardWeilder>("AwardUser"));
                    return result;

                default:
                    return null;
            }
        }

        private static int CheckSettings()
        {
            var Manager = new ToFolder(Path + @"\\Settings.json");
            Settings SettingsData;

            try
            {
                SettingsData = Manager.Deserialize<Settings>()[0];
            }
            catch (System.Exception)
            {
                SettingsData = new Settings
                {
                    NumberOfRealisation = 1
                };

                Manager.ClearFile();
                Manager.Serialize(SettingsData);
            }

            return SettingsData.NumberOfRealisation;
        }
    }
}

