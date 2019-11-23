using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
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
    }
}
