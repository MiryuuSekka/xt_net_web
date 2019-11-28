using System;
using System.Linq;

namespace CustomString
{
    public class MyString
    {
        string text;

        public MyString(string Text)
        {
            text = Text;
        }

        public MyString(char[] Text)
        {
            text = "";
            foreach (var item in Text)
            {
                text += item;
            }
        }


        public char[] GetCharArray()
        {
            return text.ToArray();
        }

        public string GetString()
        {
            return text;
        }

        public void Concatenation(string str)
        {
            text += str;
        }

        public int SearchCharFisrt(char data)
        {
            return text.IndexOf(data);
        }

        public bool Compare(string str)
        {
            return str.Equals(text);
        }
    }
}
