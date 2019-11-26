using System;

namespace Graphics
{
    public class Line
    {
        int _length;

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (!Helper.Class.IsNaturalNumber(value))
                {
                    throw new ArgumentException("!Invalid value. Required value above zero!");

                }
                _length = value;
            }
        } 

        public Line(int length)
        {
            Length = length;
        }
    }
}
