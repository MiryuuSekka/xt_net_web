using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public class AwardWeilders : HaveKey
    {
        public int AwardId { get; set; }
        public int WeilderId { get; set; }


        static public AwardWeilders Parse(int Award, int User, List<AwardWeilders> data)
        {
            var item = new AwardWeilders();
            item.AwardId = Award;
            item.WeilderId = User;
            item.Id = GetNewId(data);
            return item;
        }
    }
}
