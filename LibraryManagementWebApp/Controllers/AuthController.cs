using LibraryManagementWebApp.Data;
using LibraryManagementWebApp.Entity;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagementWebApp.Controllers
{
    [ApiController]
    public class AuthController :  ControllerBase
    {
        private readonly LibraryContext _db ;

        public AuthController(LibraryContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("auth/register")]
        public async Task<IActionResult> Register(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Role))
                return NotFound("Username, Password, and Role are required");

            if (_db.Users.Any(u => u.Username == user.Username))
                return BadRequest("Username already exists");

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return Ok("User registered successfully");
        }
    }
}
