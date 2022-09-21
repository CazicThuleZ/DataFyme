using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyMediaController : ControllerBase
    {
        private readonly LibraryContext _context;

        public MyMediaController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<MediaObject>>> GetMedias()
        {
            var mediaObjects = await _context.MediaObjects.ToListAsync();
            return Ok(mediaObjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MediaObject>> GetMedia(int id)
        {
            return await _context.MediaObjects.FindAsync(id);
        }

    }
}