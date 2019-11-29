using System;

namespace Graphics
{
    public class Task6 : Helper.Task<Ring>
    {
        public override string TaskTitle()
        {
            return "Task 2.6 - RING";
        }

        public override void AddToList()
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
        
    }
}
