using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaApp.Data.Data;
using DiplomaApp.Data.Models;
using DiplomaApp.Repositories.Interfaces;
using DiplomaApp.Repositories.Models;
using DiplomaApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DiplomaApp.Services.Services
{
    public class RoleService: IRoleService
    {
        private readonly IUserUnitOfWork userUnitOfWork;
        private ICollection<string> errorsCollection;

        public RoleService(IdentityContext context,
            UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            userUnitOfWork = new UserUnitOfWork(context, userManager, roleManager);
        }

        public ICollection<string> ErrorsCollection { get; }

        public IEnumerable<IdentityRole> GetRoles()
        {
            return userUnitOfWork.RoleManager.Roles.ToList();
        }

        public async Task<bool> IsRoleCreated(string role)
        {
            bool isCreated = false;
            IdentityResult result = await userUnitOfWork.RoleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded)
            {
                isCreated = true;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errorsCollection = new List<string>();
                    errorsCollection.Add(error.Description);
                }
            }

            return isCreated;
        }

        public async Task<IdentityRole> FindByIdAsync(string id)
        {
            IdentityRole role = await userUnitOfWork.RoleManager.FindByIdAsync(id);

            return role;
        }

        public async Task<IdentityRole> FindByName(string roleName)
        {
            IdentityRole role = await userUnitOfWork.RoleManager.FindByNameAsync(roleName);

            return role;
        }

        public async Task Delete(IdentityRole role)
        {
            IdentityResult result = await userUnitOfWork.RoleManager.DeleteAsync(role);
        }
    }
}
