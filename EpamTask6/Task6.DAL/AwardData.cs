using Entities;
using Task6.DAL.Interface;

namespace Task6.DAL
{
    public class AwardData : AbstractData<Award>
    {
        public AwardData()
        {
            Manager = new Serializer<Award>(PathData.Awards);
            Manager.OpenOrCreateFile();
        }
    }
}
