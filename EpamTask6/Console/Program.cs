using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static ConsoleKey Key;
        static Task6.BLL.UserLogic Logic;

        static void Main(string[] args)
        {
            Logic = new Task6.BLL.UserLogic();
            Menu();
        }

        static void ShowNewScreen(string Text)
        {
            Console.Clear();
            Console.WriteLine(Text);
        }

        static void Menu()
        {
            var Text = new StringBuilder();
            Text.AppendLine("TASK 6");
            Text.AppendLine();
            Text.AppendLine("Press <<Esc>> to exit");
            Text.AppendLine("Press <<1>> to Show all users");
            Text.AppendLine("Press <<2>> to add user");
            Text.AppendLine("Press <<3>> to delete user");

            ShowNewScreen(Text.ToString());

            do
            {
                Key = Console.ReadKey().Key;
                switch (Key)
                {
                    default:
                        break;

                    case ConsoleKey.D1:
                        ShowResult();
                        break;

                    case ConsoleKey.D2:
                        AddUser();
                        break;

                    case ConsoleKey.D3:
                        Delete();
                        break;
                }
            } while (Key != ConsoleKey.Escape);
        }

        static void AddUser()
        {
            ShowNewScreen("Write name");
            var name = Console.ReadLine();

            ShowNewScreen("Write BirthDate at format like 16.04.2019 (DD.MM.YYYY)");
            var date = Console.ReadLine();

            //
            Console.WriteLine("New user data is - {0}", 0);
            Console.WriteLine("If its correct press <<Y>>");
            var answer = Console.ReadKey().Key;
            if (answer.Equals(ConsoleKey.Y))
            {
                //
            }
            else
            {
                Console.WriteLine("canselled");
            }
        }

        static void Delete()
        {
            ShowNewScreen("Write Id");
            Console.ReadLine();
            //
            Console.WriteLine("User Deleted");
        }

        static void ShowResult()
        {
            //
        }
    }
}
