using System.Collections.Generic;

namespace Task6.BLL.Interface
{
    public interface IDataLogic<T>
    {
        void AddData(T data);

        void DeleteById(int Id);

        IEnumerable<T> GetAll();

        T GetByID(int Id);

        IEnumerable<T> GetAllByID(int Id);
    }
}
