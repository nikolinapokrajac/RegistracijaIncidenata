using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IMunicipalitieRepository : IRepository<Municipalitie>
    {
        void Update(Municipalitie obj);
        //void Save(); ovo izbrisemo zbog UnitOfWork
    }
}
