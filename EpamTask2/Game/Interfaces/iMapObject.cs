using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IIMapObject
    {
        Classes.Point Position { get; set; }
        string Name { get;}
    }
}
