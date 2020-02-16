using Entity;
using System;
using System.Collections.Generic;

namespace WebEntity
{
    public class Images : HaveId
    {
        public string Image { get; set; }
        public int? UserId { get; set; }
        public int? WebUserId { get; set; }
        public int? AwardId { get; set; }
        public bool IsDefault { get; set; }

        public static Images Parse(IEnumerable<Images> AllImages, string Image, int? WebUserId, int? UserId, int? AwardId)
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
            var NewImage = new Images
            {
                Image = Image,
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
