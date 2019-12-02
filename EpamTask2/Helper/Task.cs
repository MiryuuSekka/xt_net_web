using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public abstract class Task<T> where T: IInfo
    {
        public List<T> Data;

        public abstract string TaskTitle();

        public Task()
        {
            ConsoleKey Pressed;
            Data = new List<T>();
            ShowMenu();
            do
            {
                Pressed = Console.ReadKey().Key;
                Action(Pressed);
            }
            while (!Pressed.Equals(ConsoleKey.Escape));
        }

        void Action(ConsoleKey Pressed)
        {
            switch (Pressed)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    ShowMenu();
                    AddToList();
                    break;

                case ConsoleKey.D2:
                    ShowMenu();
                    View();
                    break;

                case ConsoleKey.D3:
                    ShowMenu();
                    Delete();
                    break;
            }
        }

        public abstract void AddToList();

        public void ShowMenu()
        {
            Console.Clear();
            var str = new StringBuilder();

            str.AppendLine(TaskTitle());
            str.AppendLine("Press key 1   - Create new");
            str.AppendLine("          2   - View created");
            str.AppendLine("          3   - Clear created");
            str.AppendLine("          ESC - Back to menu");
            str.AppendLine("---------------------------------");

            Console.WriteLine(str.ToString());
        }

        void Delete()
        {
            Data.Clear();
        }

        void View()
        {
            var str = new StringBuilder();
            foreach (var item in Data)
            {
                str.Append(item.GetInfo());
            }
            Console.WriteLine("\n" + str.ToString());
        }

        public int ShowInfo(string str)
        {
            Console.WriteLine(str);
            str = Console.ReadLine();
            int.TryParse(str, out int value);
            return value;
        }
    }
}
