

namespace Logic.Interfaces
{
    interface IIPlayer : IIMovable, IIDamager, IIMapObject
    {
        int Score { get; set; }
    }
}
