using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Services.Models;

namespace DiplomaApp.Services.Interfaces
{
    public interface IUserService
    {
        ICollection<string> ErrorsCollection { get; }

        Task<IEnumerable<UserDto>> GetUsers();

        Task<bool> IsUserCreated(UserDto userDto, string password);

        Task<bool> IsUserExist(UserDto userDto);

        Task<bool> IsUserAdmin(UserDto userDto);

        Task UserLogOut();

        Task<UserDto> FindUserByIdAsync(string id);

        Task<UserDto> DeleteAsync(string id);
    }
}
