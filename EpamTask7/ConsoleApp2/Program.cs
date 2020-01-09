
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractTask App;

            App = new Task1();
            App.Start();

            App = new Task2();
            App.Start();

            App = new Task3();
            App.Start();

            App = new Task4();
            App.Start();

            App = new Task5();
            App.Start();
        }
    }
}
