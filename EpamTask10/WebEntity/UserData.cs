using Entity;
using System.Collections.Generic;

namespace WebEntity
{
    public class UserData : HaveId
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public List<Award> Awards { get; set; }
    }
}
