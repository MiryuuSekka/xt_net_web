using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Turn
    {
        public enum Direction
        {
            None,
            Left,
            Right,
            Up,
            Down
        }

        public Turn()
        {
        }

        void Step<T>(Direction target) where T : Interfaces.iMovable
        {

        }

        void Attack()
        { }
    }
}
