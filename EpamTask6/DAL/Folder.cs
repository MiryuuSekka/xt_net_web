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

        public void DeleteById(int Id)
        {
            var Users = GetAll().ToList();
            Users.RemoveAll(x => x.Id.Equals(Id));

            Manager.ClearFile();
            foreach (var item in Users)
            {
                Manager.Serialize(item);
            }
        }
    }
}
