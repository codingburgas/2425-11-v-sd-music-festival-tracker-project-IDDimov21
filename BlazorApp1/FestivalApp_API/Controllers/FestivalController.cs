using FestivalApp_DAL.Data;
using FestivalApp_DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace FestivalApp_API.Controllers
{
    [ApiController]
    [Route("api/festivals")]
    public class FestivalController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FestivalController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFestivals()
        {
            var festivals = await _context.Festivals.ToListAsync();
            return Ok(festivals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFestival([FromBody] Festival festival)
        {
            if (festival == null || string.IsNullOrWhiteSpace(festival.FestivalName))
                return BadRequest("Invalid festival data.");

            var artistExists = await _context.Artists.AnyAsync(a => a.Id == festival.ArtistId);
            if (!artistExists)
                return BadRequest("Artist ID does not exist.");

            _context.Festivals.Add(festival);
            await _context.SaveChangesAsync();

            return Ok(festival);
        }
    }
}