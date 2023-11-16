using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.Commands.Contacts;
using MyContactsApp.DAL.DTOs;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] ContactDTO contactDto)
    {
        var command = new CreateContactCommand(contactDto);
        var contactId = await _mediator.Send(command);
        return Ok(contactId);
    }
}
