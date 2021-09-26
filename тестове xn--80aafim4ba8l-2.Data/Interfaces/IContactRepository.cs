using System.Collections.Generic;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;

namespace тестове_xn__80aafim4ba8l_2.Data.Interfaces
{
    public interface IContactRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<bool> PostContactAsync(Contact incident);
    }
}
