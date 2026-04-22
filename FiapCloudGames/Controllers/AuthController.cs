using FiapCloudGames.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromQuery] string email, string senha, string papel)
        {

            if (email == "teste@gmail.com" && senha == "123")
            {

                // Considerando o email como login do usuário.
                var token = _authService.GenerateToken(_configuration, email, papel);

                return Ok(token);
            }

            return Unauthorized();
        }

    }

}
