using System;
using System.Text.RegularExpressions;

namespace ConsoleTask
{
    public abstract class AbstractTask
    {
        internal Regex TextMask;

        internal string SuccsessText;
        internal string QuestionText;
        internal string GreatingsMessage;
        internal string ErrorText = "Wrong text";


        public abstract void SelectMessages();

        public virtual bool CheckText(string Text)
        {
            TextMask = new Regex("^[0-9]");
            return TextMask.IsMatch(Text);
        }

        public void Start()
        {
            Console.Clear();
            SelectMessages();
            Console.WriteLine(GreatingsMessage);
            do
            {
                Answer();
            }
            while (Progress());
        }

        public bool Progress()
        {
            Console.WriteLine("Do u want try again?  <<Press ENTER for process>>");
            var key = Console.ReadKey();

            return key.Key.Equals(ConsoleKey.Enter);
        }

        public void Answer()
        {
            Console.WriteLine();
            Console.WriteLine(QuestionText);

            if (CheckText(Console.ReadLine()))
            {
                Console.WriteLine(SuccsessText);
            }
            else
            {
                Console.WriteLine(ErrorText);
            }
        }

    }
}
