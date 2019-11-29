

namespace Game.Interfaces
{
    interface iMovable
    {
        int SpeedPoint { get; set; }
        Classes.Point LastPosition { get; set; }
    }
}
