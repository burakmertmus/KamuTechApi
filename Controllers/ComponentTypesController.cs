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
    public class ComponentTypesController : ControllerBase
    {
        private readonly KamutechdbContext _context;

        public ComponentTypesController(KamutechdbContext context)
        {
            _context = context;
        }

        // GET: api/ComponentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentType>>> GetComponentType()
        {
            return await _context.ComponentType.ToListAsync();
        }

        // GET: api/ComponentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentType>> GetComponentType(int id)
        {
            var componentType = await _context.ComponentType.FindAsync(id);

            if (componentType == null)
            {
                return NotFound();
            }

            return componentType;
        }

        // PUT: api/ComponentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentType(int id, ComponentType componentType)
        {
            if (id != componentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentTypeExists(id))
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

        // POST: api/ComponentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComponentType>> PostComponentType(ComponentType componentType)
        {
            _context.ComponentType.Add(componentType);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComponentTypeExists(componentType.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComponentType", new { id = componentType.Id }, componentType);
        }

        // DELETE: api/ComponentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentType(int id)
        {
            var componentType = await _context.ComponentType.FindAsync(id);
            if (componentType == null)
            {
                return NotFound();
            }

            _context.ComponentType.Remove(componentType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentTypeExists(int id)
        {
            return _context.ComponentType.Any(e => e.Id == id);
        }
    }
}
