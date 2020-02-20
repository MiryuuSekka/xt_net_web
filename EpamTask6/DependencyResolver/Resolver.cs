using DAL;
using DALInterfaces;
using BLLInterfaces;
using BLL;
using Entity;

namespace DependencyResolver
{
    public class Resolver
    {
        //..\
        public static readonly string Path = @"D:\\epam\\EpamTask10\\EpamTask10";

        public static IUserBLL SelectUserBLL()
        {
            return new UserBLL(SelectDAL<User>(Path + @"\\DataUser.json"));
        }

        public static IAwardBLL SelectAwardBLL()
        {
            var UserDAL = SelectDAL<User>(Path + @"\\DataUser.json");
            var AwardDAL = SelectDAL<Award>(Path + @"\\DataAward.json");
            var WeilderDAL = SelectDAL<AwardWeilder>(Path + @"\\DataAwardWeilder.json");

            return new AwardBLL(UserDAL, AwardDAL, WeilderDAL);
        }
        
        public static IWebBLL SelectWebBLLjson()
        {
            var UserDAL = SelectDAL<User>(Path + @"\\DataUser.json");
            var AwardDAL = SelectDAL<Award>(Path + @"\\DataAward.json");
            var WeilderDAL = SelectDAL<AwardWeilder>(Path + @"\\DataAwardWeilder.json");
            var WebUserDAL = SelectDAL<WebUser>(Path + @"\\WebUsers.json");
            var ImageDAL = SelectDAL<Image>(Path + @"\\Images.json");

            return new WebBLL(UserDAL, AwardDAL, WeilderDAL, WebUserDAL, ImageDAL);
        }
        /*
        public static IWebBLL SelectWebBLLSQL()
        {
            var UserDAL = SelectDAL<User>(Path + @"\\DataUser.json");
            var AwardDAL = SelectDAL<Award>(Path + @"\\DataAward.json");
            var WeilderDAL = SelectDAL<AwardWeilder>(Path + @"\\DataAwardWeilder.json");
            var WebUserDAL = SelectDAL<WebUser>(Path + @"\\WebUsers.json");
            var ImageDAL = SelectDAL<Image>(Path + @"\\Images.json");

            return new WebBLL(UserDAL, AwardDAL, WeilderDAL, WebUserDAL, ImageDAL);
        }
        */
        private static IData<T> SelectDAL<T>(string Path) where T : HaveId
        {
            switch (CheckSettings())
            {
                default:
                    return new Local<T>();

                case 1:
                    return new Folder<T>(Path);
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

