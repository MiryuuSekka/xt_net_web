using System.Collections.Generic;

namespace Task6.DAL.Interface
{
    public interface IData<T>
    {
        void AddData(T data);

        void DeleteById(int Id);

        IEnumerable<T> GetAll();
    }
}
