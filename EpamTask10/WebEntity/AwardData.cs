using Entity;
using System.Collections.Generic;

namespace WebEntity
{
    public class AwardData : HaveId
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}
