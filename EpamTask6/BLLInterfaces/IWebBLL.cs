using Entity;
using System.Collections.Generic;

namespace BLLInterfaces
{
    public interface IWebBLL : IAwardBLL
    {
        IEnumerable<Image> GetAllImages();

        IEnumerable<WebUser> GetAllWebUsers();

        IEnumerable<UserAward> GetAllWeilders();


        string AddImage(string Path, int? WebUserId, int? UserId, int? AwardId);

        WebUser AddUser(string Username, string Password, WebUser.Roles Role);
        

        void DeleteImage(int Id);


        void ChangeUserRole(int UserId, WebUser.Roles NewRole);


        bool CheckPassword(string Username, string Password);



        WebUser GetUser(int Id);

        WebUser GetUser(string Username, string Password);


        Image GetImageByImageId(int Id);

        Image GetImageByUserId(int Id);

        Image GetImageByWebUserId(int Id);

        Image GetImageByAwardId(int Id);


        Image GetDefaultImageForWebUser(WebUser.Roles Role);

        Image GetDefaultImageForAward();

        Image GetDefaultImageForUser();
    }
}
