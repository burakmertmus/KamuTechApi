﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KamuTechApi.Data;
using KamuTechApi.Models;

namespace KamuTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly KamutechdbContext _context;

        public PhotosController(KamutechdbContext context)
        {
            _context = context;
        }

        // GET: api/Photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photos>>> GetPhotos()
        {
            return await _context.Photos.ToListAsync();
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photos>> GetPhotos(int id)
        {
            var photos = await _context.Photos.FindAsync(id);

            if (photos == null)
            {
                return NotFound();
            }

            return photos;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotos(int id, Photos photos)
        {
            if (id != photos.Id)
            {
                return BadRequest();
            }

            _context.Entry(photos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Photos>> PostPhotos(Photos photos)
        {
            _context.Photos.Add(photos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhotosExists(photos.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhotos", new { id = photos.Id }, photos);
        }

        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotos(int id)
        {
            var photos = await _context.Photos.FindAsync(id);
            if (photos == null)
            {
                return NotFound();
            }

            _context.Photos.Remove(photos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotosExists(int id)
        {
            return _context.Photos.Any(e => e.Id == id);
        }
    }
}
