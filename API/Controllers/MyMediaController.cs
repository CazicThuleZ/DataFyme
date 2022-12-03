using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Entities.Media;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class MyMediaController : BaseApiController
    {

        private readonly IGenericRepository<VideoFile> _vf_repo;
        private readonly IGenericRepository<DiskVolume> _dv_repo;
        private readonly IMapper _mapper;

        public MyMediaController(IGenericRepository<VideoFile> vf_repo, IGenericRepository<DiskVolume> dv_repo, IMapper mapper)
        {
            _mapper = mapper;
            _dv_repo = dv_repo;
            _vf_repo = vf_repo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<VideoFileToReturnDto>>> GetMedias()
        {
            var spec = new MediasWithVolumes();
            var VideoFiles = await _vf_repo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<VideoFile>, IReadOnlyList<VideoFileToReturnDto>>(VideoFiles));
        }

        [HttpGet("{mediaId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VideoFileToReturnDto>> GetMedia(int mediaId)
        {
            var spec = new MediasWithVolumes(mediaId);
            var videoFile = await _vf_repo.GetEntityWithSpec(spec);
            if (videoFile == null)
                 return NotFound(new ApiResponse(404));

            return _mapper.Map<VideoFile, VideoFileToReturnDto>(videoFile);

        }

        // [HttpGet("volumes")]
        // public async Task<ActionResult<IReadOnlyList<DiskVolume>>> GetVolumes()
        // {
        //     return Ok(await _dv_repo.ListAsync());
        // }

        // [HttpGet("{volumeId}")]
        // public async Task<ActionResult<DiskVolume>> GetVolume(int volumeId)
        // {
        //      return await _dv_repo.GetByIdAsync(volumeId);
        // }
    }
}