
namespace Game.Classes.Walls
{
    public class Rock : Interfaces.iBlock
    {
        public Rock(Point position)
        {
            Position = position;
            Hp = 1000000;
            Broken = false;
        }

        public string Name
        {
            get
            {
                return GetType().ToString();
            }
        }
        public Point Position { get; set; }
        public int Hp { get; set; }
        public bool Broken { get; set; }
    }
}
