using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    public class HaveId
    {
        public int Id { get; set; }


        public int GetNewId(IEnumerable<HaveId> data)
        {
            int NewId = 1;
            if (data == null || data.Count() < 1)
            {
                return NewId;
            }
            NewId = data.Max(x => x.Id);
            NewId++;
            return NewId;
        }
    }
}
