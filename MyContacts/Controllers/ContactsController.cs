using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.Commands.Contacts;
using MyContactsApp.DAL.DTOs;

[Authorize]
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDTO contactDto)
    {
        var command = new UpdateContactCommand(id, contactDto);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var command = new DeleteContactCommand(id);
        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}
