using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;
using тестове_xn__80aafim4ba8l_2.Data.Interfaces;

namespace тестове_xn__80aafim4ba8l_2.Data
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly TestContext _context;
        public IncidentRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            return await _context.Incidents.ToListAsync();
        }

        public async Task<Incident> GetIncidentByNameAsync(string name)
        {
            return await _context.Incidents.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<bool> PostIncidentAsync(Incident incident)
        {
            if (incident == null)
                throw new ArgumentNullException(nameof(incident));

            var existingAccounts = await _context.Accounts
                .Where(a => incident.Accounts.Select(x => x.Name).Contains(a.Name)).ToListAsync();

            if (incident.Accounts.Count != existingAccounts.Count)
                throw new ArgumentException("Can not find specified account(s) in the database");

            foreach (var account in incident.Accounts)
            {
                foreach (var contact in account.Contacts)
                {
                    var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);
                    if (existingContact != null)
                    {
                        existingContact.FirstName = contact.FirstName;
                        existingContact.LastName = contact.LastName;
                        existingContact.AccountId = existingAccounts.First(e => e.Name == account.Name).Id;
                    }
                    else
                    {
                        contact.AccountId = existingAccounts.First(e => e.Name == account.Name).Id;
                        await _context.Contacts.AddAsync(contact);
                    }
                }
            }

            incident.Accounts = existingAccounts;

            await _context.Incidents.AddAsync(incident);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
