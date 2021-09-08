using KamuTechApi.Data;
using KamuTechApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KamuTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly KamutechdbContext _context;
        
        public CommonController(KamutechdbContext context)
        {
            _context = context;
        }

        // GET /Commons
        [HttpGet]
        public ActionResult<Counts> GetCounts()
        {
            Counts countModel = new Counts { };
            countModel.ArticlesCount = _context.Articles.Count();
            countModel.CardsCount = _context.Cards.Count();
            countModel.CommentsCount = _context.Comments.Count();
            countModel.SlidersCount = _context.Sliders.Count();

            return Ok(countModel);

        }
    }
}
