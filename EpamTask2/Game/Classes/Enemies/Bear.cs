using Game.Interfaces;

namespace Game.Classes.Enemies
{
    public class Bear : iEnemy
    {
        public Bear(Point position)
        {
            Target = null;
            Position = position;
            LastPosition = position;
            Hp = 800;
            SpeedPoint = 1;
        }

        public string Name
        {
            get
            {
                return GetType().ToString();
            }
        }
        public iMapObject Target { get; set; }
        public Point Position { get; set; }
        public int Hp { get; set; }
        public int SpeedPoint { get; set; }
        public Point LastPosition { get; set; }
    }
}
