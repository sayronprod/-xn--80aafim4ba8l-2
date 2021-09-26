using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;
using тестове_xn__80aafim4ba8l_2.Data.Interfaces;

namespace тестове_xn__80aafim4ba8l_2.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly TestContext _context;
        public ContactRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> PostContactAsync(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            bool isEmailNotUnique = await _context.Contacts.AnyAsync(c => c.Email == contact.Email);

            if (isEmailNotUnique)
                throw new ArgumentException("'Email' must be unique");

            await _context.Contacts.AddAsync(contact);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
