﻿using paAjmoPokusat.Models;

namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IIncidentRepository : IRepository<Incident>
    {
        void Update(Incident obj);

    }
}
