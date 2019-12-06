using System;
using System.Collections.Generic;

namespace Task3
{
    /// <summary>
    /// на базе обычного массива, не использовать коллекции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicArray<T> : IEnumerable<T>, IEnumerator<T>
    {
        internal T[] _array;

        /// <summary>
        /// Свойство Capacity — получение ёмкости: длины внутреннего массива
        /// </summary>
        public int Capacity {
            get
            {
                int N = 0;
                foreach (var item in _array)
                {
                    N++;
                }
                return N;
            }
        }

        /// <summary>
        /// Свойство Length — получение количества элементов. 
        /// </summary>
        public int Length
        {
            get
            {
                return Count<T>(_array);
            }
        }

        /// <summary>
        /// Task 3.3.1
        /// Конструктор без параметров (создаётся массив ёмкостью 8 элементов)
        /// </summary>
        public DynamicArray()
        {
            _array = new T[8];
        }

        /// <summary>
        /// Task 3.3.2
        /// Конструктор с одним целочисленным параметром 
        /// (создаётся массив указанной ёмкости)
        /// </summary>
        /// <param name="Capacity"></param>
        public DynamicArray(int Capacity)
        {
            _array = new T[Capacity];
        }

        /// <summary>
        /// Task 3.3.3
        /// Конструктор, который в качестве параметра принимает коллекцию, 
        /// реализующую интерфейс IEnumerable<T>, создаёт массив нужного размера 
        /// и копирует в него все элементы из коллекции.
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
        /// Метод Add, добавляющий в конец массива один элемент. 
        /// При нехватке места для добавления элемента, 
        /// ёмкость массива должна удваиваться.
        /// </summary>
        /// <param name="Item"></param>
        public void Add(T Item)
        {
            ChangeArrayCapacity(Length + 1);
            _array[Length] = Item;
        }

        /// <summary>
        /// Task 3.3.5
        /// Метод AddRange, добавляющий в конец массива содержимое коллекции, 
        /// реализующей интерфейс IEnumerable<T>. Обратите внимание, 
        /// метод должен корректно учитывать число элементов в коллекции с тем, 
        /// чтобы при необходимости расширения массива делать это только один 
        /// раз вне зависимости от числа элементов в добавляемой коллекции
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
        /// Метод Remove, удаляющий из коллекции указанный элемент. 
        /// Метод должен возвращать true, если удаление прошло успешно 
        /// и false в противном случае. 
        /// При удалении элементов реальная ёмкость массива не должна уменьшаться
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
        /// Метод Insert, позволяющий добавить элемент в произвольную позицию массива 
        /// (обратите внимание, может потребоваться расширить массив). 
        /// Метод должен возвращать true, если добавление прошло успешно и 
        /// false в противном случае. При выходе за границу массива должно 
        /// генерироваться исключение ArgumentOutOfRangeException.
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
            throw new ArgumentOutOfRangeException();
        }

        #region Task 3.3.10 IEnumerable<T> и IEnumerator

        /// <summary>
        /// Task 3.3.10
        /// массив обьектов в виде IEnumerator<T>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArray<T>(_array);
        }

        /// <summary>
        /// Task 3.3.10
        /// массив обьектов в виде IEnumerator<T>
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _array.GetEnumerator();
        }
        #endregion

        #region Task 3.3.11 indexator

        /// <summary>
        /// индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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

        /// <summary>
        /// индекс
        /// </summary>
        internal int index;

        /// <summary>
        /// Task 3.3.11
        /// выбранное значение
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
        /// к следующему значению
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
        /// вернуться к первому значению
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

        void ChangeArrayCapacity(int ItemCount)
        {
            var length = (Capacity > ItemCount) ? ItemCount : Length;
            
            var newArray = new T[Helper.Number.GetRankOfTwo(ItemCount)];
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
