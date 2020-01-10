using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.BLL.Interface
{
    public interface IMainLogic
    {
        void AddData(HaveKey data);

        void DeleteById(int Id);

        IEnumerable<HaveKey> GetAll();

        HaveKey GetByID(int Id);

        IEnumerable<HaveKey> GetAllByID(int Id);
    }
}
