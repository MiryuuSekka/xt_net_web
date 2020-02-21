using Entity;
using System.Collections.Generic;

namespace BLLInterfaces
{
    public interface IWebBLL : IAwardBLL
    {
        #region Edit
        void EditUser(User EditedVer);
        void EditAward(Award EditedVer);
        void EditWebUser(WebUser EditedVer);
        void EditRole(Role EditedVer);
        void EditImage(Image EditedVer, int? UserId, int? AwardId);
        void EditWeilder(AwardWeilder EditedVer);
        #endregion

        #region delete
        void DeleteImage(int Id);
        void DeleteWebUser(int Id);
        void DeleteRole(int Id);
        #endregion

        #region get
        IEnumerable<Image> GetAllImages();
        Image GetImage(int Id);
        Image GetImageForUser(User user);
        Image GetImageForAward(Award award);

        IEnumerable<Role> GetAllRoles();
        Role GetRole(int Id);

        IEnumerable<WebUser> GetAllWebUsers();
        WebUser GetWebUser(int Id);
        WebUser GetWebUser(string Username, string Password);
        
        User GetUser(int Id);
        
        Award GetAward(int Id);
        
        IEnumerable<UserAward> GetAllWeilders();
        #endregion


        #region add
        void AddRole(Role data);

        void AddImage(Image data);
        string AddImage(string Path, int? UserId, int? AwardId);

        WebUser AddWebUser(string Username, string Password, Role Role);
        #endregion

        bool LogInCheck(string Username, string Password);
    }
}
