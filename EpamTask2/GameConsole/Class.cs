using System;
using System.Collections.Generic;

namespace GameConsole
{
    public class Class
    {
        Game.Menu _game;
        List<Game.Interfaces.iMapObject> map;
        string TextMenu = "Task 2.8 - Game\n" +
            "\nstandart map size - 50x25" +
            "\nP - player, X - barrier(green - tree, gray - rock)" +
            "\n E - enemies(red - bear, magenta - wolf)" +
            "\n o - items(yellow - apple, cyan - cherry)" +
            "\n\npress ESC for back to menu\n\n";

        public Class()
        {
           _game = new Game.Menu();
            ConsoleKey Pressed;
            do
            {
                PrintMap();
                Pressed = Console.ReadKey().Key;
            }
            while (!Pressed.Equals(ConsoleKey.Escape));
        }

        public void PrintMap()
        {
            Console.Clear();
            Console.WriteLine(TextMenu);
            map = _game.GetMap();
            int? index;
            for (int i = 0; i < _game.GetWidth(); i++)
            {
                for (int j = 0; j < _game.GetHeight(); j++)
                {
                    index = GetIndex(i, j);
                    if (index.HasValue)
                    {
                        Console.Write(GetSymbol(map[index.Value]));
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write('|');
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        int? GetIndex(int x, int y)
        {
            for (int i = 0; i < map.Count; i++)
            {
                if (map[i].Position.X == x && map[i].Position.Y == y)
                {
                    return i;
                }
            }
            return null;
        }

        char GetSymbol(Game.Interfaces.iMapObject type)
        {
            switch (type.GetType().ToString())
            {
                default:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    return '|';

                case "Game.Classes.Player":
                    Console.ForegroundColor = ConsoleColor.White;
                    return 'P'; //Player

                case "Game.Classes.Walls.Tree":
                    Console.ForegroundColor = ConsoleColor.Green;
                    return 'X'; //tree

                case "Game.Classes.Walls.Rock":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    return 'X'; //rock

                case "Game.Classes.Items.Cherry":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    return 'o'; //cherry

                case "Game.Classes.Items.Apple":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return 'o'; //apple

                case "Game.Classes.Enemies.Wolf":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    return 'E'; //wolf

                case "Game.Classes.Enemies.Bear":
                    Console.ForegroundColor = ConsoleColor.Red;
                    return 'E'; //bear
            }
        }
    }
}
