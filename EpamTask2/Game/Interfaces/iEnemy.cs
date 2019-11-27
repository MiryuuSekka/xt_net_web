using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    interface iEnemy: iMapObject, iMovable
    {
        iMapObject Target { get; set; }

    }
}
