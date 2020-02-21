using System.Collections.Generic;
using System.Linq;
using DALInterfaces;
using Entity;

namespace DAL
{
    public class Folder<T> : IData<T> where T : HaveId
    {
        private ToFolder Manager;

        public Folder(string Path)
        {
            Manager = new ToFolder(Path);
            Manager.OpenOrCreateFile();
        }


        public IEnumerable<T> GetAll()
        {
            return Manager.Deserialize<T>();
        }

        public void AddData(T data)
        {
            Manager.Serialize(data);
        }

        public void Delete(int Id)
        {
            var All = GetAll().ToList();
            All.RemoveAll(x => x.Id.Equals(Id));

            Manager.ClearFile();
            foreach (var item in All)
            {
                Manager.Serialize(item);
            }
        }

        public void Edit(T Edited)
        {
            Delete(Edited.Id);
            AddData(Edited);
        }
    }
}
