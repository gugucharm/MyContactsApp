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

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] UserDTO userDto)
    {
        var command = new CreateUserCommand(userDto);
        var contactId = await _mediator.Send(command);
        return Ok(contactId);
    }
}
