using System.Collections.Generic;
using System.Linq;

namespace Entities
{
    public abstract class HaveKey
    {
        public int Id { get; set; }

        static internal int GetNewId(IEnumerable<HaveKey> data)
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
