using ContactBackend.Repostiory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels.Models;

namespace ContactBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/contacts
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return Ok(new ApiResponse<List<Contact>>(contacts, true));
        }

        // GET: api/contacts/{id}
        [HttpGet("{contactId}")]
        public async Task<IActionResult> GetContact(int contactId)
        {
            var contact = await _contactRepository.GetByIdAsync(contactId);
            if (contact == null)
            {
                return NotFound(new ApiResponse<string>("", $"Contact with ID {contactId} not found.", false));
            }
            return Ok(new ApiResponse<Contact>(contact, true));
        }

        // POST: api/contacts
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
                return BadRequest(new ApiResponse<string>("Validation failed", errors));
                
            }
            var createdContact = await _contactRepository.AddAsync(contact);
            return CreatedAtAction(nameof(GetContact), new { contactId = createdContact.ContactId }, new ApiResponse<Contact>(createdContact));
        }

        // PUT: api/contacts/{id}
        [HttpPut("{contactId}")]
        public async Task<IActionResult> UpdateContact(int contactId, [FromBody] Contact contact)
        {
            if (contactId != contact.ContactId)
            {
                return BadRequest("ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));
                return BadRequest(new ApiResponse<string>("Validation failed", errors));
            }

            try
            {
                if (!await _contactRepository.ContactExistsAsync(contact.ContactId))
                {
                    return NotFound(new ApiResponse<string>("","not found",false));
                }
                

                await _contactRepository.UpdateAsync(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new ApiResponse<string>("","conflict",false));
            }
          
            return Ok(new ApiResponse<string>("",true));
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{contactId}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            var contact = await _contactRepository.GetByIdAsync(contactId);
            if (contact == null)
            {
                return NotFound(new ApiResponse<string>("", $"Contact with ID {contactId} not found.", false));
               
            }

            await _contactRepository.DeleteAsync(contactId);
            return Ok(new ApiResponse<string>("", true));
        }

    
    }
}
