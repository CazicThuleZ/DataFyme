using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities.Media;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<VideoFile, VideoFileToReturnDto>()
                  .ForMember(d => d.ThumbnailUrl, o => o.MapFrom<ThumbnailUrlResolver>());
        }
    }
}