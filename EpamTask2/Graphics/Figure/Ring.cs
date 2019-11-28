using System;
using System.Text;

namespace Graphics
{
    public class Ring : iFigure
    {
        public Round Inner { get; set; }

        public Round Outer { get; set; }

        public Point Center { get; set; }

        public double Length
        {
            get
            {
                return Inner.Length + Outer.Length;
            }
        }

        public Ring(Round outer, Round inner)
        {
            if(outer.Radius.Length.Equals(inner.Radius.Length))
            {
                throw new ArgumentException("! Wrong value. Radiuses cant be equal !");
            }

            if(inner.Radius.Length > outer.Radius.Length)
            {
                Inner = outer;
                Outer = inner;
            }
            else
            {
                Inner = inner;
                Outer = outer;
            }

            Center = Inner.Center;
            Outer.Center = Center;
        }

        public double GetArea()
        {
            return Outer.GetArea() - Inner.GetArea();
        }

        public string GetInfo()
        {
            var str = new StringBuilder();
            str.Append("\nRing - Center at { " + Center.X);
            str.Append(" ; " + Center.Y + " }, ");
            str.Append("Inner round radius is " + Inner.Radius.Length + ", ");
            str.Append("\n          Outer round radius is " + Outer.Radius.Length + ", ");
            str.Append("Lenght of both rounds is " + Math.Round(Length, 2) + ", ");
            str.Append("Area is " + Math.Round(GetArea(), 2));
            return str.ToString();
        }
    }
}
