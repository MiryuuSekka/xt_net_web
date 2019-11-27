using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics
{
    abstract public class FigureTask<T> where T: iFigure
    {
        internal bool _inProgress;
        internal List<T> _data;

        public FigureTask()
        {
            _inProgress = true;
            _data = new List<T>();
            _start();
            do
            {
                _inProgress = _selectedAction(Console.ReadKey());
            }
            while (_inProgress);
        }

        internal bool _selectedAction(ConsoleKeyInfo Pressed)
        {
            switch (Pressed.Key)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    _start();
                    _add();
                    break;

                case ConsoleKey.D2:
                    _start();
                    _view();
                    break;

                case ConsoleKey.D3:
                    _start();
                    _delete();
                    break;

                case ConsoleKey.Escape:
                    return false;
            }
            return true;
        }

        abstract internal void _add();

        abstract internal string _menu();

        internal void _start()
        {
            Console.Clear();
            Console.WriteLine(_menu());
        }

        internal void _delete()
        {
            _data.Clear();
        }

        internal void _view()
        {
            var str = new StringBuilder();
            foreach (var item in _data)
            {
                str.Append(item.GetInfo());
            }
            Console.WriteLine("\n" + str.ToString());
        }

        internal int _getValue(string str)
        {
            Console.WriteLine(str);
            str = Console.ReadLine();
            int.TryParse(str, out int value);
            return value;
        }
    }
}
