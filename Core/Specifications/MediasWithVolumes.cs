using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Media;

namespace Core.Specifications
{
    public class MediasWithVolumes : BaseSpecification<VideoFile>
    {
        public MediasWithVolumes()
        {
            AddInclude(m => m.DiskVolume);
        }

        public MediasWithVolumes(int id) : base(x => x.Id == id)
        {
            AddInclude(m => m.DiskVolume);
        }
    }
}