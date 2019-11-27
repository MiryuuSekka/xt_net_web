using System;
using System.Collections.Generic;

namespace Game.Classes
{
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Interfaces.iMapObject> Objects;

        public Map(int width, int height, Player Player1)
        {
            Width = width;
            Height = height;

            _generateObjects(Player1);
        }

        void _generateObjects(Player Player1)
        {
            Objects = new List<Interfaces.iMapObject>();
            Objects.Add(Player1);
            AddObjects(20, 5, 100);
        }

        bool IsFilled(Point cell)
        {
            foreach (var item in Objects)
            {
                if (item.Position.X.Equals(cell.X) & item.Position.Y.Equals(cell.Y))
                {
                    return true;
                }
            }
            return false;
        }

        void AddObjects(int ItemCount, int EnemyCount, int WallsCount)
        {
            Point cell;
            for (int i = 0; i < ItemCount; i++)
            {
                cell = GetRandomCell();
                Objects.Add(GetItem(cell));
            }
            for (int i = 0; i < EnemyCount; i++)
            {
                cell = GetRandomCell();
                Objects.Add(GetEnemy(cell));
            }
            for (int i = 0; i < WallsCount; i++)
            {
                cell = GetRandomCell();
                Objects.Add(GetWall(cell));
            }
        }

        Interfaces.iMapObject GetItem(Point cell)
        {
            var N = Helper.Class.Randomize.Next(2);

            switch (N)
            {
                default:
                    return new Items.Apple(cell);

                case 1:
                    return new Items.Cherry(cell);
            }
        }
        Interfaces.iMapObject GetEnemy(Point cell)
        {
            var N = Helper.Class.Randomize.Next(2);

            switch (N)
            {
                default:
                    return new Enemies.Bear(cell);

                case 1:
                    return new Enemies.Wolf(cell);
            }
        }
        Interfaces.iMapObject GetWall(Point cell)
        {
            var N = Helper.Class.Randomize.Next(2);

            switch (N)
            {
                default:
                    return new Walls.Tree(cell);

                case 1:
                    return new Walls.Rock(cell);

            }

        }

        Point GetRandomCell()
        {
            Point point = new Point(0, 0);
            if (Width * Height / 2 <= Objects.Count)
            {
                throw new Exception("too much objects on map");
            }

            do
            {
                point.X = Helper.Class.Randomize.Next(Width);
                point.Y = Helper.Class.Randomize.Next(Height);
            }
            while (IsFilled(point));
            return point;
        }
    }
}
