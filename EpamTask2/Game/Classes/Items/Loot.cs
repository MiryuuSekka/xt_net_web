using Game.Interfaces;

namespace Game.Classes.Items
{
    abstract public class Loot : IIMapObject
    {
        public string EffectText { get; set; }
        public Point Position { get; set; }
        public string Name { get; }
    }
}
