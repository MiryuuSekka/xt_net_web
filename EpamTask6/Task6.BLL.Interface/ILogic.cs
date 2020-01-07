using System.Collections.Generic;

namespace Task6.BLL.Interface
{
    public interface ILogic<T>
    {
        void AddData(T data);

        void DeleteById(int Id);

        IEnumerable<T> GetAll();

        T GetByID(int Id);
    }
}
