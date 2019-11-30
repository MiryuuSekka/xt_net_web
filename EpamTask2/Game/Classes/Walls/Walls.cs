using Game.Interfaces;

namespace Game.Classes.Walls
{
    abstract public class Walls : IIMapObject, IIBreakable
    {
        public Point Position { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public bool Broken { get; set; }
    }
}
