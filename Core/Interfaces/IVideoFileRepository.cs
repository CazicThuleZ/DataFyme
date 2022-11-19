using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Media;

namespace Core.Interfaces
{
    public interface IVideoFileRepository
    {
        Task<VideoFile> GetVideoFileByIdAsync(int id);
        Task<IReadOnlyList<VideoFile>> GetVideoFilesAsync();
    }
}