using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Task6.DAL.Interface
{
    public abstract class Serializer<T>
    {
        public void Serialize(string FilePath, T Data)
        {
            using (var writer = new StreamWriter(FilePath, true))
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

        public bool OpenOrCreateFile(string FilePath)
        {
            try
            {
                var Stream = new FileStream(FilePath, FileMode.OpenOrCreate);
                Stream.Close();

            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }

        public bool ClearFile(string FilePath)
        {
            try
            {
                var Stream = new FileStream(FilePath, FileMode.Create);
                Stream.Close();
            }
            catch (IOException)
            {
                return false;
            }
            return true;
        }


        public List<T> Deserialize(string FilePath)
        {
            var result = new List<T>();

            using (var Stream = new FileStream(FilePath, FileMode.Open))
            {
                var buffStream = new BufferedStream(Stream);
                var reader = new StreamReader(buffStream);
                string str;
                T ReadedEntry;
                do
                {
                    str = reader.ReadLine();
                    if (str != null)
                    {
                        try
                        {
                            ReadedEntry = JsonConvert.DeserializeObject<T>(str);
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
