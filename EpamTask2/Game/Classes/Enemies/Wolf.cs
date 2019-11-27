using Game.Interfaces;

namespace Game.Classes.Enemies
{
    public class Wolf : iEnemy
    {
        public Wolf(Point position)
        {
            Target = null;
            Position = position;
            LastPosition = position;
            Hp = 300;
            SpeedPoint = 3;
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
