using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.Media;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyMediaController : ControllerBase
    {

        private readonly IVideoFileRepository _vf_repo;
        private readonly IDiskVolumeRepository _dv_repo;

        public MyMediaController(IVideoFileRepository vf_repo, IDiskVolumeRepository dv_repo)
        {
            _dv_repo = dv_repo;
            _vf_repo = vf_repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<VideoFile>>> GetMedias()
        {
            var VideoFiles = await _vf_repo.GetVideoFilesAsync();
            return Ok(VideoFiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VideoFile>> GetMedia(int id)
        {
            return await _vf_repo.GetVideoFileByIdAsync(id);
        }

        [HttpGet("volumes")]
        public async Task<ActionResult<IReadOnlyList<DiskVolume>>> GetVolumes()
        {
            return Ok( await _dv_repo.GetDiskVolumesAsync());
        }
    }
}