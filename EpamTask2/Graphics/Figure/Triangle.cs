using System;
using System.Text;

namespace Graphics
{
    public class Triangle : iFigure
    {
        public Line SideA { get; set; }
        public Line SideB { get; set; }
        public Line SideC { get; set; }
        
        public Triangle(int a, int b, int c)
        {
            SideA = new Line(a);
            SideB = new Line(b);
            SideC = new Line(c);
        }

        public double GetPerimeter()
        {
            return SideA.Length + SideB.Length + SideC.Length;
        }

        public double GetArea()
        {
            return GetPerimeter() / 2;
        }

        public string GetInfo()
        {
            var str = new StringBuilder();
            str.Append("\nTriangle");
            str.Append(" Side a = " + SideA.Length + ", ");
            str.Append(" Side b = " + SideB.Length + ", ");
            str.Append(" Side c = " + SideC.Length + ", ");
            str.Append("Perimeter is " + Math.Round(GetPerimeter(),2) + ", ");
            str.Append("Area is " + Math.Round(GetArea(), 2));
            return str.ToString();
        }
    }
}
