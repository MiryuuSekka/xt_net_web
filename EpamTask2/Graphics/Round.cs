using System;


namespace Graphics
{
    public class Round
    {
        int radius;
        Point center;

        public Round(int x, int y, int Radius)
        {
            center = new Point(x, y);
            radius = (Helper.Class.IsNaturalNumber(Radius)) ? Radius : 1;
        }

        public Round(Point Center, int Radius)
        {
            center = Center;
            radius = (Helper.Class.IsNaturalNumber(Radius)) ? Radius : 1;
        }

        public double GetArea()
        {
            return (Math.PI * radius * radius);
        }

        public double GetLength()
        {
            return (2 * Math.PI * radius);
        }

        public int GetRadius()
        {
            return radius;
        }

        public Point GetCenter()
        {
            return center;
        }

        internal void SetCenter(Point newCenter)
        {
            center = newCenter;
        }
    }
}
