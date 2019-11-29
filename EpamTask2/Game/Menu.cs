using System.Collections.Generic;
using Game.Classes;

namespace Game
{
    public class Menu
    {
        Map GameMap;

        public Menu()
        {
            var NewPlayer = new Player("Unknown", new Point(0, 0));
            GameMap = new Map(25, 50, NewPlayer);
            GameMap.Objects[0].Position = new Point(GameMap.Width / 2, GameMap.Height / 2);
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

        public Player GetPlayerData()
        {
            return (Player)GameMap.Objects[0];
        }
    }
}
