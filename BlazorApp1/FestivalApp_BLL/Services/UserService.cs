﻿using FestivalApp_DAL.Models;
using FestivalApp_DAL.Repository;
using System.Threading.Tasks;
using BCrypt.Net;

namespace FestivalApp_BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        public async Task<object> ValidateUser(string email, string password)
        {
            var guest = await _userRepository.GetGuestByEmailAsync(email);
            if (guest != null && VerifyPassword(password, guest.PasswordHash))
            {
                return guest;
            }

            var artist = await _userRepository.GetArtistByEmailAsync(email);
            if (artist != null && VerifyPassword(password, artist.PasswordHash))
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
                    PasswordHash = HashPassword(password),
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
                    PasswordHash = HashPassword(password)
                };

                await _userRepository.AddGuestAsync(guest);
            }

            return true;
        }
    }
}
