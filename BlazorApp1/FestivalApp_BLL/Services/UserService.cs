using FestivalApp_DAL.Models;
using FestivalApp_DAL.Repository;
using System.Threading.Tasks;

namespace FestivalApp_BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetUserByEmailAsync(email);
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userRepository.AddUserAsync(user);
        }
    }
}