using Entities;
using System.Collections.Generic;
using System.Linq;
using Task6.DAL.Interface;

namespace Task6.DAL
{
    public class UserData : Serializer<User>, IData<User>
    {
        public void AddData(User data) => Serialize(PathData.User, data);

        public void DeleteById(int Id)
        {
            var AllData = GetAll().ToList();
            for (int i = 0; i < AllData.Count(); i++)
            {
                if (AllData[i].Id.Equals(Id))
                {
                    AllData.Remove(AllData[i]);
                }
            }
            ClearFile(PathData.User);
            foreach (var item in AllData)
            {
                Serialize(PathData.User, item);
            }
        }

        public IEnumerable<User> GetAll() => Deserialize(PathData.User);
    }
}
