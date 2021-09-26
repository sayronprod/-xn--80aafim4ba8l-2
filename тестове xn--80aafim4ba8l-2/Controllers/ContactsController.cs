using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;
using тестове_xn__80aafim4ba8l_2.Data.Interfaces;
using тестове_xn__80aafim4ba8l_2.Models;

namespace тестове_xn__80aafim4ba8l_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactsController(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContactsAsync()
        {
            var contacts = await _contactRepository.GetAllContactsAsync();

            if (!contacts.Any())
            {
                return NotFound("Sorry, the list of contacts is empty.");
            }

            return Ok(_mapper.Map<IEnumerable<ContactReadModel>>(contacts));
        }

        [HttpGet("{id}", Name = "GetContactByIdAsync")]
        public async Task<ActionResult<IEnumerable<ContactReadModel>>> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepository.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound($"Sorry. No contact found for the specified id: {id}.");
            }

            return Ok(_mapper.Map<ContactReadModel>(contact));
        }

        [HttpPost]
        public async Task<ActionResult<ContactCreateModel>> CreateContactAsync(ContactCreateModel contactCreateModel)
        {
            var contactModel = _mapper.Map<Contact>(contactCreateModel);

            await _contactRepository.PostContactAsync(contactModel);
            await _contactRepository.SaveChangesAsync();

            var contactReadModel = _mapper.Map<ContactReadModel>(contactModel);

            return CreatedAtRoute(nameof(GetContactByIdAsync), new { contactReadModel.Id }, contactReadModel);
        }
    }
}
