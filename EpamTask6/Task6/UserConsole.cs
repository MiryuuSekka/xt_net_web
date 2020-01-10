using System;
using Entity;
using BLLInterfaces;

namespace Task6
{
    public class UserConsole
    {
        private IUserBLL BLL;


        public UserConsole()
        {
            BLL = DependencyResolver.Resolver.SelectUserBLL();
        }

        public void Start()
        {
            ActionMenu();
        }



        #region Menu
        private ConsoleKey TextMenu()
        {
            Console.Clear();
            Console.WriteLine("Task 6.1");
            Console.WriteLine("     <<1>> View all Users");
            Console.WriteLine("     <<2>> Add new User");
            Console.WriteLine("     <<3>> Delete User");
            Console.WriteLine("     <<ESC>> return");

            return Console.ReadKey().Key;
        }

        private void ActionMenu()
        {
            ConsoleKey Key;
            do
            {
                Key = TextMenu();

                switch (Key)
                {
                    case ConsoleKey.D1:
                        ActionView();
                        Console.ReadLine();
                        break;

                    case ConsoleKey.D2:
                        ActionAdd();
                        break;

                    case ConsoleKey.D3:
                        ActionDelete();
                        break;

                    default:
                        break;
                }
            } while (Key != ConsoleKey.Escape);
        }
        #endregion

        #region View all
        private void ActionView()
        {
            Console.Clear();
            Console.WriteLine("Users in database:");
            var users = BLL.GetAll();
            foreach (var item in users)
            {
                PrintUserData(item);
            }
        }
        #endregion

        #region Add
        private string[] TextAdd()
        {
            Console.Clear();
            var Text = new string[3];

            Console.WriteLine("Write NAME of user");
            Text[0] = Console.ReadLine();

            Console.WriteLine("Write BirthDate of user (sample: 19.02.1997)");
            Text[1] = Console.ReadLine();

            Console.WriteLine("Write Age of user (U can skip this step --> PRESS <<SPACE>>)");
            Text[2] = Console.ReadLine();

            return Text;
        }

        private void ActionAdd()
        {
            ConsoleKey Key;
            User NewUser = new User();
            string[] Answers;

            do
            {
                Answers = TextAdd();
                try
                {
                    NewUser = User.Parse(BLL.GetAll(), Answers);
                    PrintUserData(NewUser);
                    BLL.AddData(NewUser);
                    Console.WriteLine("Succsessfully added");
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Try again? (Press <<Y>>)");
                    Key = Console.ReadKey().Key;
                }
            } while (Key != ConsoleKey.Escape);
        }
        #endregion

        #region Delete
        private int TextDelete()
        {
            Console.Clear();
            ActionView();
            Console.WriteLine("Write Id of user for delete his data");
            var Id = Console.ReadLine();
            if (Id.Length < 1)
            {
                return 0;
            }
            int.TryParse(Id, out int result);
            return result;
        }

        private void ActionDelete()
        {
            var Id = TextDelete();
            BLL.DeleteById(Id);
        }
        #endregion


        private void PrintUserData(User user)
        {
            Console.WriteLine($"User Id {user.Id}");
            Console.WriteLine($"Name : {user.Name}");
            Console.WriteLine($"BirthDay : {user.BirthDay.Date.Day}.{user.BirthDay.Date.Month}.{user.BirthDay.Date.Year}");
            Console.WriteLine($" ( {user.Age} )");
            Console.WriteLine("------------------------------------");
        }
    }
}
