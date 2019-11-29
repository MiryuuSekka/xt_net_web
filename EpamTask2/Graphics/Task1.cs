using System;

namespace Graphics
{
    public class Task1 : Helper.Task<Round>
    {
        public override string TaskTitle()
        {
            return "Task 2.1 - ROUND";
        }

        public override void AddToList()
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
    }
}
