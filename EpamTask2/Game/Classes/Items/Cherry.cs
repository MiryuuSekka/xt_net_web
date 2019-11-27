
namespace Game.Classes.Items
{
    public class Cherry : Interfaces.iLoot
    {
        public Cherry(Point position)
        {
            EffectText = "+100 AP";
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
