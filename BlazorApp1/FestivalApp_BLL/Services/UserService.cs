using FestivalApp_DAL.Models;
using FestivalApp_DAL.Repository;
using System.Threading.Tasks;
using BCrypt.Net;

namespace FestivalApp_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<object> ValidateUser(string email, string password)
        {
            var guest = await _userRepository.GetGuestByEmailAsync(email);
            if (guest != null && BCrypt.Net.BCrypt.Verify(password, guest.Password)) // Changed from PasswordHash
            {
                return guest;
            }

            var artist = await _userRepository.GetArtistByEmailAsync(email);
            if (artist != null && BCrypt.Net.BCrypt.Verify(password, artist.Password)) // Changed from PasswordHash
            {
                return artist;
            }

            return null;
        }

        public async Task<bool> RegisterUser(string name, string email, string password, bool isArtist)
        {
            if (isArtist)
            {
                var existingArtist = await _userRepository.GetArtistByEmailAsync(email);
                if (existingArtist != null)
                    return false;

                var artist = new Artist
                {
                    Name = name,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password), // Changed from PasswordHash
                    Rating = 0
                };

                await _userRepository.AddArtistAsync(artist);
            }
            else
            {
                var existingGuest = await _userRepository.GetGuestByEmailAsync(email);
                if (existingGuest != null)
                    return false;

                var guest = new Guest
                {
                    Name = name,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password), // Changed from PasswordHash
                };

                await _userRepository.AddGuestAsync(guest);
            }

            return true;
        }
    }
}
