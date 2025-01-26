using FestivalApp_DAL.Models;
using FestivalApp_DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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

            try
            {
                _context.Festivals.Add(festival);
                await _context.SaveChangesAsync();
                return Ok(festival);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}