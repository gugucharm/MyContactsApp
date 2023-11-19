using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.DTOs;
using MyContactsApp.DAL.Commands.Users;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    // The controller utilizes the IMediator interface from MediatR for sending commands.
    private readonly IMediator _mediator;

    // Constructor to inject the IMediator instance for handling commands.
    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Method: Register
    // Route: POST /[controller]/register
    // Description:
    // - Handles user registration.
    // - Accepts a UserDTO with user registration details, sends a RegisterUserCommand,
    //   and returns the registered user's information.
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDto)
    {
        var command = new RegisterUserCommand(userDto);
        var user = await _mediator.Send(command);
        return Ok(user);
    }

    // Method: Login
    // Route: POST /[controller]/login
    // Description:
    // - Manages user login.
    // - Accepts a LoginDTO with login credentials, sends a LoginUserCommand.
    // - On successful login, returns a JWT token.
    // - Catches UnauthorizedAccessException to return an Unauthorized response in case of login failure.
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
