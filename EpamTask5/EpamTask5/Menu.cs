using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EpamTask5
{
    public class Menu
    {
        Logger.Main Loginator;
        Logger.FolderManager Watcher;
        ConsoleKey Key;

        public Menu()
        {
            Watcher = new Logger.FolderManager();
            Loginator = new Logger.Main();

            do
            {
                ShowMenu();
                Key = Console.ReadKey().Key;
                if (Key == ConsoleKey.Escape)
                {
                    Watcher.End();
                }

                if (Key == ConsoleKey.D1)
                {
                    StartWrite();
                }

                if (Key == ConsoleKey.D2)
                {
                    StartRead();
                }
            } while (Key != ConsoleKey.Escape);
        }


        void ShowMenu()
        {
            Console.Clear();

            Console.WriteLine("TASK 5");
            Console.WriteLine("select mode <PRESS key>");

            Console.WriteLine(" < 1 >       Write Log");
            Console.WriteLine(" < 2 >       Read Log");
            Console.WriteLine("< ESC >        Exit");

            Console.WriteLine("\n");
        }



        void StartRead()
        {
            Watcher.Start();
            ReadLogMain();

            ConsoleKey Key;
            do
            {
                Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.Escape:
                        Watcher.End();
                        ShowMenu();
                        break;

                    case ConsoleKey.D1:
                        WriteFullLog();
                        break;

                    case ConsoleKey.D2:
                        ReadLogGoTo();
                        break;

                    case ConsoleKey.D3:
                        ReadLogGoTo();
                        break;

                    default:
                        break;
                }
            } while (Key != ConsoleKey.Escape);
        }

        void ReadLogMain()
        {
            Console.Clear();

            Console.WriteLine("TASK 5");
            Console.WriteLine("Read log - mode");
            Console.WriteLine("Now u can:");

            Console.WriteLine(" < 1 >       Get list of changes");
            Console.WriteLine(" < 2 >       Get list of changes BY FILE NAME");
            Console.WriteLine(" < 3 >       Get list of changes BY CHANGE TYPE");
            Console.WriteLine("< ESC >        Back");

            Console.WriteLine("\n");
        }

        void ReadLogGoTo()
        {
            Console.Clear();

            Console.WriteLine("TASK 5");
            Console.WriteLine("Read log - mode");

            Console.WriteLine("Write number of change wat u want turn back");
            Console.WriteLine("write < ESC >        Back");

            Console.WriteLine("\n");
        }

        void WriteFullLog()
        {
            var SearchData = Loginator.GetLog();
            ReadLogMain();

            foreach (var item in SearchData)
            {
                Console.WriteLine("File name: {0}", item.FileName);
                Console.WriteLine("Date: {0}       Change type: {1}", item.Time, item.Action);
                Console.WriteLine("Text: {0}", item.Text);
            }
        }

        void ReadByName()
        {
            ConsoleKey Key;
            bool result = false;
            string Search = "";
            do
            {
                Search = Console.ReadLine();
                var SearchData = Loginator.GetLog().FindAll(x => x.FileName.Equals(Logger.Entry.TargetPath + @"\" + Search + ".txt"));
                foreach (var item in SearchData)
                {
                    Console.WriteLine(item.FileName + " " + item.Action + item.Time);
                }
                Key = Console.ReadKey().Key;
            } while (Key != ConsoleKey.Escape || !result);
        }


        void WriteLog()
        {
            Console.Clear();

            Console.WriteLine("TASK 5");
            Console.WriteLine("Write log - mode");
            Console.WriteLine("Now u can do something with txt files in folder");
            Console.WriteLine("< ESC >        Exit");

            Console.WriteLine("\n");
        }

        void StartWrite()
        {
            Watcher.Start();
            WriteLog();
            ConsoleKey Key;
            do
            {
                Key = Console.ReadKey().Key;
                if (Key == ConsoleKey.Escape)
                {
                    ShowMenu();
                }
            } while (Key != ConsoleKey.Escape);
        }

    }
}

