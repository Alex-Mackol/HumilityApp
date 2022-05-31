using DiplomaApp.Data.Models;

namespace DiplomaApp.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRepository<Apartament> Apartaments { get; }

    IRepository<Refugee> Refugees { get; }

    IVolunteerRepository Volunteers { get; }

    void Save();
}