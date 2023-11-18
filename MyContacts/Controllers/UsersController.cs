using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Commands.Users;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDto)
    {
        var command = new RegisterUserCommand(userDto);
        var user = await _mediator.Send(command);
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
    {
        try
        {
            var command = new LoginUserCommand(loginDto);
            var token = await _mediator.Send(command);
            return Ok(new { token });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}
