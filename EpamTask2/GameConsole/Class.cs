﻿using System;
using System.Text;
using System.Collections.Generic;
using Game.Interfaces;
using Game.Classes;
using Game.Classes.Walls;
using Game.Classes.Items;
using Game.Classes.Enemies;

namespace GameConsole
{
    public class Class
    {
        Game.Menu game;
        List<iMapObject> map;

        public Class()
        {

            game = new Game.Menu();
            ConsoleKey Pressed;
            do
            {
                PrintMap();
                printPlayerData();
                Pressed = Console.ReadKey().Key;
            }
            while (!Pressed.Equals(ConsoleKey.Escape));
        }

        public void PrintMap()
        {
            showMenu();
            map = game.GetMap();
            int? index;
            for (int i = 0; i < game.GetWidth(); i++)
            {
                for (int j = 0; j < game.GetHeight(); j++)
                {
                    index = getIndex(i, j);
                    if (index.HasValue)
                    {
                        writeSymbol(map[index.Value]);
                    }
                    else
                    {
                        writeSymbol(null);
                    }
                }
                Console.WriteLine();
            }
        }

        void showMenu()
        {
            Console.Clear();
            var str = new StringBuilder();
            Console.WriteLine("Task 2.8 - Game\nstandart map size - 50x25");

            writeSymbol(new Player(null, null));
            Console.WriteLine(" - player");

            writeSymbol(new Tree(null));
            Console.Write(" - Tree,     ");
            writeSymbol(new Rock(null));
            Console.WriteLine(" - Rock, ");

            writeSymbol(new Apple(null));
            Console.Write(" - Apple,    ");
            writeSymbol(new Cherry(null));
            Console.WriteLine(" - Cherry, ");

            writeSymbol(new Bear(null));
            Console.Write(" - Bear,     ");
            writeSymbol(new Wolf(null));
            Console.WriteLine(" - Wolf ");

            Console.WriteLine("<<< press ESC for back to menu >>>\n");

            str.AppendLine("<<< press ESC for back to menu >>>");
            str.AppendLine();
        }

        void printPlayerData()
        {
            var player = game.GetPlayerData();
            var str = new StringBuilder();
            str.Append("Player name: " + player.Name);
            str.AppendLine("    Score: " + player.Score);
            str.Append("    HP:" + player.Hp);
            str.Append("    AP: "+player.AttackP);
            str.AppendLine("    SP: "+player.SpeedPoint);
            Console.WriteLine(str.ToString());
        }

        int? getIndex(int x, int y)
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

        char getSymbol(iMapObject type)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.OutputEncoding = Encoding.Unicode;
            if (type != null)
            {
                switch (type.GetType().FullName)
                {
                    default:
                        break;

                    case "Game.Classes.Player":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        return '\u263B'; //Player

                    case "Game.Classes.Walls.Tree":
                        Console.ForegroundColor = ConsoleColor.White;
                        return '\u25B2'; //tree

                    case "Game.Classes.Walls.Rock":
                        Console.ForegroundColor = ConsoleColor.Black;
                        return '\u25B2'; //rock

                    case "Game.Classes.Items.Cherry":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        return '\u058D'; //cherry

                    case "Game.Classes.Items.Apple":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        return '\u058D'; //apple

                    case "Game.Classes.Enemies.Wolf":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        return '\u25BC'; //wolf

                    case "Game.Classes.Enemies.Bear":
                        Console.ForegroundColor = ConsoleColor.Red;
                        return '\u25BC'; //bear
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            return ' ';
        }

        void writeSymbol(iMapObject type)
        {
            Console.Write(getSymbol(type));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
