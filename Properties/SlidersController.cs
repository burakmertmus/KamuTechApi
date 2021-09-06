using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KamuTechApi.Data;
using KamuTechApi.Models;

namespace KamuTechApi.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly KamutechdbContext _context;

        public SlidersController(KamutechdbContext context)
        {
            _context = context;
        }

        // GET: api/Sliders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sliders>>> GetSliders()
        {
            return await _context.Sliders.ToListAsync();
        }

        // GET: api/Sliders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sliders>> GetSliders(int id)
        {
            var sliders = await _context.Sliders.FindAsync(id);

            if (sliders == null)
            {
                return NotFound();
            }

            return sliders;
        }

        // PUT: api/Sliders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSliders(int id, Sliders sliders)
        {
            if (id != sliders.Id)
            {
                return BadRequest();
            }

            _context.Entry(sliders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlidersExists(id))
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

        // POST: api/Sliders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sliders>> PostSliders(Sliders sliders)
        {
            _context.Sliders.Add(sliders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SlidersExists(sliders.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSliders", new { id = sliders.Id }, sliders);
        }

        // DELETE: api/Sliders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSliders(int id)
        {
            var sliders = await _context.Sliders.FindAsync(id);
            if (sliders == null)
            {
                return NotFound();
            }

            _context.Sliders.Remove(sliders);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SlidersExists(int id)
        {
            return _context.Sliders.Any(e => e.Id == id);
        }
    }
}
