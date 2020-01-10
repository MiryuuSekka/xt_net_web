using Entities;
using Task6.DAL.Interface;

namespace Task6.DAL
{
    public class WeilderData : AbstractData<AwardWeilders>
    {
        public WeilderData()
        {
            Manager = new Serializer<AwardWeilders>(PathData.AwardWeildersList);
            Manager.OpenOrCreateFile();
        }
    }
}
