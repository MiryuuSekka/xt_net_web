
namespace Game.Interfaces
{
    interface IIBreakable : IIMapObject
    {
        int Hp { get; set; }
        bool Broken { get; set; }
    }
}
