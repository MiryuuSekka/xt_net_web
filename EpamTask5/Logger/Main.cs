using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class Main
    {
        public List<Entry> EntryLog;

        public Main()
        {
            Entry.OpenOrCreateFile();
            EntryLog = Entry.Deserialize();
        }

        public List<Entry> GetLog()
        {
            EntryLog = Entry.Deserialize();
            return EntryLog;
        }
    }
}
