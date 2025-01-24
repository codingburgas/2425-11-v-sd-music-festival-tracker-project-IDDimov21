using FestivalApp_DAL.Models;
using System.Threading.Tasks;

namespace FestivalApp_DAL.Repository
{
    public interface IUserRepository
    {
        Task<Guest> GetGuestByEmailAsync(string email);
        Task<Artist> GetArtistByEmailAsync(string email);
        Task AddGuestAsync(Guest guest);
        Task AddArtistAsync(Artist artist);
    }
}