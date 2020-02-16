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
            //check table
            //create table if havenot
        }

        public string AddImage(string Path, string Info)
        {
            Images NewImage;
            try
            {
                NewImage = Images.Parse(DALImages.GetAll(), Path, Info);
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

        public Images GetImageByInfo(string Info)
        {
            var Images = DALImages.GetAll();
            return Images.Where(x => x.Info == Info).First();
        }
    }
}
