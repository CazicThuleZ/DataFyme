using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Media;

namespace Core.Interfaces
{
    public interface IDiskVolumeRepository
    {
        Task<DiskVolume> GetVolumesByIdAsync(int id);

        Task<IReadOnlyList<DiskVolume>> GetDiskVolumesAsync();
    }
}