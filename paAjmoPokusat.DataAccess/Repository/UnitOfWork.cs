using paAjmoPokusat.DataAccess.Data;
using paAjmoPokusat.DataAccess.Repository.IRepository;

namespace paAjmoPokusat.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IIncidentTypeRepository IncidentType { get; private set; }

        public IMunicipalitieRepository Municipalitie { get; private set; }

        public IIncidentRepository Incident { get; private set; }

        public IIncidentImageRepository IncidentImage { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            IncidentType = new IncidentTypeRepository(_db);
            Municipalitie = new MunicipalitieRepository(_db);
            Incident = new IncidentRepository(_db);
            IncidentImage = new IncidentImageRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
