using System;
using System.Collections.Generic;
using System.Text;

namespace Graphics
{
    public class Task1
    {
        bool IsProgress = true;
        List<Round> data;

        public Task1()
        {
            data = new List<Round>();
            Start();
            do
            {
                IsProgress = SelectAction(Console.ReadKey());
            }
            while(IsProgress);
        }

        void Start()
        {
            Console.Clear();
            Console.WriteLine("Task 2.1. Round\n");
            Console.WriteLine("Press key 1 - Create new Round");
            Console.WriteLine("          2 - View created Rounds");
            Console.WriteLine("          3 - Clear created Rounds");
            Console.WriteLine("          4 - Back to menu");
            Console.WriteLine("---------------------------------\n");
        }

        bool SelectAction(ConsoleKeyInfo Pressed)
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
                    View();
                    break;

                case ConsoleKey.D3:
                    Start();
                    Delete();
                    break;

                case ConsoleKey.D4:
                    return false;
            }
            return true;
        }

        void Add()
        {
            int x = 0, y = 0, radius = 0;
            string str;

            Console.WriteLine("Write X coordinate of center");
            str = Console.ReadLine();
            int.TryParse(str, out x);
            Console.WriteLine("Write Y coordinate of center");
            str = Console.ReadLine();
            int.TryParse(str, out y);
            Console.WriteLine("Write radius of round (Value must be above 0)");
            str = Console.ReadLine();
            int.TryParse(str, out radius);

            data.Add(new Round(new Point(x, y), radius));
        }

        void Delete()
        {
            data.Clear();
        }

        void View()
        {
            var str = new StringBuilder();
            foreach (var item in data)
            {
                str.Append("\nRound - Center at { " + item.GetCenter().X);
                str.Append(" ; " + item.GetCenter().Y + " }, ");
                str.Append("Radius is " + item.GetRadius() + ", ");
                str.Append("Lenght is " + item.GetLength() + ", ");
                str.Append("Area is " + item.GetArea());
            }
            Console.WriteLine("\n" + str.ToString());
        }

    }
}
