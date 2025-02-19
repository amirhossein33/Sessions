using Microsoft.AspNetCore.Mvc;

namespace Presentation.UI.Controllers
{
    using Application.Interfaces;
    using Application.UseCase.Application.UseCase;
    using Domain.Entity.Domain.Entities;
    using Microsoft.AspNetCore.Mvc;

    namespace WebAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class UserController : ControllerBase
        {
            private readonly UserService _userService;

            public UserController(UserService userService)
            {
                _userService = userService;
            }

         
            [HttpGet("{id}")]
            public async Task<ActionResult<User>> GetUserById(int id)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound("User not found");

                return Ok(user);
            }

        
            [HttpPost]
            public async Task<ActionResult<User>> CreateUser([FromBody] User user)
            {
                if (user == null)
                    return BadRequest("Invalid user data");

                var createdUser = await _userService.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }

         
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
            {
                if (user == null || id != user.Id)
                    return BadRequest("Invalid user data");

                var updated = await _userService.UpdateUserAsync(user);
                if (!updated)
                    return NotFound("User not found");

                return NoContent();
            }

           
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                var deleted = await _userService.DeleteUserAsync(id);
                if (!deleted)
                    return NotFound("User not found");

                return NoContent();
            }
        }
    }

}
