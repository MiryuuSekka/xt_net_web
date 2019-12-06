using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class CycledDynamicArray<T> : HardcoreDynamicArray<T>
    {
        public new bool MoveNext()
        {
            if (index < Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            return true;
        }

        public new T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    index += Capacity;
                }
                if (index > Capacity)
                {
                    int num = index / Capacity;
                    index -= Capacity * num;
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("index");
                }
                return _array[index];
            }
            set
            {
                if (index < 0)
                {
                    index += Capacity;
                }
                if (index > Capacity)
                {
                    int num = index / Capacity;
                    index -= Capacity * num;
                }
                if (index < 0)
                {
                    throw new IndexOutOfRangeException("index");
                }
                _array[index] = value;
            }
        }
    }
}
