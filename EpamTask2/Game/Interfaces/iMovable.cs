﻿

namespace Logic.Interfaces
{
    interface IIMovable : IIMapObject
    {
        int SpeedPoint { get; set; }
        Classes.Point LastPosition { get; set; }
    }
}
