﻿using System;
using System.Collections.Generic;

namespace Graphics
{
    public class Task2 : FigureTask<Triangle>
    {
        internal override void _add()
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

        internal override string _menu()
        {
            return "Task 2.2. Triangle\n" +
               "\nPress key 1 - Create new Triangle" +
               "\n          2 - View created Triangles" +
               "\n          3 - Clear created Triangles" +
               "\n          4 - Back to menu" +
               "\n---------------------------------\n";
        }
    }
}
