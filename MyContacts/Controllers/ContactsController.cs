using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyContactsApp.DAL.Commands.Contacts;
using MyContactsApp.DAL.DTOs;


[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    // The controller uses the IMediator interface from MediatR to delegate the handling of commands and queries.
    private readonly IMediator _mediator;

    // Constructor injecting the IMediator instance.
    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Method: CreateContact
    // Route: POST /[controller]
    // Authorization: Required
    // Description:
    // - Handles the creation of a new contact using the provided ContactDTO.
    // - Sends a CreateContactCommand to the mediator and returns the new contact's ID.
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateContact([FromBody] ContactDTO contactDto)
    {
        var command = new CreateContactCommand(contactDto);
        var contactId = await _mediator.Send(command);
        return Ok(contactId);
    }

    // Method: UpdateContact
    // Route: PUT /[controller]/{id}
    // Authorization: Required
    // Description:
    // - Manages updating an existing contact identified by the provided ID.
    // - Sends an UpdateContactCommand with the ID and updated ContactDTO to the mediator.
    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, [FromBody] ContactDTO contactDto)
    {
        var command = new UpdateContactCommand(id, contactDto);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // Method: DeleteContact
    // Route: DELETE /[controller]/{id}
    // Authorization: Required
    // Description:
    // - Handles the deletion of a contact using the provided ID.
    // - Sends a DeleteContactCommand and returns an appropriate response based on the result.
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

    // Method: GetAllContacts
    // Route: GET /[controller]
    // Authorization: None
    // Description:
    // - Retrieves all contacts.
    // - Sends a GetAllContactsQuery and returns the list of contacts.
    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var query = new GetAllContactsQuery();
        var contacts = await _mediator.Send(query);
        return Ok(contacts);
    }

    // Method: GetContactByEmail
    // Route: GET /[controller]/findByEmail/{email}
    // Authorization: Required
    // Description:
    // - Searches for a contact using the provided email address.
    // - Sends a GetContactByEmailQuery and returns the found contact.
    [Authorize]
    [HttpGet("findByEmail/{email}")]
    public async Task<IActionResult> GetContactByEmail(string email)
    {
        var query = new GetContactByEmailQuery(email);
        var contact = await _mediator.Send(query);
        return Ok(contact);
    }
}
