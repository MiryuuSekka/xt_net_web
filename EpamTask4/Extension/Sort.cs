using System;
using System.Linq;
using System.Threading;

namespace Extension
{
    public class Sort<T>
    {
        public event EventHandler Finished;
        Thread CalculatingThread;

        public Func<T, T, bool> PrimarySortMethod = (x, y) => (x.ToString().Length < y.ToString().Length);

        public Func<T, T, bool> SecondarySortMethod = (x, y) => ((x.ToString().Length == y.ToString().Length) &&
                                                                    (x.ToString().Max() < y.ToString().Max()));



        public void DoSort(T[] array, Func<T, T, bool> PrimarySort, Func<T, T, bool> SecondarySort)
        {
            if (PrimarySort == null || SecondarySort == null)
            {
                throw new ArgumentNullException();
            }

            var Length = array.Length;

            for (int i = 1, count = 0; i < Length; i++)
            {
                count = i;
                while (count > 0 && (PrimarySort(array[count], array[count - 1]) || SecondarySort(array[count], array[count - 1])))
                {
                    var ReplaceItem = array[count];
                    array[count] = array[count - 1];
                    array[count - 1] = ReplaceItem;
                    count--;
                }
            }
            try
            {
                Finished.Invoke(this, EventArgs.Empty);
            }
            catch (Exception)
            {
                return;
            }
        }

        void SecondModule_Finished(object sender, EventArgs e)
        {
            Finished -= new EventHandler(SecondModule_Finished);
            Console.WriteLine("Sorted");
        }

        public void CreateThread(T[] array, Func<T, T, bool> PrimarySort, Func<T, T, bool> SecondarySort)
        {
            CalculatingThread = new Thread(() => this.DoSort(array, PrimarySort, SecondarySort));
            Finished += new EventHandler(SecondModule_Finished);
            CalculatingThread.Start();
        }

    }
}
