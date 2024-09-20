using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyBizDatabase.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        public void CopyFrom(IEntity copyFrom);
    }   
}
