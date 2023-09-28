using RegistrovanjeIncidenata.DataAccess.Data;
using RegistrovanjeIncidenata.DataAccess.Repository.IRepository;
using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository
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
