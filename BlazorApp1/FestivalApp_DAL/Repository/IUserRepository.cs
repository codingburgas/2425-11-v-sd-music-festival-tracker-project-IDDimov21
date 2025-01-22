using FestivalApp_DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FestivalApp_DAL.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}