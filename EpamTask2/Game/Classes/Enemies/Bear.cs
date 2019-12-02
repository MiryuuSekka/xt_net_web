using Logic.Interfaces;

namespace Logic.Classes.Enemies
{
    public class Bear : Enemy
    {
        public Bear(Point position)
        {
            Position = position;
            LastPosition = position;
            Hp = 800;
            SpeedPoint = 1;
        }
    }
}
