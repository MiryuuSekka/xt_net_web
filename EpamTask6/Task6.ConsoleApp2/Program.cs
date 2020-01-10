using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.ConsoleApp2
{
    class Program
    {
        static ConsoleKey Key;
        static BLL.Interface.IDataLogic<User> UserLogic;

        static void Main(string[] args)
        {
            //UserLogic = new BLL.UserLogic();
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
                Text.AppendLine("TASK 6.2");
                Text.AppendLine();
                Text.AppendLine("Press <<Esc>> to exit");
                Text.AppendLine("Press <<1>> to Show all users");
                Text.AppendLine("Press <<2>> to add user");
                Text.AppendLine("Press <<3>> to delete user");

                Text.AppendLine("Press <<4>> to Show all awards");
                Text.AppendLine("Press <<5>> to add awards");
                Text.AppendLine("Press <<6>> to delete awards");

                ShowNewScreen(Text.ToString());
                Key = Console.ReadKey().Key;
                switch (Key)
                {
                    default:
                        break;

                    case ConsoleKey.D1:
                        ShowAllUserData();
                        break;

                    case ConsoleKey.D2:
                        AddUser();
                        break;

                    case ConsoleKey.D3:
                        DeleteUser();
                        break;

                    case ConsoleKey.D4:
                        ShowAllAwardData();
                        break;

                    case ConsoleKey.D5:
                        AddAward();
                        break;

                    case ConsoleKey.D6:
                        DeleteAward();
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
                NewUser = User.Parse(name, date, UserLogic.GetAll());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong data. {e.Message}");
                return;
            }

            Console.WriteLine("If you want add awards to user press <<Y>>");
            var answer = Console.ReadKey().Key;
            if (answer.Equals(ConsoleKey.Y))
            {
                UserLogic.AddData(NewUser);
            }

            Console.WriteLine("New user data is:");
            ShowUser(NewUser);
            Console.WriteLine("If its correct press <<Y>>");
            answer = Console.ReadKey().Key;
            if (answer.Equals(ConsoleKey.Y))
            {
                UserLogic.AddData(NewUser);
            }
            else
            {
                Console.WriteLine("canselled");
            }


            Console.ReadKey();
        }

        static void AddAward()
        {
            var NewAward = new Award();
            ShowNewScreen("Write title");
            var title = Console.ReadLine();
            try
            {
              //  NewAward = Award.Parse(title, AwardLogic.GetAll().ToList());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("New award data is:");
            ShowAward(NewAward);
            Console.WriteLine("If its correct press <<Y>>");
            var answer = Console.ReadKey().Key;
            if (answer.Equals(ConsoleKey.Y))
            {
              //  AwardLogic.AddData(NewAward);
            }
            else
            {
                Console.WriteLine("canselled");
            }
            Console.ReadKey();
        }

        static void DeleteUser()
        {
            ShowNewScreen("Write Id");
            var answer = Console.ReadLine();
            int.TryParse(answer, out int Id);
            try
            {
                UserLogic.DeleteById(Id);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong data. {e.Message}");
                return;
            }
            Console.WriteLine("User Deleted");
            Console.ReadKey();
        }
        
        static void DeleteAward()
        {
            ShowNewScreen("Write Id");
            var answer = Console.ReadLine();
            int.TryParse(answer, out int Id);
            try
            {
                //AwardLogic.DeleteById(Id);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Wrong data. {e.Message}");
                return;
            }
            Console.WriteLine("User Deleted");
            Console.ReadKey();
        }

        static void ShowAllUserData()
        {
            var Result = UserLogic.GetAll();
            ShowNewScreen("User data list:");
            foreach (var item in Result)
            {
                ShowUser(item);
            }
            Console.WriteLine("----------------\nIts all");
            Console.ReadKey();
        }

        static void ShowAllAwardData()
        {/*
            var Result = AwardLogic.GetAll();
            ShowNewScreen("Award data list:");
            foreach (var item in Result)
            {
                ShowAward(item);
            }*/
            Console.WriteLine("----------------\nIts all");
            Console.ReadKey();
        }

        static void ShowUser(User user)
        {
            Console.WriteLine($"     Id: {user.Id}");
            Console.WriteLine($"     Name: {user.Name}");
            Console.WriteLine($"     Age: {user.Age}");
            Console.WriteLine($"     BirthDay: {user.BirthDay.Date.Day}.{user.BirthDay.Date.Month}.{user.BirthDay.Date.Year}");
           // var AwardList = GetAwards(user.Id);
           // foreach (var item in AwardList) Console.WriteLine();
            Console.WriteLine();
        }

        static void ShowAward(Award award)
        {
            Console.WriteLine($"     Id: {award.Id}");
            Console.WriteLine($"     Title: {award.Title}");
            Console.WriteLine();
        }

        
    }
}

