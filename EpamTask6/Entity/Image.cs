using System;
using System.Collections.Generic;

namespace Entity
{
    public class Image : HaveId
    {
        public string Path { get; set; }
        public int? UserId { get; set; }
        public int? WebUserId { get; set; }
        public int? AwardId { get; set; }
        public bool IsDefault { get; set; }

        public static Image Parse(IEnumerable<Image> AllImages, string Image, int? WebUserId, int? UserId, int? AwardId)
        {
            if (AllImages == null)
            {
                throw new ArgumentException("Cant find Image library");
            }
            if (Image.Length < 5)
            {
                throw new ArgumentException("Image url too short");
            }
            if (WebUserId == null && UserId == null && AwardId == null)
            {
                throw new ArgumentException("Cant add image to stock");
            }
            var NewImage = new Image
            {
                Path = Image,
                UserId = UserId,
                AwardId = AwardId,
                WebUserId = WebUserId,
                IsDefault = false
            };
            NewImage.Id = NewImage.GetNewId(AllImages);
            return NewImage;
        }
    }
}
