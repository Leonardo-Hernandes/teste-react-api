using Microsoft.AspNetCore.Mvc;
using teste_react_api.Persistence;
using teste_react_api.Services;

namespace teste_react_api.Controllers
{
    [Route("/api/Auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UsersDbContext _context;

        public AuthController(UsersDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Auth(string email, string password) {
            var user = _context.User.SingleOrDefault(d => d.Email == email);
            
            if(user != null && user.Email == email && user.Password == password)
            {
                var token = TokenService.GenerateToken(user);
                return Ok(new { user = user, token });
            }

            return BadRequest("email or password invalid");
        }
    }
}
