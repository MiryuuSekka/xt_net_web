using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class Program
    {
        static Task6.BLL.Interface.IMainLogic Logic;
        static ConsoleKey Key;

        static void Main(string[] args)
        {
            Logic = Common.DependencyResolver.GetLogic();
            do
            {
                Menu();
                Key = Console.ReadKey().Key;
            } while (Key != ConsoleKey.Escape);
        }

        static void ShowNewScreen(string Text)
        {
            Console.Clear();
            Console.WriteLine(Text);
        }

        static void Menu()
        {
            do
            {
                var Text = new StringBuilder();
                Text.AppendLine("TASK 6");
                Text.AppendLine();
                Text.AppendLine("Press <<Esc>> to exit");
                Text.AppendLine("Press <<1>> to Show all users");
                Text.AppendLine("Press <<2>> to add user");
                Text.AppendLine("Press <<3>> to delete user");

                ShowNewScreen(Text.ToString());
                Key = Console.ReadKey().Key;
                switch (Key)
                {
                    default:
                        break;

                    case ConsoleKey.D1:
                        ShowAllData();
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
            User NewUser = new User();
            ShowNewScreen("Write name");
            var name = Console.ReadLine();
            ShowNewScreen("Write BirthDate at format like 16.04.2019 (DD.MM.YYYY)");
            var date = Console.ReadLine();
            try
            {
                NewUser = User.Parse(name, date, (IEnumerable<User>)Logic.GetAll());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong data. {e.Message}");
                return;
            }

            Console.WriteLine("New user data is:");
            ShowResult(NewUser);
            Console.WriteLine("If its correct press <<Y>>");
            var answer = Console.ReadKey().Key;
            if (answer.Equals(ConsoleKey.Y))
            {
                Logic.AddData(NewUser);
            }
            else
            {
                Console.WriteLine("canselled");
            }
            Console.ReadKey();
        }

        static void Delete()
        {
            ShowNewScreen("Write Id");
            var answer = Console.ReadLine();
            int.TryParse(answer, out int Id);
            try
            {
                Logic.DeleteById(Id);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong data. {e.Message}");
                return;
            }
            Console.WriteLine("User Deleted");
            Console.ReadKey();
        }

        static void ShowAllData()
        {
            var Result = Logic.GetAll();
            ShowNewScreen("User data list:");
            foreach (var item in Result)
            {
                ShowResult((User)item);
            }
            Console.WriteLine("----------------\nIts all");
            Console.ReadKey();
        }

        static void ShowResult(User user)
        {
            Console.WriteLine($"     Id: {user.Id}");
            Console.WriteLine($"     Name: {user.Name}");
            Console.WriteLine($"     Age: {user.Age}");
            Console.WriteLine($"     BirthDay: {user.BirthDay.Date.Day}.{user.BirthDay.Date.Month}.{user.BirthDay.Date.Year}");
            Console.WriteLine();
        }
    }
}
