using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IIncidentImageRepository : IRepository<IncidentImage>
    {
        void Update(IncidentImage obj);
        //void Save(); ovo izbrisemo zbog UnitOfWork
    }
}
