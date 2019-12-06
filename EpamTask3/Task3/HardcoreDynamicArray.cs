using System;

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

        internal int _capacity;

        /// <summary>
        /// Task 3.4.2
        /// ёмкость
        /// </summary>
        public new int Capacity
        {
            get { return _capacity; }
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
                _capacity = value;
            }
        }

        /// <summary>
        /// Task 3.4.3
        /// создание копии массива
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
        /// возвращает новый массив (обычный), 
        /// содержащий все содержащиеся в текущем динамическом массиве объекты
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            return _array;
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
