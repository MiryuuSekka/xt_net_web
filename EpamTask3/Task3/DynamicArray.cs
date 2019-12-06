using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    /// <summary>
    /// на базе обычного массива, не использовать коллекции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        internal T[] _array;
        public int Capacity { get; set; }
        public int Length
        {
            get
            {
                return Count<T>(_array);
            }
        }

        /// <summary>
        /// Task 3.3.1
        /// 
        /// </summary>
        public DynamicArray()
        {
            Capacity = 8;
            _array = new T[Capacity];
        }

        /// <summary>
        /// Task 3.3.2
        /// 
        /// </summary>
        /// <param name="Capacity"></param>
        public DynamicArray(int Capacity)
        {
            this.Capacity = Capacity;
            _array = new T[Capacity];
        }

        /// <summary>
        /// Task 3.3.3
        /// 
        /// </summary>
        /// <param name="Items"></param>
        public DynamicArray(IEnumerable<T> Items)
        {
            _array = new T[GetCapacity(Items)];

            int count = 0;
            foreach (var item in Items)
            {
                _array[count] = item;
                count++;
            }
        }



        /// <summary>
        /// Task 3.3.4
        /// 
        /// </summary>
        /// <param name="Item"></param>
        public void Add(T Item)
        {
            ChangeArrayCapacity(Length + 1);
            _array[Length] = Item;
        }

        /// <summary>
        /// Task 3.3.5
        /// 
        /// </summary>
        /// <param name="Items"></param>
        public void AddRange(IEnumerable<T> Items)
        {
            var ItemCount = Count<T>(Items);
            var length = Length;
            ChangeArrayCapacity(Length + ItemCount);
            int i = 0;
            foreach (var item in Items)
            {
                _array[length + i] = item;
                i++;
            }
        }

        /// <summary>
        /// Task 3.3.6
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            var NewArray = new T[Capacity];

            for (int i = 0, j = 0; i < Length; i++)
            {
                if (_array[i] != null)
                {
                    if (!_array[i].Equals(item))
                    {
                        NewArray[j] = _array[i];
                        j++;
                    }
                }
            }
            if (!NewArray.Equals(_array))
            {
                _array = NewArray;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Task 3.3.7
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Insert(int index, T item)
        {
            if (index >= 0 || index < Capacity)
            {
                _array[index] = item;
                return true;
            }
            return false;
        }

        #region Task 3.3.10 IEnumerable<T> и IEnumerator

        /// <summary>
        /// Task 3.3.10
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArray<T>(_array);
        }

        /// <summary>
        /// Task 3.3.10
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
        #endregion

        #region Task 3.3.11 indexator

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Capacity)
                {
                    throw new IndexOutOfRangeException("index");
                }
                return _array[index];
            }
            set
            {
                if (index < 0 || index > Capacity)
                {
                    throw new IndexOutOfRangeException("index");
                }
                _array[index] = value;
            }
        }

        internal int index;

        /// <summary>
        /// Task 3.3.11
        /// 
        /// </summary>
        public T Current
        {
            get
            {
                return _array[index];
            }
        }

        /// <summary>
        /// Task 3.3.11
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (index < Length - 1)
            {
                index++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Task 3.3.11
        /// 
        /// </summary>
        public void Reset()
        {
            index = 0;
        }

        public void Dispose()
        {

        }

        object System.Collections.IEnumerator.Current
        {
            get { return _array[index]; }
        }

        #endregion

        #region helper

        int GetRankOfTwo(int N)
        {
            double result = 0;
            int rank = 0;

            while (N > result)
            {
                result = Math.Pow(2, rank);
                if (N > result)
                {
                    rank++;
                }
            }
            int.TryParse(result.ToString(), out N);
            return N;
        }

        void ChangeArrayCapacity(int ItemCount)
        {
            var length = (Capacity > ItemCount) ? ItemCount : Length;

            Capacity = GetRankOfTwo(ItemCount);
            var newArray = new T[Capacity];
            for (int i = 0; i < length; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }

        int Count<M>(IEnumerable<M> items)
        {
            int N = 0;
            foreach (var item in items)
            {
                if (item != null)
                {
                    N++;
                }
            }
            return N;
        }

        int GetCapacity(IEnumerable<T> items)
        {
            int N = 0;
            foreach (var item in items)
            {
                N++;
            }
            return N;
        }

        #endregion

    }
}
