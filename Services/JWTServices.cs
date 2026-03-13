using EmployeeManagementSystem.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagementSystem.Services
{
    public class JwtService
    {
        private readonly string key;
        public JwtService(IConfiguration config)
        {
            key = config["JWT"]
                ?? throw new Exception("JWT key not found");
        }
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Username ?? "")
            };
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);
                return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
