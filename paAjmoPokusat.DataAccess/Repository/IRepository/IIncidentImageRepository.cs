using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IIncidentImageRepository : IRepository<IncidentImage>
    {
        void Update(IncidentImage obj);

    }
}
