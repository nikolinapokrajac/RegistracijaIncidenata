using paAjmoPokusat.DataAccess.Data;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository
{
    public class IncidentImageRepository : Repository<IncidentImage>, IIncidentImageRepository
    {
        private ApplicationDbContext _db;
        public IncidentImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /*public void Save()
        {
            _db.SaveChanges();
        }*/
        //ovo prebacili u UnitOfWork

        public void Update(IncidentImage obj)
        {
            _db.IncidentImages.Update(obj);
        }
    }
}
