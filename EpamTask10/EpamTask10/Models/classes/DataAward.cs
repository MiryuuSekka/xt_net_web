using System.Collections.Generic;

namespace EpamTask10.Models.classes
{
    public class DataAward
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public List<Entity.User> Users { get; set; }
    }
}