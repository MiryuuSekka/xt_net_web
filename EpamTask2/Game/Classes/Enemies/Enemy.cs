using Game.Interfaces;

namespace Game.Classes.Enemies
{
    abstract public class Enemy : IIMapObject, IIMovable, IIBreakable, IIDamager
    {
        public Point Position { get; set; }
        public string Name { get; }
        public int SpeedPoint { get; set; }
        public Point LastPosition { get; set; }
        public int Hp { get; set; }
        public bool Broken { get; set; }
        public int AttackP { get; set; }
        IIMapObject Target { get; set; }
    }
}
