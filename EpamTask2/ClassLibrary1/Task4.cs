using System;

namespace CustomString
{
    public class Task4
    {
        public bool _inProgress;
        public MyString myString;

        public Task4()
        {
            myString = new MyString("");
            _inProgress = true;
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
                    _search();
                    break;

                case ConsoleKey.D3:
                    _start();
                    _compare();
                    break;

                case ConsoleKey.Escape:
                    return false;
            }
            return true;
        }

        public void _add()
        {
            Console.WriteLine("Write string for add");
            myString.Concatenation(Console.ReadLine());
            _menu();
            Console.WriteLine("\nResult string:\n" + myString.GetString());
        }

        public void _menu()
        {
            Console.Clear();
            Console.WriteLine("Task 2.4. My string\n" +
                "\nPress key 1 - Concatenation" +
                "\n          2 - Search char" +
                "\n          3 - Сompare strings" +
                "\n          ESC - Back to menu" +
                "\n---------------------------------\n" +
                "Now string is: " + myString.GetString() +
                "\n---------------------------------\n");

        }

        public void _start()
        {
            Console.Clear();
            _menu();
        }

        public void _view()
        {
            Console.WriteLine(myString.GetString());
        }

        public void _compare()
        {
            Console.WriteLine("Write string for compare");
            var result = (myString.Compare(Console.ReadLine())) ? "equals" : "not equals";
            Console.WriteLine("Strings is " + result);
        }

        public void _search()
        {
            Console.WriteLine("Write char for search");
            var result = myString.SearchCharFisrt(Console.ReadKey().KeyChar);
            string str = (result >= 0)? ("Same char at index " + result) : "String isnt have this char";
            Console.WriteLine(str);
        }
        
    }
}
