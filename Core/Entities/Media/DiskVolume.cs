using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities.Media
{
    public class DiskVolume : BaseEntity
    {
        public string Name { get; set; }

        public int AvailableSpace { get; set; }
        
    }
}