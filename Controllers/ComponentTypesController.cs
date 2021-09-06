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
    public class ComponentTypesController : ControllerBase
    {
        private readonly KamutechdbContext _context;

        public ComponentTypesController(KamutechdbContext context)
        {
            _context = context;
        }

        // GET: api/ComponentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentTypes>>> GetComponentTypes()
        {
            return await _context.ComponentTypes.ToListAsync();
        }

        // GET: api/ComponentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentTypes>> GetComponentTypes(int id)
        {
            var componentTypes = await _context.ComponentTypes.FindAsync(id);

            if (componentTypes == null)
            {
                return NotFound();
            }

            return componentTypes;
        }

        // PUT: api/ComponentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentTypes(int id, ComponentTypes componentTypes)
        {
            if (id != componentTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentTypesExists(id))
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
        public async Task<ActionResult<ComponentTypes>> PostComponentTypes(ComponentTypes componentTypes)
        {
            _context.ComponentTypes.Add(componentTypes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComponentTypesExists(componentTypes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComponentTypes", new { id = componentTypes.Id }, componentTypes);
        }

        // DELETE: api/ComponentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentTypes(int id)
        {
            var componentTypes = await _context.ComponentTypes.FindAsync(id);
            if (componentTypes == null)
            {
                return NotFound();
            }

            _context.ComponentTypes.Remove(componentTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentTypesExists(int id)
        {
            return _context.ComponentTypes.Any(e => e.Id == id);
        }
    }
}
