using paAjmoPokusat.DataAccess.Data;
using paAjmoPokusat.DataAccess.Repository.IRepository;
using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.ApplicationUsers.Update(applicationUser);
        }
    }
}
