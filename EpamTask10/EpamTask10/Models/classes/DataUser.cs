using System.Collections.Generic;

namespace EpamTask10.Models.classes
{
    public class DataUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public string Birthday { get; set; }
        public List<DataAward> Awards { get; set; }
    }
}