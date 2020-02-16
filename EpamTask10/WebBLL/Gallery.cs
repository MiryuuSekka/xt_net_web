using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEntity;

namespace WebBLL
{
    public class Gallery
    {
        private DAL.Folder<Images> DALImages;

        public Gallery()
        {
            DALImages = new DAL.Folder<Images>(Common.Path + @"\Images.json");

        }
        
        public void DeleteImage(int Id)
        {
            var Image = DALImages.GetAll().FirstOrDefault(x => x.Id == Id);
            if (!Image.IsDefault)
            {
                DALImages.DeleteById(Id);
            }
        }

        public string AddImage(string Path, int? WebUserId, int? UserId, int? AwardId)
        {
            Images NewImage;
            try
            {
                NewImage = Images.Parse(DALImages.GetAll(), Path, WebUserId, UserId, AwardId);
                DALImages.AddData(NewImage);
                return "";
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        public IEnumerable<Images> GetAllImages()
        {
            return DALImages.GetAll();
        }
        
        public Images GetImageByImageId(int Id)
        {
            var all = DALImages.GetAll();
            all = all.Where(x => x.Id == Id);

            return all.FirstOrDefault();
        }

        public Images GetImageByUserId(int Id)
        {
            return DALImages.GetAll().Where(x => x.UserId == Id).FirstOrDefault();
        }

        public Images GetImageByWebUserId(int Id)
        {
            return DALImages.GetAll().Where(x => x.WebUserId == Id).FirstOrDefault();
        }

        public Images GetImageByAwardId(int Id)
        {
            return DALImages.GetAll().Where(x => x.AwardId == Id).FirstOrDefault();
        }
    }
}
