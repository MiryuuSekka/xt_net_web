

namespace Graphics
{
    public class Triangle
    {
        int a, b, c;

        public Triangle()
        {
            a = 1;
            b = 1;
            c = 1;
        }

        public Triangle(int a, int b, int c)
        {
            this.a = (Helper.Class.IsNaturalNumber(a)) ? a : 1;
            this.b = (Helper.Class.IsNaturalNumber(b)) ? b : 1;
            this.c = (Helper.Class.IsNaturalNumber(c)) ? c : 1;
        }

        public double GetPerimeter()
        {
            return a + b + c;
        }

        public double GetVolume()
        {
            return GetPerimeter() / 2;
        }

        public string GetInformation()
        {
            var Data = "Triangle:\n";
            Data += "   side a = " + a;
            Data += ", side b = " + b;
            Data += ", side c = " + c;
            Data += "\n Perimeter = " + GetPerimeter();
            Data += ", volume = " + GetVolume();
            return Data;
        }
    }
}
