using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics
{
    public class Ring
    {
        Round outer;
        Round inner;
        Point center;

        public Ring(Round round1, Round round2, Point center)
        {
            this.center = center;
            outer.SetCenter(center);
            inner.SetCenter(center);

            if (round1.GetRadius() < round2.GetRadius())
            {
                outer = round1;
                inner = round2;
            }
            else
            {
                if (round1.GetRadius() > round2.GetRadius())
                {
                    inner = round1;
                    outer = round2;
                }
                else
                {
                    Console.WriteLine("Wrong radius of circles");
                    return;
                }
            }
        }
        
        public double GetArea()
        {
            return outer.GetArea() - inner.GetArea();
        }
    }
}
