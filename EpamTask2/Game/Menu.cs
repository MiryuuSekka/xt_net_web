using System;
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

        public List<Interfaces.IIMapObject> GetMap()
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

        public void NextTurn(Direction direction)
        {
            for (int i = 0; i < GameMap.Objects.Count; i++)
            {
                if (GameMap.Objects[i] is Interfaces.IIMovable)
                {
                    var r = GameMap.Objects[i] as Interfaces.IIMovable;
                    var targets = NearlyObjects(GameMap.Objects[i], r.SpeedPoint);
                    r.LastPosition = GameMap.Objects[i].Position;
                    Step((Interfaces.IIMovable)GameMap.Objects[i], direction);
                }
            }
        }

        public enum Direction
        {
            None,
            Left,
            Right,
            Up,
            Down
        };

        void Step(Interfaces.IIMovable Obj, Direction direction)
        {
            if (!(Obj is Player))
            {
                direction = (Direction)Helper.Class.Randomize.Next(4);
            }
                switch (direction)
                {
                    default:
                        break;
                    case Direction.Down:
                        if (Obj.Position.X + Obj.SpeedPoint < GetWidth())
                        {
                            Obj.Position.X += Obj.SpeedPoint;
                        }
                        break;
                    case Direction.Up:
                        if (Obj.Position.X - Obj.SpeedPoint >= 0 )
                        {
                            Obj.Position.X -= Obj.SpeedPoint;
                        }
                        break;
                    case Direction.Right:
                        if (Obj.Position.Y + Obj.SpeedPoint < GetHeight())
                        {
                            Obj.Position.Y += Obj.SpeedPoint;
                        }
                        break;
                    case Direction.Left:
                        if (Obj.Position.Y - Obj.SpeedPoint >= 0 )
                        {
                            Obj.Position.Y -= Obj.SpeedPoint;
                        }
                        break;
                }
        }

        void Attack(int Area, Point Position)
        {
        }

        void PickUp(int Area, Point Position)
        {
        }

        List<Interfaces.IIMapObject> NearlyObjects(Interfaces.IIMapObject value, int Area)
        {
            var targets = new List<Interfaces.IIMapObject>();
            foreach (var item in GameMap.Objects)
            {
                if(Math.Abs(item.Position.X - value.Position.X) <= Area && Math.Abs(item.Position.Y - value.Position.Y) <= Area)
                {
                    targets.Add(item);
                }
            }
            return targets;
        }

    }
}
