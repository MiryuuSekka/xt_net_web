

namespace Game.Interfaces
{
    interface iPlayer : iMovable, iDamager, iMapObject
    {
        int Score { get; set; }
    }
}
