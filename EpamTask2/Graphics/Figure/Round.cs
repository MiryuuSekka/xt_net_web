using System;
using System.Text;


namespace Graphics
{
    public class Round : iFigure
    {
        public Point Center { get; set; }

        public Line Radius { get; set; }
        
        public double Length
        {
            get
            {
                return (2 * Math.PI * Radius.Length);
            }
        }

        public Round(Point center, int radius)
        {
            Center = center;
            Radius = new Line(radius);
        }

        public double GetArea()
        {
            return (Math.PI * Radius.Length * Radius.Length);
        }

        public string GetInfo()
        {
            var str = new StringBuilder();
            str.Append("\nRound - Center at { " + Center.X);
            str.Append(" ; " + Center.Y + " }, ");
            str.Append("Radius is " + Radius.Length + ", ");
            str.Append("Lenght is " + Math.Round(Length, 2) + ", ");
            str.Append("Area is " + Math.Round(GetArea(), 2));
            return str.ToString();
        }
    }
}
