using System;
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
    public class PhotoListsController : ControllerBase
    {
        private readonly KamutechdbContext _context;

        public PhotoListsController(KamutechdbContext context)
        {
            _context = context;
        }

        // GET: api/PhotoLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoList>>> GetPhotoList()
        {
            return await _context.PhotoList.ToListAsync();
        }

        // GET: api/PhotoLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoList>> GetPhotoList(int id)
        {
            var photoList = await _context.PhotoList.FindAsync(id);

            if (photoList == null)
            {
                return NotFound();
            }

            return photoList;
        }

        // PUT: api/PhotoLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoList(int id, PhotoList photoList)
        {
            if (id != photoList.Id)
            {
                return BadRequest();
            }

            _context.Entry(photoList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoListExists(id))
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

        // POST: api/PhotoLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoList>> PostPhotoList(PhotoList photoList)
        {
            _context.PhotoList.Add(photoList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhotoListExists(photoList.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhotoList", new { id = photoList.Id }, photoList);
        }

        // DELETE: api/PhotoLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoList(int id)
        {
            var photoList = await _context.PhotoList.FindAsync(id);
            if (photoList == null)
            {
                return NotFound();
            }

            _context.PhotoList.Remove(photoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoListExists(int id)
        {
            return _context.PhotoList.Any(e => e.Id == id);
        }
    }
}
