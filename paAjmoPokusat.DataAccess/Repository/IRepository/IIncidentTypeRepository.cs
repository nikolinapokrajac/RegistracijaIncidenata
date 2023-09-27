using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IIncidentTypeRepository : IRepository<IncidentType>
    {
        void Update(IncidentType obj);

    }
}
