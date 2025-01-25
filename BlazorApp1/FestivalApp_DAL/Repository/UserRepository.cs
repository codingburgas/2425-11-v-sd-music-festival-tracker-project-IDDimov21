using FestivalApp_DAL.Data;
using FestivalApp_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FestivalApp_DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guest> GetGuestByEmailAsync(string email)
        {
            return await _context.Guests.FirstOrDefaultAsync(g => g.Email.ToLower() == email.ToLower());
        }

        public async Task<Artist> GetArtistByEmailAsync(string email)
        {
            return await _context.Artists.FirstOrDefaultAsync(a => a.Email.ToLower() == email.ToLower());
        }

        public async Task AddGuestAsync(Guest guest)
        {
            await _context.Guests.AddAsync(guest);
            await _context.SaveChangesAsync();
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }
    }
}