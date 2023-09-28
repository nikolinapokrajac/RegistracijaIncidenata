using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository.IRepository
{
    public interface IIncidentRepository : IRepository<Incident>
    {
        void Update(Incident obj);

    }
}
