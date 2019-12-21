using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class Main
    {
        internal List<Entry> EntryLog;

        public Main()
        {
            Entry.OpenOrCreateFile();
            EntryLog = Entry.Deserialize();
        }


    }
}
