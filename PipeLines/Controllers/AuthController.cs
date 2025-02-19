using MediatR;
using Microsoft.AspNetCore.Mvc;
using PipeLines;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginCommand command)
    {
        var result = await _mediator.Send(command);
        return result ? Ok("Login successful") : Unauthorized("Login failed");
    }
}
