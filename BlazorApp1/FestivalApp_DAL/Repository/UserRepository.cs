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
            return await _context.Guests.FirstOrDefaultAsync(g => g.Email == email);
        }

        public async Task<Artist> GetArtistByEmailAsync(string email)
        {
            return await _context.Artists.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task AddGuestAsync(Guest guest)
        {
            Console.WriteLine($"Adding Guest: {guest.Email}");
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            Console.WriteLine($"Guest {guest.Email} Registered Successfully!");
        }

        public async Task AddArtistAsync(Artist artist)
        {
            Console.WriteLine($"Adding Artist: {artist.Email}");
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            Console.WriteLine($"Artist {artist.Email} Registered Successfully!");
        }

    }
}