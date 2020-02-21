using System.Collections.Generic;

namespace DALInterfaces
{
    public interface IData<T>
    {
        IEnumerable<T> GetAll();

        void AddData(T data);

        void Delete(int Id);

        void Edit(T Edited);
    }
}
