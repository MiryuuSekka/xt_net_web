using System;
using System.Collections.Generic;
using Game.Interfaces;

namespace Game.Classes
{
    public class Map
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public List<IIMapObject> Objects;

        public Map(int width, int height, Player Player1)
        {
            Width = width;
            Height = height;

            GenerateObjects(Player1);
        }



        void GenerateObjects(Player Player1)
        {
            Objects = new List<IIMapObject>
            {
                Player1
            };
            AddObjects((Width * Height / 50), (Width * Height / 250), (Width*Height/12));
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

        IIMapObject GetItem(Point cell)
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
        IIMapObject GetEnemy(Point cell)
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
        IIMapObject GetWall(Point cell)
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
