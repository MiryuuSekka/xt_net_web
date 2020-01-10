using System;
using BLLInterfaces;
using Entity;
using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    class AwardConsole
    {
        private IAwardBLL BLL;

        public AwardConsole()
        {
            BLL = DependencyResolver.Resolver.SelectAwardBLL();
        }


        public void Start()
        {
            ActionMenu();
        }



        #region Menu
        private ConsoleKey TextMenu()
        {
            Console.Clear();
            Console.WriteLine("Task 6.2");
            Console.WriteLine("     <<1>> View all Users");
            Console.WriteLine("     <<2>> View all Awards");

            Console.WriteLine("     <<3>> Add new User");
            Console.WriteLine("     <<4>> Add new Award");

            Console.WriteLine("     <<5>> Award -to-> Users");
            Console.WriteLine("     <<6>> Awards -to-> User");

            Console.WriteLine("     <<7>> Delete User");
            Console.WriteLine("     <<8>> Delete Award");

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
                        ActionViewUsers();
                        Console.ReadLine();
                        break;

                    case ConsoleKey.D2:
                        ActionViewAwards();
                        Console.ReadLine();
                        break;

                    case ConsoleKey.D3:
                        ActionAddUser();
                        break;

                    case ConsoleKey.D4:
                        ActionAddAward();
                        break;

                    case ConsoleKey.D5:
                        ActionGiveToManyUsers();
                        break;

                    case ConsoleKey.D6:
                        ActionGiveManyAwards();
                        break;

                    case ConsoleKey.D7:
                        ActionDeleteUser();
                        break;

                    case ConsoleKey.D8:
                        ActionDeleteAward();
                        break;

                    default:
                        break;
                }
            } while (Key != ConsoleKey.Escape);
        }
        #endregion

        #region View
        void ActionViewUsers()
        {
            Console.Clear();
            Console.WriteLine("Users in database:");
            var users = BLL.GetAllUsers();
            foreach (var item in users)
            {
                PrintUserData(item);
            }
        }

        void ActionViewAwards()
        {
            Console.Clear();
            Console.WriteLine("Users in database:");
            var awards = BLL.GetAllAwards();
            foreach (var item in awards)
            {
                PrintAwardData(item);
            }
        }
        #endregion

        #region Add
        private string[] TextAddUser()
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

        private string TextAddAward()
        {
            Console.Clear();
            Console.WriteLine("Write Title of award");
            return Console.ReadLine();
        }

        void ActionAddAward()
        {
            ConsoleKey Key;
            Award NewAward = new Award();
            string Answer;

            do
            {
                Answer = TextAddAward();
                try
                {
                    NewAward = Award.Parse(BLL.GetAllAwards(), Answer);
                    PrintAwardData(NewAward);
                    BLL.AddAward(NewAward);
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

        void ActionAddUser()
        {
            ConsoleKey Key;
            User NewUser = new User();
            string[] Answers;

            do
            {
                Answers = TextAddUser();
                try
                {
                    NewUser = User.Parse(BLL.GetAllUsers(), Answers);
                    PrintUserData(NewUser);
                    BLL.AddUser(NewUser);
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

        #region Give
        int TextGetAwardId()
        {
            ActionViewAwards();
            Console.WriteLine("Write ONE award Id");
            var answer = Console.ReadLine();
            int Id = 0;
            int.TryParse(answer, out Id);

            var Awards = BLL.GetAllAwards();
            var result = Awards.ToList().FindAll(x => x.Id.Equals(Id));
            if (result.Count < 1)
            {
                throw new ArgumentException("Wrong Id");
            }
            return Id;
        }

        int[] TextGetManyAwardId()
        {
            ActionViewAwards();
            Console.WriteLine("Write awards Id (separate numbers with one <<SPACE>>)");
            var answer = Console.ReadLine();
            var answers = answer.Split(' ');
            var Id = new List<int>();
            int value = 0;
            foreach (var item in answers)
            {
                int.TryParse(item, out value);
                Id.Add(value);
            }

            var Awards = BLL.GetAllAwards();
            foreach (var item in Id)
            {
                var result = Awards.ToList().FindAll(x => x.Id.Equals(item));
                if (result.Count < 1)
                {
                    throw new ArgumentException("Wrong Id - " + item);
                }
            }
            return Id.ToArray();
        }

        int TextGetUserId()
        {
            ActionViewUsers();
            Console.WriteLine("Write ONE user Id");
            var answer = Console.ReadLine();
            int Id = 0;
            int.TryParse(answer, out Id);

            var Users = BLL.GetAllUsers();
            var result = Users.ToList().FindAll(x => x.Id.Equals(Id));
            if (result.Count < 1)
            {
                throw new ArgumentException("Wrong Id");
            }
            return Id;
        }

        int[] TextGetManyUserId()
        {
            ActionViewUsers();
            Console.WriteLine("Write users Id (separate numbers with one <<SPACE>>)");
            var answer = Console.ReadLine();
            var answers = answer.Split(' ');
            var Id = new List<int>();
            int value = 0;
            foreach (var item in answers)
            {
                int.TryParse(item, out value);
                Id.Add(value);
            }

            var Users = BLL.GetAllUsers();
            foreach (var item in Id)
            {
                var result = Users.ToList().FindAll(x => x.Id.Equals(item));
                if (result.Count < 1)
                {
                    throw new ArgumentException("Wrong Id - " + item);
                }
            }
            return Id.ToArray();
        }


        void ActionGiveManyAwards()
        {
            ConsoleKey Key;
            int[] AwardId;
            int UserId;
            AwardWeilder WeilderInfo;

            do
            {
                AwardId = TextGetManyAwardId();
                UserId = TextGetUserId();
                try
                {
                    foreach (var item in AwardId)
                    {
                        WeilderInfo = new AwardWeilder();
                        WeilderInfo.UserId = UserId;
                        WeilderInfo.AwardId = item;
                        WeilderInfo.Id = WeilderInfo.GetNewId(BLL.GetAllAwardWeilders());
                        BLL.AddAwardWeilder(WeilderInfo);
                    }
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

        void ActionGiveToManyUsers()
        {
            ConsoleKey Key;
            int AwardId;
            int[] UserId;
            AwardWeilder WeilderInfo;

            do
            {
                AwardId = TextGetAwardId();
                UserId = TextGetManyUserId();
                try
                {
                    foreach (var item in UserId)
                    {
                        WeilderInfo = new AwardWeilder();
                        WeilderInfo.AwardId = AwardId;
                        WeilderInfo.UserId = item;
                        WeilderInfo.Id = WeilderInfo.GetNewId(BLL.GetAllAwardWeilders());
                        BLL.AddAwardWeilder(WeilderInfo);
                    }
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

        private int TextDeleteAward()
        {
            Console.Clear();
            ActionViewAwards();
            Console.WriteLine("Write Id of award for delete its data");
            var Id = Console.ReadLine();
            if (Id.Length < 1)
            {
                return 0;
            }
            int result = 0;
            int.TryParse(Id, out result);
            return result;
        }

        void ActionDeleteAward()
        {
            var Id = TextDeleteAward();
            BLL.DeleteAwardById(Id);
        }

        private int TextDeleteUser()
        {
            Console.Clear();
            ActionViewUsers();
            Console.WriteLine("Write Id of user for delete his data");
            var Id = Console.ReadLine();
            if (Id.Length < 1)
            {
                return 0;
            }
            int result = 0;
            int.TryParse(Id, out result);
            return result;
        }

        void ActionDeleteUser()
        {
            var Id = TextDeleteUser();
            BLL.DeleteUserById(Id);
        }
        #endregion


        private void PrintUserData(User user)
        {
            Console.WriteLine("User Id " + user.Id);
            Console.WriteLine("Name : " + user.Name);
            Console.Write("BirthDay : " + user.BirthDay.Date.Day);
            Console.Write("." + user.BirthDay.Date.Month);
            Console.Write("." + user.BirthDay.Date.Year);
            Console.WriteLine(" ( " + user.Age + " )");

            var awards = BLL.GetAllAwardAtUser(user.Id);
            Console.WriteLine("Awards: ");
            foreach (var item in awards)
            {
                Console.Write(item.Title + " (id:" + item.Id + ")  ");
            }
            Console.WriteLine("\n------------------------------------");
        }

        private void PrintAwardData(Award award)
        {
            Console.WriteLine("User Id " + award.Id);
            Console.WriteLine("Title : " + award.Title);

            var users = BLL.GetAllUsersWithAward(award.Id);
            Console.WriteLine("Users: ");
            foreach (var item in users)
            {
                Console.Write(item.Name + " (id:" + item.Id + ")  ");
            }
            Console.WriteLine("\n------------------------------------");
        }
    }
}
