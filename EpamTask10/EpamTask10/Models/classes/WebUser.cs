namespace EpamTask10.Models.classes
{
    public class WebUser
    {
        public enum Roles
        {
            Guest,
            User,
            Admin
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

    }
}