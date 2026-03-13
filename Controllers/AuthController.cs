using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Entities;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwt;

        public AuthController(AppDbContext context, JwtService jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var dbUser = _context.Users.FirstOrDefault(u =>
                u.Username == user.Username &&
                u.Password == user.Password);

            if (dbUser == null)
            {
                return Unauthorized();
            }

            var token = _jwt.GenerateToken(dbUser);

            return Ok(new { token });
        }
    }
}
