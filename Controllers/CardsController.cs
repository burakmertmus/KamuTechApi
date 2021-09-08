using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KamuTechApi.Data;
using KamuTechApi.Models;
using AutoMapper;
using KamuTechApi.RequestModel;

namespace KamuTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly KamutechdbContext _context;
        private readonly IMapper _mapper;
        public CardsController(KamutechdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCardsModel>>> GetCards()
        {
            var cards = await _context.Cards.Include(p => p.Photo.IdNavigation).ToListAsync();
            var reqCards = _mapper.Map<List<GetCardsModel>>(cards);
            return Ok(reqCards);
        }

        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cards>> GetCards(int id)
        {
            var cards = await _context.Cards.FindAsync(id);

            if (cards == null)
            {
                return NotFound();
            }

            return cards;
        }

        // PUT: api/Cards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCards(int id, UpdateCardModel updateCardModel)
        {
            
            var card = await _context.Cards.Include(p => p.Photo.IdNavigation).FirstOrDefaultAsync(p=>p.Id==id);

            if (card == null)
            {
                return NotFound();
            }


            card.Photo.IdNavigation.Url = updateCardModel.PhotoUrl;
            card.Content = updateCardModel.Content;
            card.Header = updateCardModel.Header;
            


            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardsExists(id))
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

        // POST: api/Cards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cards>> PostCards(Cards cards)
        {

            _context.Cards.Add(cards);
            try
            {
                
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateException)
            {
                if (CardsExists(cards.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }


            return CreatedAtAction("GetCards", new { id = cards.Id }, cards);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCards(int id)
        {
            var cards = await _context.Cards.FindAsync(id);
            if (cards == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(cards);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardsExists(int id)
        {
            return _context.Cards.Any(e => e.Id == id);
        }
    }
}
