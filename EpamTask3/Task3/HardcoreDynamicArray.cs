using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class HardcoreDynamicArray<T> : DynamicArray<T>, ICloneable
    {
        public HardcoreDynamicArray()
        {
        }

        /// <summary>
        /// Task 3.4.1
        /// 
        /// </summary>
        public new T Current
        {
            get
            {
                if (index < 0)
                {
                    index += Length;
                }
                return base._array[index];
            }
        }

        /// <summary>
        /// Task 3.4.2
        /// 
        /// </summary>
        public new int Capacity
        {
            get { return base.Capacity; }
            set
            {
                var NewArray = new T[value];
                for (int i = 0; i < Length; i++)
                {
                    if (i < value)
                    {
                        NewArray[i] = _array[i];
                    }
                }
                _array = NewArray;
                base.Capacity = value;
            }
        }

        /// <summary>
        /// Task 3.4.3
        /// 
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var newArray = new T[Capacity];
            newArray = _array;
            return newArray;
        }

        /// <summary>
        /// Task 3.4.4
        /// 
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return _array;
        }

        public new T this[int index]
        {
            get
            {
                if (index < 0)
                {
                    index += base.Length;
                }
                if (index < 0 || index > base.Capacity)
                {
                    throw new IndexOutOfRangeException("index");
                }
                return _array[index];
            }
            set
            {
                if (index < 0)
                {
                    index += base.Length;
                }
                if (index < 0 || index > base.Capacity)
                {
                    throw new IndexOutOfRangeException("index");
                }
                _array[index] = value;
            }
        }
    }
}
