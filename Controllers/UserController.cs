using Microsoft.AspNetCore.Mvc;
using DaanPath.Services.Interfaces;
using DaanPath.Entity;

namespace DaanPath.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _userService.GetUserDetailsAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            var created = await _userService.CreateUserAsync(user);
            if (!created)
            {
                return BadRequest("Invalid user data.");
            }
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserID }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserID)
            {
                return BadRequest("User ID mismatch.");
            }

            var updated = await _userService.UpdateUserAsync(user);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var removed = await _userService.RemoveUserAsync(id);
            if (!removed)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
