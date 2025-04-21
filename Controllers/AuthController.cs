
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Perfumeria.Data;
using Perfumeria.Dtos;
using Perfumeria.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace Perfumeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly string _keyJwt;
        private readonly string _issuer;
        private readonly string _audience;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _keyJwt = configuration["Jwt:Key"]!;
            _issuer = configuration["Jwt:Issuer"]!;
            _audience = configuration["Jwt:Audience"]!;

        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto request)
        {

            if (string.IsNullOrEmpty(_keyJwt))
            {
                return Unauthorized("Unauthorized...");
            }

            User? user = _context.Users.FirstOrDefault(user => user.Email == request.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Unauthorized");
            }

            // create data user
            var claims = new[]
            {   new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            // create signature

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_keyJwt));

            var signatureCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create jwt token 

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signatureCreds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}