using System;

namespace Graphics
{
    public class Task6 : FigureTask<Ring>
    {
        internal override void _add()
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

        internal override string _menu()
        {
            return "Task 2.6. Ring\n" +
               "\nPress key 1 - Create new Ring" +
               "\n          2 - View created Rings" +
               "\n          3 - Clear created Rings" +
               "\n          4 - Back to menu" +
               "\n---------------------------------\n";
        }
    }
}
