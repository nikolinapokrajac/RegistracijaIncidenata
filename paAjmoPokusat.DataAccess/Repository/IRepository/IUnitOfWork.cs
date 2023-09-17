namespace paAjmoPokusat.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IIncidentTypeRepository IncidentType { get; }
        IMunicipalitieRepository Municipalitie { get; }
        IIncidentRepository Incident { get; }

        IIncidentImageRepository IncidentImage { get; }
        void Save();
    }
}
