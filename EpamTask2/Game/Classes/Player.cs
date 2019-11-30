using Game.Interfaces;

namespace Game.Classes
{
    public class Player : IIPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public int Hp { get; set; }
        public int AttackP { get; set; }
        public int SpeedPoint { get; set; }

        public Point LastPosition { get; set; }
        public Point Position { get; set; }
        

        public Player(string name, Point position)
        {
            Name = name;
            Hp = 500;
            AttackP = 50;
            SpeedPoint = 1;
            LastPosition = position;
            Position = position;
            Score = 0;
        }
    }
}
