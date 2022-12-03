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
        public MediasWithVolumes(string sort, string volumeName)
            : base(x => (volumeName == null || x.DiskVolume.Name == volumeName))
        {
            AddInclude(m => m.DiskVolume);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "title":
                        AddOrderBy(m => m.ShowTitle);
                        break;
                    case "title_desc":
                        AddOrderByDesc(m => m.ShowTitle);
                        break;
                    case "size":
                        AddOrderBy(m => m.Size);
                        break;
                    case "size_desc":
                        AddOrderByDesc(m => m.Size);
                        break;
                    default:
                        AddOrderBy(m => m.ShowTitle);
                        break;
                }
            }
        }

        public MediasWithVolumes(int id) : base(x => x.Id == id)
        {
            AddInclude(m => m.DiskVolume);
        }
    }
}