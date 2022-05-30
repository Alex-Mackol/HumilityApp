using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DiplomaApp.Services.Interfaces
{
    public interface IRoleService
    {
        ICollection<string> ErrorsCollection { get; }

        IEnumerable<IdentityRole> GetRoles();

        Task<bool> IsRoleCreated(string role);

        Task<IdentityRole> FindByIdAsync(string id);

        Task<IdentityRole> FindByName(string roleName);

        Task Delete(IdentityRole role);
    }
}
