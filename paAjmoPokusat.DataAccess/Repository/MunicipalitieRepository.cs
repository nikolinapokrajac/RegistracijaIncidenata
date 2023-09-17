using paAjmoPokusat.DataAccess.Data;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository
{
    public class MunicipalitieRepository : Repository<Municipalitie>, IMunicipalitieRepository
    {
        private ApplicationDbContext _db;
        public MunicipalitieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        /*public void Save()
        {
            _db.SaveChanges();
        }*/
        //ovo prebacili u UnitOfWork

        public void Update(Municipalitie obj)
        {
            _db.Municipalities.Update(obj);
        }
    }
}
