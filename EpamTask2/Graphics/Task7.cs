using System;

namespace Graphics
{
    public class Task7 : Helper.Task<iFigure>
    {
        public override string TaskTitle()
        {
            return "Task 2.7 - VECTOR GRAPHICS EDITOR";
        }

        public override void AddToList()
        {
            Console.WriteLine(figuresMenu());
            switch(Console.ReadKey().Key)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    addRound();
                    break;

                case ConsoleKey.D2:
                    addRing();
                    break;

                case ConsoleKey.D3:
                    addTrinagle();
                    break;

                case ConsoleKey.D4:
                    ShowMenu();
                    break;
            }
        }

        void addRound()
        {
            var x = ShowInfo("Write X coordinate of center");
            var y = ShowInfo("Write Y coordinate of center");
            var radius = ShowInfo("Write radius of round (Value must be above 0)");
            try
            {
                Data.Add(new Round(new Point(x, y), radius));
                ShowMenu();
                Console.WriteLine("Added new round");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void addTrinagle()
        {
            Console.WriteLine("Values must be above 0");
            var a = ShowInfo("Write lenght of side \"a\" of triangle");
            var b = ShowInfo("Write lenght of side \"b\" of triangle");
            var c = ShowInfo("Write lenght of side \"c\" of triangle");

            try
            {
                Data.Add(new Triangle(a, b, c));
                ShowMenu();
                Console.WriteLine("Added new triangle");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void addRing()
        {
            var x = ShowInfo("Write X coordinate of center");
            var y = ShowInfo("Write Y coordinate of center");
            Console.WriteLine("Values must be above 0, and cant be equals");
            var radius1 = ShowInfo("Write radius of first round");
            var radius2 = ShowInfo("Write radius of second round");

            try
            {
                var center = new Point(x, y);
                var Round1 = new Round(center, radius1);
                var Round2 = new Round(center, radius2);
                Data.Add(new Ring(Round1, Round2));
                ShowMenu();
                Console.WriteLine("Added new ring");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        string figuresMenu()
        {
            Console.Clear();
            return "Task 2.7 - VECTOR GRAPHICS EDITOR\n" +
               "\n Add figure" +
               "\nPress key 1 - Round" +
               "\n          2 - Ring" +
               "\n          3 - Triangle" +
               "\n          ESC - Back to menu" +
               "\n---------------------------------\n";
        }
    }
}
