using System;

namespace Graphics
{
    public class Task1 : FigureTask<Round>
    {
        internal override string _menu()
        {
            return "Task 2.1. Round\n" +
               "\nPress key 1 - Create new Round" +
               "\n          2 - View created Rounds" +
               "\n          3 - Clear created Rounds" +
               "\n          4 - Back to menu" +
               "\n---------------------------------\n";
        }

        internal override void _add()
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
    }
}
