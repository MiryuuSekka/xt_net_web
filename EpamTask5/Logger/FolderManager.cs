﻿using System;
using System.IO;

namespace Logger
{
    public class FolderManager
    {
        FileSystemWatcher Watcher;

        public FolderManager()
        {
            Watcher = new FileSystemWatcher(Entry.TargetPath);
        }

        public void Start()
        {
            Watcher.Deleted += new FileSystemEventHandler(Watcher_Deleted);
            Watcher.Created += new FileSystemEventHandler(Watcher_Created);
            Watcher.Changed += new FileSystemEventHandler(Watcher_Changed);
            Watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);

            Watcher.EnableRaisingEvents = true;
        }

        public void End()
        {
            Watcher.Deleted -= new FileSystemEventHandler(Watcher_Deleted);
            Watcher.Created -= new FileSystemEventHandler(Watcher_Created);
            Watcher.Changed -= new FileSystemEventHandler(Watcher_Changed);
            Watcher.Renamed -= new RenamedEventHandler(Watcher_Renamed);

            Watcher.EnableRaisingEvents = false;
        }



        void Watcher_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("overflow");
        }

        void Watcher_Disposed(object sender, EventArgs e)
        {
            Console.WriteLine("disposed");
        }



        void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            AddToLog(e.Name, WatcherChangeTypes.Changed);
            MessageOnChanged(e.Name, e.ChangeType.ToString());
        }

        void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            AddToLog(e.Name, WatcherChangeTypes.Created);
            MessageOnChanged(e.Name, e.ChangeType.ToString());
        }

        void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            AddToLog(e.Name, WatcherChangeTypes.Renamed);
            MessageOnChanged(e.Name, e.ChangeType.ToString());
        }

        void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //DeleteFromLog(e.FullPath);
            MessageOnChanged(e.Name, e.ChangeType.ToString());
        }


        public void BackToChangeManager(Entry Status)
        {
            var Path = Entry.TargetPath + @"\" + Status.FileName;

            switch (Status.Action)
            {
                case WatcherChangeTypes.Created:
                    File.Create(Path);
                    break;

                case WatcherChangeTypes.Deleted:
                    File.Delete(Path);
                    break;

                case WatcherChangeTypes.Changed:
                    using (var Stream = new FileStream(Path, FileMode.Open))
                    {
                        var buffStream = new BufferedStream(Stream);
                        var writer = new StreamWriter(buffStream);
                        writer.Write(Status.Text);
                        writer.Close();
                    }
                    break;

                case WatcherChangeTypes.Renamed:

                    break;

                default:
                    break;
            }
        }




        void MessageOnChanged(string fileName, string ActionName)
        {
            try
            {
                Console.WriteLine(fileName + "     " + ActionName);
                Watcher.EnableRaisingEvents = false;
            }
            finally
            {
                Watcher.EnableRaisingEvents = true;
            }
        }

        string GetTextFromFile(string FileName)
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

        public void AddToLog(string FileName, WatcherChangeTypes ActionType)
        {
            var str = GetTextFromFile(FileName);

            var AddData = new Entry() {
                Action = ActionType,
                FileName = FileName,
                Time = DateTime.Now,
                Text = str
            };

            Entry.Serialize(AddData);
        }
    }
}
