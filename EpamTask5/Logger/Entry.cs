using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Logger
{
    public class Entry
    {
        public string FileName { get; set; }
        public DateTime Time { get; set; }
        public WatcherChangeTypes Action { get; set; }
        public string Text { get; set; }

        public void Serialize()
        {
            Serialize(this);
        }



        static internal string LogPath = @"..\\Log.json";
        static internal string TargetPath = @"..\\TEST";

        static public void Serialize(Entry Data)
        {
            using (var writer = new StreamWriter(LogPath, true))
            {
                try
                {
                    writer.WriteLine(JsonConvert.SerializeObject(Data));
                    writer.Close();
                }
                catch (Exception)
                {
                }
            }
        }

        static public bool OpenOrCreateFile()
        {
            try
            {
                var Stream = new FileStream(LogPath, FileMode.OpenOrCreate);
                Stream.Close();
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }

        static public List<Entry> Deserialize()
        {
            var result = new List<Entry>();

            using (var Stream = new FileStream(LogPath, FileMode.Open))
            {
                var buffStream = new BufferedStream(Stream);
                var reader = new StreamReader(buffStream);
                string str;
                Entry ReadedEntry;
                do
                {
                    str = reader.ReadLine();
                    if (str!=null)
                    {
                        try
                        {
                            ReadedEntry = JsonConvert.DeserializeObject<Entry>(str);
                            result.Add(ReadedEntry);
                        }
                        catch (Exception) { }
                    }
                } while (!reader.EndOfStream);
                reader.Close();
            }
            return result;
        }
    }
}
