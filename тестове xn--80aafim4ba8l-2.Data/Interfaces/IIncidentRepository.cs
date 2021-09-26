using System.Collections.Generic;
using System.Threading.Tasks;
using тестове_xn__80aafim4ba8l_2.Data.DatabaseModels;

namespace тестове_xn__80aafim4ba8l_2.Data.Interfaces
{
    public interface IIncidentRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Incident>> GetAllIncidentsAsync();
        Task<Incident> GetIncidentByNameAsync(string name);
        Task<bool> PostIncidentAsync(Incident incident);
    }
}
