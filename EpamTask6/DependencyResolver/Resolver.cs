using DAL;
using DALInterfaces;
using BLLInterfaces;
using BLL;
using Entity;

namespace DependencyResolver
{
    public class Resolver
    {
        public static IUserBLL SelectUserBLL()
        {
            return new UserBLL(SelectDAL<User>(@"..\\DataUser.json"));
        }

        public static IAwardBLL SelectAwardBLL()
        {
            var UserDAL = SelectDAL<User>(@"..\\DataUser.json");
            var AwardDAL = SelectDAL<Award>(@"..\\DataAward.json");
            var WeilderDAL = SelectDAL<AwardWeilder>(@"..\\DataAwardWeilder.json");

            return new AwardBLL(UserDAL, AwardDAL, WeilderDAL);
        }

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
            var Manager = new ToFolder(@"..\\Settings.json");
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

