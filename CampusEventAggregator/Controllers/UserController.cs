//UserCnt
using CampusEventAggregator.Data;
using CampusEventAggregator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TestingAppForAssess.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST api/User/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // POST api/User/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var foundUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == user.Username && u.Password == user.Password);

            if (foundUser == null)
            {
                return NotFound("Invalid username or password");
            }

            return Ok(foundUser);
        }
    }
}

