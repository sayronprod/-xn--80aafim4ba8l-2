using System.Collections.Generic;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;

namespace тестове_xn__80aafim4ba8l_2.Data.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task<bool> PostAccountAsync(Account account);
    }
}
