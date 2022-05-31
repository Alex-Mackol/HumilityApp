using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Repositories;

namespace DiplomaApp.Repositories.Models;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationContext context;
    private RefugeeRepository refugeeRepository;
    private VolunteerRepository volunteerRepository;
    private ApartamentRepository apartamentRepository;
    private bool disposed = false;

    public UnitOfWork(ApplicationContext context)
    {
        this.context = context;
    }

    public IRepository<Apartament> Apartaments => apartamentRepository ??= new ApartamentRepository(context);
    public IRepository<Refugee> Refugees => refugeeRepository ??= new RefugeeRepository(context);
    public IRepository<Volunteer> Volunteers => volunteerRepository ??= new VolunteerRepository(context);

    public void Save()
    {
        context.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
        if (disposed) return;
        if (disposing)
        {
            context.Dispose();
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}