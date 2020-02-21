using System;
using System.Collections.Generic;

namespace Entity
{
    public class Image : HaveId
    {
        public string Path { get; set; }
        public bool IsDefault { get; set; }

        public static Image Parse(IEnumerable<Image> AllImages, string Image)
        {
            if (AllImages == null)
            {
                throw new ArgumentException("Cant find Image library");
            }
            if (Image.Length < 5)
            {
                throw new ArgumentException("Image url too short");
            }
            var NewImage = new Image
            {
                Path = Image,
                IsDefault = false
            };
            NewImage.Id = NewImage.GetNewId(AllImages);
            return NewImage;
        }
    }
}
