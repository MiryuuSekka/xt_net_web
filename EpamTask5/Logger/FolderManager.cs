using System;
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



        internal void Watcher_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("overflow");
        }

        internal void Watcher_Disposed(object sender, EventArgs e)
        {
            Console.WriteLine("disposed");
        }



        internal void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            WriteStatusOfFiles(e);
        }

        internal void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            WriteStatusOfFiles(e);
        }

        internal void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            WriteStatusOfFiles(e);
        }

        internal void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            WriteStatusOfFiles(e);
        }




        internal void MessageOnChanged(string fileName, string ActionName)
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

        internal void WriteStatusOfFiles(FileSystemEventArgs e)
        {
            string Hash = DateTime.Now.ToString().GetHashCode().ToString();
            Main.AddToLogEntry(e.Name, WatcherChangeTypes.Changed, Hash);
            MessageOnChanged(e.Name, e.ChangeType.ToString());


            var Files = Directory.GetFiles(Entry.TargetPath);
            foreach (var item in Files)
            {
                if(!item.Contains(e.Name))
                Main.AddToLogEntry(item.Replace(Entry.TargetPath, ""), WatcherChangeTypes.All, Hash);
            }

        }
    }
}
