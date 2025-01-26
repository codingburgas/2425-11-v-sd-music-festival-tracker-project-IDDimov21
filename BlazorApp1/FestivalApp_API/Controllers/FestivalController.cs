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
        [HttpGet]
        public async Task<IActionResult> GetFestivals()
        {
            var festivals = await _context.Festivals.ToListAsync();

            foreach (var festival in festivals)
            {
                // ✅ Convert time string to TimeOnly for correct API response
                if (TimeOnly.TryParse(festival.Time, out var parsedTime))
                {
                    festival.Time = parsedTime.ToString("HH:mm"); // Format as "18:00"
                }
            }

            return Ok(festivals);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFestival([FromBody] Festival festival)
        {
            if (string.IsNullOrWhiteSpace(festival.FestivalName) || string.IsNullOrWhiteSpace(festival.Time))
            {
                return BadRequest("Invalid festival data.");
            }

            // ✅ Convert string to TimeOnly safely
            if (!TimeOnly.TryParseExact(festival.Time, "HH:mm", out var parsedTime))
            {
                return BadRequest("Invalid time format. Use 'HH:mm'.");
            }

            festival.Time = parsedTime.ToString("HH:mm"); // Store as string in DB

            _context.Festivals.Add(festival);
            await _context.SaveChangesAsync();

            return Ok(festival);
        }



    }
}