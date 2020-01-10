using System.Collections.Generic;
using DALInterfaces;
using Entity;

namespace DAL
{
    public class Local<T> : IData<T> where T : HaveId
    {
        private List<T> Data;

        public Local()
        {
            Data = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return Data;
        }

        public void AddData(T data)
        {
            Data.Add(data);
        }

        public void DeleteById(int Id)
        {
            Data.RemoveAll(x => x.Id.Equals(Id));
        }
    }
}
