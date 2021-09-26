using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;
using тестове_xn__80aafim4ba8l_2.Data.Interfaces;

namespace тестове_xn__80aafim4ba8l_2.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TestContext _context;
        public AccountRepository(TestContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<bool> PostAccountAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            bool isNameNotUnique = await _context.Accounts.AnyAsync(a => a.Name == account.Name);
            bool isContactExists = account.Contacts.Any(x => _context.Contacts.Any(y => y.Email == x.Email));

            if (isNameNotUnique)
                throw new ArgumentException("'Name' must be unique");

            if (isContactExists)
                throw new ArgumentException("'Email' already exists in the database");

            await _context.Accounts.AddAsync(account);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
