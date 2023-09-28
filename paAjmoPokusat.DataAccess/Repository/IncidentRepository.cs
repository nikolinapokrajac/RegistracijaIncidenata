using RegistrovanjeIncidenata.DataAccess.Data;
using RegistrovanjeIncidenata.DataAccess.Repository.IRepository;
using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository
{
    public class IncidentImageRepository : Repository<IncidentImage>, IIncidentImageRepository
    {
        private ApplicationDbContext _db;
        public IncidentImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(IncidentImage obj)
        {
            _db.IncidentImages.Update(obj);
        }
    }
}
