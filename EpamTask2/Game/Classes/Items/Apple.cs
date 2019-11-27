
namespace Game.Classes.Items
{
    public class Apple : Interfaces.iLoot
    {
        public Apple(Point position)
        {
            EffectText = "+100 HP";
            Position = position;
        }

        public string Name
        {
            get
            {
                return GetType().ToString();
            }
        }
        public string EffectText { get; set; }
        public Point Position { get; set; }
    }
}
