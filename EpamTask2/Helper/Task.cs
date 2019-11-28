using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public abstract class Task<T> where T: iInfo
    {
        public bool _inProgress;
        public List<T> _data;

        public Task()
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

        public bool _selectedAction(ConsoleKeyInfo Pressed)
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

        public abstract void _add();

        public abstract string _menu();

        public void _start()
        {
            Console.Clear();
            Console.WriteLine(_menu());
        }

        public void _delete()
        {
            _data.Clear();
        }

        public void _view()
        {
            var str = new StringBuilder();
            foreach (var item in _data)
            {
                str.Append(item.GetInfo());
            }
            Console.WriteLine("\n" + str.ToString());
        }

        public int _getValue(string str)
        {
            Console.WriteLine(str);
            str = Console.ReadLine();
            int.TryParse(str, out int value);
            return value;
        }
    }
}
