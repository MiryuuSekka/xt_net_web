using Entity;
using System;
using System.Collections.Generic;

namespace WebEntity
{
    public class Images : HaveId
    {
        public string Image { get; set; }
        public string Info { get; set; }

        public static Images Parse(IEnumerable<Images> AllImages, string Image, string Info)
        {
            if (AllImages != null && Image.Length > 3 && Info.Length > 5)
            {
                var NewImage = new Images
                {
                     Image = Image,
                     Info = Info
                };
                NewImage.Id = NewImage.GetNewId(AllImages);
                return NewImage;
            }
            else
            {
                throw new ArgumentException("Cant create Image with empty");
            }

        }
    }
}
