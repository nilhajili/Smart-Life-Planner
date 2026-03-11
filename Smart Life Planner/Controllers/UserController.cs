using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLifePlanner.DTOs;
using SmartLifePlanner.Services.Interfaces;

namespace SmartLifePlanner.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(Guid id)
        {
            var user = await _userService.GetUserProfileAsync(id);
            if (user == null) return NotFound(new { Message = "User not found" });

            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userDto.FullName, userDto.Email);
            if (updatedUser == null) return NotFound(new { Message = "User not found" });

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success) return NotFound(new { Message = "User not found" });

            return NoContent();
        }
    }
}