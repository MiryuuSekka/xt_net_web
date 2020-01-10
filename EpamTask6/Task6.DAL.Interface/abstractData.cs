using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Task6.DAL.Interface
{
    abstract public class AbstractData<T> : IData<T>
    {
        public Serializer<T> Manager;

        public AbstractData()
        {
            Manager = new Serializer<T>("");
            Manager.OpenOrCreateFile();
        }

        virtual public void AddData(T data)
        {
            Manager.Serialize(data);
        }

        virtual public void DeleteById(int Id)
        {
            var AllData = GetAll().ToList();
            for (int i = 0; i < AllData.Count(); i++)
            {
                if (((HaveKey)AllData[i]).Id.Equals(Id))
                {
                    AllData.Remove(AllData[i]);
                }
            }

            Manager.ClearFile();
            foreach (var item in AllData)
            {
                Manager.Serialize(item);
            }
        }

        virtual public IEnumerable<T> GetAll() => Manager.Deserialize();

    }
}
