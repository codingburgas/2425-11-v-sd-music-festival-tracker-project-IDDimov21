using FestivalApp_API.Services;
using FestivalApp_DAL.Models;
using FestivalApp_DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FestivalApp_API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public AuthController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var success = await _userService.RegisterUser(request.Name, request.Email, request.Password, request.IsArtist);
            if (!success)
                return BadRequest("User already exists.");

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var guest = await _userRepository.GetGuestByEmailAsync(request.Email);
            var artist = await _userRepository.GetArtistByEmailAsync(request.Email);
            var user = (object)guest ?? artist;

            if (user == null)
                return Unauthorized("Invalid email or password.");

            string role = guest != null ? "Guest" : "Artist";

            return Ok(new
            {
                Id = guest?.Id ?? artist?.Id,
                Email = request.Email,
                Name = guest?.Name ?? artist?.Name,
                Role = role // ✅ Ensure Role is Returned
            });
        }
    }

    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsArtist { get; set; }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
