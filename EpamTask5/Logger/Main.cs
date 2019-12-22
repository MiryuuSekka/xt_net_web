using System;
using System.Collections.Generic;
using System.IO;

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

        static public void AddToLogEntry(string FileName, WatcherChangeTypes ActionType, string Hash)
        {
            var str = GetTextFromFile(FileName);

            var AddData = new Entry()
            {
                Action = ActionType,
                FileName = FileName,
                Time = DateTime.Now,
                Text = str,
                ChangeNumber = Hash
            };

            Entry.Serialize(AddData);
        }


        static string GetTextFromFile(string FileName)
        {
            var str = "";
            var Path = Entry.TargetPath + @"\" + FileName;
            try
            {
                using (var Stream = new FileStream(Path, FileMode.Open))
                {
                    var buffStream = new BufferedStream(Stream);
                    var reader = new StreamReader(buffStream);
                    str = reader.ReadToEnd();
                    reader.Close();
                }
            }
            catch (Exception) { }
            return str;
        }

        public void BackToChangeManager(Entry Status)
        {
            string Path;
            foreach (var item in EntryLog)
            {
                if(item.ChangeNumber.Equals(Status.ChangeNumber))
                {
                    Path = Entry.TargetPath + @"\" + item.FileName;
                    try
                    {
                        File.Delete(Path);
                    }
                    catch (Exception) { }

                    if (item.Action != WatcherChangeTypes.Deleted)
                    {
                        try
                        {
                            using (var Stream = new FileStream(Path, FileMode.OpenOrCreate))
                            {
                                var buffStream = new BufferedStream(Stream);
                                var writer = new StreamWriter(buffStream);
                                writer.Write(item.Text);
                                writer.Close();
                            }
                        }
                        catch (Exception) { }
                    }


                }
            }
        }

    }
}
