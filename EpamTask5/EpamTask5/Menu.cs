using System;
using System.IO;

namespace EpamTask5
{
    public class MenuMain
    {
        internal Logger.Main Loginator;
        internal Logger.FolderManager Watcher;
        internal ConsoleKey Key;

        internal void ShowMenu(int N)
        {
            Console.Clear();
            switch (N)
            {
                case 0:
                    Console.WriteLine("TASK 5 \nselect mode <PRESS key>");
                    Console.WriteLine("< 1 >       Write Log");
                    Console.WriteLine("< 2 >       Read Log");
                    Console.WriteLine("< ESC >        Exit");
                    break;

                case 1:
                    Console.WriteLine("TASK 5 \nRead log - mode \nNow u can:");
                    Console.WriteLine(" < 1 >       Get list of changes");
                    Console.WriteLine(" < 2 >       Return change by date");
                    Console.WriteLine("< ESC >        Back");
                    break;

                case 2:
                    Console.WriteLine("TASK 5\nRead log - mode");
                    Console.WriteLine("Write date of change wat u want back to");
                    break;

                case 3:
                    Console.WriteLine("TASK 5 \nWrite log - mode");
                    Console.WriteLine("Now u can do something with txt files in folder");
                    Console.WriteLine("< ESC >        Exit");
                    break;

                default:
                    break;
            }
        }

        public MenuMain()
        {
            Watcher = new Logger.FolderManager();
            Loginator = new Logger.Main();

            do
            {
                Watcher.End();
                ShowMenu(0);
                Key = Console.ReadKey().Key;

                if (Key == ConsoleKey.D1)
                {
                    MenuWrite();
                }

                if (Key == ConsoleKey.D2)
                {
                    MenuRead();
                }
            } while (Key != ConsoleKey.Escape);
        }

        internal void MenuRead()
        {
            ShowMenu(1);

            ConsoleKey Key;
            do
            {
                Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.Escape:
                        ShowMenu(0);
                        break;

                    case ConsoleKey.D1:
                        ShowMenu(1);
                        WriteFullLog();
                        break;

                    case ConsoleKey.D2:
                        MenuRecover();
                        break;

                    default:
                        break;
                }
            } while (Key != ConsoleKey.Escape);
        }

        internal void MenuRecover()
        {
            ShowMenu(2);
            WriteFullLog();
            Console.WriteLine("sample is \"21.12.2019 14:07:04\"");

            string str = "";
            do
            {
                str = Console.ReadLine();
                DateTime.TryParse(str, out DateTime date);
                var SearchResult = Loginator.EntryLog.Find(x => x.Time.Date.Equals(date.Date)
                                                               && x.Time.Hour.Equals(date.Hour)
                                                               && x.Time.Minute.Equals(date.Minute)
                                                               && x.Time.Second.Equals(date.Second));
                if (SearchResult != null)
                {
                    Loginator.BackToChangeManager(SearchResult);
                    Console.WriteLine("File was returned at this change status");
                    Console.WriteLine("u can write new date");
                }

            } while (str.Equals("ESC") || str.Equals("ecs"));
        }

        internal void MenuWrite()
        {
            Watcher.Start();
            ShowMenu(3);
            ConsoleKey Key;
            do
            {
                Key = Console.ReadKey().Key;
                if (Key == ConsoleKey.Escape)
                {
                    ShowMenu(0);
                }
            } while (Key != ConsoleKey.Escape);
        }


        internal void WriteFullLog()
        {
            var SearchData = Loginator.GetLog();
            Console.WriteLine("======================================================");
            Console.WriteLine("Log: ");
            foreach (var item in SearchData)
            {
                if (item.Action != WatcherChangeTypes.All)
                {
                    Console.WriteLine("\nFile name: {0}", item.FileName);
                    Console.WriteLine("Date: {0}       Change type: {1}", item.Time, item.Action);
                    Console.WriteLine("Text: {0}", item.Text);
                }
            }
            Console.WriteLine("======================================================");
        }

        internal void ReadByName()
        {
            ConsoleKey Key;
            bool result = false;
            string Search = "";
            do
            {
                Search = Console.ReadLine();
                Search = Logger.Entry.TargetPath + @"\" + Search + ".txt";
                var SearchData = Loginator.GetLog().FindAll(x => x.FileName.Equals(Search));
                foreach (var item in SearchData)
                {
                    Console.WriteLine(item.FileName + " " + item.Action + item.Time);
                }
                Key = Console.ReadKey().Key;
            } while (Key != ConsoleKey.Escape || !result);
        }

    }
}

