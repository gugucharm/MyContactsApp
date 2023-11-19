using MediatR;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] ContactDTO contactDto)
    {
        var command = new CreateContactCommand(contactDto);
        var contactId = await _mediator.Send(command);
        return Ok(contactId);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDTO contactDto)
    {
        var command = new UpdateContactCommand(id, contactDto);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [Authorize]
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

    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var query = new GetAllContactsQuery();
        var contacts = await _mediator.Send(query);
        return Ok(contacts);
    }

    [Authorize]
    [HttpGet("findByEmail/{email}")]
    public async Task<IActionResult> GetContactByEmail(string email)
    {
        var query = new GetContactByEmailQuery(email);
        var contact = await _mediator.Send(query);
        return Ok(contact);
    }
}
