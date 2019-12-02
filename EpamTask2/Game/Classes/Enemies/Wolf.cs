using Logic.Interfaces;

namespace Logic.Classes.Enemies
{
    public class Wolf : Enemy
    {
        public Wolf(Point position)
        {
            Position = position;
            LastPosition = position;
            Hp = 300;
            SpeedPoint = 3;
        }
    }
}
