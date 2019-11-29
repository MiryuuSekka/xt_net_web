using System;

namespace Graphics
{
    public class Task2 : Helper.Task<Triangle>
    {
        public override string TaskTitle()
        {
            return "Task 2.2 - TRIANGLE";
        }

        public override void AddToList()
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
    }
}
