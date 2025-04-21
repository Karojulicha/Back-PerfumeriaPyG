using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perfumeria.Data;
using Perfumeria.Models;


namespace Perfumeria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<ResponseUserDto> users = await _context.Users.Select(user => new ResponseUserDto {
                FullName = user.Username,
                Email = user.Email,
                Role = user.Role.ToString(),
            }).ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            User? user  = await _context.Users.FindAsync(id);

            if(user == null) 
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            // validation email
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return BadRequest("Email already exists");
            }

            //Hashear password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);



            if (!Enum.IsDefined(typeof(UserRole), request.Role))
            {
                return BadRequest("Invalid role");
            }

            UserRole role = (UserRole)request.Role;


            // Create new user
            User user = new User
            {
                Username = request.FullName,
                Email = request.Email,
                PasswordHash = passwordHash,
                Role = role
            };

            // Save DB
            _context.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User successfully registered");

        }
    }
}