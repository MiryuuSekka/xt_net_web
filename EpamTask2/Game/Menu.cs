using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Menu
    {
        Classes.Map GameMap;

        public Menu()
        {
            var NewPlayer = new Classes.Player("Unknown", new Classes.Point(0, 0));
            GameMap = new Classes.Map(25, 50, NewPlayer);
        }

        public List<Interfaces.iMapObject> GetMap()
        {
            return GameMap.Objects;
        }
        
        public int GetWidth()
        {
            return GameMap.Width;
        }

        public int GetHeight()
        {
            return GameMap.Height;
        }
    }
}
