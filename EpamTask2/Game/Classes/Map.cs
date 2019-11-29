using System;
using System.Collections.Generic;
using Game.Interfaces;

namespace Game.Classes
{
    public class Map
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public List<iMapObject> Objects;

        public Map(int width, int height, Player Player1)
        {
            Width = width;
            Height = height;

            generateObjects(Player1);
        }

        void generateObjects(Player Player1)
        {
            Objects = new List<iMapObject>();
            Objects.Add(Player1);
            addObjects((Width * Height / 50), (Width * Height / 250), (Width*Height/12));
        }

        bool isFilled(Point cell)
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

        void addObjects(int ItemCount, int EnemyCount, int WallsCount)
        {
            Point cell;
            for (int i = 0; i < ItemCount; i++)
            {
                cell = getRandomCell();
                Objects.Add(getItem(cell));
            }
            for (int i = 0; i < EnemyCount; i++)
            {
                cell = getRandomCell();
                Objects.Add(getEnemy(cell));
            }
            for (int i = 0; i < WallsCount; i++)
            {
                cell = getRandomCell();
                Objects.Add(getWall(cell));
            }
        }

        iMapObject getItem(Point cell)
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
        iMapObject getEnemy(Point cell)
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
        iMapObject getWall(Point cell)
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

        Point getRandomCell()
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
            while (isFilled(point));
            return point;
        }
    }
}
