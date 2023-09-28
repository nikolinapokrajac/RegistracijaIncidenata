using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository.IRepository
{
    public interface IIncidentTypeRepository : IRepository<IncidentType>
    {
        void Update(IncidentType obj);

    }
}
