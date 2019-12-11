using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Extension
{
    public delegate List<T> Function<T>(List<T> array);

    public class SortTask1
    {
        Stopwatch timer;

        public SortTask1()
        {
            timer = new Stopwatch();
        }

        public long GetTime()
        {
            return timer.ElapsedTicks;
        }


        /// <summary>
        /// Task 4.1
        /// Increase cort metod
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public List<T> CustomIncreaseSort<T>(List<T> array)
        {
            return array.OrderBy(x => x).ToList<T>();
        }

        /// <summary>
        /// Task 4.1
        /// Descrease cort metod
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns>result</returns>
        public List<T> CustomDescreaseSort<T>(List<T> array)
        {
            return array.OrderByDescending(x => x).ToList<T>();
        }


        public List<T> DoSort<T>(List<T> array, Function<T> SortType)
        {
            timer.Restart();

            var LastArray = SortType(array);

            timer.Stop();
            return LastArray;
        }
    }
}
