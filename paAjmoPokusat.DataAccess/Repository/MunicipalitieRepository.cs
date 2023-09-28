using RegistrovanjeIncidenata.DataAccess.Data;
using RegistrovanjeIncidenata.DataAccess.Repository.IRepository;
using RegistrovanjeIncidenata.Models;

namespace RegistrovanjeIncidenata.DataAccess.Repository
{
    public class MunicipalitieRepository : Repository<Municipalitie>, IMunicipalitieRepository
    {
        private ApplicationDbContext _db;
        public MunicipalitieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Municipalitie obj)
        {
            _db.Municipalities.Update(obj);
        }
    }
}
