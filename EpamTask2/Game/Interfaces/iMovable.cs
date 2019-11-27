using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    interface iMovable
    {
        int SpeedPoint { get; set; }
        Classes.Point LastPosition { get; set; }
    }
}
