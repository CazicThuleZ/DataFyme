using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities.Media;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ThumbnailUrlResolver : IValueResolver<VideoFile, VideoFileToReturnDto, string>
    {
        private IConfiguration _config { get; }
        public ThumbnailUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Core.Entities.Media.VideoFile source, VideoFileToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ThumbnailUrl))
                 return _config["ApiUrl"] + source.ThumbnailUrl;
            else
                return null;
        }
    }
}