using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.DAL.Interface;

namespace Task6.BLL.Interface
{
    abstract public class AbstractLogic<T> : IDataLogic<T>
    {
        public AbstractData<T> Data;

        public void AddData(T data)
        {
            Data.Manager.Serialize(data);
        }

        public void DeleteById(int Id)
        {
            Data.DeleteById(Id);
        }

        public IEnumerable<T> GetAll()
        {
            return Data.Manager.Deserialize();
        }

        public IEnumerable<T> GetAllByID(int Id)
        {
            var result = Data.GetAll();
            return result.Where(x => ((HaveKey)x).Id.Equals(Id));
        }

        public T GetByID(int Id)
        {
            var result = Data.GetAll();
            return result.First(x => ((HaveKey)x).Id.Equals(Id));
        }
    }
}
