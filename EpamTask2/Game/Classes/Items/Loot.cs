using Logic.Interfaces;

namespace Logic.Classes.Items
{
    abstract public class Loot : IIMapObject
    {
        public string EffectText { get; set; }
        public Point Position { get; set; }
        public string Name { get; }
    }
}
