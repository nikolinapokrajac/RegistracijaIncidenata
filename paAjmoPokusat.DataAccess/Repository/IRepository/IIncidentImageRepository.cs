using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository.IRepository
{
    public interface IIncidentImageRepository : IRepository<IncidentImage>
    {
        void Update(IncidentImage obj);

    }
}
