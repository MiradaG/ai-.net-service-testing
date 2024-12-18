using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;
using UserManagementApi.Services;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers() => Ok(_userService.GetAllUsers());

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound($"User with ID {id} not found.");
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userService.UpdateUser(id, user))
                return NotFound($"User with ID {id} not found.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (!_userService.DeleteUser(id))
                return NotFound($"User with ID {id} not found.");

            return NoContent();
        }

        [HttpPatch("{id}/activate")]
        public IActionResult ActivateUser(int id)
        {
            if (!_userService.ActivateUser(id))
                return NotFound($"User with ID {id} not found.");

            return NoContent();
        }

        [HttpPatch("{id}/deactivate")]
        public IActionResult DeactivateUser(int id)
        {
            if (!_userService.DeactivateUser(id))
                return NotFound($"User with ID {id} not found.");

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchUsers([FromQuery] string name, [FromQuery] string role)
        {
            var users = _userService.SearchUsers(name, role);
            return Ok(users);
        }
    }
}
