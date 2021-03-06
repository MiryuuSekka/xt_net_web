﻿using Logic.Classes;
using Logic.Classes.Enemies;
using Logic.Classes.Items;
using Logic.Classes.Walls;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Visual
{
    public class Menu
    {
        Logic.Menu game;
        List<IIMapObject> map;

        public Menu()
        {

            game = new Logic.Menu();
            ConsoleKey Pressed;
            do
            {
                PrintMap();
                PrintPlayerData();
                Pressed = Console.ReadKey().Key;

                var direction = GetAction(Pressed);
                game.NextTurn(direction);
            }
            while (!Pressed.Equals(ConsoleKey.Escape));
        }

        public void PrintMap()
    {
            ShowMenu();
            map = game.GetMap();
            int? index;
            for (int i = 0; i < game.GetWidth(); i++)
            {
                for (int j = 0; j < game.GetHeight(); j++)
                {
                    index = GetIndex(i, j);
                    if (index.HasValue)
                    {
                        WriteSymbol(map[index.Value]);
                    }
                    else
                    {
                        WriteSymbol(null);
                    }
                }
                Console.WriteLine();
            }
        }

        Logic.Menu.Direction GetAction(ConsoleKey Pressed)
        {
            Logic.Menu.Direction direction;
            switch (Pressed)
            {
                default:
                    direction = Logic.Menu.Direction.None;
                    break;

                case ConsoleKey.LeftArrow:
                    direction = Logic.Menu.Direction.Left;
                    break;

                case ConsoleKey.RightArrow:
                    direction = Logic.Menu.Direction.Right;
                    break;

                case ConsoleKey.UpArrow:
                    direction = Logic.Menu.Direction.Up;
                    break;

                case ConsoleKey.DownArrow:
                    direction = Logic.Menu.Direction.Down;
                    break;
            }
            return direction;
        }

        void ShowMenu()
        {
            Console.Clear();
            var str = new StringBuilder();
            Console.WriteLine("Task 2.8 - Game\nstandart map size - 50x25");

            WriteSymbol(new Player(null, null));
            Console.WriteLine(" - player");

            WriteSymbol(new Tree(null));
            Console.Write(" - Tree,     ");
            WriteSymbol(new Rock(null));
            Console.WriteLine(" - Rock, ");

            WriteSymbol(new Apple(null));
            Console.Write(" - Apple,    ");
            WriteSymbol(new Cherry(null));
            Console.WriteLine(" - Cherry, ");

            WriteSymbol(new Bear(null));
            Console.Write(" - Bear,     ");
            WriteSymbol(new Wolf(null));
            Console.WriteLine(" - Wolf ");
              
            Console.WriteLine("<<< press ESC for back to menu >>>\n"); 
        }

        void PrintPlayerData()
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

        char GetSymbol(IIMapObject type)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.OutputEncoding = Encoding.Unicode;
            if (type != null)
            {
                switch (type.GetType().FullName)
                {
                    default:
                        break;

                    case "Logic.Classes.Player":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        return '\u263B'; //Player

                    case "Logic.Classes.Walls.Tree":
                        Console.ForegroundColor = ConsoleColor.White;
                        return '\u25B2'; //tree

                    case "Logic.Classes.Walls.Rock":
                        Console.ForegroundColor = ConsoleColor.Black;
                        return '\u25B2'; //rock

                    case "Logic.Classes.Items.Cherry":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        return '\u058D'; //cherry

                    case "Logic.Classes.Items.Apple":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        return '\u058D'; //apple

                    case "Logic.Classes.Enemies.Wolf":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        return '\u25BC'; //wolf

                    case "Logic.Classes.Enemies.Bear":
                        Console.ForegroundColor = ConsoleColor.Red;
                        return '\u25BC'; //bear
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            return ' ';
        }

        void WriteSymbol(IIMapObject type)
        {
            Console.Write(GetSymbol(type));
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
