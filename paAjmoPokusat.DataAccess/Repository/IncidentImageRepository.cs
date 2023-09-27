using paAjmoPokusat.DataAccess.Data;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository
{
    public class IncidentRepository : Repository<Incident>, IIncidentRepository
    {
        private ApplicationDbContext _db;
        public IncidentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Incident obj)
        {
            _db.Incidents.Update(obj);
        }
    }
}
