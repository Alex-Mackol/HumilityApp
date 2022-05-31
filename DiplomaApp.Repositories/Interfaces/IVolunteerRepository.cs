using DiplomaApp.Data.Models;

namespace DiplomaApp.Repositories.Interfaces;

public interface IVolunteerRepository
{
    IEnumerable<Volunteer> GetAll();

    bool IsEntityExist(Volunteer entity);

    void Create(Volunteer item);

    Volunteer Read(string id);

    void Update(Volunteer item);

    void Delete(int id);
}