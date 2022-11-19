using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Media;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class VideoFileRepository : IVideoFileRepository, IDiskVolumeRepository
    {
        private readonly LibraryContext _context;
        public VideoFileRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<DiskVolume>> GetDiskVolumesAsync()
        {
            return await _context.DiskVolumes.ToListAsync();
        }

        public async Task<VideoFile> GetVideoFileByIdAsync(int id)
        {
            return await _context.VideoFiles
                      .Include(d => d.DiskVolume)
                      .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IReadOnlyList<VideoFile>> GetVideoFilesAsync()
        {
            return await _context.VideoFiles
            .Include(d => d.DiskVolume)
            .ToListAsync();
        }

        public async Task<DiskVolume> GetVolumesByIdAsync(int id)
        {
            return await _context.DiskVolumes.FindAsync(id);
        }
    }
}