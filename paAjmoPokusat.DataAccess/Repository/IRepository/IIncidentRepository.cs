using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IIncidentRepository : IRepository<Incident>
    {
        void Update(Incident obj);
        //void Save(); ovo izbrisemo zbog UnitOfWork
    }
}
