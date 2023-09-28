using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository.IRepository
{
    public interface IMunicipalitieRepository : IRepository<Municipalitie>
    {
        void Update(Municipalitie obj);

    }
}
