using System;

namespace Graphics
{
    public class Task7 : Helper.Task<iFigure>
    {
        public override void _add()
        {
            Console.WriteLine(_figuresMenu());
            switch(Console.ReadKey().Key)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    _addRound();
                    break;

                case ConsoleKey.D2:
                    _addRing();
                    break;

                case ConsoleKey.D3:
                    _addTrinagle();
                    break;

                case ConsoleKey.D4:
                    _start();
                    break;
            }
        }

        void _addRound()
        {
            var x = _getValue("Write X coordinate of center");
            var y = _getValue("Write Y coordinate of center");
            var radius = _getValue("Write radius of round (Value must be above 0)");
            try
            {
                _data.Add(new Round(new Point(x, y), radius));
                _start();
                Console.WriteLine("Added new round");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void _addTrinagle()
        {
            Console.WriteLine("Values must be above 0");
            var a = _getValue("Write lenght of side \"a\" of triangle");
            var b = _getValue("Write lenght of side \"b\" of triangle");
            var c = _getValue("Write lenght of side \"c\" of triangle");

            try
            {
                _data.Add(new Triangle(a, b, c));
                _start();
                Console.WriteLine("Added new triangle");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void _addRing()
        {
            var x = _getValue("Write X coordinate of center");
            var y = _getValue("Write Y coordinate of center");
            Console.WriteLine("Values must be above 0, and cant be equals");
            var radius1 = _getValue("Write radius of first round");
            var radius2 = _getValue("Write radius of second round");

            try
            {
                var center = new Point(x, y);
                var Round1 = new Round(center, radius1);
                var Round2 = new Round(center, radius2);
                _data.Add(new Ring(Round1, Round2));
                _start();
                Console.WriteLine("Added new ring");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        string _figuresMenu()
        {
            Console.Clear();
            return "Task 2.7. VECTOR GRAPHICS EDITOR\n" +
               "\n Add figure" +
               "\nPress key 1 - Round" +
               "\n          2 - Ring" +
               "\n          3 - Triangle" +
               "\n          ESC - Back to menu" +
               "\n---------------------------------\n";
        }

        public override string _menu()
        {
            return "Task 2.7. VECTOR GRAPHICS EDITOR\n" +
               "\nPress key 1 - Create new figure" +
               "\n          2 - View created figures" +
               "\n          3 - Clear created figures" +
               "\n          4 - Back to menu" +
               "\n---------------------------------\n";
        }
    }
}
