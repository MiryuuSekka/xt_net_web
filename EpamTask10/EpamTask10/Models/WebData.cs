using EpamTask10.Models.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamTask10.Models
{
    public class WebData
    {
        private static string Path = @"D:\epam\EpamTask10\EpamTask10";

        //DAL.Folder<WebUser> WebUserData = new DAL.Folder<WebUser>(Path);
        public static DAL.Folder<Images> ImageData = new DAL.Folder<Images>(Path);

        private static string DefaultImage = "https://cdn4.iconfinder.com/data/icons/trophy-and-awards-1/64/Icon_Medal_Trophy_Awards_Red-512.png";
        private static string DefaultAvatar = "https://cdn.iconscout.com/icon/free/png-256/avatar-370-456322.png";


        public static IEnumerable<Images> GetImages()
        {
            return ImageData.GetAll();
        }

        public static void AddImage(string Path)
        {
            var newImage = new Images
            {
                Image = Path
            };
            newImage.Id = newImage.GetNewId(GetImages());
            ImageData.AddData(newImage);
        }
    }
}