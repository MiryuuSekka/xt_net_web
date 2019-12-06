using System;

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

        /// <summary>
        /// индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
