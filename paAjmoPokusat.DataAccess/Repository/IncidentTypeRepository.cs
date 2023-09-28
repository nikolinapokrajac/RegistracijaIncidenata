using RegistrovanjeIncidenata.DataAccess.Data;
using RegistrovanjeIncidenata.DataAccess.Repository.IRepository;
using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository
{
    public class IncidentTypeRepository : Repository<IncidentType>, IIncidentTypeRepository
    {
        private ApplicationDbContext _db;
        public IncidentTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(IncidentType obj)
        {
            _db.IncidentTypes.Update(obj);
        }
    }
}
