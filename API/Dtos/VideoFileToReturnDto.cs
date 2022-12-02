using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class VideoFileToReturnDto
    {
        public String DiskVolumeName { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string ShowTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Duration { get; set; } = 0;
        public int Size { get; set; } = 0;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public string EpisodeTitle { get; set; } = string.Empty;
        public int SeasonNumber { get; set; } = 0;
        public int EpisodeNumber { get; set; } = 0;                
    }
}