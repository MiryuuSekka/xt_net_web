namespace Entity
{
    public class UserAward
    {
        public int WeilderId { get; set; }
        public User User { get; set; }
        public Award Award { get; set; }
    }
}
