using FestivalApp_DAL.Models;
using System.Threading.Tasks;

namespace FestivalApp_BLL.Services
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        Task RegisterUserAsync(User user);
    }
}