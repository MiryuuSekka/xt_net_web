using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.BLL.Interface;

namespace Task6.BLL
{
    public class MainLogic : IMainLogic, AbstractLogic<T>
    {
        public MainLogic()
        {
        }

        public void AddData(HaveKey data)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HaveKey> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HaveKey> GetAllByID(int Id)
        {
            throw new NotImplementedException();
        }

        public HaveKey GetByID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
