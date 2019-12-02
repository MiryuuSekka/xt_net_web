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
            Start();
            do
            {
                _inProgress = SelectedAction(Console.ReadKey());
            }
            while (_inProgress);
        }

        public bool SelectedAction(ConsoleKeyInfo Pressed)
        {
            switch (Pressed.Key)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    Start();
                    Add();
                    break;

                case ConsoleKey.D2:
                    Start();
                    Search();
                    break;

                case ConsoleKey.D3:
                    Start();
                    Compare();
                    break;

                case ConsoleKey.Escape:
                    return false;
            }
            return true;
        }

        public void Add()
        {
            Console.WriteLine("Write string for add");
            myString.Concatenation(Console.ReadLine());
            Menu();
            Console.WriteLine("\nResult string:\n" + myString.GetString());
        }

        public void Menu()
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

        public void Start()
        {
            Console.Clear();
            Menu();
        }

        public void View()
        {
            Console.WriteLine(myString.GetString());
        }

        public void Compare()
        {
            Console.WriteLine("Write string for compare");
            var result = (myString.Compare(Console.ReadLine())) ? "equals" : "not equals";
            Console.WriteLine("Strings is " + result);
        }

        public void Search()
        {
            Console.WriteLine("Write char for search");
            var result = myString.SearchCharFisrt(Console.ReadKey().KeyChar);
            string str = (result >= 0)? ("Same char at index " + result) : "String isnt have this char";
            Console.WriteLine(str);
        }
        
    }
}
